using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pripev.Web.UI
{
    public partial class Artist : ModifiedWebPage
    {
        private BLL.Artist _artist;

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( IsCrossPagePostBack ) return;

            if ( String.IsNullOrEmpty( Request["Id"] ) && !String.IsNullOrEmpty( Request["ArtistId"] ) )
                Redirect( "/Artist.aspx?Id=" + Request["ArtistId"] ); //google sends artistid for some reason
            else
            {
                _artist = new BLL.Artist( RequestArtistId );
                BLL.Counter.CountArtist( RequestArtistId );
                if ( _artist.TextNum == 0 ) plhFooter.Visible = false;

                if ( _artist.Id == null || !ShowAlbums() )
                {
                    litNotFound.Visible = true;
                    pnlArtist.Visible = false;
                    Master.Title = "*Исполнитель не найден";
                }
                else Master.Title = "*" + _artist.Name + " - альбомы";

                if ( !String.IsNullOrEmpty( _artist.Info ) )
                    litInfo.Text = _artist.Info;
                else
                    pnlInfo.Visible = false;

                if ( !String.IsNullOrEmpty( _artist.Links ) )
                    litLinks.Text = _artist.Links;
                else
                    pnlLinks.Visible = false;
            }
        }

        private bool ShowAlbums()
        {
            ShowDetails();
            if ( _artist.DetailsFlag && _artist.Albums.Count > 0 )
            {
                rptAlbums.DataSource = _artist.Albums;
                rptAlbums.DataBind();
            }
            else
                plhAlbums.Visible = false;

            if ( _artist.DetailsFlag && _artist.Albums.Count == 0 ) tblNoAlbums.Visible = true;

            return (true);
        }

        private void ShowDetails()
        {
            if ( !_artist.DetailsFlag )
                plhDetails.Visible = false;
            else
            {
                litArtistName.Text = _artist.Name;
                if ( _artist.Image != null )
                    imgArtist.ImageUrl = _artist.Image;
                else
                {
                    imgArtist.Visible = false;
                    litNoImage.Visible = true;
                }
            }
        }

        private int RequestArtistId
        {
            get
            {
                if ( String.IsNullOrEmpty( Request["Id"] ) && !String.IsNullOrEmpty( Request["ArtistId"] ) )
                    return (Convert.ToInt32( Request["ArtistId"] ));
                
                return (Convert.ToInt32( Request["Id"] ));
            }
        }

        protected void rptAlbums_ItemDataBound( Object Sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem ) return;

            var alb = (BLL.Album)e.Item.DataItem;

            if ( alb.CD ) ((HtmlTableCell)e.Item.FindControl( "tdName" )).Attributes["class"] += " cd";
            if ( alb.SmallImage == null && alb.Year != String.Empty )
            {
                e.Item.FindControl( "lnkAlbum" ).Visible = false;
                e.Item.FindControl( "lnkNoAlbumImage" ).Visible = true;
            }

            if ( alb.Year != String.Empty )
            {
                if ( alb.Wanted && !alb.CD && alb.Mp3Num < alb.SongNum )
                {
                    ((HtmlTableCell)e.Item.FindControl( "tdSounds" )).Attributes["class"] = "wnt";
                }
            }

            if ( alb.Wanted && alb.Mp3Num == 0 && alb.Year != String.Empty )
            {
                e.Item.FindControl( "imgWanted" ).Visible = true;
                e.Item.FindControl( "litSounds" ).Visible = false;
            }
            else
                ((Literal)e.Item.FindControl( "litSounds" )).Text = Utils.Convert.ToNBSPString( alb.Mp3Num );

            if ( String.IsNullOrEmpty( alb.ListenLink ) )
            {
                e.Item.FindControl( "lnkListen" ).Visible = false;
                e.Item.FindControl( "litListen" ).Visible = true;
            }

            if ( !String.IsNullOrEmpty( alb.BuyURL ) ) return;

            e.Item.FindControl( "lnkBuy" ).Visible = false;
            e.Item.FindControl( "litBuy" ).Visible = true;
        }

        protected override DateTime LastModificationDate
        {
            //google sends artistid for some reason
            get { return (BLL.Stats.GetAlbumsUpdateTime( RequestArtistId )); }
        }
    }
}
