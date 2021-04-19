using System;
using System.Web;
using System.IO;

namespace Pripev.Utils.Web
{
    public class IO
    {
        public static String ReadFile( String file, bool exec )
        {
            return (File.ReadAllText( HttpContext.Current.Request.MapPath( file ) ));
        }

        public static String ReadFile( String file )
        {
            return (ReadFile( file, false ));
        }
    }
}
