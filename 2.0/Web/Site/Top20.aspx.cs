using System;
using Pripev.BLL;

namespace Pripev.Web.UI
{
    public partial class Top20 : WebPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if ( IsCrossPagePostBack ) return;

            if ( !IsPostBack )
            {
                Counter.CountTOP();
                Master.Title = "*Самые популярные припевы";
            }

            rptArtists.DataSource = DAL.DB.ExecuteDataTable( "exec TOP20 @Type='Artist'" );
            rptArtists.DataBind();

            rptAlbums.DataSource = DAL.DB.ExecuteDataTable( "exec TOP20 @Type='Album'" );
            rptAlbums.DataBind();

            rptSongs.DataSource = DAL.DB.ExecuteDataTable( "exec TOP20 @Type='Song'" );
            rptSongs.DataBind();
        }
    }
}
