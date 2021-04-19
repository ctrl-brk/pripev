using System;
using System.Data;
using Pripev.Utils.Web;

namespace Pripev.Web.UI.User
{
    public partial class RemindPassword : WebPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if ( CurrentUser.bRegistered ) Redirect( "/User/Account.aspx" );
        }

        protected void btnSubmit_Click( Object sender, EventArgs e )
        {
            if ( !Page.IsValid ) return;

            var dr = DAL.DB.ExecuteDataRow( "select Name, Password from WebUsers where Email=" + Utils.Convert.ToSQLString( txtUserEmail.Text ) );

            if ( dr != null )
            {
                Email.RemindPasswordMail( txtUserEmail.Text, dr["Name"].ToString(), dr["Password"].ToString() );
                litMsg.Text = "Ваш логин был выслан по адресу <strong>" + Server.HtmlEncode( txtUserEmail.Text ) + "</strong>";
            }
            else
                litMsg.Text = "Пользователь с адресом <strong>" + Server.HtmlEncode( txtUserEmail.Text ) + "</strong> не найден.";

            plhMsg.Visible = true;
        }

    }
}
