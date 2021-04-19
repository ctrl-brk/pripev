using System;
using System.Collections.Generic;

namespace Pripev.Chat.Server
{
   public static class Tools
   {
      public static List<ChatMessage> GetDebugData()
      {
         return (new List<ChatMessage>
         {
            new ChatMessage {UserName = "User", Message = "Message", CreatedOn = DateTime.Now},
            new ChatMessage {UserName = "User1", Message = "Message1", CreatedOn = DateTime.Now},
            new ChatMessage {UserName = "User2", Message = "Message2", CreatedOn = DateTime.Now}
         });
      }
   }
}
