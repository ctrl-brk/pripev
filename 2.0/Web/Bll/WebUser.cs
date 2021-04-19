// ReSharper disable UnusedMember.Global
using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using Pripev.DAL;

namespace Pripev.BLL
{

    #region // Enums

    public enum WebUserStatus
    {
        Unknown,
        Active = 'A',
        Banned = 'B',
        Hold = 'H',
        Inactive = 'N',
        Waiting = 'W'
    }

    public enum WebUserType
    {
        Unknown,
        Admin = 'A',
        Manager = 'M',
        User = 'U'
    }

    #endregion

    #region // WebUserSession

    [Serializable]
    public struct WebUserSession
    {
        private WebUser _user;

        public WebUserSession( int userId, String sessionId ) : this()
        {
            UserId = userId;
            SessionId = sessionId;
            _user = null;
        }

        public int UserId { get; private set; }

        public String SessionId { get; private set; }

        public String Name
        {
            get
            {
                if ( _user == null ) _user = new WebUser( UserId );
                return (_user.Name);
            }
        }

        public String Email
        {
            get
            {
                if ( _user == null ) _user = new WebUser( UserId );
                return (_user.Email);
            }
        }
    }

    #endregion

    [Serializable]
    public class WebUser
    {
        public static WebUser CreateUser()
        {
            WebUser u;
            try
            {
                if ( HttpContext.Current.Session["CurrentUser"] != null )
                {
                    u = (WebUser)HttpContext.Current.Session["CurrentUser"];
                    u._inSession = true;
                    return (u);
                }
            }
            catch {}

            u = new WebUser();
            try
            {
                if ( !Utils.Web.Tools.IsRobot() )
                {
                    HttpContext.Current.Session["CurrentUser"] = u;
                    u._inSession = true;
                }
            }
            catch {}

            return (u);
        }

        public static bool IsFirstVisit
        {
            get { return (Request.Cookies["FirstVisit"] == null); }
        }

        private bool _bOrders, _bLocalOrders, _bAllOrders, _bShowAllOrders;
        private bool? _bMailList, _bHtmlEmail, _bEmailLinks;
        private Int16? _timeOffset;
        private String _sEmail, _sPassword;
        private WebUserStatus _Status;
        private WebUserType _Type;
        private bool _inSession;
        private bool _exInfoLoaded;

        private WebUser()
        {
            InitVars( false );
        }

        public WebUser( int userId )
        {
            InitVars( false );
            LoadUserData( DB.ExecuteDataRow( "exec GetWebUser @UserId=" + userId ) );
            Id = userId;
        }

        public WebUser( bool inError )
        {
            InitVars( inError );
        }

        public void Serialize()
        {
            if ( _inSession || Id == null ) return;
            try
            {
                HttpContext.Current.Session["CurrentUser"] = this;
            }
            catch {}
        }

        private void InitVars( bool inError )
        {
            Id = null;
            _bOrders = false;
            _bLocalOrders = false;
            _bAllOrders = false;
            _bShowAllOrders = true;
            _bMailList = _bHtmlEmail = _bEmailLinks = null;
            _timeOffset = null;
            _sEmail = String.Empty;
            _sPassword = String.Empty;
            Name = String.Empty;
            ErrorMessage = String.Empty;
            Alert = String.Empty;
            _Status = WebUserStatus.Unknown;
            _Type = WebUserType.Unknown;
            _inSession = false;
            _exInfoLoaded = false;

            if ( inError || !IsFirstVisit ) return;

// ReSharper disable PossibleNullReferenceException
            Response.Cookies["FirstVisit"].Value = "N";
            Response.Cookies["FirstVisit"].Expires = DateTime.Now.AddDays( 7 );
// ReSharper restore PossibleNullReferenceException
        }

        public void Logout()
        {
            HttpContext.Current.Application.Lock();
            try
            {
                var userList = (List<WebUserSession>)HttpContext.Current.Application["OnlineUsers"];
// ReSharper disable PossibleInvalidOperationException
                userList.Remove( new WebUserSession( Id.Value, HttpContext.Current.Session.SessionID ) );
// ReSharper restore PossibleInvalidOperationException
            }
            catch {}
            finally
            {
                HttpContext.Current.Application.UnLock();
            }
            // ReSharper disable PossibleNullReferenceException
            Response.Cookies["UserGUID"].Value = String.Empty;
            Response.Cookies["UserGUID"].Expires = DateTime.Now.AddDays( -1 );
            // ReSharper restore PossibleNullReferenceException
            InitVars( false );
        }

