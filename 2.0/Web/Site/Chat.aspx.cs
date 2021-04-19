using System;

namespace Pripev.Web.UI.Popup
{
   public partial class Chat : PopupPage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if ( !CurrentUser.bLoggedIn)
         {
            litLogin.Visible = true;
            Chat1.Enabled = false;
         }
         else 
            Chat1.InitParameters = "UserName=" + CurrentUser.ChatName;
      }
   }
}
