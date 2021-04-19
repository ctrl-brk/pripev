using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pripev.Utils.Web;

namespace Pripev.Web.UI
{
   public partial class ShareInfo : WebPage
   {
      protected void Page_Load( object sender, EventArgs e )
      {
         litEmail.Text = Email.EmailLink( "SongsMail" );
      }
   }
}
