using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Pripev.Chat.Server
{
   public class GarbageCollector
   {
      private MessageHistory _history;

      public GarbageCollector( MessageHistory history )
      {
         _history = history;
      }

      public void Start()
      {
         var expired = new List<ChatMessage>();

         while(true)
         {
            System.Threading.Thread.Sleep( 1000 * 60 );
            expired.Clear();
            var expirationDate = DateTime.Now.AddHours( -2 );

            Debug.WriteLine("=====\r\n\tGarbage collection...\r\n" );
            foreach( var msg in _history.Messages)
            {
               if (msg.CreatedOn <= expirationDate)
                  expired.Add( msg );
            }

            if (expired.Count > 0)
            {
               lock ( _history.Messages )
               {
                  foreach ( var msg in expired )
                  {
                     Debug.WriteLine( "\tDeleting expired message: " + msg + "\r\n" );
                     _history.Messages.Remove( msg );
                  }
               }
            }

            Debug.WriteLine("=====\r\n");
         }
      }
   }
}
