using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;
using System.Net;
using System.Windows.Browser;
using System.Windows.Threading;

namespace Pripev.Silverlight.Chat
{
   public class ChatSession : INotifyPropertyChanged
   {
      private const int TCP_PORT = 4510;

      private Dispatcher _dispatcher;

      private Socket _socket;
      private bool _connected;
      private StringBuilder _messageBuilder;

      public String UserName { get; set; }
      internal ObservableCollection<ChatMessage> MessageHistory { get; set; }

      public event PropertyChangedEventHandler PropertyChanged;
      private delegate void ReceiveHandler(List<ChatMessage> messages);
      
      public ChatSession()
      {
         MessageHistory = new ObservableCollection<ChatMessage>();
         if (!HtmlPage.IsEnabled)
         {
            PopulateDummyData();
         }
         else
         {
            _messageBuilder = new StringBuilder( 10 * 1024);
         }
      }

      public void Connect(string userName, Dispatcher dispatcher)
      {
         if ( _connected ) return;

         _dispatcher = dispatcher;
         UserName = userName;
         PopulateChatData();
         if (PropertyChanged != null)
         {
            PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
            PropertyChanged( this, new PropertyChangedEventArgs( "MessageHistory" ) );
         }
      }

      public void Disconnect()
      {
         if ( !_connected ) return;

         _socket.Shutdown(SocketShutdown.Both);
         _socket.Close();
         _connected = false;
      }

      private void AddMessage( ChatMessage msg )
      {
         if (_dispatcher != null)
         {
            var handler = new ReceiveHandler( MessageReceived );
            _dispatcher.BeginInvoke( handler, new[] {new List<ChatMessage> {msg}} );
         }
         else
            MessageReceived( new List<ChatMessage> { msg } );
      }

      public void SendMessage( String msg )
      {
         SendMessages(new List<ChatMessage> { new ChatMessage { UserName = UserName, Message = msg, CreatedOn = DateTime.Now } });
      }

      private void SendMessages(List<ChatMessage> messages)
      {
         if (_connected)
         {
            var sendArgs = new SocketAsyncEventArgs();

            var serializer = new DataContractJsonSerializer( messages.GetType() );

            using ( var stream = new MemoryStream() )
            {
               serializer.WriteObject( stream, messages );
               var buffer = stream.GetBuffer();
               sendArgs.SetBuffer( buffer, 0, (int)stream.Length );
               _socket.SendAsync( sendArgs );
            }
         }
         else
            AddMessage(new ChatMessage { UserName = UserName, Message = "Не установлено соединение с сервером.", CreatedOn = DateTime.Now });
      }

      private void PopulateChatData()
      {
         _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

         var args = new SocketAsyncEventArgs();
         args.UserToken = _socket;
 
         if ( String.IsNullOrEmpty(Application.Current.Host.Source.DnsSafeHost))
            args.RemoteEndPoint = new DnsEndPoint("localhost", TCP_PORT);
         else
            args.RemoteEndPoint = new DnsEndPoint(Application.Current.Host.Source.DnsSafeHost, TCP_PORT);
         
         args.Completed += OnSocketConnectCompleted;
         _socket.ConnectAsync(args);
      }

      private void OnSocketConnectCompleted(object sender, SocketAsyncEventArgs e)
      {
         _connected = (e.SocketError == SocketError.Success);

         if ( !_connected )
         {
            ((Socket)e.UserToken).Close();
            AddMessage(new ChatMessage { UserName = UserName, Message = "Ошибка соединения с сервером.", CreatedOn = DateTime.Now });
            return;
         }
         
         var response = new byte[1024 * 100];
         e.SetBuffer(response, 0, response.Length);
         e.Completed -= OnSocketConnectCompleted;
         e.Completed += OnSocketReceive;
         var socket = (Socket)e.UserToken;
         socket.ReceiveAsync(e);

         SendMessage( "Зашёл в чат." );
      }

      private void BuildMessage( String msg )
      {
         _messageBuilder.Append( msg );
         if (!msg.EndsWith("}") && !msg.EndsWith("]")) return;

         try
         {
            List<ChatMessage> msgs;

            using (var ms = new MemoryStream())
            {
               using (var sw = new StreamWriter(ms))
               {
                  sw.AutoFlush = true;
                  sw.Write(_messageBuilder);
                  ms.Seek(0, SeekOrigin.Begin);
                  var serializer = new DataContractJsonSerializer(typeof(List<ChatMessage>));

                  msgs = serializer.ReadObject(ms) as List<ChatMessage>;
               }
            }
            var handler = new ReceiveHandler(MessageReceived);
            _dispatcher.BeginInvoke(handler, new[] { msgs });
         }
         catch { }

         _messageBuilder.Length = 0;
      }

      private void OnSocketReceive(object sender, SocketAsyncEventArgs e)
      {
         if( _connected && e.BytesTransferred == 0 )
         {
            Disconnect();
            AddMessage(new ChatMessage { UserName = UserName, Message = "Cоединение разорвано.", CreatedOn = DateTime.Now });
            return;
         }

         BuildMessage(Encoding.UTF8.GetString(e.Buffer, e.Offset, e.BytesTransferred));
         
         var socket = (Socket)e.UserToken;
         if ( !socket.ReceiveAsync(e) )
            OnSocketReceive( socket, e );
      }

      private void MessageReceived( List<ChatMessage> messages )
      {
         if (messages != null)
         {
            foreach ( var msg in messages )
               MessageHistory.Add( msg );
         }
         if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs("MessageHistory"));
      }

      private void PopulateDummyData()
      {
         UserName = "Bill";
         MessageHistory.Add(new ChatMessage { UserName = "Bill", Message = "Message 1", CreatedOn = DateTime.Now });
         MessageHistory.Add(new ChatMessage { UserName = "Bill 2", Message = "Message 2", CreatedOn = DateTime.Now });
         MessageHistory.Add(new ChatMessage { UserName = "Bill", Message = "Длинное сообщение чисто для показа скроллбара или лучше сказать не для показа его", CreatedOn = DateTime.Now });
         MessageHistory.Add(new ChatMessage { UserName = "Bill 2", Message = "Message 4", CreatedOn = DateTime.Now });
      }

   }
}
