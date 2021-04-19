<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="ArtistSongs.aspx.cs" Inherits="Pripev.Web.UI.ArtistSongs" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<asp:Panel ID='pnlData' runat='server' CssClass='ArtistSongs' EnableViewState='false'>
   <asp:Literal ID='litNotFound' runat='server' Visible='false'><p>Извиняемся, но такого не найдено :(((</p></asp:Literal>
      <asp:Repeater ID='rptSongs' runat='server' OnItemDataBound='rptSongs_ItemDataBound'>
         <HeaderTemplate>
            <table cellspacing="0" class="tbl03">
               <thead><tr><td colspan='3'><asp:HyperLink ID='lnkArtist' runat='server'/>&nbsp;-&nbsp;Все песни</td></tr></thead>
               <tr><th class='chrd'>&nbsp;</th><th>Название</th><th class='snd'>&nbsp;</th></tr>
         </HeaderTemplate>
         <ItemTemplate>
            <tr>
               <td id='tdTextIcon' runat='server' class='st01'>&nbsp;</td>
               <td><asp:Literal ID='litSongName' runat='server' /></td>
               <td><asp:Literal ID='litSongIcons' runat='server' /></td>
            </tr>
         </ItemTemplate>
         <FooterTemplate>
            </table>
         </FooterTemplate>
      </asp:Repeater>
</asp:Panel>

</asp:Content>
