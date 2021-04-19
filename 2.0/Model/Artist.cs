using System;
using System.Data;

namespace Pripev.Model
{
    public class Artist : IModel
    {
        public Artist() {}

        public Artist( int? id )
        {
            Id = id;
            Retrieve();
        }

        public Artist( String name )
        {
            Name = name;
            Retrieve();
        }

        #region // Public properties

        public int? Id { get; private set; }

        public String Name  { get; set; }

        public String Name1 { get; set; }

        public int? Aka { get; set; }

        public char? Letter { get; set; }

        public String Image { get; set; }

        public String InfoText { get; set; }

        public String LinksText { get; set; }

        public char? ListFlag { get; private set; }

        public char? DetailsFlag { get; set; }

        public int? Songs { get; private set; }

        public int? Texts { get; private set; }

        public int? Chords { get; private set; }

        public int? Mp3 { get; private set; }

        public int? Mid { get; private set; }

        public int? Kar { get; private set; }

        public int? Mov { get; private set; }

        public Int16? Albums { get; private set; }

        public Int16? Cd { get; private set; }

        public DateTime? Added { get; private set; }

        public int? CreatedBy { get; private set; }

        public int? ModifiedBy { get; private set; }

        public DateTime? ModifiedOn { get; private set; }

        #endregion

        #region // IModel

        public void Clear() {}

        public void Retrieve()
        {
            DataRow dr;

            if ( Id.HasValue )
                dr = DAL.DB.ExecuteDataRow( "exec usp_GetArtist @ArtistId=" + Id );
            else if ( !String.IsNullOrEmpty( Name ) )
                dr = DAL.DB.ExecuteDataRow( "exec usp_GetArtistByName @ArtistName=" + Utils.Convert.ToSQLString( Name ) );
            else
                return;

            Id = dr.Field<int>("ARTIST_ID");
            Letter = dr.Field<string>("LETTER")[0];
            Name = dr.Field<string>("Name");
            Name1 = dr.Field<string>("Name1");
            Image = dr.Field<string>("IMAGE");
            Added = dr.Field<DateTime>("ADDED");
            if ( dr["AKA"] != DBNull.Value ) Aka = dr.Field<int>("AKA");
            Albums = dr.Field<byte>("ALBUMS");
            Cd = dr.Field<byte>("CD");
            Songs = dr.Field<int>("SONGS");
            Texts = dr.Field<int>("TEXTS");
            Chords = dr.Field<int>("CHORDS");
            Mp3 = dr.Field<int>("MP3");
            Mid = dr.Field<int>("MID");
            Kar = dr.Field<int>("KAR");
            Mov = dr.Field<int>("MOV");
            CreatedBy = dr.Field<int>("CreatedBy");
            ModifiedBy = dr.Field<int?>("ModifiedBy");
            ModifiedOn = dr.Field<DateTime?>("ModifiedOn");
            ListFlag = dr.Field<string>("ListFlag")[0];
            DetailsFlag = dr.Field<string>("DetailsFlag")[0];
            InfoText = dr.Field<string>("InfoText");
            LinksText = dr.Field<string>("LinksText");
        }

        public void Save( int userId )
        {
            var sql = string.Format( "exec usp_UpdateArtist @Id={0},@Letter={1},@Name={2},@Name1={3},@Image={4},@InfoText={5},@LinksText={6},@AKA={7},@ModifiedBy={8}",
                                     Utils.Convert.ToSQL( Id ), Utils.Convert.ToSQLString( Letter ), Utils.Convert.ToSQLString( Name ), Utils.Convert.ToSQLString( Name1 ),
                                     Utils.Convert.ToSQLString( Image ), Utils.Convert.ToSQLString( InfoText ), Utils.Convert.ToSQLString( LinksText ),
                                     Utils.Convert.ToSQLString( Aka ), Utils.Convert.ToSQLString( ModifiedBy ) );

            Id = Convert.ToInt32( DAL.DB.ExecuteScalar( sql ) );
        }

        public void Delete() {}

        #endregion
    }
}
