using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pripev.Utils.Web;

namespace Pripev.Web.UI.User
{
   public partial class Confirm : WebPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         Guid guid = Guid.Empty;

         if( Master.CurrentUser.bLoggedIn ) Response.Redirect( "/User/Account.aspx" );

         try { guid = new Guid( Request[ "GUID" ] ); }
         catch {}
   
         if ( guid == Guid.Empty ) litMsg.Text = "У Вас неверная ссылка.";

         if ( !Master.CurrentUser.ConfirmLogin( guid ) )
            litMsg.Text = "Извините, но Ваш код подтверждения неверен. " + Email.EmailLink( "ContactMail" ) + "Пишите письма</a> - будем разбираться.";
         else
            Response.Redirect( "/User/Account.aspx" );
      }
   }
}
