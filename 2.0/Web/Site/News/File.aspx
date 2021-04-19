<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="File.aspx.cs" Inherits="Pripev.Web.UI.News.Files" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentData' runat='server'>

<div class='News'>

<table cellspacing='0' class='tbl01' align="center" style='margin-bottom:5px'>
   <thead><tr><td>Добавилось за</td></tr></thead>
   <tr><td style='text-align:center'>
      <asp:DropDownList ID='ddlDays' runat='server' AutoPostBack='true'>
         <asp:ListItem Value='1' Text='сегодня' />
         <asp:ListItem Value='2' Text='2 дня' />
         <asp:ListItem Value='3' Text='3 дня' />
         <asp:ListItem Value='4' Text='4 дня' />
         <asp:ListItem Value='5' Text='5 дней' />
         <asp:ListItem Value='6' Text='6 дней' />
         <asp:ListItem Value='7' Text='неделю' />
      </asp:DropDownList>
   </td></tr>
</table>

<asp:PlaceHolder ID='plhNotFound' runat='server'>
   <table cellspacing="0" class="tbl01" align='center'>
      <thead><tr><td>Ничего :(</td></tr></thead>
      <tr><td>Пока ничего нового. Присылайте :)</td></tr>
   </table>
</asp:PlaceHolder>

<asp:Repeater ID='rptNews' runat='server' OnItemDataBound='rptNews_ItemDataBound'>
   <HeaderTemplate>
      <table cellspacing="0" class="tbl03" align='center'>
         <thead><tr><td colspan='3'>Файлы</td></tr></thead>
         <tr><th>Композиция</th><th>Альбом</th><th>Исполнитель</th></tr>
   </HeaderTemplate>
   <ItemTemplate>
      <tr>
         <td nowrap><asp:Literal ID='litSong' runat='server' /></td>
         <td nowrap><asp:HyperLink ID='lnkAlbum' runat='server' NavigateUrl='<%# "/Album.aspx?Id=" + Eval( "ALBUM_ID" ) %>' Text='<%# Eval( "AlbumName" ) %>' /></td>
         <td nowrap><asp:HyperLink ID='lnkArtist' runat='server' NavigateUrl='<%# "/Artist.aspx?Id=" + Eval( "ARTIST_ID" ) %>' Text='<%# Eval( "ArtistName" ) %>' /></td>
      </tr>
   </ItemTemplate>
</asp:Repeater>

</div>

</asp:Content>
