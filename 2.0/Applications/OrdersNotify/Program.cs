using System;
using System.Collections.Generic;
using System.Data;
using Pripev.DAL;
using Pripev.TextTemplates.Email;
using Pripev.Utils;
using log4net;
using log4net.Config;

namespace Pripev.App.OrdersNotification
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program).FullName);
        private static readonly List<OrdersNotify> AllOrders = new List<OrdersNotify>();

        static void Main()
        {
#if !DEBUG
            try
#endif
            {
                XmlConfigurator.Configure();
                Prepare();
                Notify();
            }
#if !DEBUG            
            catch (Exception e)
            {
                Log.Error( e.Message );
                Email.ErrorMail("Ошибка нотификации о заказе", e.Message, false);
            }
#endif
        }

        private static void Prepare()
        {
            int? userId = null;

            var dt = DB.ExecuteDataTable(@"select o.Order_Id, o.UserId, o.Artist, o.Album, o.Song, o.ExternalLink, u.Name, u.Email, u.EmailFormat
                                             from Orders o
                                            inner join WebUsers u on u.UserId = o.UserId
                                            where o.Active='Y' and o.Notify=0 and o.ExternalLink is not null order by o.UserId, o.Date");

            var userOrders = new OrdersNotify{HtmlTitle = "Припевы найдены!"};

            foreach (DataRow dr in dt.Rows)
            {
                if (userId.HasValue && userId != dr.Field<int>("UserId"))
                {
                    AllOrders.Add(userOrders);
                    userOrders = new OrdersNotify();
                    userId = dr.Field<int>("UserId");
                }
                else if (!userId.HasValue) userId = dr.Field<int>( "UserId" );

                var o = new Order
                            {
                                OrderId = dr.Field<int>("ORDER_ID"),
                                UserName = dr.Field<string>("Name"),
                                UserEmail = dr.Field<string>("Email"),
                                Artist = dr.Field<string>("Artist"),
                                Album = dr.Field<string>("Album"),
                                Song = dr.Field<string>("Song"),
                                Url = new Uri(dr.Field<string>("ExternalLink"))
                            };

                userOrders.Orders.Add(o);
                Log.Debug( o );
            }
            if ( userId.HasValue )
                AllOrders.Add(userOrders);
        }

        private static void Notify()
        {
            foreach (var o in AllOrders)
            {
                var body = o.TransformText();
                Email.SendMail(Registry.GetString("Orders\\MailFrom"), Registry.GetString("Orders\\MailFromName"), o.Orders[0].UserEmail, o.Orders[0].UserName, Registry.GetString("Orders\\MailSubject"),  body, true );
                Log.InfoFormat("Message sent to {0} ({1}). {2} orders", o.Orders[0].UserName, o.Orders[0].UserEmail, o.Orders.Count);
                DB.ExecuteNonQuery(String.Format( "Update orders set Notify=1, ModifiedOn=getdate(), ModifiedBy=1 where Order_Id in ({0})", o.SplitIds(',')));
            }
        }
    }
}
