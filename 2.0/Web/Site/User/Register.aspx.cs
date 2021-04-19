using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Pripev.Utils.Web;

namespace Pripev.Web.UI.User
{
   public partial class Register : WebPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
      }

      private void SaveUser()
      {
         int? userId;

         String sql = "exec PutWebUser @UserId=null" +
                     ",@Name=" + Utils.Convert.ToSQLString( txtUserName.Text ) +
                     ",@Email=" + Utils.Convert.ToSQLString( txtUserEmail.Text ) +
                     ",@Password=" + Utils.Convert.ToSQLString( txtPassword.Text ) +
                     ",@Comments=" + Utils.Convert.ToSQLString( txtUserComments.Text ) +
                     ",@MailList=" + Utils.Convert.ToSQLString( rbMailListY.Checked ) +
                     ",@EmailFormat=" + ( rbMailFormatH.Checked ? "'H'" : "'T'" ) +
                     ",@EmailLinks=" + Utils.Convert.ToSQLString( rbMailLinksY.Checked ) +
                     ",@TimeOffset=" + Utils.Convert.ToSQL( ddlTimeOffset.SelectedValue );

         DataRow dr = DAL.DB.ExecuteDataRow( sql );
         if( dr["UserId"] != DBNull.Value )
         {
            userId = Convert.ToInt32( dr["UserId"] );
            Email.RegisterMail( txtUserEmail.Text, txtUserName.Text, new Guid( dr["GUID"].ToString() ), rbMailFormatH.Checked );
            Response.Redirect( "/User/RConfirm.aspx" );
         }
         else
         {
            mvView1.ActiveViewIndex = 1;
            Session["LoginEmail"] = txtUserEmail.Text;
            litEmail.Text = Server.HtmlEncode( txtUserEmail.Text );
            litContact.Text = Email.EmailLink( "ContactMail" );
         }

      }

      protected void rbMailList_CheckedChanged( Object sender, EventArgs e )
      {
         trMailFormat.Visible = rbMailListY.Checked;
         trMailLinks.Visible = rbMailListY.Checked ? rbMailFormatH.Checked : false;
      }

      protected void rbMailFormat_CheckedChanged( Object sender, EventArgs e )
      {
         trMailLinks.Visible = rbMailFormatH.Checked;
      }

      protected void btnSubmit_Click( Object sender, EventArgs e )
      {
         if ( Page.IsValid ) SaveUser();
      }
   
   }
}
