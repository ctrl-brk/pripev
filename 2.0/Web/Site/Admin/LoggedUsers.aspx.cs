using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pripev.BLL;

namespace Pripev.Web.UI.Admin
{
   public partial class LoggedUsers : PopupPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         if ( !CurrentUser.bAdmin )
            Response.End();
         else
            ShowUsers();
      }

      private class UserComparer : IComparer<WebUserSession>
      {
         public int Compare( WebUserSession a, WebUserSession b )
         {
            if ( a.UserId > b.UserId ) return ( 1 );
            if ( a.UserId < b.UserId ) return ( -1 );
            return ( a.SessionId.CompareTo( b.SessionId ) );
         }
      }

      private void ShowUsers()
      {
         Application.Lock();
         ( (List<WebUserSession>)Application["OnlineUsers"] ).Sort( new UserComparer() );
         rptUsers.DataSource = (List<WebUserSession>)Application["OnlineUsers"];
         rptUsers.DataBind();
         Application.UnLock();
      }
   }
}
