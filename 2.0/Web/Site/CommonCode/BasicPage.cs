using System;
using System.Web.UI;
using Pripev.BLL;
using Pripev.Web.Security;

namespace Pripev.Web.UI
{
    public class BasicPage : Page
    {
        private bool _dosValidation, _createUser = true;

        protected WebUser CurrentUser { get; private set; }

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            foreach ( var attr in GetType().GetCustomAttributes( typeof ( PageAttribute ), true ) )
            {
                _dosValidation = ((PageAttribute)attr).DoSValidation;
                _createUser = ((PageAttribute)attr).CreateUser;
            }

            if ( _dosValidation && !ActionValidator.ValidateRequest( IsPostBack ) )
                Response.End();

            if ( !_createUser ) return;

            CurrentUser = WebUser.CreateUser();
            if ( !CurrentUser.bLoggedIn ) CurrentUser.LoginFromCookie();
        }

        protected override void OnUnload( EventArgs e )
        {
            base.OnUnload( e );
            if ( CurrentUser != null ) CurrentUser.Serialize();
        }

        protected new BasicPage PreviousPage
        {
            get { return (base.PreviousPage == null ? null : (BasicPage)base.PreviousPage); }
        }

        protected void Redirect( String url )
        {
            Response.Redirect( url, true );
        }

// ReSharper disable UnusedMember.Global
        public void Redirect( String url, bool endResponse )
        {
            Response.Redirect( url, endResponse );
        }
// ReSharper restore UnusedMember.Global
    }
}
