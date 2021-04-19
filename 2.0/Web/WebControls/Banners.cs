using System;
using System.ComponentModel;
using System.Web.UI;

namespace Pripev.Web.UI.WebControls
{
    public enum BannerProvider
    {
        AdSense,
        Music,
        RLE,
        RBC,
        SpyLog,
        Rambler,
        MailRu,
        HotLog
    }

    [DefaultProperty( "Provider" )]
    [ToolboxData( "<{0}:Banner runat=server></{0}:Banner>" )]
    public class Banner : WebControl
    {
        [Bindable( true )]
        [Category( "Appearance" )]
        //[DefaultValue( 1 )]
        [Localizable( false )]
        public BannerProvider Provider
        {
            get { return (ViewState["Provider"] == null ? BannerProvider.AdSense : (BannerProvider)ViewState["Provider"]); }

            set { ViewState["Provider"] = value; }
        }

        [Bindable( true )]
        [Category( "Appearance" )]
        [DefaultValue( "" )]
        [Localizable( false )]
        public string Params
        {
            get { return ((String)ViewState["Params"] ?? String.Empty); }
            set { ViewState["Params"] = value; }
        }

        private string RenderAdSense()
        {
            if ( Params == "TopRight" )
            {
                return (@"<script type='text/javascript'><!--
                   google_ad_client = 'pub-8339128551371595';
                   google_alternate_ad_url = 'http://ad.bannerbank.ru/bb.cgi?cmd=ad&pubid=44739801&pg=1&vbn=108&w=468&h=60&num=|bnum|&r=ssi&ssi=nofillers&r=ssi';
                   google_ad_width = 468;
                   google_ad_height = 60;
                   google_ad_format = '468x60_as';
                   google_ad_type = 'text_image';
                   //2007-08-09: TopRight
                   google_ad_channel = '3086556252';
                   google_color_border = '804000';
                   google_color_bg = 'FFFFCC';
                   google_color_link = '0066CC';
                   google_color_text = '000000';
                   google_color_url = 'CC0000';
                   google_ui_features = 'rc:0';
                   //-->
                </script>
                <script type='text/javascript'
                   src='http://pagead2.googlesyndication.com/pagead/show_ads.js'>
                </script>");
            }
            if ( Params == "Bottom" )
            {
                return (@"<script type='text/javascript'><!--
                   google_ad_client = 'pub-8339128551371595';
                   google_ad_width = 728;
                   google_ad_height = 90;
                   google_ad_format = '728x90_as';
                   google_ad_type = 'text_image';
                   //2007-08-09: Bottom
                   google_ad_channel = '6090069641';
                   google_color_border = '804000';
                   google_color_bg = 'FFFFCC';
                   google_color_link = '0066CC';
                   google_color_text = '000000';
                   google_color_url = 'CC0000';
                   google_ui_features = 'rc:6';
                   //-->
                </script>
                <script type='text/javascript'
                   src='http://pagead2.googlesyndication.com/pagead/show_ads.js'>
                </script>");
            }
            return (String.Empty);
        }

        private static String RenderMusicCounter()
        {
            return ("<a href='http://musiccounter.ru' target='_blank'><img src='http://musiccounter.ru/hit.pl?id=2976&style=1' height='40' width='88' border='0'></a>");
        }

        private static String RenderSpyLogCounter()
        {
            return (@"<script language=""javascript""><!--
   Mu=""u1425.60.spylog.com"";Md=document;Mnv=navigator;Mp=0;
   Md.cookie=""b=b"";Mc=0;if(Md.cookie)Mc=1;Mrn=Math.random();
   Mn=(Mnv.appName.substring(0,2)==""Mi"")?0:1;Mt=(new Date()).getTimezoneOffset();
   Mz=""p=""+Mp+""&rn=""+Mrn+""&c=""+Mc+""&t=""+Mt;
   if(self!=top){Mfr=1;}else{Mfr=0;}Msl=""1.0"";
   //--></script><script language=""javascript1.1""><!--
   Mpl="""";Msl=""1.1"";Mj = (Mnv.javaEnabled()?""Y"":""N"");Mz+='&j='+Mj;
   //--></script><script language=""javascript1.2""><!-- 
   Msl=""1.2"";Ms=screen;Mpx=(Mn==0)?Ms.colorDepth:Ms.pixelDepth;
   Mz+=""&wh=""+Ms.width+'x'+Ms.height+""&px=""+Mpx;
   //--></script><script language=""javascript1.3""><!--
   Msl=""1.3"";//--></script><script language=""javascript""><!--
   My="""";My+=""<a href='http://""+Mu+""/cnt?cid=142560&f=3&p=""+Mp+""&rn=""+Mrn+""' target='_blank'>"";
   My+=""<img src='http://""+Mu+""/cnt?cid=142560&""+Mz+""&sl=""+Msl+""&r=""+escape(Md.referrer)+""&fr=""+Mfr+""&pg=""+escape(window.location.href);
   My+=""' border=0 width=88 height=31 alt='SpyLOG'>"";
   My+=""</a>"";Md.write(My);//--></script><noscript>
   <a href=""http://u1425.60.spylog.com/cnt?cid=142560&f=3&p=0"" target=""_blank"">
   <img src=""http://u1425.60.spylog.com/cnt?cid=142560&p=0"" alt='SpyLOG' border='0' width=88 height=31 >
   </a></noscript>");
        }

        private static String RenderRamblerCounter()
        {
            return ("<a href='http://top100.rambler.ru/top100/' target='_blank'><img src='http://counter.rambler.ru/top100.cnt?473919' alt=\"Rambler's Top100\" width='81' height='63' border='0'></a>");
        }

        private static String RenderMailRuCounter()
        {
            return (@"<script language=""JavaScript""><!--
   d=document;a='';a+=';r='+escape(d.referrer)
   js=10//--></script><script language=""JavaScript1.1""><!--
   a+=';j='+navigator.javaEnabled()
   js=11//--></script><script language=""JavaScript1.2""><!--
   s=screen;a+=';s='+s.width+'*'+s.height
   a+=';d='+(s.colorDepth?s.colorDepth:s.pixelDepth)
   js=12//--></script><script language=""JavaScript1.3""><!--
   js=13//--></script><script language=""JavaScript""><!--
   d.write('<a href=""http://top.mail.ru/jump?from=182433""'+
   ' target=_blank><img src=""http://top.list.ru/counter'+
   '?id=182433;t=56;js='+js+a+';rand='+Math.random()+
   '"" alt=""Рейтинг@Mail.ru""'+' border=0 height=31 width=88></a>')
   if(js>11)d.write('<'+'!-- ')//--></script><noscript><a
   target=_blank href=""http://top.mail.ru/jump?from=182433""><img
   src=""http://top.list.ru/counter?js=na;id=182433;t=56""
   border=0 height=31 width=88
   alt=""Рейтинг@Mail.ru""></a></noscript><script language=""JavaScript""><!--
   if(js>11)d.write('--'+'>')//--></script>");
        }

        private static String RenderHotLogCounter()
        {
            return (@"<script language=""javascript"">
   hotlog_js=""1.0"";
   hotlog_r=""""+Math.random()+""&s=115661&im=101&r=""+escape(document.referrer)+""&pg=""+
   escape(window.location.href);
   document.cookie=""hotlog=1; path=/""; hotlog_r+=""&c=""+(document.cookie?""Y"":""N"");
   </script><script language=""javascript1.1"">
   hotlog_js=""1.1"";hotlog_r+=""&j=""+(navigator.javaEnabled()?""Y"":""N"")</script>
   <script language=""javascript1.2"">
   hotlog_js=""1.2"";
   hotlog_r+=""&wh=""+screen.width+'x'+screen.height+""&px=""+
   (((navigator.appName.substring(0,3)==""Mic""))?
   screen.colorDepth:screen.pixelDepth)</script>
   <script language=""javascript1.3"">hotlog_js=""1.3""</script>
   <script language=""javascript"">hotlog_r+=""&js=""+hotlog_js;
   document.write(""<a href='http://click.hotlog.ru/?115661' target='_top'><img ""+
   "" src='http://hit5.hotlog.ru/cgi-bin/hotlog/count?""+
   hotlog_r+""&' border=0 width=88 height=31 alt=HotLog></a>"")</script>
   <noscript><a href=http://click.hotlog.ru/?115661 target=_top><img
   src=""http://hit5.hotlog.ru/cgi-bin/hotlog/count?s=115661&im=101"" border=0 
   width=""88"" height=""31"" alt=""HotLog""></a></noscript>");
        }

        protected override void Render( HtmlTextWriter writer )
        {
            var str = String.Empty;

            switch ( Provider )
            {
                case BannerProvider.AdSense:
                    str = RenderAdSense();
                    break;
                case BannerProvider.Music:
                    str = RenderMusicCounter();
                    break;
                case BannerProvider.SpyLog:
                    str = RenderSpyLogCounter();
                    break;
                case BannerProvider.Rambler:
                    str = RenderRamblerCounter();
                    break;
                case BannerProvider.MailRu:
                    str = RenderMailRuCounter();
                    break;
                case BannerProvider.HotLog:
                    str = RenderHotLogCounter();
                    break;
            }
            writer.Write( str );
        }
    }
}
