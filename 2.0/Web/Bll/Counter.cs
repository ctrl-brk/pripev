using Pripev.DAL;
using Pripev.Utils.Web;
using System.Web;

namespace Pripev.BLL
{
    public static class Counter
    {
        private static void SaveCounter( string type, int? id = null )
        {
            var sql = "exec PutCounter @Type='" + type + "',@IP='" + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] + "'";
            if ( id != null ) sql += ",@Id=" + id;
            DB.ExecuteNonQuery( sql );
        }

        public static void CountArtist( int id )
        {
            if ( Tools.IsFriendAddress() ) return;

            var key = "CNT$ARTIST$" + id;
            if ( HttpContext.Current.Session[key] != null ) return;

            SaveCounter( "ARTIST", id );
            HttpContext.Current.Session[key] = 1;
        }

        public static void CountAlbum( int id )
        {
            if ( Tools.IsFriendAddress() ) return;

            var key = "CNT$ALBUM$" + id;
            if ( HttpContext.Current.Session[key] != null ) return;

            SaveCounter( "ALBUM", id );
            HttpContext.Current.Session[key] = 1;
        }

        public static void CountSong( int id )
        {
            if ( Tools.IsFriendAddress() ) return;

            var key = "CNT$SONG$" + id;
            if ( HttpContext.Current.Session[key] != null ) return;

            SaveCounter( "SONG", id );
            HttpContext.Current.Session[key] = 1;
        }

        public static void CountGuitar()
        {
            if ( Tools.IsFriendAddress() ) return;

            const string key = "CNT$GUITAR";
            if ( HttpContext.Current.Session[key] != null ) return;
            
            SaveCounter( "GUITAR" );
            HttpContext.Current.Session[key] = 1;
        }

        public static void CountLinks()
        {
            if ( Tools.IsFriendAddress() ) return;
            
            const string key = "CNT$LINKS";
            if ( HttpContext.Current.Session[key] != null ) return;

            SaveCounter( "LINKS" );
            HttpContext.Current.Session[key] = 1;
        }

        public static void CountTOP()
        {
            if ( Tools.IsFriendAddress() ) return;
            
            const string key = "CNT$TOP";
            if ( HttpContext.Current.Session[key] != null ) return;
            
            SaveCounter( "TOP" );
            HttpContext.Current.Session[key] = 1;
        }

        public static void CountAbout()
        {
            if ( Tools.IsFriendAddress() ) return;
            
            const string key = "CNT$HELP";
            if ( HttpContext.Current.Session[key] != null ) return;

            SaveCounter( "HELP" );
            HttpContext.Current.Session[key] = 1;
        }

        public static void CountOrders()
        {
            if ( Tools.IsFriendAddress() ) return;

            const string key = "CNT$ORDER";
            if ( HttpContext.Current.Session[key] != null ) return;

            SaveCounter( "ORDER" );
            HttpContext.Current.Session[key] = 1;
        }
    }
}
