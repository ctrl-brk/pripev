using System;
using System.Web.UI;

namespace Pripev.Web.RooK.Y
{
    public partial class DomPriv : Page
    {
        protected void btnOk_Click(object sender, EventArgs e)
        {
            if ( txtPassword.Text != "юльченок") return;

            pnlLogin.Visible = false;
            pnlVideo.Visible = true;
        }
    }
}
