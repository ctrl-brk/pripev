using System;
using System.Configuration;
using Pripev.Utils.Web;

namespace Pripev.BLL
{
    public class Text
    {
        #region OOO Message
        private const String OooMsg = @"В связи с тем, что некое ооо ""контент и право""
обладает всеми мыслимыми и немыслимыми правами
на любую существующую в природе информацию,
а так же получает несказанное удовольствие
от судебных процессов по поводу и без,
то во избежание предоставления им такового удовольствия,
текст данного произведения доступен только по предъявлению
разрешения на то вышеуказанного ооо.

Советую обратиться на их сайт <a href='http://www.e-now.ru' target='_blank'>www.e-now.ru</a>,
где они вам его любезно продадут.
Ежели у них нет такового - требуйте и ругайтесь матом.

Кстати, если они вам продадут текст с аккордами -
проверьте наличие у них письменного договора
с автором подбора. В случае отсутствия - можете подавать
в суд. Неплохой способ разбогатеть.
Если же аккордов (табулатур, проигрышей) нет,
то это некачественный товар. Требуйте возврата
денег и обращайтесь в общество защиты прав потребителя.";
        #endregion

        private string OwnerMsg { get; set; }
        public int? Id { get; private set; }
        public int? SongId { get; private set; }
        public int? AlbumId { get; private set; }
        public int? ArtistId { get; private set; }
        public bool HasChords { get; private set; }
        private string RawText { get; set; }

        public Text( int? id )
        {
            Id = id;
            if ( Id != null ) LoadData();
        }

        public Text( String id ) : this( Convert.ToInt32( id ) ) {}

        public Text( int? id, String ownerMsg ) : this( id )
        {
            OwnerMsg = ownerMsg;
        }

        public Text( int? id, String ownerMsg, int? songId, int? albumId, int? artistId ) : this( id )
        {
            OwnerMsg = ownerMsg;
            SongId = songId;
            AlbumId = albumId;
            ArtistId = artistId;
        }

        private void LoadData()
        {
            var dr = DAL.DB.ExecuteDataRow( "exec GetText @CodeVersion=2.0, @CheckOwner='Y', @TextId=" + Id );
            if ( dr == null )
            {
                Id = null;
                return;
            }
            RawText = dr["TextData"].ToString();
            HasChords = Convert.ToInt32( dr["CHORDS"] ) == 1;
        }

        public String GetHTML( WebUser usr )
        {
            var s = RawText;
            var cLevel = ConfigurationManager.AppSettings["CopyrightLevel"];

            switch(cLevel)
            {
                case "OOO" :
                    if ( !usr.bLoggedIn && !Tools.IsRobot() ) s = OooMsg;
                    break;
                case "Low" :
                    if ( !String.IsNullOrEmpty( OwnerMsg ) ) s = OwnerMsg;
                    break;
            }
        
            return ("<pre>" + s + "</pre>");
        }
    }
}
