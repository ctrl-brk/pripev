using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using WebControlCaptcha;

namespace Pripev.Web.UI
{
   public partial class GuestBook : ExpiredWebPage
   {
      private bool _isSubmit = false;

      protected void Page_Load( object sender, EventArgs e )
      {
         Master.Title = "*Гостевая";
      }

      protected void Page_LoadComplete( object sender, EventArgs e )
      {
         if ( IsCrossPagePostBack ) return;

         if( IsPostBack )
         {
            if( _isSubmit )
            {
               if( !((IValidator)CaptchaControl1).IsValid )
               {
                  lblAlert.Text = ( (IValidator)CaptchaControl1 ).ErrorMessage + "<br>Попробуйте еще раз.";
                  Pager1.Visible = false;
                  return;
               }
               else SaveMessage();
            }

         }
         Pager1.Visible = true;
         LoadData();
      }

      private void LoadData()
      {
         BLL.GuestBook l = new BLL.GuestBook( _PageIndex, 10, _ShowAllPages );
         Pager1.ItemCount = l.TotalCount;
         rptBook.DataSource = l;
         rptBook.DataBind();
      }

      private void SaveMessage()
      {
         if( Page.IsValid )
         {
            BLL.GuestBookRecord r = new Pripev.BLL.GuestBookRecord();
            r.UserName = txtName.Text;
            r.UserEmail = txtEmail.Text;
            r.Text = txtMsg.Text;
            r.Save();
         }
      }

      private int _PageIndex
      {
         get { return ( ViewState["PageIndex"] == null ? 1 : (int)ViewState["PageIndex"] ); }
         set { ViewState["PageIndex"] = value; }
      }

      private bool _ShowAllPages
      {
         get { return ( ViewState["ShowAllPages"] == null ? false : (bool)ViewState["ShowAllPages"] ); }
         set { ViewState["ShowAllPages"] = value; }
      }

      protected void rptBook_ItemDataBound( Object Sender, RepeaterItemEventArgs e )
      {
         if( e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )
         {
            BLL.GuestBookRecord rec = (BLL.GuestBookRecord)e.Item.DataItem;

            Literal litHead = (Literal)e.Item.FindControl( "litHead" );
            Literal litText = (Literal)e.Item.FindControl( "litText" );

            StringBuilder sb = new StringBuilder( rec.Date );

            if( !String.IsNullOrEmpty( rec.UserEmail ) && Master.CurrentUser.bAdmin )
            {
               sb.Append( " - <a href='mailto:" + rec.UserEmailHtml + "'>" );
               sb.Append( String.IsNullOrEmpty( rec.UserName ) ? rec.UserEmailHtml : rec.UserNameHtml );
               sb.Append( "</a>" );
            }
            else if( !String.IsNullOrEmpty( rec.UserName ) )
            {
               sb.Append( " - " );
               sb.Append( rec.UserNameHtml );
            }

            litHead.Text = sb.ToString();
            litText.Text = rec.TextHtml;
         }
      }

      protected void Pager1_Command( object sender, CommandEventArgs e )
      {
         _PageIndex = Convert.ToInt32( e.CommandArgument );
         if( _PageIndex == 0 ) { _ShowAllPages = true; Pager1.ShowAllLink = false; }
         else
         {
            _ShowAllPages = false;
            Pager1.CurrentIndex = _PageIndex;
            Pager1.Visible = true;
         }
         LoadData();
      }

      protected void btnSubmit_Click( object sender, EventArgs e )
      {
         _isSubmit = true;
      }

   }
}
