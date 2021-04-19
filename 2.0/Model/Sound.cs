using System;
using System.Data;
using Pripev.DAL;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Pripev.Model
{
    public enum SoundType
    {
        Unknown,
        ASF,
        AVI,
        Karaoke,
        Midi,
        MP3,
        Mpeg,
        Vorbis,
        RealAudio,
        RealMovie,
        WMA
    }

    public enum SoundBitrateType
    {
        Unknown = 'N',
        Constant = 'C',
        Variable = 'V'
    }

    public class Sound : IModel
    {
        public int? Id { get; private set; }

        public SoundType Type { get; private set; }

        public String Path { get; private set; }

        public int? BitRate { get; private set; }

        public int? Size { get; private set; }

        public DateTime? Added { get; private set; }

        public int? CreatedBy { get; private set; }

        public String Length { get; private set; }

        public String PhysicalPath { get; private set; }

        public SoundBitrateType BitrateType { get; private set; }

        public String Comments { get; private set; }

        public Uri DownloadLink { get; private set; }

        public Sound() {}

        public Sound( int? id )
        {
            Id = id;
            Retrieve();
        }

        public Sound( DataRow dr )
        {
            Retrieve( dr );
        }

        #region // IModel

        public void Clear() {}

        private void Retrieve( DataRow dr )
        {
            Id = dr.Field<int>( "SOUND_ID" );
            switch ( dr.Field<String>( "TYPE" ) )
            {
                case "asf":
                    Type = SoundType.ASF;
                    break;
                case "avi":
                    Type = SoundType.AVI;
                    break;
                case "kar":
                    Type = SoundType.Karaoke;
                    break;
                case "mid":
                    Type = SoundType.Midi;
                    break;
                case "mp3":
                    Type = SoundType.MP3;
                    break;
                case "mpg":
                    Type = SoundType.Mpeg;
                    break;
                case "ogg":
                    Type = SoundType.Vorbis;
                    break;
                case "ra":
                    Type = SoundType.RealAudio;
                    break;
                case "rm":
                    Type = SoundType.RealMovie;
                    break;
                case "wma":
                    Type = SoundType.WMA;
                    break;
            }

            Path = dr.Field<string>("PATH");
            PhysicalPath = dr.Field<string>("PhysicalPath");
            Size = dr.Field<int?>( "Size" );
            BitRate = dr.Field<Int16?>( "BitRate" );
            BitrateType = (SoundBitrateType)dr["BitrateType"].ToString().ToCharArray( 0, 1 )[0];
            Length = dr.Field<string>("Length");
            Comments = dr.Field<string>("Comments");
            CreatedBy = dr.Field<int?>( "CreatedBy" );
            Added = dr.Field<DateTime?>( "ADDED" );
            
            var lnk = dr.Field<string>( "ExternalLink" );
            if (!String.IsNullOrWhiteSpace( lnk ))
                DownloadLink = new Uri(lnk);
        }

        public void Retrieve()
        {
            if ( !Id.HasValue ) return;

            var dr = DB.ExecuteDataRow( "exec usp_GetSound @SoundId=" + Id );
            Retrieve( dr );
        }

        public void Save( int userId ) {}

        public void Delete() {}

        #endregion
    }
}
