using System;
using System.Web.UI.WebControls;
using Pripev.BLL;
using Pripev.DAL;
using Pripev.Utils;
using Pripev.Web.UI.UserControls;
using System.IO;
using Convert = System.Convert;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global

namespace Pripev.Web.UI.Admin
{
    public partial class Orders : AdminWebPage
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if ( ScriptManager1.IsInAsyncPostBack ) return;

            var dt = DB.ExecuteDataTable( "exec AdminGetOrders" );
            rptOrders.DataSource = dt;
            rptOrders.DataBind();
        }

        private int OrderId
        {
            get { return (ViewState["OrderId"] == null ? 0 : Convert.ToInt32( ViewState["OrderId"] )); }
            set { ViewState["OrderId"] = value; }
        }

        protected void rptOrders_ItemCommand( object source, RepeaterCommandEventArgs e )
        {
            switch ( e.CommandName )
            {
                case "Delete":
// ReSharper disable PossibleInvalidOperationException
                    UserOrder.DeleteOrder( Convert.ToInt32( e.CommandArgument ), CurrentUser.Id.Value );
// ReSharper restore PossibleInvalidOperationException
                    break;
                case "Edit":
                    EditUserOrders( Convert.ToInt32( e.CommandArgument ) );
                    break;
            }
        }

        protected void rptUserOrders_ItemCommand( object source, RepeaterCommandEventArgs e )
        {
            //TODO: Removed because of autodelete?
            /*         if ( e.CommandName.ToString() == "Delete" )
                     {
                        UserOrder.DeleteOrder( Convert.ToInt32( e.CommandArgument ), (int)CurrentUser.Id );
                     }*/
            if ( e.CommandName == "Edit" )
                EditUserOrders( Convert.ToInt32( e.CommandArgument ) );
        }

        protected void FileBrowser_FileSelected( Object sender, FileBrowserCommandEventArgs e )
        {
            var order = new UserOrder( OrderId );

            DB.ExecuteNonQuery( "exec UpdateAlbumSoundPath @SoundId=" + lstFiles.SelectedValue + ",@Path=" + Utils.Convert.ToSQLString( Path.GetDirectoryName( e.RelativePath ) ) );

            var path = Tools.GetAppSetting( "UserOrdersPath" ) + order.UserId + Path.GetDirectoryName( e.RelativePath );

            Directory.CreateDirectory( path );
            var s = path + "/" + e.FileName;
            File.Copy( e.AbsolutePath, s, true );
            File.SetAttributes( s, FileAttributes.Normal );

            var sql = "exec UpdateUserOrder @OrderId=" + OrderId + ",@SoundId=" + lstFiles.SelectedValue + ",@ExternalLink=" + Utils.Convert.ToSQLString( "http://orders.pripev.net/" + order.UserId + e.RelativePath ) + ",@ModifiedBy=" + CurrentUser.Id;
            DB.ExecuteNonQuery( sql );
            lblMsg.Text = "Скопировано в<br>" + s;
        }

        private void EditUserOrders( int orderId )
        {
            OrderId = orderId;

            var order = new UserOrder( orderId );
            var artist = new BLL.Artist( order.ArtistName );
// ReSharper disable PossibleInvalidOperationException
// ReSharper disable RedundantNameQualifier
            var album = new BLL.Album( artist.Id.Value, order.AlbumName );
            var song = new BLL.Song( album.Id.Value, order.SongName );
// ReSharper restore RedundantNameQualifier
// ReSharper restore PossibleInvalidOperationException

            FileBrowser1.CurrentPath = album.RootPath;

            litUser.Text = order.UserId + "/" + order.Id;
            litArtist.Text = artist.Name;
            litAlbum.Text = album.Name;
            litSong.Text = song.Name;
            litComments.Text = order.Comments;

            var i = -1;
            lstFiles.Items.Clear();
            foreach ( var sd in song.Sounds )
            {
                var li = new ListItem( sd.Path, sd.Id.ToString() );
                lstFiles.Items.Add( li );
                if ( sd.Path.EndsWith( ".mp3" ) || sd.Path.EndsWith( ".wma" ) || sd.Path.EndsWith( ".ogg" ) || sd.Path.EndsWith( ".wav" ) )
                    i = lstFiles.Items.Count - 1;
            }
            if ( i >= 0 ) lstFiles.SelectedIndex = i;

            rptUserOrders.DataSource = DB.ExecuteDataTable( "exec GetCurrentUserOrders @OrderId=" + order.Id );
            rptUserOrders.DataBind();
        }
    }
}
