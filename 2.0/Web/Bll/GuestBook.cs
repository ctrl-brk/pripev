using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;

namespace Pripev.BLL
{
   public class GuestBook : List<GuestBookRecord>
   {
      private int _totalCount = 0;
      private bool _showAllPages = false;
      private int _pageSize = 10;
      private int _pg = 1;
      private int _maxPage = 1;

      public GuestBook()
      {
         LoadData();
      }

      public GuestBook( int pg, int pageSize, bool showAllPages )
      {
         _pg = pg;
         _pageSize = pageSize;
         _showAllPages = showAllPages;
         LoadData();
      }

      private void LoadData()
      {
         DataTable dt = DAL.DB.ExecuteDataTable( "exec GetOpinions @Pg=" + _pg.ToString() + ",@RecsPerPage=" + _pageSize.ToString() + ",@AllPages=" + Utils.Convert.ToSQLString( _showAllPages ) );

         if( dt.Rows.Count > 0 )
         {
            _totalCount = Convert.ToInt32( dt.Rows[0]["TotalCount"] );
            if( !_showAllPages && _totalCount > _pageSize )
            {
               _maxPage = _totalCount / _pageSize;
               if( _totalCount % _pageSize > 0 ) _maxPage++;
            }
         }
         foreach( DataRow dr in dt.Rows ) this.Add( new GuestBookRecord( dr ) );
      }

      public int TotalCount
      {
         get { return ( _totalCount ); }
      }

      public int CurrentPage
      {
         get { return ( _pg ); }
         set { if( value > 0 && _pg <= _maxPage ) _pg = value; }
      }

      public int PageSize
      {
         get { return ( _pageSize ); }
         set { if ( value > 0 ) _pageSize = value; }
      }

      public bool ShowAllPages
      {
         get { return( _showAllPages ); }
         set { _showAllPages = value; }
      }
   }

   public class GuestBookRecord
   {
      private int? _id;
      private String _date, _userName, _userEmail, _text;

      public GuestBookRecord( DataRow dr )
      {
         _id = Convert.ToInt32( dr["MESSAGE_ID"] );
         _date = dr["REC_DATE"].ToString();
         _userName = dr["NAME"].ToString();
         _userEmail = dr["E_MAIL"].ToString();
         _text = dr["TEXT"].ToString();
      }

      public GuestBookRecord() { }

      public void Save()
      {
         _id = System.Convert.ToInt32( DAL.DB.ExecuteScalar( "exec PutOpinion @Id=" + Utils.Convert.ToSQL( _id ) +
                                                                            ",@Name=" + Utils.Convert.ToSQLString( _userName ) +
                                                                            ",@Email=" + Utils.Convert.ToSQLString( _userEmail ) +
                                                                            ",@Text=" + Utils.Convert.ToSQLString( _text ) ) );
      }

      public int? Id
      {
         get { return ( _id ); }
         set { _id = value; }
      }

      public string Date
      {
         get { return ( _date ); }
      }

      public string UserName
      {
         get { return ( _userName ); }
         set { _userName = value; }
      }

      public string UserNameHtml
      {
         get { return ( HttpContext.Current.Server.HtmlEncode( _userName ) ); }
      }

      public string UserEmail
      {
         get { return ( _userEmail ); }
         set { _userEmail = value; }
      }

      public string UserEmailHtml
      {
         get { return ( HttpContext.Current.Server.HtmlEncode( _userEmail ) ); }
      }

      public string Text
      {
         get { return ( _text ); }
         set { _text = value; }
      }

      public string TextHtml
      {
         get { return ( HttpContext.Current.Server.HtmlEncode( _text ).Replace( 
                       "$AdmCmtS$", "<hr class='HR'><font class='AdminComment'><b><u>Комментарий Админа</u>:</b><br>" ).Replace( "$AdmCmtE$", "</font>" ) ); }
      }
   }
}