        public bool Login()
        {
            if ( bLoggedIn ) return (true);

            if ( String.IsNullOrEmpty( _sEmail ) || String.IsNullOrEmpty( _sPassword ) )
            {
                ErrorMessage = "Пустой email или пароль";
                return (false);
            }

            var dr = DB.ExecuteDataRow( "exec UserLogin @Email=" + Utils.Convert.ToSQLString( _sEmail ) + ",@Password=" + Utils.Convert.ToSQLString( _sPassword ) + ",@IP='" + Request.ServerVariables["REMOTE_ADDR"] + "'" );
            if ( dr["UserId"] != DBNull.Value )
            {
                LoadUserData( dr );

                if ( !String.IsNullOrEmpty( Alert ) )
                    Utils.Email.AdminMail( "Опасный пользователь!", "Опасный пользователь:\n" + Alert + "\nId=" + Id + "\nEmail=" + _sEmail + "\nIP=" + Request.ServerVariables["REMOTE_ADDR"] + "\nDate: " + DateTime.Now );

                // ReSharper disable PossibleNullReferenceException
                var bCookie = false;
                try
                {
                    var g = new Guid( Request.Cookies["UserGUID"].Value );
                    if ( g != Guid.Empty ) bCookie = true;
                }
                catch {}
                if ( !bCookie )
                {
                    Response.Cookies["UserGUID"].Value = GUID.ToString();
                    Response.Cookies["UserGUID"].Expires = DateTime.Now.AddYears( 1 );
                }
                // ReSharper restore PossibleNullReferenceException

                HttpContext.Current.Application.Lock();
                var userList = (List<WebUserSession>)HttpContext.Current.Application["OnlineUsers"];
// ReSharper disable PossibleInvalidOperationException
                userList.Add( new WebUserSession( Id.Value, HttpContext.Current.Session.SessionID ) );
// ReSharper restore PossibleInvalidOperationException
                HttpContext.Current.Application.UnLock();

                return (true);
            }

            ErrorMessage = "Неверный email или пароль";
            return (false);
        }

        public bool Login( String email, String password )
        {
            _sEmail = email.Trim();
            _sPassword = password.Trim();
            return (Login());
        }

        public bool ConfirmLogin( Guid guid )
        {
            DataRow dr;

            try
            {
                dr = DB.ExecuteDataRow( "exec ConfirmWebUser @GUID='" + guid + "',@IP='" + Request.ServerVariables["REMOTE_ADDR"] + "'" );
            }
            catch ( Exception )
            {
                return (false);
            }

            if ( dr != null )
            {
                Logout();
                Login( dr["Email"].ToString(), dr["Password"].ToString() );
                Utils.Email.AdminMail( "Подтверждение регистрации пользователя", "Email: " + _sEmail + "\nComments: " + dr["Comments"] );
                return (true);
            }

            return (false);
        }

        public void LoginFromCookie()
        {
            var guid = Guid.Empty;

            try
            {
// ReSharper disable PossibleNullReferenceException
                if ( Request.Cookies["UserGUID"] != null )
                    guid = new Guid( Request.Cookies["UserGUID"].Value );
// ReSharper restore PossibleNullReferenceException
            }
            catch {}

            if ( guid == Guid.Empty ) return;

            var dr = DB.ExecuteDataRow( "exec UserLogin @UserGUID=" + Utils.Convert.ToSQLString( guid ) + ",@IP='" + Request.ServerVariables["REMOTE_ADDR"] + "'" );
            if ( dr == null || dr["UserId"] == DBNull.Value ) return;

            LoadUserData( dr );
            HttpContext.Current.Application.Lock();
            var userList = (List<WebUserSession>)HttpContext.Current.Application["OnlineUsers"];
// ReSharper disable PossibleInvalidOperationException
            userList.Add( new WebUserSession( Id.Value, HttpContext.Current.Session.SessionID ) );
// ReSharper restore PossibleInvalidOperationException
            HttpContext.Current.Application.UnLock();

            if ( !String.IsNullOrEmpty( Alert ) )
                Utils.Email.AdminMail( "Опасный пользователь!", "Опасный пользователь:\n" + Alert + "\nId=" + Id + "\nEmail=" + _sEmail + "\nIP=" + Request.ServerVariables["REMOTE_ADDR"] + "\nDate: " + DateTime.Now );
        }

        private void LoadUserData( DataRow dr )
        {
            Id = Convert.ToInt32( dr["UserId"] );
            var dr1 = DB.ExecuteDataRow( "exec GetWebUser @UserId=" + Id );

            _sEmail = dr1["Email"].ToString();
            Alert = dr["Alert"].ToString();
            _Status = (WebUserStatus)(Convert.ToChar( dr1["Status"] ));
            _Type = (WebUserType)(Convert.ToChar( dr1["UserType"] ));
            _bOrders = dr1["OrdersEnabled"].ToString() == "Y";
            _bLocalOrders = dr1["LocalOrdersFlag"].ToString() == "Y";
            _bAllOrders = dr1["AllOrdersFlag"].ToString() == "Y";
            Name = dr1["Name"].ToString();
            GUID = new Guid( dr1["GUID"].ToString() );
        }

