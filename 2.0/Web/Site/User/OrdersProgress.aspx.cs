using System;

namespace Pripev.Web.UI.User
{
    public partial class OrdersProgress : WebPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var script = @"<script language='JavaScript'>
    function OnLoad() {
       document.location = '/User/Orders.aspx?Dup=" + Request["Dup"] + @"&Hst=" + Request["Hst"] + @"&AllOrd=" + Request["AllOrd"] + @"&Err=" + Request["Err"] + @"';
    }
    </script>";

            ClientScript.RegisterClientScriptBlock( GetType(), "OP", script );
        }
    }
}
