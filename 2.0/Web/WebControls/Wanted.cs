using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pripev.Web.UI.WebControls
{
   public class Wanted : Pripev.Web.UI.WebControls.WebControl
   {
      public String Letters
      {
         get { return ( ViewState["Letters"] == null ? null : ViewState["Letters"].ToString() ); }
         set { ViewState["Letters"] = value; }
      }

      private String Header
      {
         get
         {
            return ( @"<tr>
         <th align='left'>Исполнитель</th>
         <th align='left'>Альбом</th>
         <th>№</th>
         <th align='left'>Композиция</th>
         <th>&nbsp;</th>
         </tr>" );
         } 
      }

      protected override void Render( HtmlTextWriter writer )
      {
         if ( String.IsNullOrEmpty( Letters ) ) return;

         int nOldArtist = 0, nOldAlbum = 0;
         int nArtist, nAlbum, nTrack;
         String sArtist, sAlbum, sSong, sArtistRows, sAlbumRows, sClass = String.Empty;
         StringBuilder sb = new StringBuilder( "<tr>", 100 * 1024 );

         DataTable dt = DAL.DB.ExecuteDataTable( "exec WantedMP3 @sLetters=" + Utils.Convert.ToSQLString( Letters ) );
         foreach ( DataRow dr in dt.Rows )
         {
            nArtist = Convert.ToInt32( dr["ArtistId"] );
            sArtist = dr["Artist"].ToString();
            nAlbum  = Convert.ToInt32( dr["AlbumId"] );
            sAlbum  = dr["Album"].ToString();
            sSong   = dr["Song"].ToString();
            nTrack = Convert.ToInt32( dr["Track"] );

            if ( nOldArtist != nArtist ) 
            {
               if ( Convert.ToInt32( dr["ArtistRows"] ) > 1 ) sArtistRows = " rowspan=" + dr["ArtistRows"].ToString();
               else sArtistRows = String.Empty;
         
               if ( nOldArtist != 0 ) sb.Append( "<td colspan='5' class='nlb'><hr size='1'></td></tr><tr>" );
               sb.Append( "<td" + sArtistRows + " class='nlb'>" + sArtist + "</td>" );
               nOldArtist = nArtist;
            }
         
            if ( nOldAlbum != nAlbum )
            {
               if ( Convert.ToInt32( dr["AlbumRows"] ) > 1 )
               {
                  sAlbumRows = " rowspan=" + dr["AlbumRows"].ToString();
                  sClass = String.IsNullOrEmpty( sClass ) ? " class='hl'" : String.Empty;
               }
               else sAlbumRows = sClass = String.Empty;

               sb.Append( "<td" + sAlbumRows + sClass + ">" + sAlbum + "</td>" );
               nOldAlbum = nAlbum;
            }
      
            sb.Append( "<td class='trk" );
            if ( !String.IsNullOrEmpty( sClass ) ) sb.Append( " hl" );
            sb.Append( "'" );
            sb.Append( nTrack == 0 ? "&nbsp;" : nTrack.ToString() );
            sb.Append( "</td>" );
            sb.Append( "<td" + sClass + ">" + sSong + "</td>" );
            sb.Append( "<td><a href=\"javascript:FileUpload(" + nTrack.ToString() + ",'" + sArtist + "','" + sAlbum + "','" + sSong + "')\">Загрузить</a></td>" );
            sb.Append( "</tr>" );
         }
         sb.Insert( 0, Header );
         writer.Write( sb );
      }
   }
}
