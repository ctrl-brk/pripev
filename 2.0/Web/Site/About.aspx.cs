using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pripev.Utils.Web;

namespace Pripev.Web.UI
{
   public partial class About : WebPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         BLL.Counter.CountAbout();

         Master.Title = "О проекте \"Припев!\"";
         litEmail.Text = litEmail1.Text = Email.EmailLink( "ContactMail" );
      }
   }
}
