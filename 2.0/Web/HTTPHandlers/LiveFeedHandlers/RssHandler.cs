using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.IO;
using System.ServiceModel.Syndication;

namespace Pripev.Web
{
   public class RssHandler : SyndicationHandler
   {
      public override void WriteFeed( SyndicationFeed feed )
      {
         Context.Response.ContentType = "application/rss+xml";
         XmlWriter rssWriter = XmlWriter.Create( Context.Response.OutputStream );
         Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter( feed );
         rssFormatter.WriteTo(  rssWriter );
         rssWriter.Close();
      }
   }
}
