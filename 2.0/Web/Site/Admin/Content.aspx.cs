using System;
using Pripev.Web.UI.Admin.UserControls;

namespace Pripev.Web.UI.Admin
{
    public partial class Content : ExpiredWebPage
    {
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( !CurrentUser.bManager && !CurrentUser.bAdmin )
                Response.End();
        }

        protected void lstArtists_ArtistChanged( object sender, ArtistListEventArgs e )
        {
            ctlArtist.ArtistId = e.ArtistId;
            ctlArtist.DataBind();
        }

        protected void ctlArtist_AlbumChanged( object sender, ArtistEventArgs e )
        {
            ctlAlbum.ArtistId = e.ArtistId;
            ctlAlbum.AlbumId = e.AlbumId;
            ctlAlbum.DataBind();
        }

        protected void ctlAlbum_SongChanged( object sender, AlbumEventArgs e ) {}
    }
}
