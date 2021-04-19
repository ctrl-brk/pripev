using System;
using System.Data;
using Pripev.DAL;
using Pripev.Utils;

namespace Pripev.Model
{
    public class Album : IModel
    {
        #region // Constructors

        public Album() {}

        public Album( int? id )
        {
            Id = id;
            Retrieve();
        }

        public Album( int artistId, String albumName )
        {
            ArtistId = artistId;
            Name = albumName;
            Retrieve();
        }

        #endregion

        #region // Public properties

        public int? Id { get; private set; }

        public int? ArtistId { get; set; }

        public String Name { get; set; }

        public String ArtistName { get; private set; }

        public String LargeImage { get; set; }

        public String SmallImage { get; set; }

        public Int16? Year { get; set; }

        public Byte? Genre { get; set; }

        public bool? Wanted { get; set; }

        public String Producer { get; set; }

        public bool? CD { get; set; }

        public String Buy { get; set; }

        public bool? BuyFlag { get; private set; }

        public String Listen { get; set; }

        public String RootPath { get; set; }

        public String InfoText { get; set; }

        public Byte? Songs { get; private set; }

        public Int16? Texts { get; private set; }

        public Int16? Chords { get; private set; }

        public Byte? Mp3 { get; private set; }

        public Byte? Mp3Online { get; private set; }

        public Byte? Mid { get; private set; }

        public Byte? Kar { get; private set; }

        public Byte? Mov { get; private set; }

        public DateTime? Added { get; private set; }

        public int? CreatedBy { get; private set; }

        public int? ModifiedBy  { get; set; }

        public DateTime? ModifiedOn { get; private set; }

        #endregion

        #region // IModel

        public void Clear() {}

        public void Retrieve()
        {
            if ( Id.HasValue )
                Retrieve( DB.ExecuteDataRow( "exec usp_GetAlbum @AlbumId=" + Id ) );
            else if ( ArtistId.HasValue && !String.IsNullOrEmpty( Name ) )
                Retrieve( DB.ExecuteDataRow( "exec usp_GetAlbumByName @ArtistId=" + ArtistId + ",@AlbumName=" + Name.ToSQL() ) );
        }

        public void Retrieve( DataRow dr )
        {
            Id = dr.Field<int>( "ALBUM_ID" );
            ArtistId = dr.Field<int>( "ARTIST_ID" );
            ArtistName = dr.Field<string>("ArtistName");
            Name = dr.Field<string>("Name");
            LargeImage = dr.Field<string>("LARGE_IMAGE");
            SmallImage = dr.Field<string>("SMALL_IMAGE");
            Year = dr.Field<Int16?>( "Year" );
            Genre = dr.Field<Byte?>( "Gendre" );
            Producer = dr.Field<string>("PRODUCER");
            CD = dr.Field<byte>("CD") == 1;
            CreatedBy = dr.Field<int>("CreatedBy");
            Added = dr.Field<DateTime>("Added");
            Wanted = System.Convert.ToInt16( dr["WANTED"] ) == 1;
            Texts = dr.Field<Int16?>("Texts");
            Chords = dr.Field<Int16?>("Chords");
            Songs = dr.Field<Byte?>("Songs");
            Mp3 = dr.Field<Byte?>("MP3");
            Mp3Online = dr.Field<Byte?>("MP3ONLINE");
            dr.Field<Byte?>("MP3ONLINE");
            Mid = dr.Field<Byte?>("MID");
            Kar = dr.Field<Byte?>( "KAR" );
            Mov = dr.Field<Byte?>( "MOV" );
            Buy = dr.Field<string>("BUY");
            Listen = dr.Field<string>("LISTEN");
            InfoText = dr.Field<string>("InfoText");
            BuyFlag = dr.Field<string>("BuyFlag") == "Y";
            ModifiedBy = dr.Field<int?>( "ModifiedBy" );
            ModifiedOn = dr.Field<DateTime?>( "ModifiedOn" );
        }

        public void Save( int userId )
        {
            var sql = string.Format( "exec usp_UpdateAlbum @Id={0},@ArtistId={1},@Name={2},@LargeImage={3},@SmallImage={4},@Year={5},@Genre={6},@Wanted={7},@Producer={8},@CD={9},@Buy={10},@Listen={11},@InfoText={12},@ModifiedBy={13}",
                Utils.Convert.ToSQL( Id ), Utils.Convert.ToSQL( ArtistId ), Utils.Convert.ToSQLString( Name ), Utils.Convert.ToSQLString( LargeImage ), Utils.Convert.ToSQLString( SmallImage ),
                Utils.Convert.ToSQL( Year ), Utils.Convert.ToSQL( Genre ), Utils.Convert.ToSQL( Wanted ), Utils.Convert.ToSQLString( Producer ), Utils.Convert.ToSQL( CD ),
                Utils.Convert.ToSQLString( Buy ), Utils.Convert.ToSQLString( Listen ), Utils.Convert.ToSQLString( InfoText ), Utils.Convert.ToSQL( userId ) );

            Id = System.Convert.ToInt32( DB.ExecuteScalar( sql ) );
        }

        public void Delete()
        {
            DB.ExecuteNonQuery( "usp_DeleteAlbum @AlbumId=" + Id );
        }

        #endregion
    }
}
