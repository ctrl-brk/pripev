using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Data;

namespace Pripev.Web.UI.WebControls
{
    [DefaultProperty( "Letter" )]
    public class ArtistList : WebControl
    {
        private char? _letter;
        private char _curLetter = '|';
        private int _nRow;

        [Bindable( true )]
        [Category( "Appearance" )]
        public char? Letter
        {
            get { return (_letter); }
            set { _letter = value; }
        }

        public String LinkTemplate { get; set; }

        public int Count
        {
            get { return (_nRow); }
        }

        private static String Footer
        {
            get { return ("</table>"); }
        }

        private String Header
        {
            get { return (@"
<table class='tbl03' cellspacing='0' style='width:600px;' align='center'>
   <thead><tr><td colspan='10'>" + _curLetter + @"</td></tr></thead>
   <tr>
      <th>Имя</th>
      <th class='alb' title='Альбомов'>&nbsp;</th>
      <th class='cd' title='CD в наличии'>&nbsp;</th>
      <th class='chrd' title='Аккордов'>&nbsp;</th>
      <th class='txt' title='Текстов'>&nbsp;</th>
      <th class='on' title='Звуков online'>&nbsp;</th>
      <th class='off' title='Информации о файлах'>&nbsp;</th>
      <th class='mid' title='Midi'>&nbsp;</th>
      <th class='kar' title='Karaoke'>&nbsp;</th>
      <th class='mov' title='Video'>&nbsp;</th>
   </tr>"); }
        }

        protected override void Render( HtmlTextWriter writer )
        {
            var sb = new StringBuilder( 10*1024 );
            var dt = DAL.DB.ExecuteDataTable( "exec GetArtistList @Letter=" + Utils.Convert.ToSQLString( _letter ) );
            
            foreach ( DataRow dr in dt.Rows )
            {
                var artistId = Convert.ToInt32( dr["AKA"] != DBNull.Value ? dr["AKA"] : dr["ARTIST_ID"] );

                if ( _curLetter != Convert.ToChar( dr["LETTER"] ) )
                {
                    _curLetter = Convert.ToChar( dr["LETTER"] );
                    if ( _nRow > 0 ) sb.Append( Footer );
                    sb.Append( Header );
                }
                sb.Append( "<tr" );
                if ( _nRow%2 != 0 ) sb.Append( "class='st01'" );
                sb.Append( "><td class='name'><a href='" );
                sb.Append( LinkTemplate + artistId + "'>" );
                sb.Append( dr["NAME"] + "</a></td>" );
                sb.Append( "<td class='alb'>" + dr["ALBUMS"] + "</td>" );
                sb.Append( "<td class='cd'>" + dr["CD"] + "</td>" );
                sb.Append( "<td class='chrd'>" + dr["CHORDS"] + "</td>" );
                sb.Append( "<td class='txt'>" + dr["TEXTS"] + "</td>" );
                sb.Append( "<td class='on'>" + dr["MP3ONLINE"] + "</td>" );
                sb.Append( "<td class='off'>" + dr["MP3"] + "</td>" );
                sb.Append( "<td class='mid'>" + dr["MID"] + "</td>" );
                sb.Append( "<td class='kar'>" + dr["KAR"] + "</td>" );
                sb.Append( "<td class='mov'>" + dr["MOV"] + "</td>" );
                sb.Append( "</tr>" );

                _nRow++;
            }

            if ( _nRow > 0 ) sb.Append( Footer );
            writer.Write( sb );
        }
    }
}
