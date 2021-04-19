using System;

namespace Pripev.Web.UI
{
    public class WebPage : BasicPage
    {
        protected new MainMasterPage Master
        {
            get { return (base.Master == null ? null : (MainMasterPage)base.Master); }
        }

        protected new String Title
        {
            set { if ( Master != null ) Master.Title = value; }
// ReSharper disable UnusedMember.Global
            get { return (Master == null ? null : Master.Title); }
// ReSharper restore UnusedMember.Global
        }

    }
}
