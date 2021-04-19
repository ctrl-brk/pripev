using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Linq;

namespace Pripev.Exception
{
    public static class ExceptionManager
    {
        private static void PopulateDbData( System.Exception e, Int64? nId, SqlConnection conn )
        {
            foreach ( var cmd in from DictionaryEntry de in e.Data select "exec PutExceptionData @ExceptionId=" + nId + ",@DataKey=" + Utils.Convert.ToSQLString( de.Key ) + ",@DataValue=" + Utils.Convert.ToSQLString( de.Value ) into sql select new SqlCommand( sql, conn ) )
                cmd.ExecuteNonQuery();
        }

        private static Int64? PopulateDB( System.Exception e, Int64? nParentId, string sCustomInfo )
        {
            Int64? ret;

            using ( var conn = new SqlConnection( ConfigurationManager.ConnectionStrings["webdb"].ToString() ) )
            {
                conn.Open();

                var sql = "exec PutException @Message=" + Utils.Convert.ToSQLString( e.Message ) + ",@Source=" + Utils.Convert.ToSQLString( e.Source ) + ",@HelpLink=" + Utils.Convert.ToSQLString( e.HelpLink ) + ",@StackTrace=" + Utils.Convert.ToSQLString( e.StackTrace ) + ",@TargetSite=" + Utils.Convert.ToSQLString( e.TargetSite.ToString() ) + ",@CustomInfo=" + Utils.Convert.ToSQLString( sCustomInfo );

                if ( nParentId != null ) sql += ",@ParentExceptionId=" + nParentId;

                var cmd = new SqlCommand( sql, conn );
                ret = Convert.ToInt64( cmd.ExecuteScalar() );

                PopulateDbData( e, ret, conn );
                conn.Close();
            }

            return (ret);
        }

        private static void PopulateThread( System.Exception e, string sCustomInfo )
        {
            try
            {
                var nExcId = PopulateDB( e, null, sCustomInfo );
                var e1 = e;
                while ( e1.InnerException != null )
                {
                    nExcId = PopulateDB( e, nExcId, null );
                    e1 = e.InnerException;
                }
            }
            catch {}
        }

        public static void Populate( System.Exception e )
        {
            PopulateThread( e, null );
        }

        public static void Populate( System.Exception e, string sCustomInfo )
        {
            PopulateThread( e, sCustomInfo );
        }

    }
}
