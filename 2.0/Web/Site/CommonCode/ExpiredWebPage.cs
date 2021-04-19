using System;
using Pripev.Utils.Web;

namespace Pripev.Web.UI
{
    public class ExpiredWebPage : WebPage
    {
        protected ExpiredWebPage()
        {
            if ( Convert.ToBoolean( Utils.Tools.GetAppSetting( "ExpirePages" ) ) )
                WebHelper.ExpirePage();
        }
    }
}
