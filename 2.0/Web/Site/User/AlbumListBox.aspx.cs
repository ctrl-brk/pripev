using System;
using System.Data;

namespace Pripev.Web.UI.Popup.User
{
   public partial class AlbumListBox : PopupPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         ClientScript.RegisterClientScriptBlock( GetType(), "LB", @"<script language='JavaScript' type='text/javascript'>
function SelectAlbum()
{
   var lb = document.getElementById('" + lbAlbum.ClientID + @"');
   if ( lb.selectedIndex != -1 )
      {
      window.opener.SetOrderAlbum( lb.options[lb.selectedIndex].value );
      window.opener.SetOrderSong( '' );
      window.close();
      }
}
</script>" );

         DataTable dt = DAL.DB.ExecuteDataTable( "GetAlbumListBox @ArtistName=" + Utils.Convert.ToSQLString( Request["Artist"] ) );
         lbAlbum.DataTextField = "NAME";
         lbAlbum.DataValueField = "NAME";
         lbAlbum.DataSource = dt;
         lbAlbum.DataBind();

         if ( dt.Rows.Count > 0 )
         {
            lnkSubmit.Text = "Выбрать";
            lnkSubmit.NavigateUrl = "javascript:SelectAlbum()";
         }
         else
         {
            litNotFound.Text = "Нет файлов для<br><b>" + Request["Artist"] + "</b>";
            litNotFound.Visible = true;
            lbAlbum.Visible = false;
            lnkSubmit.Text = "Закрыть";
            lnkSubmit.NavigateUrl = "javascript:window.close()";
         }
      }
   }
}
