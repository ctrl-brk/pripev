using System.ServiceProcess;
using System.Threading;

namespace Pripev.Chat.Server
{
   public partial class ChatService : ServiceBase
   {
      private const string POLICY_FILE = "C:\\SLPolicy.xml";
      private Thread _listenerThread, _policyThread;
      private Listener _listener;
      private PolicyServer _policyServer;

      public ChatService()
      {
         InitializeComponent();
      }

      private void StartListener()
      {
         if ( _listener != null )
            return;

         _policyServer = new PolicyServer( POLICY_FILE );
         _policyThread = new Thread(_policyServer.Start);
         _policyThread.Start();

         _listener = new Listener();
         _listenerThread = new Thread( _listener.Start );
         _listenerThread.Start();
      }

      private void StopListener()
      {
         if ( _listener == null )
            return;

         _listener.Stop();
         _listener = null;
         _policyServer.Stop();
      }

      protected override void OnContinue()
      {
         StartListener();
      }

      protected override void OnPause()
      {
         StopListener();
      }
      protected override void OnStart(string[] args)
      {
         StartListener();
      }

      protected override void OnStop()
      {
         StopListener();
      }

      public void StartLocal()
      {
         StartListener();
      }

      public void StopLocal()
      {
         StopListener();
      }

   }


}
