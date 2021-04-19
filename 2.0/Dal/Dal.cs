using System.Data;
using System.Data.SqlClient;
using System.Text;
using Pripev.Exception;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Local

namespace Pripev.DAL
{
    public class DBException : System.Exception
    {

        public DBException() {}
        public DBException( string sMsg ) : base( sMsg ) {}
#if DEBUG
      public DBException( string sMsg, string sDebugData ) : base( sMsg + "\r\n" + sDebugData ) { }
#else
        public DBException( string sMsg, string sDebugData ) : base( sMsg ) {}
#endif
    }

    public class DB
    {
        private static SqlConnection OpenConnection()
        {
            SqlConnection conn;

            try
            {
                conn = new SqlConnection( Utils.Registry.GetString( "DSN" ) );
                conn.Open();
            }
            catch ( System.Exception e )
            {
                ExceptionManager.Populate( e );
                throw (new DBException( e.Message ));
            }
            return (conn);
        }

        public static DataTable ExecuteDataTable( string sql )
        {
            var tbl = new DataTable();
            using ( var conn = OpenConnection() )
            {
                try
                {
                    var da = new SqlDataAdapter( sql, conn );
                    da.Fill( tbl );
                }
                catch ( System.Exception e )
                {
                    ExceptionManager.Populate( e, sql );
                    throw (new DBException( e.Message, sql ));
                }
                finally
                {
                    conn.Close();
                }
            }
            return (tbl);
        }

        public static DataTable ExecuteDataTable( StringBuilder sql )
        {
            return (ExecuteDataTable( sql.ToString() ));
        }

        public static DataRow ExecuteDataRow( string sql )
        {
            var dt = ExecuteDataTable( sql );
            return (dt.Rows.Count > 0 ? dt.Rows[0] : null);
        }

        public static DataRow ExecuteDataRow( StringBuilder sql )
        {
            return (ExecuteDataRow( sql.ToString() ));
        }

        public static void ExecuteNonQuery( string sql )
        {
            using ( var conn = OpenConnection() )
            {
                try
                {
                    var cmd = new SqlCommand( sql, conn );
                    cmd.ExecuteNonQuery();
                }
                catch ( System.Exception e )
                {
                    ExceptionManager.Populate( e, sql );
                    throw (new DBException( e.Message, sql ));
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void ExecuteNonQuery( StringBuilder sql )
        {
            ExecuteNonQuery( sql.ToString() );
        }

        public static object ExecuteScalar( string sql )
        {
            using ( var conn = OpenConnection() )
            {
                try
                {
                    var cmd = new SqlCommand( sql, conn );
                    return (cmd.ExecuteScalar());
                }
                catch ( System.Exception e )
                {
                    ExceptionManager.Populate( e, sql );
                    throw (new DBException( e.Message, sql ));
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static object ExecuteScalar( StringBuilder sql )
        {
            return (ExecuteScalar( sql.ToString() ));
        }
    }
}
