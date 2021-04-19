using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pripev.Web.UI.WebControls
{
   [ToolboxData( "<{0}:NavLetters runat=server></{0}:NavLetters>" )]
   public class NavLetters : Pripev.Web.UI.WebControls.WebControl
   {
      [Bindable( false )]
      [Category( "Appearance" )]
      [Localizable( true )]
      protected override void Render( HtmlTextWriter writer )
      {
         String sLetters = "АБВГДЖЗИКЛМНОПРСТУФХЦЧШЭЮЯ";
         StringBuilder sb = new StringBuilder();

         foreach ( Char c in sLetters )
         {
            sb.Append( "<a href='/Artists.aspx?Letter=" + c + "' title='Исполнители на букву " + c + "'>" + c + "</a>" );
         }

         sb.Append( "<a href='/Artists.aspx?Letter=L' title='Нерусские названия'>A-Z</a>" );
         sb.Append( "<a href='/Artists.aspx?Letter=1' title='Цифры'>0-9</a>" );

         writer.Write( sb.ToString() );
      }
   }
}
