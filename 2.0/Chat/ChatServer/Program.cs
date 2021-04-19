using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace Pripev.Chat.Server
{
   static class Program
   {
      static void Main(string[] args)
      {
         if (args.Length == 0)
         {
            Debug.Listeners.Clear();
            var ServicesToRun = new ServiceBase[] {new ChatService()};
            ServiceBase.Run( ServicesToRun );
         }
         else
         {
            Debug.Listeners.Clear();
            Debug.Listeners.Add( new ConsoleTraceListener() );
            var svc = new ChatService();
            svc.StartLocal();
            Console.ReadKey();
            svc.StopLocal();
         }
      }
   }
}
