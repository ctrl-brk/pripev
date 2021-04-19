using System;
using System.Web.UI;
using Pripev.DAL;

namespace Pripev.Web.UI.News
{
    public partial class Artist : Page
    {
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            var days = 1;

            if ( !IsPostBack )
            {
                if ( !String.IsNullOrEmpty( Request["Days"] ) ) days = Convert.ToInt32( Request["Days"] );
                ddlDays.SelectedValue = days.ToString();
            }
            else days = Convert.ToInt32( ddlDays.SelectedValue );

            var dt = DB.ExecuteDataTable( "exec GetNews @Type='Artist',@Days=" + days );
            if ( dt.Rows.Count == 0 )
            {
                plhNotFound.Visible = true;
                rptNews.Visible = false;
            }
            else
            {
                plhNotFound.Visible = false;
                rptNews.Visible = true;
                rptNews.DataSource = dt;
                rptNews.DataBind();
            }
        }
    }
}
