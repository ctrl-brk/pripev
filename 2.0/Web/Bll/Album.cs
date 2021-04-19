using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pripev.DAL;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Pripev.BLL
{
    #region // AlbumText

    public class AlbumText
    {
        public AlbumText( int albumId, String albumName, int songId, String songName, int chordsNum, Text text, String iconsHtml )
        {
            AlbumId = albumId;
            SongId = songId;
            AlbumName = albumName;
            SongName = songName;
            ChordsNum = chordsNum;
            SongText = text;
            IconsHtml = iconsHtml;
        }

        public int AlbumId { get; private set; }

        public String AlbumName { get; private set; }

        public int SongId { get; private set; }

        public String SongName { get; private set; }

        public int ChordsNum { get; private set; }

        public Text SongText { get; private set; }

        public String IconsHtml { get; private set; }

        public int TextId
        {
// ReSharper disable PossibleInvalidOperationException
            get { return SongText.Id.Value; }
// ReSharper restore PossibleInvalidOperationException
        }
    }

    #endregion

    public class Album
    {
        #region // Private variables

        private readonly Model.Album _model;
        private int? _currentArtistId;
        private List<Song> _songs;
        private List<AlbumText> _textList;

        #endregion

        #region // Constructors

        public Album()
        {
            _model = new Model.Album();
        }

        public Album( int? id )
        {
            _model = new Model.Album( id );
        }

        public Album( int artistId, String name )
        {
            _model = new Model.Album( artistId, name );
        }

        #endregion

        #region // Public methods

        public void Save( int userId )
        {
            _model.Save( userId );
        }

        public void Delete()
        {
            _model.Delete();
        }

        #endregion

        #region // Public properties

        public int? Id
        {
            get { return (_model.Id); }
        }

        public int? ArtistId
        {
            get { return (_model.ArtistId); }
            set { _model.ArtistId = value; }
        }

        public int? CurrentArtistId
        {
            get { return (_currentArtistId ?? _model.ArtistId); }
            set { _currentArtistId = value; }
        }

        public String Name
        {
            get { return (_model.Name); }
            set { _model.Name = value; }
        }

        public String ArtistName
        {
            get { return (_model.ArtistName); }
        }

        /// <summary>
        /// Returns year (if year&lt;10000 ) or String.Empty (if year&gt;=20000 (other songs) or "?"
        /// </summary>
        public String Year
        {
            get
            {
                if ( _model.Year < 10000 ) return (_model.Year.ToString());
                return _model.Year >= 20000 ? (String.Empty) : ("?");
            }
            set
            {
                if ( !String.IsNullOrEmpty( value ) )
                    _model.Year = Convert.ToInt16( value );
                else
                    _model.Year = null;
            }
        }

        public Byte? Genre
        {
            get { return (_model.Genre); }
            set { _model.Genre = value; }
        }

        public bool CD
        {
            get { return (_model.CD ?? false); }
            set { _model.CD = value; }
        }

        public bool Wanted
        {
            get { return (_model.Wanted ?? false); }
            set { _model.Wanted = value; }
        }

        public int TextNum
        {
            get { return (_model.Texts ?? 0); }
        }

        public int ChordNum
        {
            get { return (_model.Chords ?? 0); }
        }

        public int SongNum
        {
            get { return (_model.Songs ?? 0); }
        }

        public int SoundsNum
        {
            get { return ((_model.Mp3 ?? 0) + (_model.Mid ?? 0) + (_model.Kar ?? 0) + (_model.Mov ?? 0)); }
        }

        public int Mp3Num
        {
            get { return (_model.Mp3 ?? 0); }
        }

        public int Mp3OnlineNum
        {
            get { return (_model.Mp3Online ?? 0); }
        }

        public int MidNum
        {
            get { return (_model.Mid ?? 0); }
        }

        public int KarNum
        {
            get { return (_model.Kar ?? 0); }
        }

        public int MovNum
        {
            get { return (_model.Mov ?? 0); }
        }

        public String ModelSmallImage
        {
            get { return (_model.SmallImage); }
            set { _model.SmallImage = value; }
        }

        public String SmallImage
        {
            get
            {
                if ( !String.IsNullOrEmpty( _model.SmallImage ) ) return ("/Images/Albums/Small/" + _model.SmallImage);
                return (null);
            }
        }

        public String ModelLargeImage
        {
            get { return (_model.LargeImage); }
            set { _model.LargeImage = value; }
        }

        public String LargeImage
        {
            get
            {
                if ( _model.LargeImage.Contains( "Dot.gif" ) ) return (String.Empty);
                if ( !String.IsNullOrEmpty( _model.LargeImage ) ) return ("/Images/Albums/Large/" + _model.LargeImage);
                if ( Year == String.Empty ) return (String.Empty);
                return (null);
            }
        }

        public String ModelListenLink
        {
            get { return (_model.Listen); }
            set { _model.Listen = value; }
        }

        public String ListenLink
        {
            get { return (String.IsNullOrEmpty( _model.Listen ) ? null : "http://www.russiandvd.com/store/album_asx.asp?aid=6462&" + _model.Listen); }
        }

        public String BuyURL
        {
            get { return ((_model.BuyFlag ?? false) ? "/Buy.aspx?ProductId=" + _model.Id + "&ProductType=B" : null); }
        }

        public String RootPath
        {
            get { return (_model.RootPath); }
        }

        public String InfoText
        {
            get { return (_model.InfoText); }
            set { _model.InfoText = value; }
        }

        public String Info
        {
            get
            {
                var sb = new StringBuilder( 100*1024 );
                var dt = DB.ExecuteDataTable( "exec GetAlbumArtists @AlbumId=" + _model.Id + ",@ArtistId=" + CurrentArtistId );

                if ( dt.Rows.Count > 0 )
                {
                    sb.Append( "В записи принимали участие:<ul>" );
                    foreach ( DataRow dr in dt.Rows )
                        sb.Append( "<li><a href='/Artist.asp?Id=" + dr["ArtistId"] + "'>" + dr["Name"] + "</a></li>" );
                    sb.Append( "</ul>" );
                    if ( !String.IsNullOrEmpty( _model.InfoText ) ) sb.Append( "<hr size='1'>" );
                }
                sb.Append( _model.InfoText );
                return (sb.ToString());
            }
        }

        public String Producer
        {
            get { return (_model.Producer); }
            set { _model.Producer = value; }
        }

        public List<Song> Songs
        {
            get
            {
                if ( _songs == null )
                {
                    _songs = new List<Song>( 100 );
                    var dt = DB.ExecuteDataTable( "exec GetSongs @AlbumId=" + _model.Id + ",@SortCol='" + (Year == String.Empty ? "Name" : "Number") + "'" );
                    foreach ( DataRow dr in dt.Rows )
                    {
                        _songs.Add( new Song( Convert.ToInt32( dr["SONG_ID"] ) ) );
                    }
                }
                return (_songs);
            }
        }

        public List<AlbumText> Texts
        {
            get
            {
                if ( _textList == null )
                {
                    _textList = new List<AlbumText>( 50 );
                    if ( _model.Id != null )
                    {
                        foreach ( var s in Songs )
                        {
                            foreach ( var t in s.Texts )
                            {
// ReSharper disable PossibleInvalidOperationException
                                _textList.Add( new AlbumText( s.AlbumId.Value, s.AlbumName, s.Id.Value, s.Name, s.ChordsNum, t, s.GetIconsHtml( false ) ) );
// ReSharper restore PossibleInvalidOperationException
                            }
                        }
                    }
                }
                return (_textList);
            }
        }

        #endregion
    }
}
