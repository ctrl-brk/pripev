using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Caching;

namespace Pripev.DAL.Web
{
    public class DB : DAL.DB
    {
        public static DataTable ExecuteDataTable( string sql, Cache cache, string cacheKey )
        {
            if ( cache != null && !String.IsNullOrEmpty( cacheKey ) && cache[cacheKey] != null )
            {
                return ((DataTable)cache[cacheKey]);
            }

            var cmd = new SqlCommand( sql );
            var tbl = ExecuteDataTable( sql );
            if ( cache != null && !String.IsNullOrEmpty( cacheKey ) ) cache.Insert( cacheKey, tbl, new SqlCacheDependency( cmd ) );

            return (tbl);
        }
    }
}
