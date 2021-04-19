using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pripev.DAL;
using Pripev.Model;
using Pripev.Utils;
using Convert = System.Convert;

namespace Pripev.BLL
{
    public class Song
    {
        private int _texts, _chords, _sounds;
        private bool _detailsLoaded;

    #region Properties

        public int? Id { get; private set; }
        public int? AlbumId { get; private set; }
        public int? ArtistId { get; private set; }
        public int? TrackNumber { get; private set; }
        public String Name { get; private set; }
        public String AlbumName { get; private set; }
        public String ArtistName { get; private set; }
        public bool IsSeparator { get; private set; }
        public bool HasCD { get; private set; }

        public int TextsNum
        {
            get
            {
                LoadDetails();
                return (_texts);
            }
        }

        public int ChordsNum
        {
            get
            {
                LoadDetails();
                return (_chords);
            }
        }

        public int SoundsNum
        {
            get
            {
                LoadDetails();
                return (_sounds);
            }
        }

        public bool HasVideo
        {
            get { return (Name.Contains("(видео)") || Name.Contains("(video)")); }
        }

        public String HTMLName
        {
            get
            {
                if (!Id.HasValue) return (null);
                if (IsSeparator) return ("<strong>" + Name + "</strong>");
                return _texts == 0 ? Name : String.Format("<a href='/Text.aspx?SongId={0}' title='Текст{1} песни'>{2}</a>", Id, (ChordsNum > 0 ? " и аккорды" : String.Empty), Name);
            }
        }

        private List<Text> _textList;
        public List<Text> Texts
        {
            get
            {
                if (_textList == null)
                {
                    _textList = new List<Text>(10);
                    if (Id.HasValue)
                    {
                        var dt = DB.ExecuteDataTable( "exec GetSongTexts @SongId=" + Id );
                        foreach( DataRow dr in dt.Rows)
                        {
                                _textList.Add(new Text(Convert.ToInt32(dr["TEXT_ID"]), dr["OwnerMsg"].ToString(), Id, AlbumId, ArtistId));

                        }
                    }
                }
                return (_textList);
            }
        }

        private SoundList _soundList;
        public SoundList Sounds
        {
            get
            {
                if (_soundList == null)
                {
                    _soundList = new SoundList();
                    if (Id.HasValue)
                    {
                        var dt = DB.ExecuteDataTable("exec usp_GetSongSounds @SongId=" + Id);
                        foreach (DataRow dr in dt.Rows)
                        {
                            _soundList.Add(new Sound(dr));
                        }
                    }
                }
                return (_soundList);
            }
        }

        public String LinkHtml
        {
            get
            {
                if (IsSeparator) return ("<strong>" + Name + "</strong>");
                if (TextsNum == 0) return (Name);
                return ("<a href='/Text.aspx?SongId=" + Id + "' title='Текст'" + (ChordsNum > 0 ? " и аккорды" : String.Empty) + " песни'>" + Name + "</a>");
            }
        }

    #endregion

        public Song( int? id )
        {
            Id = id;
            if ( id != null ) LoadData();
        }

        public Song( int albumId, String songName )
        {
            LoadData( albumId, songName );
        }

        public Song( String id ) : this( Convert.ToInt32( id ) ) {}

        private void LoadData()
        {
            LoadData( DB.ExecuteDataRow( "exec GetSong @SongId=" + Id ) );
        }

        private void LoadData( int albumId, String songName )
        {
            LoadData( DB.ExecuteDataRow( "exec GetSong @AlbumId=" + albumId + ",@SongName=" + Utils.Convert.ToSQLString( songName ) ) );
        }

