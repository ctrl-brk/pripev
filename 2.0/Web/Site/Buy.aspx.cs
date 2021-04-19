using System;
using Pripev.DAL;
using Pripev.Utils.Web;

namespace Pripev.Web.UI
{
    public partial class Buy : WebPage
    {
        private int _productId;

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            Master.Title = "Купить чуток припевов";
            litEmail.Text = Email.EmailLink( "ContactMail" );

            try
            {
                _productId = Convert.ToInt32( Request["ProductId"] );
            }
            catch {}

            if ( _productId == 0 )
            {
                plhData.Visible = false;
                plhNotFound.Visible = true;
            }
            else
            {
                var dt = DB.ExecuteDataTable( "exec GetPartnerLinks @ProductId=" + _productId + ",@ProductType=" + Utils.Convert.ToSQLString( Request["ProductType"] ) );

                if ( dt.Rows.Count == 0 )
                {
                    plhData.Visible = false;
                    plhNotFound.Visible = true;
                }
                else
                {
                    litTitle.Text = dt.Rows[0]["Artist"] + " - " + dt.Rows[0]["Album"];
                    rptData.DataSource = dt;
                    rptData.DataBind();
                }
            }
        }
    }
}
