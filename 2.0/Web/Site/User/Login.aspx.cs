using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pripev.Web.UI.User
{
   public partial class Login : WebPage
   {
      private String _userEmail, _userPassword;
      private bool _bSubmit;

      protected void Page_LoadComplete( object sender, EventArgs e )
      {
         if ( PreviousPage == null && IsCrossPagePostBack ) return; //search

         var u = Master.CurrentUser;

         if( u.bLoggedIn ) Response.Redirect( u.HomePage );

         if ( PreviousPage != null && PreviousPage.IsCrossPagePostBack || ( IsPostBack && !_bSubmit ) )
         {
            TemplateControl pg = PreviousPage == null ? Master : (TemplateControl)PreviousPage;

            _userEmail = ( (TextBox)pg.FindControl( "txtLoginEmail" ) ).Text;
            _userPassword = ( (TextBox)pg.FindControl( "txtLoginPassword" ) ).Text;
         }
         else if ( IsPostBack )
         {
            _userEmail = txtEmail.Text;
            _userPassword = txtPassword.Text;
         }

         if ( !String.IsNullOrEmpty( _userEmail ) && !String.IsNullOrEmpty( _userPassword ) )
         {
            if ( u.Login( _userEmail, _userPassword ) )
               Response.Redirect( u.HomePage );
         }

         if ( !String.IsNullOrEmpty( _userEmail ) && !String.IsNullOrEmpty( _userPassword ) )
         {
            mvView1.ActiveViewIndex = 0;
         }
         else if ( u.bRegistered )
         {
            litStatusDesc.Text = u.StatusDescription;
            if ( u.bDangerous ) litAlert.Text = u.Alert;
            mvView1.ActiveViewIndex = 1;
         }
         else
            mvView1.ActiveViewIndex = 2;
      }

      protected void btnSubmit_Click( object sender, EventArgs e )
      {
         _bSubmit = true;
      }

   }
}
