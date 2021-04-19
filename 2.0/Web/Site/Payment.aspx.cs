using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pripev.Web.UI
{
   public partial class Payment : WebPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         Master.Title = "*Сделать подарок";
      }
   }
}
