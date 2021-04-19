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
   public class RadioButton : System.Web.UI.WebControls.RadioButton
   {
      public string OnClientClick
      {
         get { return ( ViewState["ClientClick"] == null ? String.Empty : ViewState["ClientClick"].ToString() ); }
         set { ViewState["ClientClick"] = value;
         }
      }

      protected override void OnPreRender( EventArgs e )
      {
         if( !String.IsNullOrEmpty( OnClientClick ) ) this.Attributes.Add( "onclick", OnClientClick );
         base.OnPreRender( e );
      }

   }
}
