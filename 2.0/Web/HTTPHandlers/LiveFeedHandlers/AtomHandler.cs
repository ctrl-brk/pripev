using System.Xml;
using System.ServiceModel.Syndication;

namespace Pripev.Web
{
    public class AtomHandler : SyndicationHandler
    {
        public override void WriteFeed( SyndicationFeed feed )
        {
            Context.Response.ContentType = "application/atom+xml";
            var atomWriter = XmlWriter.Create( Context.Response.OutputStream );
            var atomFormatter = new Atom10FeedFormatter( feed );
            atomFormatter.WriteTo( atomWriter );
            atomWriter.Close();
        }

    }
}
