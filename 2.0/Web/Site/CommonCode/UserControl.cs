using Pripev.BLL;

namespace Pripev.Web.UI
{
    public class UserControl : System.Web.UI.UserControl
    {
        private readonly WebUser _webUser;

        protected UserControl()
        {
            _webUser = WebUser.CreateUser();
            if ( !_webUser.bLoggedIn ) _webUser.LoginFromCookie();
        }

        protected WebUser CurrentUser
        {
            get { return (_webUser); }
        }
    }
}
