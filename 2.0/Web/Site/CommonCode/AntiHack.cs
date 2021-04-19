using System;
using System.Web;
using System.Web.Caching;
using Pripev.BLL;
using System.Text;
using Pripev.Utils.Web;

namespace Pripev.Web.Security
{
    public static class ActionValidator
    {
        private const int BanDuration = 10; //10 min

        public enum ActionType
        {
            FirstVisit = 50,
            ReVisit = 500,
            PostBack = 1000
        }

        private class HitInfo
        {
            public int Hits;
            public bool IsNotified;
            private DateTime _expiresAt = DateTime.Now.AddMinutes( BanDuration );

            public DateTime ExpiresAt
            {
                get { return _expiresAt; }
                set { _expiresAt = value; }
            }
        }

        public static bool IsValid( ActionType actionType )
        {
            var context = HttpContext.Current;
            var req = context.Request;
            var crawlerMultiplier = 1;

            if ( Tools.IsRobot() ) crawlerMultiplier = 10;

            var key = actionType + "@" + req.UserHostAddress;

            var hit = (HitInfo)(context.Cache[key] ?? new HitInfo());

            if ( hit.Hits > ((int)actionType)*crawlerMultiplier )
            {
                if ( !hit.IsNotified )
                {
                    var sb = new StringBuilder();

                    sb.Append( "Headers:\n" );
                    sb.Append( req.Headers );
                    sb.Append( "\n\nParams:\n" );
                    sb.Append( req.Params );
                    sb.Append( "\n\nServer Variables:\n" );
                    sb.Append( req.ServerVariables );
                    sb.Append( "\n\nUser Agent:\n" );
                    sb.Append( req.UserAgent );
                    sb.Append( "\n\nHost Address:\n" );
                    sb.Append( req.UserHostAddress );
                    sb.Append( " (" );
                    sb.Append( req.UserHostName );
                    sb.Append( ")" );
                    sb.Append( "\n\nReferrer:\n" );
                    sb.Append( req.UrlReferrer );

                    Utils.Email.AdminMail( "Хост " + req.UserHostAddress + " (" + req.UserHostName + ") был забанен", sb );
                    hit.IsNotified = true;
                }
                return (false);
            }
            hit.Hits++;

            if ( hit.Hits == 1 )
                context.Cache.Add( key, hit, null, hit.ExpiresAt, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null );

            return (true);
        }

        public static bool ValidateRequest( bool isPostBack )
        {
            if ( !isPostBack )
            {
                if ( WebUser.IsFirstVisit )
                    if ( !IsValid( ActionType.FirstVisit ) ) return (false);
                else
                    if ( !IsValid( ActionType.ReVisit ) ) return (false);
            }
            else
                if ( !IsValid( ActionType.PostBack ) ) return (false);

            return (true);
        }

    }
}
