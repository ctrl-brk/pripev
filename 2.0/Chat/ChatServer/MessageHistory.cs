using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Pripev.DAL;

namespace Pripev.Chat.Server
{
   [DataContract(Name = "ChatMessage", Namespace = "http://www.pripev.ru")]
   public class ChatMessage
   {
      [DataMember]
      public String UserName { get; set; }

      [DataMember]
      public String Message { get; set; }

      [DataMember]
      public DateTime CreatedOn { get; set; }

      [IgnoreDataMember]
      public Guid Id { get; set; }

      public override string ToString()
      {
         return (String.Format("UserName: {0}, Message: {1}, Created: {2}", UserName, Message, CreatedOn));
      }
   }

   public class MessageHistory
   {
      public ObservableCollection<ChatMessage> Messages { get; private set; }

      public MessageHistory()
      {
         Messages = new ObservableCollection<ChatMessage>();
         ReadFromDB();
      }

      private void ReadFromDB()
      {
         try
         {
            var r = DB.ExecuteReader( "exec GetChatMessages" );
            while ( r.Read() )
            {
               Messages.Add( new ChatMessage {UserName = r["UserName"].ToString(), Message = r["Message"].ToString(), CreatedOn = Convert.ToDateTime( r["CreatedOn"] )} );
            }
            r.Close();
         }
         catch
         {
            Messages.Add(new ChatMessage { Message = "Ошибка соединения с базой.\r\nПросьба сообщить вебмастеру", CreatedOn = DateTime.Now });
         }
      }
   }
}