        private void LoadExtendedUserData()
        {
            if ( Id == null || _exInfoLoaded ) return;

            var dr = DB.ExecuteDataRow( "exec GetWebUser @UserId=" + Id );

            _bMailList = dr["MailList"].ToString() == "Y";
            _bHtmlEmail = dr["EmailFormat"].ToString() == "H";
            _bEmailLinks = dr["EmailLinks"].ToString() == "Y";
            _timeOffset = Convert.ToInt16( dr["TimeOffset"] );

            _exInfoLoaded = true;
        }

        public int? Id { get; private set; }

        public Guid GUID { get; private set; }

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
        public string ErrorMessage { get; private set; }
// ReSharper restore UnusedAutoPropertyAccessor.Global
// ReSharper restore MemberCanBePrivate.Global

        public bool bLoggedIn
        {
            get { return (Id != null && bActive); }
        }

        public bool bRegistered
        {
            get { return (Id != null); }
        }

        public WebUserStatus Status
        {
            get { return (_Status); }
            set { _Status = value; }
        }

        public String StatusDescription
        {
            get
            {
                if ( _Status != WebUserStatus.Unknown )
                {
                    var dr = DB.ExecuteDataRow( "exec GetWebUserStatusTbl @Status='" + _Status + "'" );
                    return (dr["Description"].ToString());
                }

                return ("Неизвестен");
            }
        }

        public bool bActive
        {
            get { return (Id != null && _Status == WebUserStatus.Active); }
        }

        public bool bAdmin
        {
            get { return (bLoggedIn && _Type == WebUserType.Admin); }
        }

        public bool bManager
        {
            get { return (bLoggedIn && (_Type == WebUserType.Admin || _Type == WebUserType.Manager)); }
        }

        public bool bDangerous
        {
            get { return (!String.IsNullOrEmpty( Alert )); }
        }

        public String Alert { get; private set; }

        public bool bOrdersEnabled
        {
            get { return (_bOrders); }
            set { _bOrders = value; }
        }

        public bool bLocalOrders
        {
            get { return (_bLocalOrders); }
            set { _bLocalOrders = value; }
        }

        public bool bAllOrders
        {
            get { return (_bAllOrders); }
            set { _bAllOrders = value; }
        }

        public bool? MailList
        {
            get
            {
                if ( _bMailList == null ) LoadExtendedUserData();
                return (_bMailList);
            }
            set { _bMailList = value; }
        }

        public bool? HtmlEmail
        {
            get
            {
                if ( _bHtmlEmail == null ) LoadExtendedUserData();
                return (_bHtmlEmail);
            }
            set { _bHtmlEmail = value; }
        }

        public bool? EmailLinks
        {
            get
            {
                if ( _bEmailLinks == null ) LoadExtendedUserData();
                return (_bEmailLinks);
            }
            set { _bEmailLinks = value; }
        }

        public Int16 TimeOffset
        {
            get
            {
                if ( _timeOffset == null ) LoadExtendedUserData();
                // ReSharper disable PossibleNullReferenceException
                // ReSharper disable PossibleInvalidOperationException
                return ((Int16)_timeOffset);
                // ReSharper restore PossibleInvalidOperationException
                // ReSharper restore PossibleNullReferenceException
            }
            set { _timeOffset = value; }
        }

        public bool ShowAllOrders
        {
            get { return (bAllOrders && _bShowAllOrders); }
            set { _bShowAllOrders = value; }
        }

        public String Email
        {
            get { return (_sEmail); }
            set { _sEmail = value; }
        }

        public String Password
        {
            get { return (_sPassword); }
            set { _sPassword = value; }
        }

        public String Name { get; private set; }

        public String ChatName
        {
            get { return (String.IsNullOrEmpty( Name ) ? "Гость" : Name); }
        }

        public String HomePage
        {
            get
            {
                if ( bActive ) return ("/User/OrdersProgress.aspx");
                return bRegistered ? ("/User/Login.aspx") : ("/");
            }
        }

        public DateTime LocalDateTime( DateTime d )
        {
            return (d.AddMinutes( TimeOffset ));
        }

        private static HttpRequest Request
        {
            get { return (HttpContext.Current.Request); }
        }

        private static HttpResponse Response
        {
            get { return (HttpContext.Current.Response); }
        }
    }
}
// ReSharper restore UnusedMember.Global
