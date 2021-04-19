using System;
using System.Web.UI;
using Pripev.BLL;
using Pripev.Web.Security;

namespace Pripev.Web.UI
{
   public class WebMasterPage : MasterPage
   {
      protected override void OnInit( EventArgs e )
      {
         base.OnInit( e );
         
         if ( !ActionValidator.ValidateRequest( IsPostBack ) )
            Response.End();

         CurrentUser = WebUser.CreateUser();
         if ( !CurrentUser.bLoggedIn ) CurrentUser.LoginFromCookie();
      }

      protected override void OnUnload( EventArgs e )
      {
         base.OnUnload( e );
         if ( CurrentUser != null ) CurrentUser.Serialize();
      }

      public WebUser CurrentUser { get; private set; }
   }
}
