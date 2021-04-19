<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="Pripev.Web.UI.Home" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='cplhMenu1' ID='contentMenu1' runat='server'>
   <asp:Panel ID='pnlComm' runat='server' CssClass='comm' Visible='false'>
      <h1>Реклама</h1>
      А здесь могла бы быть Ваша реклама
   </asp:Panel>
</asp:Content>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<div class='Home'>

<table border="0" cellpadding="0" width='99%'>
   <tr>
      <td width='305' valign='top'>
         <table border="0" cellspacing="0" class="tbl01 stat" width='100%'>
            <thead><tr><td colspan="4">Чего тут есть</td></tr></thead>
            <tr>
               <td>Исполнителей:</td><td><asp:Label ID='lblArtists' runat='server' EnableViewState='false' /></td>
               <td>Альбомов:</td><td><asp:Label ID='lblAlbums' runat='server' EnableViewState='false' /></td>
            </tr>
            <tr>
               <td>Tекстов:</td><td><asp:Label ID='lblTexts' runat='server' EnableViewState='false' /></td>
               <td>...с табами:</td><td><asp:Label ID='lblChords' runat='server' EnableViewState='false' /></td>
            </tr>
            <tr>
               <td>Звуков:</td><td><asp:Label ID='lblMP3All' runat='server' EnableViewState='false' /></td>
               <td>...online:</td><td><asp:Label ID='lblMP3Online' runat='server' EnableViewState='false' /></td>
            </tr>
            <tr>
               <td>MIDI:</td><td><asp:Label ID='lblMidi' runat='server' EnableViewState='false' /></td>
               <td>Karaoke:</td><td><asp:Label ID='lblKaraoke' runat='server' EnableViewState='false' /></td>
            </tr>
            <tr>
               <td>CD:</td><td><asp:Label ID='lblCDs' runat='server' EnableViewState='false' /></td>
               <td><asp:Label ID='lblSSN' runat='server' EnableViewState='false' Text="ssn/usr:" /></td>
               <td><asp:Label ID='lblSSNData' runat='server' EnableViewState='false' /><asp:HyperLink ID='lnkUsers' runat='server' EnableViewState='false' Visible='false' NavigateUrl='/Admin/LoggedUsers.aspx' Target='_blank' /></td>
            </tr>

            <tr><th colspan="4" nowrap="nowrap">
               <a href='/rss'><img src='/Images/RSS.gif' border='0' align='absmiddle' alt='' /></a>
               Добавилось за
               <asp:DropDownList ID='lstNewsDays' runat='server' AutoPostBack='true'>
                  <asp:ListItem Text='сегодня' Value='1' />
                  <asp:ListItem Text='2 дня' Value='2' />
                  <asp:ListItem Text='3 дня' Value='3' />
                  <asp:ListItem Text='4 дня' Value='4' />
                  <asp:ListItem Text='5 дней' Value='5' />
                  <asp:ListItem Text='6 дней' Value='6' />
                  <asp:ListItem Text='неделю' Value='7' />
               </asp:DropDownList>
               <a href='/atom'><img src='/Images/Atom.gif' border='0' align='absmiddle' alt='Atom' /></a>
            </th></tr>
            <tr>
               <td><asp:HyperLink ID='lnkNewArtists' runat='server' ToolTip='Новые исполнители'>Исполнителей</asp:HyperLink>:</td>
               <td><asp:Label ID='lblNewArtists' runat='server' /></td>
               <td><asp:HyperLink ID='lnkNewAlbums' runat='server' ToolTip='Новые альбомы'>Альбомов</asp:HyperLink>:</td>
               <td><asp:Label ID='lblNewAlbums' runat='server' /></td>
            </tr>
            <tr>
               <td><asp:HyperLink ID='lnkNewTexts' runat='server' ToolTip='Новые тексты'>Текстов</asp:HyperLink>:</td>
               <td><asp:Label ID='lblNewTexts' runat='server' /></td>
               <td><asp:HyperLink ID='lnkNewFiles' runat='server' ToolTip='Новые файлы'>Файлов</asp:HyperLink>:</td>
               <td><asp:Label ID='lblNewFiles' runat='server' /></td>
            </tr>
         </table>
      </td>
      <td valign='top'>
         <table width='100%' cellspacing="0" class="tbl01">
            <thead><tr><td>Музыкальные новости</td></tr></thead><tr><td height='100%'><iframe frameborder='0' width='100%' height='138' scrolling='yes' src='/News/YandexMusic.aspx'></iframe></td></tr>
         </table>
      </td>
   </tr>
</table>

<table width="550" cellspacing="0" class="tbl01 adm" align='center'>
   <thead><tr><td colspan="2">Колонка Админа</td></tr></thead><tr><th>Дата</th><th>Перл</th></tr><tr>
       <tr>
          <td valign="top">23.10.11</td><td>
             Мда, давненько не брал я в руки шашек :)<br>
             По причине всемирного хаоса сайт был в свободном полете... долго.<br>
             За что, конечно, извиняюсь и все такое, но это меня не извиняет :(<br />
             Так что будем стараться исправить это дело. Из хороших новостей за это время - похоже, что сцуки из контента и права сдохли (куда им и дорога). Поправьте меня, если это не так, а то они уж больно жадные.<br />
             Поэтому будем думать как облегчить доступ к материлам.
          </td>
       </tr>

</table>

<br><br>
<table border="0" align="center">
   <tr>
      <td align="center"><pwc:Banner id="bnr1" runat="server" Provider="Music" /></td>
      <td align="center"><pwc:Banner id="bnr2" runat="server" Provider="SpyLog" /></td>
      <td align="center"><pwc:Banner id="bnr3" runat="server" Provider="Rambler" /></td>
      <td align="center"><pwc:Banner id="bnr4" runat="server" Provider="MailRu" /></td>
      <td align="center"><pwc:Banner id="bnr5" runat="server" Provider="HotLog" /></td></tr>
</table>
</div>

</asp:Content>
