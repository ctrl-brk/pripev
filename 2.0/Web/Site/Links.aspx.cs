using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pripev.Web.UI
{
   public partial class Links : WebPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         if ( !IsPostBack )
         {
            BLL.Counter.CountLinks();
            Master.Title = "*Музыкальные ссылки";
         }
      }
   }
}
