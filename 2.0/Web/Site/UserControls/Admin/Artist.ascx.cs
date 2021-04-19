using System;

namespace Pripev.Web.UI.Admin.UserControls
{
    public class ArtistEventArgs
    {
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
    }

    public delegate void ArtistEventHandler( object sender, ArtistEventArgs e );

    public partial class Artist : UserControl
    {
        public event ArtistEventHandler AlbumChanged;

        public new void DataBind()
        {
            if ( ArtistId == null ) return;

            var artist = new BLL.Artist( ArtistId );
            litArtistId.Text = artist.Id.ToString();
            txtLetter.Text = artist.Letter.ToString();
            txtName.Text = artist.Name;
            txtName1.Text = artist.Name1;
            txtImage.Text = artist.ModelImage;
            txtInfo.Text = artist.Info;
            txtLinks.Text = artist.Links;
            txtAKA.Text = artist.Aka.ToString();

            lstAlbums.DataSource = artist.Albums;
            lstAlbums.DataBind();
        }

        public int? ArtistId
        {
            get
            {
                if ( ViewState["ArtistId"] == null ) return (null);
                return (Convert.ToInt32( ViewState["ArtistId"] ));
            }
            set { ViewState["ArtistId"] = value; }
        }

        protected void btnNew_Click( object sender, EventArgs e )
        {
            ArtistId = null;
        }

// ReSharper disable PossibleInvalidOperationException        
        protected void btnSave_Click( object sender, EventArgs e )
        {
            var artist = new BLL.Artist( ArtistId )
                             {
                                 Letter = txtLetter.Text.ToCharArray()[0],
                                 Name = txtName.Text,
                                 Name1 = txtName1.Text,
                                 ModelImage = txtImage.Text,
                                 Info = txtInfo.Text,
                                 Links = txtLinks.Text
                             };
            
            if ( String.IsNullOrEmpty( txtAKA.Text ) )
                artist.Aka = null;
            else
                artist.Aka = Convert.ToInt32( txtAKA.Text );

            artist.Save( CurrentUser.Id.Value );
        }

        protected void lstAlbums_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( AlbumChanged == null ) return;

            var arg = new ArtistEventArgs {ArtistId = ArtistId.Value, AlbumId = Convert.ToInt32( lstAlbums.SelectedValue )};
            AlbumChanged( this, arg );
        }
    }
}
