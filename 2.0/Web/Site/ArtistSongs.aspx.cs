using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Pripev.BLL;

namespace Pripev.Web.UI
{
    public partial class ArtistSongs : ModifiedWebPage
    {
        private BLL.Artist _artist;

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( IsCrossPagePostBack ) return;

            if ( String.IsNullOrEmpty( Request["Id"] ) )
            {
                litNotFound.Visible = true;
                rptSongs.Visible = false;
                return;
            }

            _artist = new BLL.Artist( Convert.ToInt32( Request["Id"] ) );
            if ( _artist.Id == null )
            {
                litNotFound.Visible = true;
                rptSongs.Visible = false;
            }
            else
            {
                rptSongs.DataSource = _artist.Texts;
                rptSongs.DataBind();
            }
        }

        protected void rptSongs_ItemDataBound( Object Sender, RepeaterItemEventArgs e )
        {
            switch ( e.Item.ItemType )
            {
                case ListItemType.Header:
                    var lnkArtist = (HyperLink)e.Item.FindControl( "lnkArtist" );
                    lnkArtist.NavigateUrl = "/Artist.aspx?Id=" + _artist.Id;
                    lnkArtist.Text = _artist.Name;
                    break;
                case ListItemType.AlternatingItem:
                case ListItemType.Item:
                    var txt = (ArtistText)e.Item.DataItem;
                    var song = new Song( txt.SongId );
                    if ( song.ChordsNum > 1 )
                        ((HtmlTableCell)e.Item.FindControl( "tdTextIcon" )).Attributes["class"] += " chkm";
                    else if ( song.ChordsNum > 0 )
                        ((HtmlTableCell)e.Item.FindControl( "tdTextIcon" )).Attributes["class"] += " chk";

                    ((Literal)e.Item.FindControl( "litSongName" )).Text = song.LinkHtml;
                    ((Literal)e.Item.FindControl( "litSongIcons" )).Text = song.GetIconsHtml( false );
                    break;
            }
        }

        protected override DateTime LastModificationDate
        {
            get { return (Stats.GetArtistsUpdateTime( Convert.ToInt32( Request["Id"] ) )); }
        }

    }
}
