using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pripev.Web.UI.News
{
    public partial class Files : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var days = 1;

            if ( !IsPostBack )
            {
                if ( !String.IsNullOrEmpty( Request["Days"] ) ) days = Convert.ToInt32( Request["Days"] );
                ddlDays.SelectedValue = days.ToString();
            }
            else days = Convert.ToInt32( ddlDays.SelectedValue );

            var dt = DAL.DB.ExecuteDataTable( "exec GetNews @Type='Sound',@Days=" + days );
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

        protected void rptNews_ItemDataBound( Object Sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem ) return;
            
            var dr = (DataRowView)e.Item.DataItem;
            var sng = new BLL.Song( Convert.ToInt32( dr["SONG_ID"] ) );
            ((Literal)e.Item.FindControl( "litSong" )).Text = sng.LinkHtml;
        }
    }
}
