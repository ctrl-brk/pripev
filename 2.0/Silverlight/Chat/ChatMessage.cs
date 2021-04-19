using System;
using System.Runtime.Serialization;

namespace Pripev.Silverlight.Chat
{
   [DataContract(Name = "ChatMessage", Namespace = "http://www.pripev.ru")]
   [KnownType(typeof(ChatMessage))]
   public class ChatMessage
   {
      [DataMember]
      public String UserName { get; set; }
      [DataMember]
      public String Message { get; set; }
      [DataMember]
      public DateTime CreatedOn { get; set; }

      [IgnoreDataMember]
      public String Header
      {
         get
         {
            return (String.Format("{0} ({1:t})", UserName, CreatedOn));
         }
      }

      public override string ToString()
      {
         return (String.Format("UserName: {0}, Message: {1}, Created: {2}", UserName, Message, CreatedOn));
      }
   }
}
