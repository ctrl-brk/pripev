using System;
using System.Data;
using Pripev.Model;

// ReSharper disable UnusedMember.Global

namespace Pripev.BLL
{
    public class Sound
    {
        private Model.Sound Model { get; set; }
        public String DBType { get; private set; }

        public Sound()
        {
            Model = new Model.Sound();
        }

        public Sound( int? id )
        {
            Model = new Model.Sound( id );
        }

        public Sound( DataRow dr )
        {
            DBType = dr["Type"].ToString().ToLower();
            Model = new Model.Sound( dr );
        }

        public int? Id
        {
            get { return (Model.Id); }
        }

        public SoundType Type
        {
            get { return (Model.Type); }
        }

        public String Path
        {
            get { return (Model.Path); }
        }

        public int? Size
        {
            get { return (Model.Size); }
        }

        public int? Bitrate
        {
            get { return (Model.BitRate); }
        }

        public SoundBitrateType BitrateType
        {
            get { return (Model.BitrateType); }
        }

        public String Length
        {
            get { return (Model.Length); }
        }

        public String Comments
        {
            get { return (Model.Comments); }
        }

        public bool OriginalTrack
        {
            get { return (Type == SoundType.MP3 || Type == SoundType.Vorbis || Type == SoundType.WMA); }
        }

        public Uri DownloadLink
        {
            get { return Model.DownloadLink; }
        }
    }
}
