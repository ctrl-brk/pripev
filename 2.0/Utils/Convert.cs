using System;

namespace Pripev.Utils
{
   public static class Convert
   {
      #region // Private Methods

      private static string SQLCleanup(String s)
      {
         return (s.Replace("'", "''"));
      }

      private static bool IsNull(Object src)
      {
         return (src == null || src == DBNull.Value || src.ToString() == String.Empty);
      }

      #endregion

      #region // Public Methods

      /// <summary>
      /// Converts string to DateTime. If only year passed returns 1/1/year
      /// </summary>
      /// <param name="value"></param>
      /// <returns>DateTime</returns>
      public static DateTime ToDateTime( string value )
      {
         var ret = DateTime.MinValue;

         try { ret = System.Convert.ToDateTime( value ); }
         catch( FormatException ) {}
         if ( ret == DateTime.MinValue )
         {
            ret = new DateTime( System.Convert.ToInt32( value ), 1, 1 );
         }
         return ( ret );
      }

      /// <summary>
      /// Converts object to sql string. Replaces white space, returns "null" if string is empty.
      /// </summary>
      /// <param name="src">String to convert</param>
      /// <returns>String</returns>
      public static string ToSQL( Object src )
      {
         if ( src == null || src.ToString().Trim( new[] { ' ', '\r', '\n', '\t' } ) == String.Empty ) return ( "null" );
         return ( SQLCleanup( src.ToString() ) );
      }

      /// <summary>
      /// Converts bool? to sql string ( "1" or "0")
      /// </summary>
      /// <param name="src">Value to convert</param>
      /// <returns>String</returns>
      public static string ToSQL( bool? src )
      {
         return ( src == true ? "1" : "0" );
      }

      /// <summary>
      /// Converts DateTime? to sql string. Returns either "yyyy-MM-dd" or "null"
      /// </summary>
      /// <param name="src">Value to convert</param>
      /// <returns>String</returns>
      public static string ToSQL( DateTime? src )
      {
         return IsNull( src ) ? ( "null" ) : ( ( (DateTime)src ).ToString( "yyyy-MM-dd" ) );
      }

      /// <summary>
      /// Converts bool? to sql string. Returns either "null" or "1" or "0"
      /// </summary>
      /// <param name="src">Value to convert</param>
      /// <param name="treatFalseAsNull">Returns "0" or "null" respectively</param>
      /// <returns>String</returns>
      public static string ToSQL( bool? src, bool treatFalseAsNull )
      {
         return ( src == true ? "1" : ( treatFalseAsNull ? "null" : "0" ) );
      }

      /// <summary>
      /// Converts object to sql string. Treats src as DateTime or string (replaces dangerous characters)
      /// </summary>
      /// <param name="src">Object to convert</param>
      /// <returns>String</returns>
      public static string ToSQLString( Object src )
      {
         var s = ( src is DateTime? || src is DateTime ) ? ToSQL( (DateTime?)src ) : ToSQL( src );
         return ( s == "null" ? s : "'" + s + "'" );
      }

      /// <summary>
      /// Converts bool? to sql string (null/'Y'/'N')
      /// </summary>
      /// <param name="src">Value to convert</param>
      /// <returns>String</returns>
      public static string ToSQLString( bool? src )
      {
         if ( src == null ) return ( "null" );
         return ( src == true ? "'Y'" : "'N'" );
      }

      /// <summary>
      /// Converts object to bool?. Returns either null or true/false
      /// </summary>
      /// <param name="src">Value to convert</param>
      /// <returns>bool?</returns>
      public static bool? ToBoolean( Object src )
      {
         return( IsNull( src ) ? (bool?)null : System.Convert.ToBoolean( src ) );
      }

      /// <summary>
      /// Converts object to decimal?. Returns either null or value
      /// </summary>
      /// <param name="src">Value to convert</param>
      /// <returns>decimal?</returns>
      public static decimal? ToDecimal( Object src )
      {
         return( IsNull( src ) ? (decimal?)null : System.Convert.ToDecimal( src ) );
      }

      /// <summary>
      /// Converts object to Int16?. Returns either null or value
      /// </summary>
      /// <param name="src">Value to convert</param>
      /// <returns>Int16? (short?)</returns>
      public static Int16? ToInt16( Object src )
      {
         return( IsNull( src ) ? (Int16?)null : System.Convert.ToInt16( src ) );
      }

      /// <summary>
      /// Converts object to Int32?. Returns either null or value
      /// </summary>
      /// <param name="src">Value to convert</param>
      /// <returns>Int32? (int?)</returns>
      public static int? ToInt32( Object src )
      {
         return( IsNull( src ) ? (int?)null : System.Convert.ToInt32( src ) );
      }

      /// <summary>
      /// Converts object to DateTime. Returns DateTime.MinValue if object is null
      /// </summary>
      /// <param name="src">Object to convert</param>
      /// <returns>DateTime</returns>
      public static DateTime ToDateTime( Object src )
      {
         return( IsNull( src ) ? ( DateTime.MinValue ) : ( DateTime.Parse( src.ToString() ) ) );
      }

      /// <summary>
      /// Converts Object to string with zero value processing.
      /// Returns String.Empty if src.ToString() == "0". Otherwise src.ToString()
      /// </summary>
      /// <param name="src"></param>
      /// <returns>String.Empty if src.ToString() == "0". Otherwise src.ToString()</returns>
      public static String ToEmptyString( Object src )
      {
         return( ( src == null || src.ToString() == "0" ) ? String.Empty : src.ToString() );
      }

      /// <summary>
      /// Converts Object to string with zero value processing.
      /// Returns &amp;nbsp; if src.ToString().Trim == "0" or empty string. Otherwise src.ToString()
      /// </summary>
      /// <param name="src"></param>
      /// <returns>&amp;nbsp; if src.ToString().Trim == "0" or empty string. Otherwise src.ToString()</returns>
      public static String ToNBSPString( Object src )
      {
         return( ( src == null || src.ToString() == "0" || src.ToString().Trim() == String.Empty ) ? "&nbsp;" : src.ToString() );
      }

      /// <summary>
      /// Converts bool? to String.Empty/"Yes"/"No"
      /// </summary>
      /// <param name="src">Value to convert</param>
      /// <returns>String</returns>
      public static string ToFlag( bool? src )
      {
         if ( src == null ) return ( String.Empty );
         return ( src == true ? "Yes" : "No" );
      }

      /// <summary>
      /// Converts bool? to String.Empty/"Yes"/"No"
      /// </summary>
      /// <param name="src">Value to convert</param>
      /// <param name="strong">Treat null as "No"</param>
      /// <returns>String</returns>
      public static string ToFlag( bool? src, bool strong )
      {
         return( strong && src == null ? "No" : ToFlag( src ) );
      }

      /// <summary>
      /// Converts int? to String.Empty/"Yes"/"No"
      /// </summary>
      /// <param name="src">Value to convert</param>
      /// <returns>String</returns>
      public static string ToFlag( int? src )
      {
         if ( src == null ) return ( String.Empty );
         return ( src == 0 ? "No" : "Yes" );
      }

      /// <summary>
      /// Converts int? to String.Empty/"Yes"/"No"
      /// </summary>
      /// <param name="src">Value to convert</param>
      /// <param name="strong">Treat null as "No"</param>
      /// <returns></returns>
      public static string ToFlag( int? src, bool strong )
      {
         return( strong && src == null ? "No" : ToFlag( src ) );
      }
      #endregion
   }
}
