<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Top20.aspx.cs" Inherits="Pripev.Web.UI.Top20" MasterPageFile="~/Main.Master" %>
<%@ OutputCache Duration='86400' VaryByParam='None' Location="Any" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID='contentScript' runat='server'>
<div class='top20'>
      <asp:Repeater ID='rptArtists' runat='server' EnableViewState='false'>
         <HeaderTemplate>
            <table cellspacing="0" class="tbl03" align='center'>
               <thead><tr><td colspan='3'>Исполнители</td></tr></thead>
               <tr><th>&nbsp;</th><th>Имя</th><th>Визитов</th></tr>
         </HeaderTemplate>
         <ItemTemplate>
            <tr>
               <td class='num'><asp:Literal ID='litSeq' runat='server' Text='<%#Eval( "SeqNum" )%>' /></td>
               <td><asp:HyperLink ID='lnkArtist' runat='server' Text='<%#Eval( "ArtistName" ) %>' NavigateUrl='<%#"/Artist.aspx?Id=" + Eval( "ArtistId" ) %>' /></td>
               <td class='vis'><asp:Literal ID='litHits' runat='server' Text='<%# Eval( "Hits" )%>' /></td>
            </tr>
         </ItemTemplate>
         <FooterTemplate>
            </table>
         </FooterTemplate>
      </asp:Repeater>

      <asp:Repeater ID='rptAlbums' runat='server' EnableViewState='false'>
         <HeaderTemplate>
            <table cellspacing="0" class="tbl03" align='center'>
               <thead><tr><td colspan='4'>Альбомы</td></tr></thead>
               <tr><th>&nbsp;</th><th>Альбом</th><th>Исполнитель</th><th>Визитов</th></tr>
         </HeaderTemplate>
         <ItemTemplate>
            <tr>
               <td class='num'><asp:Literal ID='litSeq' runat='server' Text='<%#Eval( "SeqNum" )%>' /></td>
               <td><asp:HyperLink ID='lnkAlbum' runat='server' Text='<%#Eval( "AlbumName" ) %>' NavigateUrl='<%#"/Album.aspx?Id=" + Eval( "AlbumId" ) %>' /></td>
               <td><asp:HyperLink ID='lnkArtist' runat='server' Text='<%#Eval( "ArtistName" ) %>' NavigateUrl='<%#"/Artist.aspx?Id=" + Eval( "ArtistId" ) %>' /></td>
               <td class='vis'><asp:Literal ID='litHits' runat='server' Text='<%# Eval( "Hits" )%>' /></td>
            </tr>
         </ItemTemplate>
         <FooterTemplate>
            </table>
         </FooterTemplate>
      </asp:Repeater>

      <asp:Repeater ID='rptSongs' runat='server' EnableViewState='false'>
         <HeaderTemplate>
            <table cellspacing="0" class="tbl03" align='center'>
               <thead><tr><td colspan='5'>Песни</td></tr></thead>
               <tr><th>&nbsp;</th><th>Песня</th><th>Альбом</th><th>Исполнитель</th><th>Визитов</th></tr>
         </HeaderTemplate>
         <ItemTemplate>
            <tr>
               <td class='num'><asp:Literal ID='litSeq' runat='server' Text='<%#Eval( "SeqNum" )%>' /></td>
               <td><asp:Literal ID='litSong' runat='server' Text='<%#Eval( "SongName" )%>' /></td>
               <td><asp:HyperLink ID='lnkAlbum' runat='server' Text='<%#Eval( "AlbumName" ) %>' NavigateUrl='<%#"/Album.aspx?Id=" + Eval( "AlbumId" ) %>' /></td>
               <td><asp:HyperLink ID='lnkArtist' runat='server' Text='<%#Eval( "ArtistName" ) %>' NavigateUrl='<%#"/Artist.aspx?Id=" + Eval( "ArtistId" ) %>' /></td>
               <td class='vis'><asp:Literal ID='litHits' runat='server' Text='<%# Eval( "Hits" )%>' /></td>
            </tr>
         </ItemTemplate>
         <FooterTemplate>
            </table>
         </FooterTemplate>
      </asp:Repeater>
      
</div>
</asp:Content>
