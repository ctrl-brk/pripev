using System;

namespace Pripev.Web.UI
{
    public partial class MainMasterPage : WebMasterPage
    {
        protected override void OnLoad(EventArgs e)
        {
            frameLoginPanel.Attributes.Add( "src", String.Format( "http://{0}/LoginPanel.aspx", Utils.Web.Tools.ServerName ) );

            SetRegistrationMode();
        }

        private void SetRegistrationMode()
        {
            litUserHr.Visible = CurrentUser.bRegistered;
        }

        public String Title
        {
            get { return (litTitle.Text); }
            set
            {
                const string sAppend = " (pripev.ru)";
                if ( value.StartsWith( "*" ) )
                    litTitle.Text = value.Substring( 1 ) + sAppend;
                else
                    litTitle.Text = value;
            }
        }
    }
}
