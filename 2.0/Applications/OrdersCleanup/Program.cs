using System;
using System.Data;
using System.IO;
using Pripev.DAL;
using log4net;
using log4net.Config;

namespace Pripev.App.OrdersCleanup
{
    class Program 
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program).FullName);
        private static int _filesDeleted, _foldersDeleted;

        static void Main()
        {
            try
            {
                XmlConfigurator.Configure();
                DeleteOrders();
                Log.InfoFormat("Deleted {0} files, {1} folders", _filesDeleted, _foldersDeleted);
            }
            catch ( Exception e )
            {
                var msg = String.Format("{0}\r\n\t\t--------------------\r\n\t\t{1}\r\n\t\t--------------------", e.Message, e.StackTrace);
                Log.Error( msg );
                Utils.Email.ErrorMail( "Ошибка удаления заказа", msg, false );
            }
        }

        static void DeleteOrders()
        {
            var dt = DB.ExecuteDataTable("exec usp_GetOrdersToDelete"); // @IncludeDeleted='Y'

            foreach ( DataRow dr in dt.Rows )
            {
                DeleteFiles( dr );
                DB.ExecuteNonQuery( "exec usp_DeleteOrder @OrderId=" + dr["ORDER_ID"] + ",@ModifiedBy=1" );
            }
        }

        static void DeleteFiles( DataRow dr )
        {
            var path = dr["ExternalLink"].ToString().Replace( Utils.Registry.GetString( "Orders\\Server" ), Utils.Registry.GetString( "Orders\\Path" ) );
            if ( path.StartsWith( "http:" ) ) return; // skip external (rapidshare, etc.)

            var fi = new FileInfo( path );

            if ( fi.Exists )
            {
                _filesDeleted++;
                Log.InfoFormat( "Deleting file {0}", fi.FullName );
                fi.Attributes = FileAttributes.Normal;
                fi.Delete();
            }
            else
                Log.WarnFormat("File not found: {0}", fi.FullName);

            var di = fi.Directory;
            while(true)
            {
                if (!DeleteFolder(di))
                    return;
// ReSharper disable PossibleNullReferenceException
                di = di.Parent;
// ReSharper restore PossibleNullReferenceException
            }
        }

        /// <summary>
        /// Deletes folder if it's empty and doesn't have .doNotDelete file
        /// </summary>
        /// <param name="di">Directory to delete</param>
        /// <returns></returns>
        static bool DeleteFolder( DirectoryInfo di )
        {
            if (!di.Exists || di.GetFiles().Length > 0 || di.GetDirectories().Length > 0 )
                return false;

            _foldersDeleted++;
            Log.InfoFormat("Deleting folder {0}", di.FullName);
            di.Delete();

            return (true);
        }
    }
}
