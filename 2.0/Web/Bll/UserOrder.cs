using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pripev.BLL
{
   public class UserOrderList : List<UserOrder>
   {
      private WebUser _user = null;
      private bool? _activeFlag = true, _allOrders = false;
      private int? _historyDays = null;

      public UserOrderList() : base(100) {}

      public UserOrderList( WebUser u ) : base( 100 )
      {
         if( u.Id == null ) return;
         _user = u;
         LoadData();
      }

      public UserOrderList( WebUser u, bool? activeFlag, int? historyDays, bool? allOrders ) : base( 100 )
      {
         if( u.Id == null ) return;
         _user = u;
         _activeFlag = activeFlag;
         _historyDays = historyDays;
         _allOrders = allOrders;
         LoadData();
      }

      private void LoadData()
      {
         DataTable dt = DAL.DB.ExecuteDataTable( "exec GetUserOrders @UserId=" + _user.Id.ToString() +
                                                                   ",@ActiveFlag=" + Utils.Convert.ToSQLString( _activeFlag ) +
                                                                   ",@History=" + Utils.Convert.ToSQL( _historyDays ) +
                                                                   ",@OtherUsersFlag=" + Utils.Convert.ToSQLString( _allOrders ) );

         foreach( DataRow dr in dt.Rows )
         {
            Add( new UserOrder( dr ) );
         }
      }
   }

   public class UserOrder
   {
      private int? _id, _userId, _soundId;
      private String _userName, _userEmail;
      DateTime? _userDate, _orderDate;
      private String _artistName, _albumName, _songName, _comments;
      private bool _isReady, _isNotified, _isActive, _isDirect;
      private String _externalLink;

      public UserOrder( int? id )
      {
         InitVars();
         _id = id;
         if( _id != null ) LoadData();
      }

      public UserOrder( DataRow dr )
      {
         InitVars();
         LoadData2( dr );
      }

      private void InitVars()
      {
         _id = _userId = _soundId = null;
         _userName = _userEmail = null;
         _userDate = _orderDate = null;
         _artistName = _albumName = _songName = _comments = null;
         _isReady = _isNotified = _isActive = _isDirect = false;
      }

      private void LoadData( DataRow dr )
      {
         _userId = Utils.Convert.ToInt32( dr["UserId"] );
         _userName = dr["UserName"].ToString();
         _userEmail = dr["UserEmail"].ToString();
         _orderDate = Convert.ToDateTime( dr["DATE"] );
         _userDate = Convert.ToDateTime( dr["UserDate"] );
         _artistName = dr["ARTIST"].ToString();
         _albumName = dr["ALBUM"].ToString();
         _songName = dr["SONG"].ToString();
         _isReady = Convert.ToInt16( dr["STATUS"] ) == 1;
         _isNotified = Convert.ToInt16( dr["NOTIFY"] ) == 1;
         _soundId = Utils.Convert.ToInt32( dr["SOUND_ID"] );
         _isActive = dr["Active"].ToString() == "Y";
         _isDirect = dr["DirectFlag"].ToString() == "Y";
         _comments = dr["Comments"].ToString();
         _externalLink = dr["ExternalLink"].ToString();
      }

      private void LoadData2( DataRow dr )
      {
         _id = Utils.Convert.ToInt32( dr["OrderId"] );
         _orderDate = Convert.ToDateTime( dr["Date"] );
         _artistName = dr["ArtistName"].ToString();
         _albumName = dr["AlbumName"].ToString();
         _songName = dr["SongName"].ToString();
         _isReady = Convert.ToInt16( dr["Status"] ) == 1;
         _isDirect = dr["DirectFlag"].ToString() == "Y";
         _isActive = dr["Active"].ToString() == "Y";
         _externalLink = dr["ExternalLink"].ToString();
      }

      private void LoadData()
      {
         DataRow dr = DAL.DB.ExecuteDataRow( "exec GetUserOrder @OrderId=" + _id.ToString() );
         if ( dr == null )
         {
            _id = null;
            return;
         }
         LoadData( dr );
      }

      public static void DeleteOrder( int orderId, int userId )
      {
         DAL.DB.ExecuteNonQuery( "exec DelUserOrder @OrderId=" + orderId.ToString() + ",@ModifiedBy=" + userId.ToString() );
      }

      public int? Id
      {
         get { return ( _id ); }
      }

      public int? UserId
      {
         get { return ( _userId ); }
      }

      public DateTime? OrderDate
      {
         get { return ( _orderDate ); }
      }

      public bool? IsReady
      {
         get { return ( _isReady || _isDirect ); }
      }

      public bool? IsActive
      {
         get { return ( _isActive ); }
      }

      public bool? IsDirect
      {
         get { return ( _isDirect ); }
      }

      public String ArtistName
      {
         get { return ( _artistName ); }
         set { _artistName = value; }
      }

      public String AlbumName
      {
         get { return ( _albumName ); }
         set { _albumName = value; }
      }

      public String SongName
      {
         get { return ( _songName ); }
         set { _songName = value; }
      }

      public String Comments
      {
         get { return ( _comments ); }
         set { _comments = value; }
      }

      public String DirectPath
      {
         get
         {
            if( !_isDirect ) return ( null );
            String[] arr = _externalLink.Replace( "http://orders.pripev.net/", String.Empty ).Split( new char[] {'/'} );
            return ( String.Join( "/", arr, 1, arr.Length - 1 ) );
         }
      }

      public String IconHtml
      {
         get
         {
         if ( IsReady == true ) return( "<a href=\"" + _externalLink + "\"><img src='/Images/OrderReady.gif' title='Найден' border='0'></a>" );
         else return( "<img src='/Images/Wanted.gif' title='Ищется'>" );
         }
      }
   
   }
}
