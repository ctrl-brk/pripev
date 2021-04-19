using System;
using System.Collections.Generic;
using Pripev.BLL;

namespace Pripev.Web.UI
{
    public partial class Home : WebPage
    {
        protected override void OnLoad(EventArgs e)
        {
            pnlComm.Visible = !Master.CurrentUser.bActive;
            if ( !IsPostBack )
            {
                Master.Title = "Припевы!";
                lstNewsDays.SelectedValue = "7";
            }
            ShowSummary();
            ShowNews();
        }

        private void ShowSummary()
        {
            var sum = new SiteSummary();

            lblArtists.Text = sum.Artists.ToString();
            lblAlbums.Text = sum.Albums.ToString();
            lblTexts.Text = sum.Texts.ToString();
            lblChords.Text = sum.Chords.ToString();
            lblMP3All.Text = sum.MP3All.ToString();
            lblMP3Online.Text = sum.MP3Online.ToString();
            lblMidi.Text = sum.Midi.ToString();
            lblKaraoke.Text = sum.Karaoke.ToString();
            lblCDs.Text = sum.CDs.ToString();

            if ( !Master.CurrentUser.bAdmin )
            {
                lblSSN.Text = "&nbsp;";
                lblSSNData.Text = "&nbsp;";
            }
            else
            {
                lblSSNData.Text = Application["nSessions"] + "/";
                lnkUsers.Text = ((List<WebUserSession>)Application["OnlineUsers"]).Count.ToString();
                lnkUsers.Visible = true;
            }
        }

        private void ShowNews()
        {
            var news = new NewArrivals( Convert.ToInt32( lstNewsDays.SelectedValue ) );

            lnkNewArtists.NavigateUrl = "/News/Artist.aspx?Days=" + lstNewsDays.SelectedValue;
            lblNewArtists.Text = news.Artists.ToString();
            lnkNewAlbums.NavigateUrl = "/News/Album.aspx?Days=" + lstNewsDays.SelectedValue;
            lblNewAlbums.Text = news.Albums.ToString();
            lnkNewTexts.NavigateUrl = "/News/Text.aspx?Days=" + lstNewsDays.SelectedValue;
            lblNewTexts.Text = news.Texts.ToString();
            lnkNewFiles.NavigateUrl = "/News/File.aspx?Days=" + lstNewsDays.SelectedValue;
            lblNewFiles.Text = news.Sounds.ToString();
        }
    }
}
