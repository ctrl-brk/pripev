<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Search.aspx.cs" Inherits="Pripev.Web.UI.Search" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>
<div class='Search'>
   <p id='pValidation' runat='server' visible='false' enableviewstate='false'>Пожалуйста используйте строку поиска не менее 3-х символов.</p>
   <asp:PlaceHolder ID='plhSearch' runat='server' EnableViewState='false'>
      
      <table border='0' cellspacing='0' align='center' class='tbl03'>
         <thead><tr><td class='noth'>&nbsp;Исполнители&nbsp;</td></tr></thead>
         <tr id='trArtistNotFound' runat='server'><td>Ничего не найдено :(</td></tr>
         <asp:Repeater ID='rptArtists' runat='server' OnItemDataBound='rptArtists_ItemDataBound'>
            <ItemTemplate>
               <tr><td class="name"><asp:HyperLink ID='lnkArtist' runat='server' /></td></tr>
            </ItemTemplate>
         </asp:Repeater>
      </table>

      <table border='0' cellspacing='0' align='center' class='tbl03'>
         <thead><tr><td colspan='2'>Альбомы</td></tr></thead>
         <tr><th>Альбом</th><th>Исполнитель</th></tr>
         <tr id='trAlbumNotFound' runat='server'><td colspan='2'>Ничего не найдено :(</td></tr>
         <asp:Repeater ID='rptAlbums' runat='server' OnItemDataBound='rptAlbums_ItemDataBound'>
            <ItemTemplate>
               <tr>
                  <td class="name"><asp:HyperLink ID='lnkAlbum' runat='server' /></a></td>
                  <td><asp:HyperLink ID='lnkArtist' runat='server' /></a></td>
               </tr>
            </ItemTemplate>
         </asp:Repeater>
      </table>

      <table align='center' cellspacing="0" class="tbl03">
         <thead><tr><td colspan='3'>Песни</td></tr></thead>
         <tr><th>Название</th><th>Альбом</th><th>Исполнитель</th></tr>
         <tr id='trSongNotFound' runat='server'><td colspan='3'>Ничего не найдено :(</td></tr>
         <asp:Repeater ID='rptSongs' runat='server' OnItemDataBound='rptSongs_ItemDataBound'>
            <ItemTemplate>
               <tr>
                  <td class="name"><asp:Literal ID='litSong' runat='server' /></td>
                  <td><a href='<%# "/Album.aspx?Id=" + Eval( "AlbumId" )%>'><%# Eval( "AlbumName" )%></a></td>
                  <td><a href='<%# "/Artist.aspx?Id=" + Eval( "ArtistId" )%>'><%# Eval( "ArtistName" )%></a></td>
               </tr>
            </ItemTemplate>
         </asp:Repeater>
      </table>
      
   </asp:PlaceHolder>
</div>
</asp:Content>
