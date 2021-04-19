using System;
using System.Web.UI.WebControls;
using Pripev.BLL;

namespace Pripev.Web.UI
{
    public partial class AlbumSongs : ModifiedWebPage
    {
        private BLL.Album _album;
        private int _variant = 1;
        private String _curSongName = String.Empty;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if ( IsCrossPagePostBack ) return;

            _album = new BLL.Album( Convert.ToInt32( Request["Id"] ) );

            if ( _album.Id == null )
            {
                litNotFound.Visible = true;
                pnlTexts.Visible = false;
                return;
            }

            if ( _album.TextNum == 0 )
            {
                litNoTexts.Visible = true;
                pnlTexts.Visible = false;
                return;
            }

            lnkArtist.NavigateUrl = "/Artist.aspx?Id=" + _album.ArtistId;
            lnkArtist.Text = _album.ArtistName;
            lnkAlbum.NavigateUrl = "/Album.aspx?Id=" + _album.Id;
            lnkAlbum.Text = _album.Name;

            rptTexts.DataSource = _album.Texts;
            rptTexts.DataBind();
        }

        protected void rptTexts_ItemDataBound( Object sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem ) return;

            var txt = (AlbumText)e.Item.DataItem;

            if ( _curSongName != txt.SongName )
            {
                _curSongName = txt.SongName;
                _variant = 1;
            }

            var plh = (PlaceHolder)e.Item.FindControl( "plhHeader" );

            if ( _variant == 1 )
            {
                plh.Visible = true;
                ((Literal)plh.FindControl( "litHeader" )).Text = txt.SongName + txt.IconsHtml;
                e.Item.FindControl( "plhVariant" ).Visible = false;
            }
            else
            {
                plh.Visible = false;
                ((Literal)plh.FindControl( "litVariant" )).Text = "Вариант " + _variant;
                e.Item.FindControl( "plhVariant" ).Visible = true;
            }

            if ( txt.ChordsNum == 0 ) e.Item.FindControl( "lnkChords" ).Visible = false;
            ((HyperLink)e.Item.FindControl( "lnkPrint" )).NavigateUrl = "javascript:PrintText(" + txt.SongId + "," + txt.TextId + ")";
            ((Literal)e.Item.FindControl( "litText" )).Text = txt.SongText.GetHTML( CurrentUser );

            _variant++;
        }

        protected override DateTime LastModificationDate
        {
            get { return (Stats.GetAlbumsUpdateTime( Convert.ToInt32( Request["Id"] ), null )); }
        }
    }
}
