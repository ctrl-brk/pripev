// ReSharper disable UnusedMember.Global
using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Pripev.Utils.Web
{
    public class Tools : Utils.Tools
    {
        public static String ServerName
        {
            get
            {
                var sb = new StringBuilder( HttpContext.Current.Request.ServerVariables["SERVER_NAME"] );
                if ( HttpContext.Current.Request.ServerVariables["SERVER_PORT"] != "80" )
                {
                    sb.Append( ":" );
                    sb.Append( HttpContext.Current.Request.ServerVariables["SERVER_PORT"] );
                }
                return (sb.ToString());
            }
        }


        public static Control FindControlRecursive( Control container, string id )
        {
            var c = container.FindControl( id );
            if ( c != null ) return (c);

            foreach ( Control c1 in container.Controls )
            {
                c = FindControlRecursive( c1, id );
                if ( c != null ) break;
            }

            return (c);
        }

        public static String RequestString( String name )
        {
            var val = HttpContext.Current.Request.Form[name];
            if ( String.IsNullOrEmpty( val ) )
                val = HttpContext.Current.Request[name];
            return (val);
        }

        public static char? RequestLetter( String name )
        {
            var val = HttpContext.Current.Request.Form[name];
            if ( String.IsNullOrEmpty( val ) )
                val = HttpContext.Current.Request[name];

            if ( String.IsNullOrEmpty( val ) ) return (null);
            return (val.ToCharArray( 0, 1 )[0]);
        }

        public static bool IsFriendAddress()
        {
            var sAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            var mask = sAddr.Split( new[] {'.'} );

            return (sAddr == "127.0.0.1" || (mask[0] == "192" && mask[1] == "168") || (mask[0] == "10" && mask[1] == "0") || sAddr == "70.57.37.201" || sAddr == "206.54.145.254");
        }

        public static bool IsRobot()
        {
            String[] robots = {"Yandex", "Googlebot", "Aport", "Rambler", "ia_archiver", "Mediapartners-Google", "libwww-perl", "eStyleSearch", "IRLbot", "NetStat.Ru", "NG/", "appie ", "LWP::Simple", "Microsoft URL Control", "Speedy Spider", "FAST", "moen_", "OmniExplorer_Bot", "msnbot", "Accoona-AI-Agent", "Baiduspider", "Biz360 spider", "ConveraCrawler", "Exabot", "Gigabot", "IRLbot", "Krugle", "MultiCrawler", "Nusearch Spider", "Sensis", "Speedy Spider", "StackSearch Crawler", "Vespa Crawler", "WebAlta Crawler", "Yahoo! Slurp"};

            return !String.IsNullOrEmpty( HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"] ) && robots.Any( s => HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].Contains( s ) );
        }
    }
}

// ReSharper restore UnusedMember.Global
