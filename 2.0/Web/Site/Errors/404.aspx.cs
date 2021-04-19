using System;

namespace Pripev.Web.UI.Errors
{
    public partial class Error404 : ErrorPage
    {
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            var path = Request["aspxerrorPath"];

            if ( String.IsNullOrEmpty( path ) )
            {
                int i = 0, startIndex = 0;
                var arr = Request.RawUrl.Split( new[] {'/'} );
                foreach ( var s in arr )
                {
                    if ( s.Contains( ".asp" ) && !s.Contains( ".aspx" ) )
                    {
                        path = "/" + String.Join( "/", arr, startIndex, arr.Length - startIndex );
                        break;
                    }
                    if ( s.Contains( "pripev.ru" ) ) startIndex = i + 1;
                    i++;
                }
            }

            if ( String.IsNullOrEmpty( path ) ) return;

            if ( path.Contains( ".asp" ) && !path.Contains( ".aspx" ) )
                Redirect( path.Replace( ".asp", ".aspx" ) );
            else
                litUrl.Text = "<b>" + path + "</b>";
        }
    }
}
