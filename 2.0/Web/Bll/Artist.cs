using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.ComponentModel;
using Pripev.DAL;

namespace Pripev.BLL
{
    public class ArtistText
    {
        public int TextId { get; private set; }

        public int SongId { get; private set; }

        public String SongName { get; private set; }

        public ArtistText( int textId, int songId, String songName )
        {
            TextId = textId;
            SongId = songId;
            SongName = songName;
        }
    }

    public class Artist : IListSource
    {
        private readonly Model.Artist _model;
        private List<Album> _albums;
        private List<ArtistText> _textList;

        public Artist( int? id )
        {
            _model = new Model.Artist( id );
        }

        public Artist( String name )
        {
            _model = new Model.Artist( name );
        }

        public void Save( int userId )
        {
            _model.Save( userId );
        }

        public int? Id
        {
            get { return (_model.Id); }
        }

        public int? OriginalId
        {
            get { return (_model.Aka ?? _model.Id); }
        }

        public int? Aka
        {
            get { return (_model.Aka); }
            set { _model.Aka = value; }
        }

        public String Name
        {
            get { return (_model.Name); }
            set { _model.Name = value; }
        }

        public String Name1
        {
            get { return (_model.Name1); }
            set { _model.Name1 = value; }
        }

        public Char? Letter
        {
            get { return (_model.Letter); }
            set { _model.Letter = value; }
        }

        public String Info
        {
            get { return (_model.InfoText); }
            set { _model.InfoText = value; }
        }

        public String Links
        {
            get { return (_model.LinksText); }
            set { _model.LinksText = value; }
        }

        public int TextNum
        {
            get { return (_model.Texts == null ? 0 : (int)_model.Texts); }
        }

        public String ModelImage
        {
            get { return (_model.Image); }
            set { _model.Image = value; }
        }

        public String Image
        {
            get
            {
                if ( !String.IsNullOrEmpty( _model.Image ) )
                    return ("/Images/Artists/" + _model.Image);

                return (null);
            }
        }

        public bool DetailsFlag
        {
            get { return (_model.DetailsFlag == 'Y'); }
            set { _model.DetailsFlag = value ? 'Y' : 'N'; }
        }

        public List<Album> Albums
        {
            get
            {
                if ( _albums == null )
                {
                    _albums = new List<Album>( 50 );
                    var dt = DB.ExecuteDataTable( "exec GetAlbums @ArtistId=" + _model.Id );
                    foreach ( DataRow dr in dt.Rows )
                    {
                        _albums.Add( new Album( Convert.ToInt32( dr["ALBUM_ID"] ) ) );
                    }
                }
                return (_albums);
            }
        }

        private class DistinctTextComparer : IEqualityComparer<ArtistText>
        {
            public bool Equals( ArtistText a, ArtistText b )
            {
                return (a.SongName.CompareTo( b.SongName ) == 0);
            }

            public int GetHashCode( ArtistText obj )
            {
                return (obj.SongName.GetHashCode());
            }
        }

        public List<ArtistText> Texts
        {
            get
            {
                if ( _model.Id != null && _textList == null )
                {
                    _textList = new List<ArtistText>( 200 );

                    var dt = DB.ExecuteDataTable( "exec GetArtistSongs @ArtistId=" + _model.Id );

                    foreach ( DataRow dr in dt.Rows )
                    {
                        _textList.Add( new ArtistText( Convert.ToInt32( dr["TEXT_ID"] ), Convert.ToInt32( dr["SONG_ID"] ), dr["NAME"].ToString() ) );
                    }
                    return (_textList.Distinct( new DistinctTextComparer() ).ToList());
                }
                return (null);
            }
        }

        #region // IListSource

        System.Collections.IList IListSource.GetList()
        {
            var artistList = new BindingList<Artist> {this};

            return (artistList);
        }

        bool IListSource.ContainsListCollection
        {
            get { return (false); }
        }

        #endregion
    }
}
