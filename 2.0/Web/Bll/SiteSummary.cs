using System;
using System.Data;

namespace Pripev.BLL
{
    public class SiteSummary
    {
        private readonly DataRow _dr;

        public SiteSummary()
        {
            _dr = DAL.DB.ExecuteDataRow("exec SiteSummary");
        }

        public int Artists
        {
            get { return (Convert.ToInt32(_dr["Artists"])); }
        }

        public int Albums
        {
            get { return (Convert.ToInt32(_dr["Albums"])); }
        }

        public int Texts
        {
            get { return (Convert.ToInt32(_dr["Texts"])); }
        }

        public int Chords
        {
            get { return (Convert.ToInt32(_dr["Chords"])); }
        }

        public int MP3All
        {
            get { return (Convert.ToInt32(_dr["MP3All"])); }
        }

        public int MP3Online
        {
            get { return (Convert.ToInt32(_dr["MP3Online"])); }
        }

        public int Midi
        {
            get { return (Convert.ToInt32(_dr["Midi"])); }
        }

        public int Karaoke
        {
            get { return (Convert.ToInt32(_dr["Karaoke"])); }
        }

        public int CDs
        {
            get { return (Convert.ToInt32(_dr["CDs"])); }
        }
    }
}
