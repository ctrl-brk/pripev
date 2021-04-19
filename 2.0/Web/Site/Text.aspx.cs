using System;
using System.Web.UI.WebControls;
using Pripev.BLL;
using Pripev.Utils.Web;

namespace Pripev.Web.UI
{
    public partial class Text : ModifiedWebPage
    {
        private Song _song;
        private int _textSeq;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if ( IsCrossPagePostBack ) return;

            _song = new Song( Convert.ToInt32( Request["SongId"] ) );

            if ( !_song.Id.HasValue )
            {
                litNotFound.Visible = true;
                return;
            }

            if ( _song.TextsNum == 0 )
            {
                litNoText.Visible = true;
                Master.Title = "*Песня не найдена";
                return;
            }
            Master.Title = "*" + _song.Name + " - " + _song.ArtistName;

            Counter.CountSong( (int)_song.Id );

            plhText.Visible = true;

            lnkArtist.NavigateUrl = "/Artist.aspx?Id=" + _song.ArtistId;
            lnkArtist.Text = _song.ArtistName;
            lnkAlbum.NavigateUrl = "/Album.aspx?Id=" + _song.AlbumId;
            lnkAlbum.Text = _song.AlbumName;

            rptTexts.DataSource = _song.Texts;
            rptTexts.DataBind();
        }

        protected void rptTexts_ItemDataBound( Object Sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem ) return;

            var txt = (BLL.Text)e.Item.DataItem;

            if ( _textSeq++ == 0 )
            {
                e.Item.FindControl( "plhHeader" ).Visible = true;
                e.Item.FindControl( "plhData" ).Visible = false;

                ((Literal)e.Item.FindControl( "litSongName" )).Text = _song.Name;
                ((Literal)e.Item.FindControl( "litSongIcons" )).Text = _song.GetIconsHtml( true );
            }
            else
            {
                e.Item.FindControl( "plhHeader" ).Visible = false;
                e.Item.FindControl( "plhData" ).Visible = true;
                ((Literal)e.Item.FindControl( "litTitle" )).Text = "Вариант " + (_textSeq);
            }

            ((Literal)e.Item.FindControl( "litText" )).Text = txt.GetHTML( Master.CurrentUser );

            e.Item.FindControl( "lnkChordGen" ).Visible = txt.HasChords;
        }

        protected override void CheckLastUpdateTime()
        {
            _song = new Song( Convert.ToInt32( Request["SongId"] ) );
            if ( _song.Id != null )
                WebHelper.CheckModificationDate( Stats.GetAlbumsUpdateTime( _song.AlbumId, null ) );
        }

        protected override DateTime LastModificationDate
        {
            // required by base abstract class
            get { return (DateTime.Now); }
        }

    }
}
