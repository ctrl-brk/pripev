<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Artist.aspx.cs" Inherits="Pripev.Web.UI.Artist" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

   <asp:Literal ID='litNotFound' runat='server' Visible='false'><p>Извиняемся, но такого не найдено :(((</p></asp:Literal>
   <asp:Panel ID='pnlArtist' runat='server' CssClass='Artist' EnableViewState='false'>
      <asp:PlaceHolder ID='plhDetails' runat='server' EnableViewState='false'>
         <table class='photo' cellspacing='0' align='center'>
            <thead><tr><td><asp:Literal ID='litArtistName' runat='server' /></td></tr></thead>
            <tr><td>
               <asp:Image ID='imgArtist' runat='server' />
               <asp:Literal ID='litNoImage' runat='server' Visible='false'>
                  <p>А здесь могла бы быть картинка :(<br>
                  Но не нашел. Так что место вакантно.<br>
                  Если у вас есть таковая - просьба <a href='javascript:ShareInfo()'> прислать мне</a>.
               </asp:Literal>
            </td></tr>
         </table>
      </asp:PlaceHolder>
      <asp:PlaceHolder ID='plhAlbums' runat='server' EnableViewState='false'>
         <table cellspacing="0" class="tbl03" align='center'>
            <thead><tr><td colspan='12'>Дискография</td></tr></thead>
            <tr>
               <th>Обложка</th>
               <th class='name'>Название</th>
               <th>Год</th>
               <th class='chrd' title='Аккордов'>&nbsp;</th>
               <th class='txt' title="Текстов">&nbsp;</th>
               <th class='on' title="Звуков online">&nbsp;</th>
               <th class='off' title="Звуков">&nbsp;</th>
               <th class='mid' title="Midi">&nbsp;</th>
               <th class='kar' title="Karaoke"></th>
               <th class='mov' title='Видео'></th>
               <th class='lst' title="Послушать"></th>
               <th class='buy' title="Купить"></th>
            </tr>
            <asp:Repeater ID='rptAlbums' runat='server' OnItemDataBound='rptAlbums_ItemDataBound' EnableViewState='false'>
               <ItemTemplate>
                  <tr>
                     <td class='cov'>
                        <asp:HyperLink ID='lnkAlbum' runat='server' Width='50' Height='50' NavigateUrl= '<%# "/Album.aspx?Id=" + Eval( "Id" ) + "&Art=" + Eval( "ArtistId" ) %>' ImageUrl='<%# Eval( "SmallImage" ) %>' />
                        <asp:HyperLink ID='lnkNoAlbumImage' runat='server' NavigateUrl='javascript:ShareInfo()' Text='Прислать' Visible='false' />
                     </td>
                     <td runat='server' id='tdName' nowrap='nowrap' class='name'><asp:HyperLink ID='lnkAlbum1' runat='server' NavigateUrl= '<%# "/Album.aspx?Id=" + Eval( "Id" ) + "&Art=" + Eval( "ArtistId" ) %>' Text='<%# Eval( "Name" ) %>' /></td>
                     <td><%# Pripev.Utils.Convert.ToNBSPString( Eval( "Year" ) ) %></td>
                     <td class='chrd'><%# Pripev.Utils.Convert.ToNBSPString( Eval( "ChordNum" ) ) %></td>
                     <td class='txt'><%# Pripev.Utils.Convert.ToNBSPString( Eval( "TextNum" ) ) %></td>
                     <td class='on'><%# Pripev.Utils.Convert.ToNBSPString( Eval( "Mp3OnlineNum" ) ) %></td>
                     <td runat='server' id='tdSounds' class='off'>
                        <asp:Image ID='imgWanted' runat='server' ImageUrl='/Images/Wanted.gif' ToolTip='Разыскивается' EnableViewState='false' Visible='false' />
                        <asp:Literal id='litSounds' runat='server' EnableViewState='false' />
                     </td>
                     <td class='mid'><%# Pripev.Utils.Convert.ToNBSPString( Eval( "MidNum" ) ) %></td>
                     <td class='kar'><%# Pripev.Utils.Convert.ToNBSPString( Eval( "KarNum" ) ) %></td>
                     <td class='mov'><%# Pripev.Utils.Convert.ToNBSPString( Eval( "MovNum" ) ) %></td>
                     <td class='lst'>
                        <asp:HyperLink ID='lnkListen' runat='server' NavigateUrl='<%# Eval( "ListenLink" ) %>' EnableViewState='false'><img src='/Images/Listen.gif' border='0'></asp:HyperLink>
                        <asp:Literal id='litListen' runat='server' Text='&nbsp;' EnableViewState='false' Visible='false' />
                     </td>
                     <td class='buy'>
                        <asp:HyperLink ID='lnkBuy' runat='server' ImageUrl='/Images/ShoppingCart.gif' NavigateUrl='<%# Eval( "BuyURL" ) %>' ToolTip='Купить' EnableViewState='false' />
                        <asp:Literal id='litBuy' runat='server' Text='&nbsp;' EnableViewState='false' Visible='false' />
                     </td>
                  </tr>
               </ItemTemplate>
               <AlternatingItemTemplate>
                  <tr class='st01'>
                     <td class='cov'>
                        <asp:HyperLink ID='lnkAlbum' runat='server' Width='50' Height='50' NavigateUrl= '<%# "/Album.aspx?Id=" + Eval( "Id" ) + "&Art=" + Eval( "ArtistId" ) %>' ImageUrl='<%# Eval( "SmallImage" ) %>' />
                        <asp:HyperLink ID='lnkNoAlbumImage' runat='server' NavigateUrl='javascript:ShareInfo()' Text='Прислать' Visible='false' />
                     </td>
                     <td runat='server' id='tdName' nowrap='nowrap' class='name'><asp:HyperLink ID='lnkAlbum1' runat='server' NavigateUrl= '<%# "/Album.aspx?Id=" + Eval( "Id" ) + "&Art=" + Eval( "ArtistId" ) %>' Text='<%# Eval( "Name" ) %>' /></td>
                     <td><%# Pripev.Utils.Convert.ToNBSPString( Eval( "Year" ) ) %></td>
                     <td class='chrd'><%# Pripev.Utils.Convert.ToNBSPString( Eval( "ChordNum" ) ) %></td>
                     <td class='txt'><%# Pripev.Utils.Convert.ToNBSPString( Eval( "TextNum" ) ) %></td>
                     <td class='on'><%# Pripev.Utils.Convert.ToNBSPString( Eval( "Mp3OnlineNum" ) ) %></td>
                     <td runat='server' id='tdSounds' class='off'>
                        <asp:Image ID='imgWanted' runat='server' ImageUrl='/Images/Wanted.gif' ToolTip='Разыскивается' EnableViewState='false' Visible='false' />
                        <asp:Literal id='litSounds' runat='server' EnableViewState='false' />
                     </td>
                     <td class='mid'><%# Pripev.Utils.Convert.ToNBSPString( Eval( "MidNum" ) ) %></td>
                     <td class='kar'><%# Pripev.Utils.Convert.ToNBSPString( Eval( "KarNum" ) ) %></td>
                     <td class='mov'><%# Pripev.Utils.Convert.ToNBSPString( Eval( "MovNum" ) ) %></td>
                     <td class='lst'>
                        <asp:HyperLink ID='lnkListen' runat='server' NavigateUrl='<%# Eval( "ListenLink" ) %>' EnableViewState='false'><img src='/Images/Listen.gif' border='0'></asp:HyperLink>
                        <asp:Literal id='litListen' runat='server' Text='&nbsp;' EnableViewState='false' Visible='false' />
                     </td>
                     <td class='buy'>
                        <asp:HyperLink ID='lnkBuy' runat='server' ImageUrl='/Images/ShoppingCart.gif' NavigateUrl='<%# Eval( "BuyURL" ) %>' ToolTip='Купить' EnableViewState='false' />
                        <asp:Literal id='litBuy' runat='server' Text='&nbsp;' EnableViewState='false' Visible='false' />
                     </td>
                  </tr>
               </AlternatingItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder ID='plhFooter' runat='server'>
               <tfoot><tr><td colspan='12'><a href='/ArtistSongs.aspx?Id=<%=Request["Id"]%>'>Все песни</a></td></tr></tfoot>
            </asp:PlaceHolder>
         </table>
      </asp:PlaceHolder>

      <table cellspacing="0" class="tbl03" align='center' id='tblNoAlbums' runat='server' visible='false'>
         <thead><tr><td colspan='12'>Дискография</td></tr></thead>
         <tr><td style='border:none'>
            &nbsp;К сожалению, у меня пока нет дискографии этого исполнителя.&nbsp;<br>
            Если у вас есть таковая - просьба <a href='javascript:ShareInfo()'> прислать мне</a>.
         </td></tr>
      </table>

      <asp:Panel ID='pnlInfo' runat='server' CssClass='info' align='center' EnableViewState='false'>
         <h1>Историческая справка</h1>
         <asp:Literal ID='litInfo' runat='server' EnableViewState='false' />
      </asp:Panel>

      <asp:Panel ID='pnlLinks' runat='server' CssClass='info lnk' EnableViewState='false'>
         <h1>Ссылки</h1>
         <asp:Literal ID='litLinks' runat='server' EnableViewState='false' />
      </asp:Panel>

   </asp:Panel>
</asp:Content>
