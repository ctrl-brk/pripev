using System;
using System.Text;
using System.Configuration;

namespace Pripev.Utils
{
    public class Tools
    {
        /// <summary>
        /// GUID with '-' removed
        /// </summary>
        public static String GUID
        {
            get { return (Guid.NewGuid().ToString().ToUpper().Replace( "-", "" )); }
        }

        /// <summary>
        /// Replaces prohibited file name characters with underscore.
        /// </summary>
        /// <param name="fileName">String to replace</param>
        /// <returns>String</returns>
        public static String EnsureFileName( String fileName )
        {
            const char repChar = '_';
            var repArr = new[] {'/', '\\', ':', '?', '*'};
            var sb = new StringBuilder( fileName );

            foreach ( var c in repArr )
                sb.Replace( c, repChar );

            return (sb.ToString());
        }

        /// <summary>
        /// Returns ConfigurationManager.AppSettings[key]
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>String</returns>
        public static String GetAppSetting( String key )
        {
            return (ConfigurationManager.AppSettings[key]);
        }
    }
}
