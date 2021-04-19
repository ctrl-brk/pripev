<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="AlbumSongs.aspx.cs" Inherits="Pripev.Web.UI.AlbumSongs" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<asp:Literal ID='litNotFound' runat='server' Visible='false'><p>Извиняемся, но такого не найдено :(((</p></asp:Literal>
<asp:Literal ID='litNoTexts' runat='server' Visible='false'><p>К сожалению, у меня пока нет текстов к этому альбому :(((</p></asp:Literal>

<asp:Panel ID='pnlTexts' runat='server' CssClass='SongText' EnableViewState='false'>
   <table cellspacing='0' class='tbl03'>
      <thead><tr><td colspan='2'><asp:HyperLink ID='lnkArtist' runat='server'/>&nbsp;-&nbsp;<asp:HyperLink ID='lnkAlbum' runat='server'/></td></tr></thead>
      <asp:Repeater ID='rptTexts' runat='server' OnItemDataBound='rptTexts_ItemDataBound'>
         <ItemTemplate>
            <asp:PlaceHolder ID='plhHeader' runat='server'>
               <tr>
                  <th><asp:Literal ID='litHeader' runat='server' /></th>
                  <th class='tb'>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID='plhVariant' runat='server'>
               <tr>
                  <th class='var'><asp:Literal ID='litVariant' runat='server' /></th>
                  <th class='tb var'>
            </asp:PlaceHolder>
            <a id='lnkChords' runat='server' href='javascript:ChordsGen()' class='chgen'>&nbsp;</a>
            <asp:HyperLink ID='lnkPrint' runat='server' CssClass='prn' Text='&nbsp;' />
            </th></tr>
            <tr><td colspan='2' class='txt'><asp:Literal ID='litText' runat='server' /></td></tr>
         </ItemTemplate>
      </asp:Repeater>
   </table>
</asp:Panel>

</asp:Content>
