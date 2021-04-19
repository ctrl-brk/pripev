using System;

namespace Pripev.Web.UI
{
    public class AdminWebPage : ExpiredWebPage
    {
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
            if ( !CurrentUser.bAdmin ) Redirect( "/User/Login.aspx" );
        }

    }
}
