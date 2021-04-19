using System;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Pripev.Utils
{
    public static class Registry
    {
        /// <summary>
        /// Returns SOFTWARE\Pripev.ru\key as an object
        /// </summary>
        /// <param name="key">Key name</param>
        /// <returns>Object</returns>
        public static Object GetValue( String key )
        {
            var hklm = Microsoft.Win32.Registry.LocalMachine;
            var subKey = "SOFTWARE\\Pripev.ru\\";
            var val = key.Replace( '/', '\\' );
            var arr = val.Split( new[] {'\\'} );
            if ( arr.Length > 1 )
            {
                subKey += String.Join( "\\", arr, 0, arr.Length - 1 );
                val = arr[arr.Length - 1];
            }
            hklm = hklm.OpenSubKey( subKey );
            return (hklm == null ? null : hklm.GetValue( val ));
        }

        /// <summary>
        /// Returns SOFTWARE\Pripev.ru\key as a String
        /// </summary>
        /// <param name="key">Key name</param>
        /// <returns>String</returns>
        public static String GetString( String key )
        {
            return (GetValue( key ).ToString());
        }

        /// <summary>
        /// Returns SOFTWARE\Pripev.ru\key as an int
        /// </summary>
        /// <param name="key">Key name</param>
        /// <returns>int</returns>

        public static int GetNumber( String key )
        {
            return (System.Convert.ToInt32( GetValue( key ) ));
        }

        /// <summary>
        /// Returns SOFTWARE\Pripev.ru\key as a boolean
        /// </summary>
        /// <param name="key">Key name</param>
        /// <returns>Boolean</returns>
        public static bool GetBoolean( String key )
        {
            return (System.Convert.ToInt32( GetValue( key ) ) != 0);
        }
    }
}
