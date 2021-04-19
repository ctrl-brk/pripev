using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Pripev.BLL;

namespace Pripev.Web.UI.User
{
   public partial class DelOrder : WebPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         Title = "Del";

         if ( !CurrentUser.bLoggedIn ) Redirect( "/User/Login.aspx" );
         if ( !CurrentUser.bActive ) Redirect( CurrentUser.HomePage );

         UserOrder ord = new UserOrder( Convert.ToInt32( Request["Id"] ) );
         if ( ord.UserId == CurrentUser.Id )
         {
            if ( ord.IsActive == true )
               UserOrder.DeleteOrder( (int)ord.Id, (int)CurrentUser.Id );

            Redirect( "/User/OrdersProgress.aspx" );
         }

         StringBuilder sb = new StringBuilder( "Какой-то хрен пытался удалить чужой заказ " );
         sb.Append( ord.Id );
         sb.Append( "\nUser Id: " );
         sb.Append( CurrentUser.Id );
         sb.Append( "\nEmail: " );
         sb.Append( CurrentUser.Email );
         sb.Append( "\nIP: " );
         sb.Append( Request.ServerVariables["REMOTE_ADDR"] );

         Utils.Email.AdminMail( "Удаление чужого заказа!", sb );
      }
   }
}
