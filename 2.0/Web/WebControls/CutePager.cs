using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace Pripev.Web.UI.WebControls
{
   [ToolboxData( "<{0}:Pager runat=\"server\"></{0}:Pager>" )]
   public class Pager : WebControl, IPostBackEventHandler, INamingContainer
   {
      #region // PostBack Stuff
      private static readonly object EventCommand = new object();

      public event CommandEventHandler Command
      {
         add { Events.AddHandler( EventCommand, value ); }
         remove { Events.RemoveHandler( EventCommand, value ); }
      }

      protected virtual void OnCommand( CommandEventArgs e )
      {
         CommandEventHandler clickHandler = (CommandEventHandler)Events[EventCommand];
         if( clickHandler != null ) clickHandler( this, e );
      }

      void IPostBackEventHandler.RaisePostBackEvent( string eventArgument )
      {
         OnCommand( new CommandEventArgs( this.UniqueID, Convert.ToInt32( eventArgument ) ) );
      }
      #endregion

      #region // Accessors

      // private int _currentIndex; // currnet page
      private double _itemCount; // total count of rows
      private int _pageSize = 10; // the Size of items that can be displayed on page
      private int _pageCount; // Total No of Pages
      // private string _PageURLFormat = "ShowResults.aspx?page={0}"; // default value for url format
      private bool _showFirstLast = false; // to determine wheter show first and last link or not
      private bool _showAllLink = false;

      [Browsable( false )]
      public double ItemCount
      {
         get { return _itemCount; }
         set
         {
            _itemCount = value;

            double divide = ItemCount / PageSize;
            double ceiled = System.Math.Ceiling( divide );
            PageCount = Convert.ToInt32( ceiled );
         }
      }

      [Browsable( false )]
      public int CurrentIndex
      {
         get
         {
            if( ViewState["aspnetPagerCurrentIndex"] == null )
            {
               ViewState["aspnetPagerCurrentIndex"] = 1;
               return 1;
            }
            else
            {
               return Convert.ToInt32( ViewState["aspnetPagerCurrentIndex"] );
            }
            // return _currentIndex;
         }
         // set { _currentIndex = value; }
         set { ViewState["aspnetPagerCurrentIndex"] = value; }
      }

      [Category( "behaviouralSettings" )]
      public int PageSize
      {
         get { return _pageSize; }
         set { _pageSize = value; }
      }

      [Browsable( false )]
      public int PageCount
      {
         get { return _pageCount; }
         set { _pageCount = value; }
      }

      [Category( "behaviouralSettings" )]
      public bool ShowFirstLast
      {
         get { return _showFirstLast; }
         set { _showFirstLast = value; }
      }

      public bool ShowAllLink
      {
         get { return _showAllLink; }
         set { _showAllLink = value; }
      }

      // to enable/disable smart shortcuts
      private bool _enableSSC = true;
      [Category( "behaviouralSettings" )]
      public bool EnableSmartShortCuts
      {
         get { return _enableSSC; }
         set { _enableSSC = value; }
      }

      // the ration to count the space whithin the smartshortcut pages
      private double _sscRatio = 3.0D;
      [Category( "behaviouralSettings" )]
      public double SmartShortCutRatio
      {
         get { return _sscRatio; }
         set { _sscRatio = value; }
      }

      // first compacted group of visible page numbers
      private int _firstCompactedPageCount = 10;
      [Category( "behaviouralSettings" )]
      public int CompactedPageCount
      {
         get { return _firstCompactedPageCount; }
         set { _firstCompactedPageCount = value; }
      }

      // ordinary not compacted visible page numbers count
      private int _notCompactedPageCount = 15;
      [Category( "behaviouralSettings" )]
      public int NotCompactedPageCount
      {
         get { return _notCompactedPageCount; }
         set { _notCompactedPageCount = value; }
      }

      // maximum number of smart shortcuts
      private int _maxSmartShortCutCount = 6;
      [Category( "behaviouralSettings" )]
      public int MaxSmartShortCutCount
      {
         get { return _maxSmartShortCutCount; }
         set { _maxSmartShortCutCount = value; }
      }

      // the number which determines that the smart short cuts must be rendered if pagecount is morethatn specific number
      private int _sscThreshold = 30;
      [Category( "behaviouralSettings" )]
      public int SmartShortCutThreshold
      {
         get { return _sscThreshold; }
         set { _sscThreshold = value; }
      }

      // generate alt title for page indeces
      private bool _altEnabled = true;
      [Category( "behaviouralSettings" )]
      public bool AlternativeTextEnabled
      {
         get { return _altEnabled; }
         set { _altEnabled = value; }
      }

      #endregion

      #region // Globalized Section
      private string _GO = "go";
      private string _OF = "из";
      private string _FROM = "с";
      private string _PAGE = "Страница";
      private string _TO = "-";
      private string _SHOWING_RESULT = "Показаны";
      private string _SHOW_RESULT = "Показать";
      private string _BACK_TO_FIRST = "на первую страницу";
      private string _GO_TO_LAST = "на последнюю страницу";
      private string _BACK_TO_PAGE = "назад к странице";
      private string _NEXT_TO_PAGE = "вперед к странице";
      private string _LAST = "&gt;&gt;";
      private string _FIRST = "&lt;&lt;";
      private string _previous = "&lt;";
      private string _next = "&gt;";

      [Category( "GlobalizaionSettings" )]
      public string GoClause
      {
         get { return _GO; }
         set { _GO = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string OfClause
      {
         get { return _OF; }
         set { _OF = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string FromClause
      {
         get { return _FROM; }
         set { _FROM = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string PageClause
      {
         get { return _PAGE; }
         set { _PAGE = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string ToClause
      {
         get { return _TO; }
         set { _TO = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string ShowingResultClause
      {
         get { return _SHOWING_RESULT; }
         set { _SHOWING_RESULT = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string ShowResultClause
      {
         get { return _SHOW_RESULT; }
         set { _SHOW_RESULT = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string BackToFirstClause
      {
         get { return _BACK_TO_FIRST; }
         set { _BACK_TO_FIRST = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string GoToLastClause
      {
         get { return _GO_TO_LAST; }
         set { _GO_TO_LAST = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string BackToPageClause
      {
         get { return _BACK_TO_PAGE; }
         set { _BACK_TO_PAGE = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string NextToPageClause
      {
         get { return _NEXT_TO_PAGE; }
         set { _NEXT_TO_PAGE = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string LastClause
      {
         get { return _LAST; }
         set { _LAST = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string FirstClause
      {
         get { return _FIRST; }
         set { _FIRST = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string PreviousClause
      {
         get { return _previous; }
         set { _previous = value; }
      }

      [Category( "GlobalizaionSettings" )]
      public string NextClause
      {
         get { return _next; }
         set { _next = value; }
      }

      private bool _rightToLeft = false;
      [Category( "GlobalizaionSettings" )]
      public bool RTL
      {
         get { return _rightToLeft; }
         set { _rightToLeft = value; }
      }


      #endregion

      #region // Render Utilities
      private string GenerateAltMessage( int desiredPage )
      {
         if( desiredPage == -1 ) return ( "Разделить по страницам" );
         if( desiredPage == 0 ) return ( "Показать все записи" );

         StringBuilder altGen = new StringBuilder();
         altGen.Append( desiredPage == CurrentIndex ? ShowingResultClause : ShowResultClause );
         altGen.Append( " " );
         altGen.Append( ( ( desiredPage - 1 ) * PageSize ) + 1 );
         altGen.Append( " " );
         altGen.Append( ToClause );
         altGen.Append( " " );
         altGen.Append( desiredPage == PageCount ? ItemCount : desiredPage * PageSize );
         altGen.Append( " " );
         altGen.Append( OfClause );
         altGen.Append( " " );
         altGen.Append( ItemCount );

         return altGen.ToString();
      }

      private string GetAlternativeText( int index )
      {
         return AlternativeTextEnabled ? string.Format( " title=\"{0}\"", GenerateAltMessage( index ) ) : "";
      }

      private string RenderFirst()
      {
         string templateCell = "<td class=\"PagerOtherPageCells\"><a class=\"PagerHyperlinkStyle\" href=\"{0}\" title=\"" + " " + BackToFirstClause + " " + "\"> " + FirstClause + " </a></td>";
         // string templateURL = String.Format(PageURLFormat, "1");
         return String.Format( templateCell, Page.ClientScript.GetPostBackClientHyperlink( this, "1" ) );
      }

      private string RenderLast()
      {
         string templateCell = "<td class=\"PagerOtherPageCells\"><a class=\"PagerHyperlinkStyle\" href=\"{0}\" title=\"" + " " + GoToLastClause + " " + "\"> " + LastClause + " </a></td>";
         // string templateURL = String.Format(PageURLFormat, PageCount.ToString());
         return String.Format( templateCell, Page.ClientScript.GetPostBackClientHyperlink( this, PageCount.ToString() ) );
      }

      private string RenderBack()
      {
         string templateCell = "<td class=\"PagerOtherPageCells\"><a class=\"PagerHyperlinkStyle\" href=\"{0}\" title=\"" + " " + BackToPageClause + " " + ( CurrentIndex - 1 ).ToString() + "\"> " + PreviousClause + " </a></td>";
         // string templateURL = String.Format(PageURLFormat, (CurrentIndex - 1).ToString());
         return String.Format( templateCell, Page.ClientScript.GetPostBackClientHyperlink( this, ( CurrentIndex - 1 ).ToString() ) );
      }

      private string RenderNext()
      {
         string templateCell = "<td class=\"PagerOtherPageCells\"><a class=\"PagerHyperlinkStyle\" href=\"{0}\" title=\"" + " " + NextToPageClause + " " + ( CurrentIndex + 1 ).ToString() + "\"> " + NextClause + " </a></td>";
         // string templateURL = String.Format(PageURLFormat, (CurrentIndex + 1).ToString());
         return String.Format( templateCell, Page.ClientScript.GetPostBackClientHyperlink( this, ( CurrentIndex + 1 ).ToString() ) );
      }

      private string RenderCurrent()
      {
         // string altMessage = AlternativeTextEnabled ? string.Format(" title=\"{0}\"", GenerateAltMessage(CurrentIndex)) : "";
         return "<td class=\"PagerCurrentPageCell\"><span class=\"PagerHyperlinkStyle\" " + GetAlternativeText( CurrentIndex ) + " ><strong> " + CurrentIndex.ToString() + " </strong></span></td>";
      }

      private string RenderOther( int index )
      {
         string templateCell = "<td class=\"PagerOtherPageCells\"><a class=\"PagerHyperlinkStyle\" href=\"{0}\" " + GetAlternativeText( index ) + " > " + index.ToString() + " </a></td>";
         // string templateURL = String.Format(PageURLFormat, index.ToString());
         return String.Format( templateCell, Page.ClientScript.GetPostBackClientHyperlink( this, index.ToString() ) );
      }

      private string RenderSSC( int index )
      {
         string templateCell = "<td class=\"PagerSSCCells\"><a class=\"PagerHyperlinkStyle\" href=\"{0}\" " + GetAlternativeText( index ) + " > " + index.ToString() + " </a></td>";
         // string templateURL = String.Format(PageURLFormat, index.ToString());
         return String.Format( templateCell, Page.ClientScript.GetPostBackClientHyperlink( this, index.ToString() ) );
      }

      private string RenderAllLink()
      {
         string templateCell = "<td class=\"PagerInfoCell\"><a class=\"PagerHyperlinkStyle\" href=\"{0}\" " + GetAlternativeText( 0 ) + " >Все</a></td>";
         return String.Format( templateCell, Page.ClientScript.GetPostBackClientHyperlink( this, "0" ) );
      }

       private string RenderPagedLink()
       {
           string templateCell = "<td class=\"PagerInfoCell\"><a class=\"PagerHyperlinkStyle\" href=\"{0}\" " + GetAlternativeText( -1 ) + " >Постранично</a></td>";
           return String.Format(templateCell, Page.ClientScript.GetPostBackClientHyperlink(this, "1"));
       }
      #endregion

      #region // Smart ShortCut Stuff

      /* smart shortcut list calculator and list */

      private List<int> _smartShortCutList;
      private List<int> SmartShortCutList
      {
         get { return _smartShortCutList; }
         set { _smartShortCutList = value; }
      }

      private void CalculateSmartShortcutAndFillList()
      {
         _smartShortCutList = new List<int>();
         double shortCutCount = this.PageCount * SmartShortCutRatio / 100;
         double shortCutCountRounded = System.Math.Round( shortCutCount, 0 );
         if( shortCutCountRounded > MaxSmartShortCutCount ) shortCutCountRounded = MaxSmartShortCutCount;
         if( shortCutCountRounded == 1 ) shortCutCountRounded++;

         for( int i = 1; i < shortCutCountRounded + 1; i++ )
         {
            int calculatedValue = (int)( System.Math.Round( ( this.PageCount * ( 100 / shortCutCountRounded ) * i / 100 ) * 0.1, 0 ) * 10 );
            if( calculatedValue >= this.PageCount ) break;
            SmartShortCutList.Add( calculatedValue );
         }
      }

      /* smart shortcut list calculator and list */


      private void RenderSmartShortCutByCriteria( int basePageNumber, bool getRightBand, HtmlTextWriter writer )
      {
         if( IsSmartShortCutAvailable() )
         {

            List<int> lstSSC = this.SmartShortCutList;

            int rVal = -1;
            // bool allowRender = false;

            if( getRightBand )
            {
               for( int i = 0; i < lstSSC.Count; i++ )
               {
                  if( lstSSC[i] > basePageNumber )
                  {
                     rVal = i;
                     // sometimes we dont reach here and inappropriate ssc show's up
                     // allowRender = true;
                     break;
                  }
               }

               if( rVal >= 0 )
               {
                  for( int i = rVal; i < lstSSC.Count; i++ )
                  {
                     if( lstSSC[i] != basePageNumber )
                     {
                        writer.Write( RenderSSC( lstSSC[i] ) );
                     }
                     //System.Web.HttpContext.Current.Response.Write(lstSSC.Count.ToString() + "<br/>");
                     //System.Web.HttpContext.Current.Response.Write("right "+i.ToString() + "<br/>");
                     //System.Web.HttpContext.Current.Response.Write(lstSSC[0].ToString() + "<br/>");
                  }
               }


            }
            else if( !getRightBand )
            {

               for( int i = 0; i < lstSSC.Count; i++ )
               {
                  if( basePageNumber > lstSSC[i] )
                  {
                     rVal = i;
                     // sometimes we dont reach here and inappropriate ssc show's up
                     // allowRender = true;
                     // break;
                  }
               }

               if( rVal >= 0 )
               {
                  for( int i = 0; i < rVal + 1; i++ )
                  {
                     if( lstSSC[i] != basePageNumber )
                     {
                        writer.Write( RenderSSC( lstSSC[i] ) );
                     }
                     //System.Web.HttpContext.Current.Response.Write(lstSSC.Count.ToString() +"<br/>");
                     //System.Web.HttpContext.Current.Response.Write("left " + i.ToString() + "<br/>");
                     // System.Web.HttpContext.Current.Response.Write(lstSSC[i].ToString());
                  }
               }



            }

         }

      }


      bool IsSmartShortCutAvailable()
      {
         return this.EnableSmartShortCuts && this.SmartShortCutList != null && this.SmartShortCutList.Count != 0;
      }
      #endregion

      #region // Override Control's Render operation
      protected override void Render( HtmlTextWriter writer )
      {
         if( Page != null ) Page.VerifyRenderingInServerForm( this );
        
         if( this.PageCount > this.SmartShortCutThreshold )
         {
            if( EnableSmartShortCuts ) CalculateSmartShortcutAndFillList();
         }

         writer.AddAttribute( HtmlTextWriterAttribute.Cellpadding, "3" );
         writer.AddAttribute( HtmlTextWriterAttribute.Cellspacing, "1" );
         writer.AddAttribute( HtmlTextWriterAttribute.Border, "0" );
         writer.AddAttribute( HtmlTextWriterAttribute.Class, "PagerContainerTable" );
         if( RTL ) writer.AddAttribute( HtmlTextWriterAttribute.Dir, "rtl" );
         writer.RenderBeginTag( HtmlTextWriterTag.Table );

         writer.RenderBeginTag(HtmlTextWriterTag.Tr);
             
          if (ShowAllLink)
          {
             writer.AddAttribute(HtmlTextWriterAttribute.Class, "PagerInfoCell");
             writer.RenderBeginTag( HtmlTextWriterTag.Td );
             writer.Write( PageClause + " " + CurrentIndex.ToString() + " " + OfClause + " " + PageCount.ToString() );
             writer.RenderEndTag();

             if (ShowFirstLast && CurrentIndex != 1)
                 writer.Write(RenderFirst());

             if (CurrentIndex != 1)
                 writer.Write(RenderBack());

             if (CurrentIndex < CompactedPageCount)
             {

                 if (CompactedPageCount > PageCount) CompactedPageCount = PageCount;

                 for (int i = 1; i < CompactedPageCount + 1; i++)
                 {
                     if (i == CurrentIndex)
                     {
                         writer.Write(RenderCurrent());
                     }
                     else
                     {
                         writer.Write(RenderOther(i));
                     }
                 }

                 RenderSmartShortCutByCriteria(CompactedPageCount, true, writer);

             }
             else if (CurrentIndex >= CompactedPageCount && CurrentIndex < NotCompactedPageCount)
             {

                 if (NotCompactedPageCount > PageCount) NotCompactedPageCount = PageCount;

                 for (int i = 1; i < NotCompactedPageCount + 1; i++)
                 {
                     if (i == CurrentIndex)
                     {
                         writer.Write(RenderCurrent());
                     }
                     else
                     {
                         writer.Write(RenderOther(i));
                     }
                 }

                 RenderSmartShortCutByCriteria(NotCompactedPageCount, true, writer);

             }
             else if (CurrentIndex >= NotCompactedPageCount)
             {
                 int gapValue = NotCompactedPageCount / 2;
                 int leftBand = CurrentIndex - gapValue;
                 int rightBand = CurrentIndex + gapValue;


                 RenderSmartShortCutByCriteria(leftBand, false, writer);

                 for (int i = leftBand; (i < rightBand + 1) && i < PageCount + 1; i++)
                 {
                     if (i == CurrentIndex)
                     {
                         writer.Write(RenderCurrent());
                     }
                     else
                     {
                         writer.Write(RenderOther(i));
                     }
                 }

                 if (rightBand < this.PageCount)
                 {

                     RenderSmartShortCutByCriteria(rightBand, true, writer);
                 }
             }

             if (CurrentIndex != PageCount)
                 writer.Write(RenderNext());

             if (ShowFirstLast && CurrentIndex != PageCount)
                 writer.Write(RenderLast());

             if (PageCount > 1) writer.Write(RenderAllLink());
         }
         else if (PageCount > 1)
         {
             writer.Write(RenderPagedLink());
         }

         writer.RenderEndTag();

         writer.RenderEndTag();

         base.Render( writer );
      }
      #endregion
   }
}
