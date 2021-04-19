using System;

namespace Pripev.Utils
{
   public static class Extensions
   {
      #region // SQL helpers
      /// <summary>
      /// Checks for null and DBNull
      /// </summary>
      /// <param name="src">Object to check</param>
      /// <returns>Boolean</returns>
      private static bool IsNull( Object src )
      {
         return ( src == null || src == DBNull.Value || src.ToString() == String.Empty );
      }

      /// <summary>
      /// Returns "null" or string with dangerous characters replaced
      /// </summary>
      /// <param name="value">String to check</param>
      /// <returns>String</returns>
      public static String ToSQL( this String value )
      {
         if ( value == null || value.IsNullOrEmptyChars() )
            return ( "null" );
    
         return ( "'" + value.SQLCleanup() + "'" );
      }

      /// <summary>
      /// Returns "null" or value.ToString()
      /// </summary>
      /// <param name="value">Value to convert</param>
      /// <returns>String</returns>
      public static String ToSQL( this Int32? value )
      {
         return ( value == null ? "null" : value.ToString() );
      }

      /// <summary>
      /// Returns "0" (in case of null or false) or "1"
      /// </summary>
      /// <param name="value">Value to convert</param>
      /// <returns>String</returns>
      public static String ToSQL( this bool? value )
      {
         return ( value == true ? "1" : "0" );
      }

      /// <summary>
      /// Converts bool? to sql string. Returns either "null" or "1" or "0"
      /// </summary>
      /// <param name="value">Value to convert</param>
      /// <param name="treatFalseAsNull">Returns "0" or "null" respectively</param>
      /// <returns>String</returns>
      public static String ToSQL(this bool? value, bool treatFalseAsNull)
      {
         return ( value == true ? "1" : ( treatFalseAsNull ? "null" : "0" ) );
      }

      /// <summary>
      /// Converts bool? to sql string (null, 'Y', 'N')
      /// </summary>
      /// <param name="value">Value to convert</param>
      /// <returns>String</returns>
      public static String ToSQLString( this bool? value )
      {
         return ( value == true ? "'Y'" : "'N'" );
      }

      /// <summary>
      /// Converts DateTime? to sql string. Returns either 'yyyy-MM-dd' or "null"
      /// </summary>
      /// <param name="value">Value to convert</param>
      /// <returns>String</returns>
      public static string ToSQL( this DateTime? value )
      {
         if ( IsNull( value ) ) return ( "null" );
         return ( "'" + ( (DateTime)value ).ToString( "yyyy-MM-dd" ) + "'" );
      }
      #endregion

      #region // Convert helpers

      /// <summary>
      /// Trims white space characters
      /// </summary>
      /// <param name="value">Value to trim</param>
      /// <returns>String</returns>
      private static String TrimSpecialChars( this String value )
      {
         if ( value == null )
            return ( null );
         return ( value.Trim( new[] { ' ', '\r', '\n', '\t' } ) );
      }

      /// <summary>
      /// Removes white space characters and returns String.IsNullOrEmpty
      /// </summary>
      /// <param name="value">Value to analyze</param>
      /// <returns>String</returns>
      private static bool IsNullOrEmptyChars( this String value )
      {
         return ( String.IsNullOrEmpty( value.TrimSpecialChars() ) );
      }

      /// <summary>
      /// Replaces "'" with "''"
      /// </summary>
      /// <param name="value">Value to replace</param>
      /// <returns>String</returns>
      private static String SQLCleanup( this String value )
      {
         return ( value == null ? value : value.Replace( "'", "''" ) );
      }

      /// <summary>
      /// Converts string to Int32?
      /// </summary>
      /// <param name="value">Value to convert</param>
      /// <returns>Int32?</returns>
      public static Int32? ToInt32( this String value )
      {
         return ( value.IsNullOrEmptyChars() ? null : Convert.ToInt32( value ) );
      }

      /// <summary>
      /// Converts string to Int16?
      /// </summary>
      /// <param name="value">Value to convert</param>
      /// <returns>Int16?</returns>
      public static Int16? ToInt16( this String value )
      {
         return ( value.IsNullOrEmptyChars() ? null : Convert.ToInt16( value ) );
      }

      #endregion
   }
}
