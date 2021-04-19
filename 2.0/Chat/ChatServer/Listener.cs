using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;

namespace Pripev.Chat.Server
{
   internal class ChatClient
   {
      private const int BUFFER_SIZE = 8 * 1024;

      public NetworkStream Stream;
      public EndPoint Address;

      public byte[] ReadBuffer { get; private set; }
      public Guid Id { get; private set; }

      public ChatClient()
      {
         ReadBuffer = new byte[BUFFER_SIZE];
         Id = new Guid();
      }

      public String GetName( MessageHistory history )
      {
         foreach( var msg in history.Messages )
         {
            if (msg.Id == Id) return (msg.UserName);
         }
         
         return (String.Empty);
      }
   }

   public class Listener
   {
      private const int TCP_PORT = 4510;
      private TcpListener _listener;
      private AutoResetEvent _tcpClientConnected = new AutoResetEvent(false);
      private List<ChatClient> _clients = new List<ChatClient>();
      private MessageHistory _messageHistory;
      private GarbageCollector _garbageCollector;
      private Thread _collectorThread;

      public void Start()
      {
         try
         {
            _messageHistory = new MessageHistory();
            _messageHistory.Messages.CollectionChanged += Messages_CollectionChanged;

            _listener = new TcpListener(IPAddress.Any, TCP_PORT);
            _listener.Start();

            _garbageCollector = new GarbageCollector( _messageHistory );
            _collectorThread = new Thread(_garbageCollector.Start);
            _collectorThread.Start();

            while( true )
            {
               _listener.BeginAcceptTcpClient(OnBeginAccept, null);
               _tcpClientConnected.WaitOne(); //Block until client connects
            }
         }
         catch( Exception e )
         {
            Debug.WriteLine( "Listen error: " + e.Message );
         }
      }

      public void Stop()
      {
         _collectorThread.Abort();

         foreach (var c in _clients)
         {
            Debug.WriteLine( "Disposing stream " + c.Stream );
            c.Stream.Dispose();
         }
         _clients.Clear();
         if ( _listener != null )
            _listener.Stop();
         _listener = null;

         if ( _messageHistory != null)
            _messageHistory.Messages.CollectionChanged -= Messages_CollectionChanged;
         _messageHistory = null;
      }

      private void OnBeginAccept(IAsyncResult ar)
      {
         if ( _listener == null ) return; //Stop service

         TcpClient client;

         try
         {
            client = _listener.EndAcceptTcpClient( ar );
            Debug.WriteLine( "Accepted " + client.Client.RemoteEndPoint );
            _tcpClientConnected.Set(); //Allow waiting thread to proceed
            if ( !client.Connected ) return;
         }
         catch( Exception e )
         {
            Debug.WriteLine("Accept error " + e.Message );
            return;
         }

         var chatClient = new ChatClient {Stream = client.GetStream(), Address = client.Client.RemoteEndPoint};

         lock (_clients)
         {
            _clients.Add(chatClient);
         }

         client.GetStream().BeginRead(chatClient.ReadBuffer, 0, chatClient.ReadBuffer.Length, OnClientMessage, chatClient);
         SendDataToNewClient( chatClient );
      }

      private void RemoveClient( ChatClient chatClient )
      {
         string name = null;

         lock (_clients)
         {
            foreach( var c in _clients )
            {
               if ( c == chatClient )
               {
                  name = c.GetName( _messageHistory );
                  Debug.WriteLine("\tClosing and removing client stream: " + c.Address);
                  c.Stream.Close();
                  _clients.Remove( c );
                  break;
               }
            }
         }

         if (!String.IsNullOrEmpty(name))
            _messageHistory.Messages.Add( new ChatMessage {CreatedOn = DateTime.Now, Message = "Покинул чат", UserName = name} );
      }

