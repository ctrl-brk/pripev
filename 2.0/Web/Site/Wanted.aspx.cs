using System;
using Pripev.Utils.Web;

namespace Pripev.Web.UI.Wanted
{
    public partial class HtmlIndex : WebPage
    {
        private String _letters = "АД";

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if ( IsPostBack ) return;

            Master.Title = "*Разыскиваются файлы";
            litEmail.Text = Email.EmailLink( "ContactMail" );
        }

        protected void Page_PreRender( object sender, EventArgs e )
        {
            if ( IsPostBack && !IsCrossPagePostBack ) wntControl.Letters = _letters;
        }

        protected void lstTop_SelectedIndexChanged( object sender, EventArgs e )
        {
            _letters = lstTop.SelectedValue;
            lstBottom.SelectedIndex = lstTop.SelectedIndex;
        }

        protected void lstBottom_SelectedIndexChanged( object sender, EventArgs e )
        {
            _letters = lstBottom.SelectedValue;
            lstTop.SelectedIndex = lstBottom.SelectedIndex;
        }
    }
}
