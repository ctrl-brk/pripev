using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;

namespace Pripev.TextTemplates.Email
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Song { get; set; }
        public Uri Url { get; set; }

        public override string ToString()
        {
            return string.Format( "{0}({1}) - {2} - {3} - {4} : {5}", UserName, UserEmail, Artist, Album, Song, Url );
        }
    }

    public partial class OrdersNotify : IEmailTemplate
    {
        public List<Order> Orders = new List<Order>(50);

        [Required]
        public string HtmlTitle { get; set; }

        public string SplitIds(char splitCh)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Orders.Count; i++)
            {
                sb.Append( Orders[i].OrderId );
                if (i < Orders.Count - 1)
                    sb.Append( splitCh );
            }
            return sb.ToString();
        }
    }
}
