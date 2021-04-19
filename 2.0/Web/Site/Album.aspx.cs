using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pripev.Web.UI
{
    public partial class Album : ModifiedWebPage
    {
        private BLL.Artist _artist;
        private BLL.Album _album;

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            if ( IsCrossPagePostBack ) return;

            _album = new BLL.Album( Convert.ToInt32( Request["Id"] ) );
            BLL.Counter.CountAlbum( Convert.ToInt32( Request["Id"] ) );

// ReSharper disable PossibleInvalidOperationException
            var artistId = !String.IsNullOrEmpty( Request["Art"] ) ? Convert.ToInt32( Request["Art"] ) : _album.ArtistId.Value;
// ReSharper restore PossibleInvalidOperationException

            _artist = new BLL.Artist( artistId );

            if ( _album.Id == null || !ShowInfo() )
            {
                litNotFound.Visible = true;
                plhAlbum.Visible = false;
                pnlInfo.Visible = false;
                Master.Title = "*Альбом не найден";
            }
            else
                Master.Title = "*" + _album.Name + " - " + _artist.Name;
        }

        private bool ShowInfo()
        {
            var cols = 2;

            if ( _album.Id == null || !_artist.DetailsFlag ) return (false);

            lstAlbums.ArtistId = _artist.Id;
            lstAlbums.AlbumId = _album.Id;

            lstAlbums.DataSource = DAL.DB.ExecuteDataTable( "exec GetAlbums @ArtistId=" + _artist.Id + ",@ListBox='Y'" );
            lstAlbums.DataBind();

            lstAlbums.SelectedValue = _album.Id.ToString();

            if ( Master.CurrentUser.bLoggedIn ) cols = 3;
            tdHeaderSongs.ColSpan = cols;
            tdNoInfo.ColSpan = tdFooter.ColSpan = cols + 1;

            if ( !String.IsNullOrEmpty( _album.ListenLink ) ) lnkListen.NavigateUrl = _album.ListenLink;
            else lnkListen.Visible = false;

            if ( _album.SoundsNum > 0 )
            {
                thSounds.Style.Add( "class", "snd" );
                thSounds.Attributes.Add( "title", "Звуки" );
            }

            litComments.Visible = Master.CurrentUser.bLoggedIn;

            if ( _album.Songs.Count > 0 )
            {
                rptSongs.DataSource = _album.Songs;
                rptSongs.DataBind();
            }
            else plhNoInfo.Visible = true;

            if ( _album.TextNum > 1 ) //|| _album.ChordNum > 0 )
            {
                plhFooter.Visible = true;
                lnkAllSongs.NavigateUrl += _album.Id.ToString();
                lnkAllSongs.Text = _album.Year != String.Empty ? "Все тексты альбома" : "Все прочие тексты";
            }

            if ( (_album.Year == String.Empty || _album.Year == "?") && String.IsNullOrEmpty( _album.Producer ) && String.IsNullOrEmpty( _album.Info ) )
                pnlInfo.Visible = false;
            else
            {
                if ( (_album.Year == String.Empty || _album.Year == "?") && String.IsNullOrEmpty( _album.Producer ) )
                    tblInfoHeader.Visible = false;
                else
                {
                    if ( _album.Year != String.Empty && _album.Year != "?" ) litYearPrinted.Text = "Год выпуска: " + _album.Year;
                    if ( !String.IsNullOrEmpty( _album.Producer ) ) litProducer.Text = "Производитель: " + _album.Producer;
                    hrInfo.Visible = !String.IsNullOrEmpty( _album.Info );
                }
                litInfo.Text = _album.Info;
            }

            return (true);
        }

        protected void rptSongs_ItemDataBound( Object Sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem ) return;

            var sng = (BLL.Song)e.Item.DataItem;

            if ( _album.Year == String.Empty )
                ((HtmlTableCell)e.Item.FindControl( "tdTrackNum" )).Attributes.Remove( "class" );
            else if ( sng.IsSeparator )
                ((HtmlTableCell)e.Item.FindControl( "tdTrackNum" )).InnerHtml = "&nbsp;";

            var tc = (HtmlTableCell)e.Item.FindControl( "tdShareInfo" );
            if ( !sng.IsSeparator )
            {
                if ( sng.ChordsNum > 0 )
                    tc.Attributes.Add( "class", sng.ChordsNum > 1 ? "chkm" : "chk" );
                else
                {
                    tc.Attributes.Add( "class", "eml" );
                    tc.InnerHtml = "<a class='eml' href='javascript:ShareInfo()' title='Поделиться " + (sng.TextsNum > 0 ? "аккордами" : "песней") + "'>&nbsp;</a>";
                }
            }
            tc.InnerHtml += sng.HTMLName;

            tc = (HtmlTableCell)e.Item.FindControl( "tdSounds" );
            if ( sng.SoundsNum > 0 || sng.IsSeparator || sng.HasCD )
            {
                tc.Attributes.Add( "class", "snd" );
                tc.InnerHtml = sng.GetIconsHtml( false );
            }

            if ( !Master.CurrentUser.bLoggedIn || sng.IsSeparator ) e.Item.FindControl( "tdComment" ).Visible = false;
        }

        protected override DateTime LastModificationDate
        {
            get { return (BLL.Stats.GetAlbumsUpdateTime( Convert.ToInt32( Request["Id"] ), null )); }
        }
    }
}
