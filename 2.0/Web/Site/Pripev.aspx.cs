using System;
using System.Web.UI;

namespace Pripev.Web.UI
{
    public partial class OldPripev : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var type = Request["hsType"];

            switch ( type )
            {
                case "Help":
                    Response.Redirect( "/About.aspx", true );
                    break;
                case "Artists":
                    Response.Redirect( "/Artists.aspx?Letter=" + Request["hsArtistLetter"], true );
                    break;
                case "Artist":
                    Response.Redirect( "/Artist.asx?Id=" + Request["hnArtistId"] );
                    break;
                case "Album":
                    Response.Redirect( "/Album.aspx?Id=" + Request["hnAlbumId"] );
                    break;
                case "Song":
                    Response.Redirect( "/Text.aspx?SongId=" + Request["hnSongId"] );
                    break;
                case "AlbumSongs":
                    Response.Redirect( "/AlbumSongs.aspx?Id=" + Request["hnAlbumId"] );
                    break;
                case "ArtistSongs":
                    Response.Redirect( "/ArtistSongs.aspx?Id=" + Request["hnArtistId"] );
                    break;
                case "GuestBook":
                    Response.Redirect( "/GuestBook.aspx" );
                    break;
                case "Orders":
                    Response.Redirect( "/User/OrdersProgress.aspx" );
                    break;
                case "Guitar":
                    Response.Redirect( "/Guitar.aspx" );
                    break;
                case "Links":
                    Response.Redirect( "/Links.aspx" );
                    break;
                case "MailList":
                    Response.Redirect( "/User/Account.aspx" );
                    break;
                case "Wanted":
                    Response.Redirect( "/Wanted.aspx" );
                    break;
                case "TOP":
                    Response.Redirect( "/TOP.aspx" );
                    break;
                case "Buy":
                    Response.Redirect( "/Buy.aspx" );
                    break;
                case "Payment":
                    Response.Redirect( "/Payment.aspx" );
                    break;
                case "Banners":
                    Response.Redirect( "/Banners.aspx" );
                    break;
                default:
                    Response.Redirect( "/" );
                    break;
            }
        }
    }
}
