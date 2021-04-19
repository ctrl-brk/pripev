using System;

namespace Pripev.Web.UI.Popup
{
    public partial class PrintText : PopupPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var song = new BLL.Song( Request["SongId"] );
            if ( song.Id == null )
            {
                pSongNotFound.Visible = true;
                return;
            }

            var text = new BLL.Text( Request["TextId"] );
            if ( text.Id == null )
            {
                pTextNotFound.Visible = true;
                return;
            }

            litH1.Text = song.ArtistName + " - " + song.Name;
            litText.Text = text.GetHTML( Master.CurrentUser );
            plhPrint.Visible = true;
        }
    }
}
