using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Pripev.Web.UI.Wanted
{
   public partial class TextIndex : System.Web.UI.Page
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         int nOldArtist = 0, nArtist, nOldAlbum = 0, nAlbum;
         StringBuilder sb = new StringBuilder( 300 * 1024 );

         DataTable dt = DAL.DB.ExecuteDataTable( "exec WantedMP3" );

         Response.Write( "СПИСОК КОМПОЗИЦИЙ, РАЗЫСКИВАЕМЫХ САЙТОМ PRIPEV.RU\n(версия от " + DateTime.Now.ToString() + ")\n\n" );

         foreach( DataRow dr in dt.Rows )
         {
            nArtist = Convert.ToInt32( dr["ArtistId"] );
            if ( nOldArtist != nArtist )
            {
               Response.Write( "-------------------------------------------------\n"  + dr["Artist"].ToString().ToUpper() + "\n" );
               nOldArtist = nArtist;
            }

            nAlbum = Convert.ToInt32( dr["AlbumId"] );
            if ( nOldAlbum != nAlbum )
            {
               Response.Write( "\t" + dr["Album"].ToString() + "\n" );
            }

            Response.Write( "\t\t" + dr["Song"].ToString() + "\n" );
         }
      }
   }
}
