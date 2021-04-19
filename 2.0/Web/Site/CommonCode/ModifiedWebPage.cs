using System;
using Pripev.Utils.Web;

namespace Pripev.Web.UI
{
    public abstract class ModifiedWebPage : WebPage
    {
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
            if ( !CurrentUser.bLoggedIn ) CheckLastUpdateTime();
        }

        protected virtual void CheckLastUpdateTime()
        {
            if ( !IsCrossPagePostBack && Convert.ToBoolean( Utils.Tools.GetAppSetting( "ExpirePages" ) ) )
                WebHelper.CheckModificationDate( LastModificationDate );
        }

        protected abstract DateTime LastModificationDate { get; }
    }
}
