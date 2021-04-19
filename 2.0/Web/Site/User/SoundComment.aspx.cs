using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pripev.Web.UI.User
{
   public partial class SoundComment : PopupPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         if ( IsPostBack )
         {
            plhComment.Visible = false;
            litConfirm.Visible = true;
            btnSubmit.Visible = false;
            lnkClose.Visible = true;

            SaveComment();
         }
         else
         {
            plhComment.Visible = true;
            litConfirm.Visible = false;
            btnSubmit.Visible = true;
            lnkClose.Visible = false;

            if ( !String.IsNullOrEmpty( Request["SongId"] ) )
            {
               BLL.Song song = new Pripev.BLL.Song( Request["SongId"] );
               litSong.Text = " (композиция \"" + song.Name + "\")";
               litSong.Visible = true;
            }
            else
               litSong.Visible = false;

            litOrder.Visible = String.IsNullOrEmpty( Request["OrderId"] );

         }
      }

      private void SaveComment()
      {
         if ( String.IsNullOrEmpty( txtComment.Text ) ) return;

         DAL.DB.ExecuteNonQuery( "exec AddSongSoundComment @UserId=" + CurrentUser.Id +
                                                         ",@SongId=" + Utils.Convert.ToSQL( Request["SongId"] ) +
                                                         ",@SoundId=" + Utils.Convert.ToSQL( Request["SoundId"] ) +
                                                         ",@OrderId=" + Utils.Convert.ToSQL( Request["OrderId"] ) +
                                                         ",@Comment=" + Utils.Convert.ToSQLString( txtComment.Text ) );
      }
   }
}