        private void LoadData( DataRow dr )
        {
            if ( dr == null )
            {
                Id = null;
                return;
            }
            Id = Convert.ToInt32( dr["SONG_ID"] );
            Name = dr["Name"].ToString();
            AlbumId = Convert.ToInt32( dr["ALBUM_ID"] );
            ArtistId = Convert.ToInt32( dr["ArtistId"] );
            AlbumName = dr["AlbumName"].ToString();
            ArtistName = dr["ArtistName"].ToString();
            TrackNumber = Convert.ToInt32( dr["TrackNumber"] );
            IsSeparator = dr["Separator"].ToString() == "Y";
            HasCD = Convert.ToInt16( dr["nCD"] ) == 1;
        }

        private void LoadDetails()
        {
            if ( _detailsLoaded || Id == null ) return;

            var dr = DB.ExecuteDataRow( "exec GetSongDetails @SongId=" + Id );
            _texts = Convert.ToInt32( dr["TextsNum"] );
            _chords = Convert.ToInt32( dr["ChordsNum"] );
            _sounds = Convert.ToInt32( dr["SoundsNum"] );

            _detailsLoaded = true;
        }

        private static String GetIconHtml( Sound sd )
        {
            var sb = new StringBuilder( 1024 );
            var altText = new StringBuilder( 1024 );
            var icon = "/Images/Sounds/" + sd.DBType + "Offline.gif";

            altText.Append( sd.Size );
            altText.Append( " " );

            if ( sd.Bitrate > 0 )
            {
                if ( sd.BitrateType == SoundBitrateType.Variable ) altText.Append( "VBR ~" );
                altText.Append( sd.Bitrate );
                altText.Append( "bps" );
            }
            else if ( sd.Bitrate < 0 ) altText.Append( "VBR" );

            if ( !String.IsNullOrEmpty( sd.Length ) ) altText.Append( " " + sd.Length );

            if ( !String.IsNullOrEmpty( sd.Comments ) )
            {
                altText.Insert( 0, sd.Comments + "(" );
                altText.Append( ")" );
                icon = "/Images/Icons/AlertNote.gif";
            }

            if ( sd.DownloadLink != null )
                icon = "/Images/Sounds/" + sd.DBType + ".gif";

            if (Tools.GetAppSetting("CopyrightLevel") == "OOO")
            {
                sb.Append(" <a href='javascript:OfflineAlert(");
                if (!String.IsNullOrEmpty(sd.Comments)) sb.Append("\"" + sd.Comments + "\"");
                sb.Append(")' title='" + altText + "'>");
                sb.Append("<img src='" + icon + "' border='0' align='absmiddle'></a>");
            }
            else
            {
                if (sd.DownloadLink == null)
                    sb.AppendFormat( "<a href='/User/OrdersProgress.aspx' title='{0}'><img src='{1}' border='0' align='absmiddle'></a>", altText, icon );
                else
                    sb.AppendFormat("<a href='{0}' title='{1}'><img src='{2}' border='0' align='absmiddle'></a>", sd.DownloadLink, altText, icon);
            }

            return (sb.ToString());
        }

        public String GetIconsHtml( bool showChords )
        {
            if ( !Id.HasValue ) return (null);
            if ( IsSeparator ) return ("&nbsp;");

            var sb = new StringBuilder( 1024 );
            var bEmpty = Sounds.SoundNum == 0;

            if ( showChords && _chords > 0 ) sb.Append( " <img src='/Images/Note.gif' align='absmiddle'>" );

            foreach ( var sd in Sounds )
            {
                sb.Append( GetIconHtml( sd ) );
            }

            if ( HasCD && Sounds.SoundNum == 0 && !IsSeparator )
            {
                if ( Sounds.SoundNum == 0 && HasCD && Sounds.VideoNum == 0 )
                {
                    bEmpty = false;
                    sb.Append( " <a href='javascript:CDExists()' title='Имеется CD'>" );
                    sb.Append( "<img src='/Images/Icons/Note.gif' border='0' align='absmiddle'></a>" );
                }
            }

            if ( bEmpty ) sb.Append( "&nbsp;" );

            return (sb.ToString());
        }
    }
}
