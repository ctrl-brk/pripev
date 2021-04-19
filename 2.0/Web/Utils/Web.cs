using System;
using System.Web;

namespace Pripev.Utils.Web
{
    public static class WebHelper
    {
        private static void ExpirePage( HttpContext context )
        {
            context.Response.AppendHeader( "Cache-Control", "no-cache" );
            context.Response.AppendHeader( "Cache-Control", "private" );
            context.Response.AppendHeader( "Cache-Control", "no-store" );
            context.Response.AppendHeader( "Cache-Control", "must-revalidate" );
            context.Response.AppendHeader( "Cache-Control", "max-stale=0" );
            context.Response.AppendHeader( "Cache-Control", "post-check=0" );
            context.Response.AppendHeader( "Cache-Control", "pre-check=0" );
            context.Response.AppendHeader( "Pragma", "no-cache" );
            context.Response.AppendHeader( "Keep-Alive", "timeout=3, max=993" );
            context.Response.Expires = 0;
            context.Response.ExpiresAbsolute = DateTime.Now.AddYears( -4 );
        }

        public static void ExpirePage()
        {
            ExpirePage( HttpContext.Current );
        }

        private static void CheckModificationDate( DateTime lastModified, HttpContext context )
        {
            if ( !String.IsNullOrEmpty( context.Request.ServerVariables["HTTP_IF_MODIFIED_SINCE"] ) )
            {
                try
                {
                    var modifiedSince = Convert.ToDateTime( context.Request.ServerVariables["HTTP_IF_MODIFIED_SINCE"] );
                    if ( lastModified <= modifiedSince )
                    {
                        try
                        {
                            context.Response.Clear();
                            context.Response.ClearHeaders();
                        }
                        catch {}

                        context.Response.StatusCode = 304;
                        context.Response.StatusDescription = "Not Modified";
                        context.Response.Flush();
                        context.Response.End();
                        return;
                    }
                }
                catch {}
            }

            context.Response.AddHeader( "Last-Modified", lastModified.ToUniversalTime().ToString( "r" ) );
        }

        public static void CheckModificationDate( DateTime lastModified )
        {
            CheckModificationDate( lastModified, HttpContext.Current );
        }
    }
}