      private void OnClientMessage( IAsyncResult ar )
      {
         int numberOfBytesRead;

         Debug.WriteLine("Client message...");
         var chatClient = ar.AsyncState as ChatClient;
         
         try
         {
            numberOfBytesRead = chatClient.Stream.EndRead(ar);
         }
         
         catch( Exception e )
         {
            Debug.WriteLine( "\tRead error: " + e.Message );
            RemoveClient( chatClient );
            return;
         }

         if ( numberOfBytesRead > 0 )
         {
            Debug.WriteLine("\t" + numberOfBytesRead + " bytes read from " + chatClient.Address);

            using ( var ms = new MemoryStream() )
            {
               using ( var sw = new StreamWriter( ms ) )
               {
                  try
                  {
                     sw.AutoFlush = true;
                     sw.Write( Encoding.UTF8.GetString( chatClient.ReadBuffer, 0, numberOfBytesRead ) );
                     Debug.WriteLine("\t" + Encoding.UTF8.GetString(chatClient.ReadBuffer, 0, numberOfBytesRead));
                     ms.Seek( 0, SeekOrigin.Begin );
                     var serializer = new DataContractJsonSerializer( typeof ( List<ChatMessage> ) );
                     var msgs = serializer.ReadObject( ms ) as List<ChatMessage>;
                     if( msgs != null )
                     {
                        Debug.WriteLine( "\tDeserialization..."  );
                        foreach (var msg in msgs)
                        {
                           Debug.WriteLine( "\t" + msg );
                           msg.Id = chatClient.Id;
                           _messageHistory.Messages.Add( msg );
                        }
                     }
                  }
                  catch( Exception e )
                  {
                     Debug.WriteLine("\tDeserialization error: " + e.Message);
                  }
               }
            }
            chatClient.Stream.BeginRead(chatClient.ReadBuffer, 0, chatClient.ReadBuffer.Length, OnClientMessage, chatClient);
         }
         else
            RemoveClient(chatClient);
      }

      void Messages_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
      {
         if (e.NewItems == null ) return;

         Debug.WriteLine( "Message collection changed:"  );
         foreach( var item in e.NewItems )
            Debug.WriteLine("\t" + item);

         SaveItemsToDB( e.NewItems );
         SendDataToClients( e.NewItems );
      }

      private static void SaveItemsToDB( IList items )
      {
         foreach( ChatMessage item in items )
         {
            try
            {
               DAL.DB.ExecuteNonQuery("exec PutChatMessage @UserName=" + Utils.Convert.ToSQLString(item.UserName) + ",@Message=" + Utils.Convert.ToSQLString(item.Message));
            }
            catch {}
         }
      }

      private void SendDataToClients( IList items )
      {
         SendDataToClients( items, null );
      }

      private void SendDataToClients( IList items, ChatClient chatClient  )
      {
         if ( chatClient != null )
            Debug.WriteLine( "Sending " + items.Count + " messages to client " + chatClient.Address + " ..."  );
         else
            Debug.WriteLine("Sending " + items.Count + " messages to all clients...");
         
         if ( items.Count == 0 ) return;

         var messages = new List<ChatMessage>( items.Count );
         foreach( var item in items )
            messages.Add( item as ChatMessage );

         var serializer = new DataContractJsonSerializer(messages.GetType());
         var disconnected = new List<ChatClient>();

         lock (_clients)
         {
            foreach ( var c in _clients )
            {
               try
               {
                  if ( chatClient == null || c == chatClient )
                  {
                     foreach( var item in items )
                        Debug.WriteLine("\t" + item);
                     serializer.WriteObject( c.Stream, messages );
                     c.Stream.Flush();
                  }
               }
               catch( SocketException e)
               {
                  Debug.WriteLine( "\tSend error: " + e.Message  );
                  disconnected.Add( c );
               }
            }
         }

         foreach (var c in disconnected)
            RemoveClient( c );
      }

      private void SendDataToNewClient( ChatClient client )
      {
         Debug.WriteLine( "Sending data to new client " + client.Address + " ..."  );
         SendDataToClients( _messageHistory.Messages, client );
      }
   }
}
