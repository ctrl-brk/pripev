using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pripev.Web.UI.Popup.User
{
   public partial class ArtistListBox : PopupPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         ClientScript.RegisterClientScriptBlock( this.GetType(), "LB", @"<script language='JavaScript' type='text/javascript'>
function SelectArtist()
{
   var lb = document.getElementById('" + lbArtist.ClientID + @"');
   if ( lb.selectedIndex != -1 )
      {
      window.opener.SetOrderArtist( lb.options[lb.selectedIndex].value );
      window.opener.SetOrderAlbum( '' );
      window.opener.SetOrderSong( '' );
      window.close();
      }
}
</script>" );

         DataTable dt = DAL.DB.ExecuteDataTable( "exec GetArtistListBox" );
         lbArtist.DataTextField = "REALNAME";
         lbArtist.DataValueField = "REALNAME";
         lbArtist.DataSource = dt;
         lbArtist.DataBind();
      }
   }
}
