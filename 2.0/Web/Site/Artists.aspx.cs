using System;
using Pripev.Utils.Web;

namespace Pripev.Web.UI
{
    public partial class Artists : ModifiedWebPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if ( IsCrossPagePostBack ) return;

            lstArtists.Letter = Tools.RequestLetter( "Letter" );
            switch ( lstArtists.Letter )
            {
                case null:
                    Master.Title = "*Список исполнителей";
                    break;
                case 'L':
                    Master.Title = "*Исполнители с типа английскими названиями";
                    break;
                case '1':
                    Master.Title = "*Исполнители с цифрами :)";
                    break;
                default:
                    Master.Title = "*Исполнители на букву '" + lstArtists.Letter + "'";
                    break;
            }
        }

        protected override DateTime LastModificationDate
        {
            get { return (BLL.Stats.GetArtistsUpdateTime()); }
        }

    }
}
