using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Pripev.Chat.Server
{
   // Listens for connections on port 943 and dispatches requests to a PolicyConnection
   class PolicyServer
   {
      private Socket _listener;
      private byte[] _policy;

      public PolicyServer(string policyFile)
      {
         var policyStream = new FileStream(policyFile, FileMode.Open);

         _policy = new byte[policyStream.Length];
         policyStream.Read(_policy, 0, _policy.Length);

         policyStream.Close();
      }

      public void Start()
      {
         // Create the Listening Socket
         _listener = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);

         // Put the socket into dual mode to allow a single socket 
         // to accept both IPv4 and IPv6 connections
         // Otherwise, server needs to listen on two sockets,
         // one for IPv4 and one for IPv6
         // NOTE: dual-mode sockets are supported on Vista and later
         _listener.SetSocketOption(SocketOptionLevel.IPv6, (SocketOptionName)27, 0);

         _listener.Bind(new IPEndPoint(IPAddress.IPv6Any, 943));
         _listener.Listen(10);
         _listener.BeginAccept(new AsyncCallback(OnConnection), null);
      }

      public void OnConnection(IAsyncResult res)
      {
         Socket client;

         try
         {
            client = _listener.EndAccept(res);
         }
         catch { return; }

         // handle this policy request with a PolicyConnection
         new PolicyConnection(client, _policy);

         // look for more connections
         _listener.BeginAccept(new AsyncCallback(OnConnection), null);
      }

      public void Stop()
      {
         if ( _listener != null )
            _listener.Close();
         _listener = null;
      }
   }

   // Encapsulate and manage state for a single connection from a client
   class PolicyConnection
   {
      private Socket m_connection;

      // buffer to receive the request from the client
      private byte[] m_buffer;
      private int m_received;

      // the policy to return to the client
      private byte[] m_policy;

      // the request that we're expecting from the client
      private static string s_policyRequestString = "<policy-file-request/>";

      public PolicyConnection(Socket client, byte[] policy)
      {
         m_connection = client;
         m_policy = policy;

         m_buffer = new byte[s_policyRequestString.Length];
         m_received = 0;

         try
         {
            // receive the request from the client
            m_connection.BeginReceive(m_buffer, 0, s_policyRequestString.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
         }
         catch { m_connection.Close(); }
      }

      // Called when we receive data from the client
      private void OnReceive(IAsyncResult res)
      {
         try
         {
            m_received += m_connection.EndReceive(res);

            // if we haven't gotten enough for a full request yet, receive again
            if (m_received < s_policyRequestString.Length)
            {
               m_connection.BeginReceive(m_buffer, m_received, s_policyRequestString.Length - m_received, SocketFlags.None, new AsyncCallback(OnReceive), null);
               return;
            }

            // make sure the request is valid
            string request = System.Text.Encoding.UTF8.GetString(m_buffer, 0, m_received);
            if (StringComparer.InvariantCultureIgnoreCase.Compare(request, s_policyRequestString) != 0)
            {
               m_connection.Close();
               return;
            }

            // send the policy
            m_connection.BeginSend(m_policy, 0, m_policy.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
         }
         catch { m_connection.Close(); }
      }

      // called after sending the policy to the client; close the connection.
      public void OnSend(IAsyncResult res)
      {
         try
         {
            m_connection.EndSend(res);
         }
         finally
         {
            m_connection.Close();
         }
      }
   }

}
