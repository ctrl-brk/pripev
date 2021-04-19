using System;
using System.Data;

namespace Pripev.Web.UI.Admin.UserControls
{
   #region // Event stuff
   public class AlbumListEventArgs
   {
      private readonly int _albumId;

      public AlbumListEventArgs( int albumId )
      {
         _albumId = albumId;
      }

      public int AlbumId
      {
         get { return ( _albumId ); }
      }
   }

   public delegate void AlbumListEventHandler( object sender, AlbumListEventArgs e );
   #endregion

   public partial class AlbumList : UserControl
   {
      private int? _artistId;
      private int _rows, _width, _height;

      #region // Custom events
      public event AlbumListEventHandler AlbumChanged;

      protected virtual void OnAlbumChanged( AlbumListEventArgs e )
      {
         if ( AlbumChanged != null ) AlbumChanged( this, e );
      }
      #endregion

      #region // Page event handlers
      protected void Page_Load( object sender, EventArgs e )
      {
         if ( !IsPostBack && ArtistId != null )
         {
            DataTable dt = DAL.DB.ExecuteDataTable( "exec GetAlbums @ArtistId=" + ArtistId.ToString() + "@,SortCol='NAME'" );
            lstAlbums.DataSource = dt;
            lstAlbums.DataBind();
         }
      }

      protected void Page_PreRender( object sender, EventArgs e )
      {
         if ( Rows > 0 ) lstAlbums.Rows = Rows;
         if ( Width > 0 ) lstAlbums.Width = Width;
         if ( Height > 0 ) lstAlbums.Height = Height;
      }
      #endregion

      #region // Public properties
      public int? ArtistId
      {
         get
         {
            if ( ViewState["ArtistId"] != null ) _artistId = (int)ViewState["ArtistId"];
            return ( _artistId );
         }
         set { ViewState["ArtistId"] = _artistId = value; }
      }

      public int Rows
      {
         get
         {
            if ( ViewState["Rows"] != null ) _rows = (int)ViewState["Rows"];
            return ( _rows );
         }
         set { ViewState["Rows"] = _rows = value; }
      }

      public int Width
      {
         get
         {
            if ( ViewState["Width"] != null ) _width = (int)ViewState["Width"];
            return ( _width );
         }
         set { ViewState["Width"] = _width = value; }
      }

      public int Height
      {
         get
         {
            if ( ViewState["Height"] != null ) _height = (int)ViewState["Height"];
            return ( _height );
         }
         set { ViewState["Height"] = _height = value; }
      }
      #endregion

      #region // Control event handlers
      protected void lstArtists_SelectedIndexChanged( object sender, EventArgs e )
      {
         OnAlbumChanged( new AlbumListEventArgs( Convert.ToInt32( lstAlbums.SelectedValue ) ) );
      }
      #endregion
   }
}
