using System;
using Pripev.Utils.Web;

namespace Pripev.Web.UI.User
{
    public partial class LoginPanel : BasicPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            WebHelper.ExpirePage();

            pnlUserNotRegistered.Visible = !CurrentUser.bRegistered;
            pnlUserRegistered.Visible = CurrentUser.bRegistered;
            litEditContent.Visible = CurrentUser.bManager && !CurrentUser.bAdmin;
            litAdmin.Visible = CurrentUser.bAdmin;
            litOrders.Visible = CurrentUser.bActive;
        }
    }
}
