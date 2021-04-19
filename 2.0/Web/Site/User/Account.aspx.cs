using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Pripev.Web.UI.User
{
   public partial class Account : ExpiredWebPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         if( !CurrentUser.bRegistered ) Redirect( "/User/Login.aspx" );
         Master.Title = "Припевный аккаунт";
      }

      protected void Page_LoadComplete( object sender, EventArgs e )
      {
         if( !IsPostBack )
         {
            litStatusDesc.Text = CurrentUser.StatusDescription;

            if( !String.IsNullOrEmpty( CurrentUser.Alert ) )
            {
               lblAlert.Text = CurrentUser.Alert;
               trAlert.Visible = true;
            }
            
            if( CurrentUser.Status == Pripev.BLL.WebUserStatus.Waiting )
            {
               plhWaitStatus.Visible = true;
               plhActiveStatus.Visible = false;
            }

            if( CurrentUser.Status == Pripev.BLL.WebUserStatus.Active )
               PopulateForm();
         }

         if ( CurrentUser.Status == Pripev.BLL.WebUserStatus.Waiting && !_ConfirmationSent )
            btnRetry.Visible = true;
         else if ( CurrentUser.Status == Pripev.BLL.WebUserStatus.Active )
            btnSubmit.Visible = true;

         if ( CurrentUser.Status == Pripev.BLL.WebUserStatus.Waiting )
         {
            if ( _ConfirmationSent )
               trRetryEmail.Visible = false;
         }
      }

      private void PopulateForm()
      {
         txtUserName.Text = CurrentUser.Name;
         txtUserEmail.Text = CurrentUser.Email;

         if ( CurrentUser.EmailLinks == true )
            rbMailLinksY.Checked = true;
         else
            rbMailLinksN.Checked = true;

         if ( CurrentUser.HtmlEmail == true )
            rbMailFormatH.Checked = true;
         else
         {
            rbMailFormatT.Checked = true;
            trMailLinks.Visible = false;
         }

         if ( CurrentUser.MailList == true )
            rbMailListY.Checked = true;
         else
         {
            rbMailListN.Checked = true;
            trMailFormat.Visible = trMailLinks.Visible = false;
         }



         ddlTimeOffset.SelectedValue = CurrentUser.TimeOffset.ToString();
      }

      private bool _ConfirmationSent
      {
         get { return ( ViewState["ConfirmationSent"] == null ? false : (bool)ViewState["ConfirmationSent"] ); }
         set { ViewState["ConfirmationSent"] = value; }
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
         if ( !Page.IsValid ) return;

         bool emailChanged = false;
         StringBuilder sql = new StringBuilder( "exec PutWebUser @UserId=" + CurrentUser.Id.ToString() +
                                                               ",@Name=" + Utils.Convert.ToSQLString( txtUserName.Text ) +
                                                               ",@MailList=" + Utils.Convert.ToSQLString( rbMailListY.Checked ) +
                                                               ",@EmailFormat=" + ( rbMailFormatH.Checked ? "'H'" : "'T'" ) +
                                                               ",@EmailLinks=" + Utils.Convert.ToSQLString( rbMailLinksY.Checked ) +
                                                               ",@TimeOffset=" + Utils.Convert.ToSQL( ddlTimeOffset.SelectedValue ) );
         if ( !String.IsNullOrEmpty( txtPassword.Text ) )
            sql.Append( ",@Password=" + Utils.Convert.ToSQLString( txtPassword.Text ) );

         if ( !txtUserEmail.Text.Equals( CurrentUser.Email, StringComparison.OrdinalIgnoreCase ) )
         {
            sql.Append( ",@Email=" + Utils.Convert.ToSQLString( txtUserEmail.Text ) +
                        ",@Confirmation='Y'" );
            emailChanged = true;
         }

         DataRow dr = DAL.DB.ExecuteDataRow( sql );
         if ( dr["UserId"] == DBNull.Value )  //new email already exists
         {
            lblAlert.Text = "Извините, но адрес" + Server.HtmlEncode( txtUserEmail.Text ) + " уже зарегистрирован.";
            trAlert.Visible = true;
            emailChanged = false;
         }
         else
         {
            if ( emailChanged )
               Utils.Web.Email.RegisterMail( txtUserEmail.Text, txtUserName.Text, CurrentUser.GUID, rbMailFormatH.Checked );

            String pass = String.IsNullOrEmpty( txtPassword.Text ) ? CurrentUser.Password : txtPassword.Text;
            String eml = emailChanged ? txtUserEmail.Text : CurrentUser.Email;
            CurrentUser.Logout();
            CurrentUser.Email = eml;
            CurrentUser.Password = pass;
            CurrentUser.Login();

            Redirect( "/User/Account.aspx" );
         }
      }

      protected void btnRetry_Click( Object sender, EventArgs e )
      {
         _ConfirmationSent = false;
         litWaitStatus.Text = "Вам было отослано повторное письмо со ссылкой для подтверждения регистрации.";

         if ( !String.IsNullOrEmpty( txtRetryEmail.Text ) && !txtRetryEmail.Text.Equals( CurrentUser.Email, StringComparison.OrdinalIgnoreCase ) )
         {
            DataRow dr = DAL.DB.ExecuteDataRow( "exec PutWebUser @UserId=" + CurrentUser.Id.ToString() +
                                                               ",@Email=" + Utils.Convert.ToSQLString( txtRetryEmail.Text ) );

            if ( dr["UserId"] != DBNull.Value )
            {
               CurrentUser.Email = txtRetryEmail.Text;
               Utils.Web.Email.RegisterMail( CurrentUser.Email, CurrentUser.Name, CurrentUser.GUID, CurrentUser.HtmlEmail == true );
               _ConfirmationSent = true;
            }
            else
               litWaitStatus.Text = "<div style='text-align:center'>Извините, но адрес <b>" + Server.HtmlEncode( txtRetryEmail.Text ) + "</b> уже зарегистрирован.</div>";
         }
         else
         {
            Utils.Web.Email.RegisterMail( CurrentUser.Email, CurrentUser.Name, CurrentUser.GUID, CurrentUser.HtmlEmail == true );
            _ConfirmationSent = true;
         }
      }

   }
}
