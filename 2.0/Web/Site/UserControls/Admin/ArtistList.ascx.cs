using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pripev.Web.UI.Admin.UserControls
{
   #region // Event stuff
   public class ArtistListEventArgs
   {
      private int _artistId;

      public ArtistListEventArgs( int artistId )
      {
         _artistId = artistId;
      }

      public int ArtistId
      {
         get { return ( _artistId ); }
      }
   }

   public delegate void ArtistListEventHandler( object sender, ArtistListEventArgs e );
   #endregion

   public partial class ArtistList : UserControl
   {
      private int _rows = 0, _width = 0, _height = 0;

      #region // Custom events
      public event ArtistListEventHandler ArtistChanged;

      protected virtual void OnArtistChanged( ArtistListEventArgs e )
      {
         if ( ArtistChanged != null ) ArtistChanged( this, e );
      }
      #endregion

      #region // Page event handlers
      protected void Page_Load( object sender, EventArgs e )
      {
         if ( !IsPostBack )
         {
            DataTable dt = DAL.DB.ExecuteDataTable( "exec GetArtists" );
            lstArtists.DataSource = dt;
            lstArtists.DataBind();
         }
      }

      protected void Page_PreRender( object sender, EventArgs e )
      {
         if ( Rows > 0 ) lstArtists.Rows = Rows;
         if ( Width > 0 ) lstArtists.Width = Width;
         if ( Height > 0 ) lstArtists.Height = Height;
      }
      #endregion

      #region // Public properties
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
         OnArtistChanged( new ArtistListEventArgs( Convert.ToInt32( lstArtists.SelectedValue ) ) );
      }
      #endregion
   }
}