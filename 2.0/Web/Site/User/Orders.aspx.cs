using System;
using System.Web.UI.WebControls;
using Pripev.BLL;
using Pripev.DAL;
using Pripev.Web.UI.UserControls;
using System.IO;

namespace Pripev.Web.UI.User
{
    public partial class Orders : ExpiredWebPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if ( ScriptManager1.IsInAsyncPostBack ) return;

            CreateScripts();
            if ( IsPostBack ) return;

            Title = "*Заказ припевов";
            if ( Request["Dup"] == "Y" )
            {
                litMsg.Text = DupMsg;
                plhMsg.Visible = true;
            }
            else if ( Request["Err"] == "Y" )
            {
                litMsg.Text = ErrMsg;
                plhMsg.Visible = true;
            }
            else plhMsg.Visible = false;
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if ( ScriptManager1.IsInAsyncPostBack ) return;

            if ( !CurrentUser.bLoggedIn ) Response.Redirect( "/User/Login.aspx" );
            Counter.CountOrders();
            if ( !CurrentUser.bActive ) Response.Redirect( CurrentUser.HomePage );
            if ( !CurrentUser.bOrdersEnabled ) mvOrders.ActiveViewIndex = 1;
            else
            {
                litContact.Text = Utils.Web.Email.EmailLink( "ContactMail" );
                ShowOrders();
            }
        }

        private void CreateScripts()
        {
            ClientScript.RegisterClientScriptBlock( GetType(), "LB", @"<script language='javascript' type='text/javascript'>
function AlbumListBox()
{
   var obj = document.getElementById( '" + txtArtist.ClientID + @"' );
   if ( obj.value == '' )
      alert( 'Введите имя исполнителя' );
   else
      window.open( '/User/AlbumListBox.aspx?Artist=' + escape( obj.value ),'','directories=no,height=220,width=600,location=no,menubar=no,status=0,toolbar=no,resizable=yes,scrollbars=yes' );
}

function SongListBox()
{
   var art = document.getElementById( '" + txtArtist.ClientID + @"' );
   if ( art.value == '' )
      {
      alert( 'Введите имя исполнителя' );
      return;
      }

   var alb = document.getElementById( '" + txtAlbum.ClientID + @"' );
   if ( alb.value == '' )
      {
      alert( 'Введите название альбома' );
      return;
      }

   window.open( '/User/SongListBox.aspx?Artist=' + escape( art.value ) + '&Album=' + escape( alb.value ),'','directories=no,height=220,width=500,location=no,menubar=no,status=0,toolbar=no,resizable=yes,scrollbars=yes' );
}

function SetOrderArtist( sName ) {
document.getElementById( """ + txtArtist.ClientID + @""" ).value = sName;
}
function SetOrderAlbum( sName ) {
document.getElementById( """ + txtAlbum.ClientID + @""" ).value = sName;
}
function SetOrderSong( sName ) {
document.getElementById( """ + txtSong.ClientID + @""" ).value = sName;
}
</script>" );
        }

        private void PutOrder()
        {
            var dup = false;
            String msg = null;
            var sql = "exec PutUserOrder @UserId=" + CurrentUser.Id + ",@Artist=" + Utils.Convert.ToSQLString( txtArtist.Text ) + ",@Album=" + Utils.Convert.ToSQLString( txtAlbum.Text ) + ",@Song=" + Utils.Convert.ToSQLString( txtSong.Text ) + ",@IP=" + Utils.Convert.ToSQLString( Request.ServerVariables["REMOTE_ADDR"] ) + ",@Comments=" + Utils.Convert.ToSQLString( txtComment.Text );

            var dr = DB.ExecuteDataRow( sql );
            if ( dr["Msg"] != DBNull.Value )
            {
                msg = dr["Msg"].ToString();
                dup = msg == "Dup";
                litMsg.Text = msg;
                plhMsg.Visible = true;
            }
            else
                plhMsg.Visible = false;

            if ( String.IsNullOrEmpty( msg ) || dup )
                Response.Redirect( "/User/OrdersProgress.aspx" + (dup ? "?Dup=Y" : String.Empty) );
        }

        private void ShowOrders()
        {
            int? histDays = null;

            try
            {
                histDays = Utils.Convert.ToInt32( Request["Hst"] );
            }
            catch {}

            var lst = new UserOrderList( CurrentUser, true, histDays, false );
            rptUserOrders.DataSource = lst;
            rptUserOrders.DataBind();

            if ( CurrentUser.bAllOrders )
            {
                cbAllOrders.Checked = CurrentUser.ShowAllOrders;
                plhAllOrders.Visible = true;

                if ( CurrentUser.ShowAllOrders )
                {
                    var lst1 = new UserOrderList( CurrentUser, true, null, true );
                    rptAllOrders.DataSource = lst1;
                    rptAllOrders.DataBind();
                }
            }
            else plhAllOrders.Visible = false;
        }

        private static String DupMsg
        {
            get { return ("Указанная композиция уже была Вами заказана в прошлом. Если повторный заказ был ошибочным, то удалите его, нажав на крестик."); }
        }

        private String ErrMsg
        {
            get
            {
                var ret = Session["OrdersMsg"] == null ? "Похоже, что произошла какая-то ошибка. Просьба сообщить мне об этом." : Session["OrdersMsg"].ToString();
                Session["OrdersMsg"] = null;
                return (ret);
            }

            set { Session["OrdersMsg"] = value; }
        }

        protected void btnSubmit_Click( Object Sender, EventArgs e )
        {
            if ( IsValid ) PutOrder();
        }

        protected void rptUserOrders_ItemDataBound( Object Sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem ) return;

            var ord = (UserOrder)e.Item.DataItem;

            e.Item.FindControl( "plhDirectOrder" ).Visible = ord.IsDirect == true;
            e.Item.FindControl( "plhNormalOrder" ).Visible = ord.IsDirect != true;
            if ( ord.IsReady != true ) e.Item.FindControl( "lnkComment" ).Visible = false;

            var lnk = (HyperLink)e.Item.FindControl( "lnkDelete" );
            if ( lnk != null ) lnk.Visible = ord.IsActive == true;
        }

        protected void cbAllOders_CheckedChanged( Object sender, EventArgs e )
        {
            CurrentUser.ShowAllOrders = ((CheckBox)sender).Checked;
            Redirect( "/User/OrdersProgress.aspx?Hst=" + Request["Hst"] + "&AllOrd=" + (CurrentUser.ShowAllOrders ? "Y" : String.Empty) );
        }

        protected void FileBrowser_FileSelected( Object sender, FileBrowserCommandEventArgs e )
        {
            var url = "/User/OrdersProgress.aspx";

            if ( !String.IsNullOrEmpty( e.AbsolutePath ) )
            {
                var path = Utils.Registry.GetString( "Orders/Path" ) + "/" + CurrentUser.Id + Path.GetDirectoryName( e.RelativePath );

                try
                {
                    Directory.CreateDirectory( path );
                    var s = path + "/" + e.FileName;
                    File.Copy( e.AbsolutePath, s, true );
                    File.SetAttributes( s, FileAttributes.Normal );

                    var sql = "exec PutUserOrder @UserId=" + CurrentUser.Id + ",@IP=" + Utils.Convert.ToSQLString( Request.ServerVariables["REMOTE_ADDR"] ) + ",@ExternalLink=" + Utils.Convert.ToSQLString( "http://orders.pripev.net/" + CurrentUser.Id + e.RelativePath ) + ",@DirectFlag='Y'";
                    var msg = DB.ExecuteScalar( sql ).ToString();
                    if ( msg == "Dup" )
                        url += "?Dup=Y";
                    else if ( !String.IsNullOrEmpty( msg ) )
                    {
                        ErrMsg = msg;
                        Utils.Email.ErrorMail( "Ошибка заказов", msg, false );
                        File.Delete( s );
                        url += "?Err=Y";
                    }
                }

                catch ( System.Exception ex )
                {
                    Utils.Email.ErrorMail("Ошибка заказов", ex.ToString(), false);
                    Exception.ExceptionManager.Populate( ex );
                    url += "?Err=Y";
                }
            }
            Response.Redirect( url, true );
        }
    }
}
