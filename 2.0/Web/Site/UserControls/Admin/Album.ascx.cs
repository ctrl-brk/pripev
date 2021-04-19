using System;

// ReSharper disable PossibleInvalidOperationException

namespace Pripev.Web.UI.Admin.UserControls
{
    public class AlbumEventArgs
    {
        public int AlbumId { get; set; }
        public int SongId { get; set; }
    }

    public delegate void AlbumEventHandler( object sender, AlbumEventArgs e );

    public partial class Album : UserControl
    {
        public event AlbumEventHandler SongChanged;

        public int? ArtistId
        {
            get
            {
                if ( ViewState["ArtistId"] == null ) return (null);
                return (Convert.ToInt32( ViewState["ArtistId"] ));
            }
            set { ViewState["ArtistId"] = value; }
        }

        public int? AlbumId
        {
            get
            {
                if ( ViewState["AlbumId"] == null ) return (null);
                return (Convert.ToInt32( ViewState["AlbumId"] ));
            }
            set { ViewState["AlbumId"] = value; }
        }

        public new void DataBind()
        {
            if ( !AlbumId.HasValue || AlbumId.Value < 0 ) return;

            var album = new BLL.Album( AlbumId );
            litAlbumId.Text = album.Id.ToString();
            txtName.Text = album.Name;
            txtLImage.Text = album.ModelLargeImage;
            txtSImage.Text = album.ModelSmallImage;
            txtYear.Text = album.Year;
            txtGenre.Text = album.Genre.ToString();
            cbWanted.Checked = album.Wanted;
            cbCD.Checked = album.CD;
            txtProducer.Text = album.Producer;
            txtListen.Text = album.ListenLink;
            txtInfo.Text = album.InfoText;

            lstSongs.DataSource = album.Songs;
            lstSongs.DataBind();
        }

        private void FillData( BLL.Album album )
        {
            album.Name = txtName.Text;
            album.ModelSmallImage = txtSImage.Text;
            album.ModelLargeImage = txtLImage.Text;
            album.Year = txtYear.Text;
            album.Genre = Convert.ToByte( txtGenre.Text );
            album.Wanted = cbWanted.Checked;
            album.CD = cbCD.Checked;
            album.Producer = txtProducer.Text;
            album.ModelListenLink = txtListen.Text;
            album.InfoText = txtInfo.Text;
        }

        protected void lstSongs_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( SongChanged == null ) return;

            var arg = new AlbumEventArgs {AlbumId = AlbumId.Value, SongId = Convert.ToInt32( lstSongs.SelectedValue )};
            SongChanged( this, arg );
        }

        protected void btnNew_Click( object sender, EventArgs e )
        {
            var album = new BLL.Album();
            FillData( album );
            album.ArtistId = ArtistId;
            album.Save( CurrentUser.Id.Value );
        }

        protected void btnSave_Click( object sender, EventArgs e )
        {
            var album = new BLL.Album( AlbumId );
            FillData( album );
            album.Save( CurrentUser.Id.Value );
        }

        protected void btnDelete_Click( object sender, EventArgs e )
        {
            var album = new BLL.Album( AlbumId );
            album.Delete();
        }

    }
}
