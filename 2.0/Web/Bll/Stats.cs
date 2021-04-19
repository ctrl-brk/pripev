using System;
using System.Data;

namespace Pripev.BLL
{
   public class Stats
   {
      public static DateTime GetArtistsUpdateTime( int? artistId )
      {
         return ( Convert.ToDateTime( DAL.DB.ExecuteDataRow( "exec GetLastModifiedDates @AlbumId=-1,@ArtistId=" + Utils.Convert.ToSQL( artistId ) )["Artists"] ) );
      }

      public static DateTime GetArtistsUpdateTime()
      {
         return ( GetArtistsUpdateTime( null ) );
      }

      public static DateTime GetAlbumsUpdateTime( int? albumId, int? artistId )
      {
         DataRow dr = DAL.DB.ExecuteDataRow( "exec GetLastModifiedDates @ArtistId=" + ( artistId == null ? "-1" : Utils.Convert.ToSQL( artistId ) ) + ",@AlbumId=" + Utils.Convert.ToSQL( albumId ) );
         DateTime artistUpdateTime;

         if (dr == null || dr["Albums"] == DBNull.Value)
             return (DateTime.MinValue);

         DateTime albumsUpdateTime = Convert.ToDateTime( dr["Albums"] );
         if ( dr["Artists"] != DBNull.Value )
         {
            artistUpdateTime = Convert.ToDateTime( dr["Artists"] );
            return ( artistUpdateTime > albumsUpdateTime ? artistUpdateTime : albumsUpdateTime );
         }
         return ( albumsUpdateTime );
      }

      public static DateTime GetAlbumsUpdateTime( int? artistId )
      {
         return ( GetAlbumsUpdateTime( null, artistId ) );
      }

      public static DateTime GetAlbumsUpdateTime()
      {
         return ( GetAlbumsUpdateTime( null, null ) );
      }

   }
}
