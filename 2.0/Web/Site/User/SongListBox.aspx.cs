using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Pripev.Web.UI.Popup.User
{
   public partial class SongListBox : PopupPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         ClientScript.RegisterClientScriptBlock( this.GetType(), "LB", @"<script language='JavaScript' type='text/javascript'>
function SelectSong()
{
   var lb = document.getElementById('selSong');
   if ( lb.selectedIndex != -1 )
      {
      window.opener.SetOrderSong( lb.options[lb.selectedIndex].value );
      window.close();
      }
}
</script>" );

         String msg;
         DataTable dt;

         if ( !String.IsNullOrEmpty( Request["Album"] ) )
         {
            msg = Request["Album"];
            dt = DAL.DB.ExecuteDataTable( "exec GetSongListBox @ArtistName=" + Utils.Convert.ToSQLString( Request["Artist" ] ) +
                                                             ",@AlbumName=" + Utils.Convert.ToSQLString( Request["Album" ] ) );
         }
         else
         {
            msg = Request["Artist"];
            dt = DAL.DB.ExecuteDataTable( "GetAlbumListBox @ArtistName=" + Utils.Convert.ToSQLString( Request["Artist"] ) );
         }

         if ( dt.Rows.Count > 0 )
         {
            StringBuilder sb = new StringBuilder( "<select size='10' id='selSong' ondblclick='SelectSong()'>" );
            bool bSeparator = false;

            foreach( DataRow dr in dt.Rows )
            {
               String name = Server.HtmlEncode( dr["NAME"].ToString() );
               if ( dr["Separator"].ToString() != "Y" )
                  sb.Append( "<option value='" + name + "'>" + name + "</option>" );
               else
               {
                  if ( bSeparator ) sb.Append( "</optgroup>" );
                  bSeparator = true;
                  sb.Append( "<optgroup label='" + name + "'>" );
               }
            }
            sb.Append( "</select>" );
            litSelSong.Text = sb.ToString();
            lnkSubmit.Text = "Выбрать";
            lnkSubmit.NavigateUrl = "javascript:SelectSong()";
         }
         else
         {
            litNotFound.Text = "Нет файлов для<br><b>" + msg + "</b>";
            litNotFound.Visible = true;
            lnkSubmit.Text = "Закрыть";
            lnkSubmit.NavigateUrl = "javascript:window.close()";
         }
      }
   }
}
