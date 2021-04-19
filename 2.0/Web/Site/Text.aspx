<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Text.aspx.cs" Inherits="Pripev.Web.UI.Text" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='plhScript' ID='contentScript' runat='server'>
<script type="text/javascript">
   function ChangeSong(obSel) {
      var nId = obSel.options[obSel.selectedIndex].value;
      Redirect("/Text.asp?SongId=" + nId);
   }
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<asp:Panel ID='pnlText' runat='server' CssClass='SongText' EnableViewState='false'>

   <asp:PlaceHolder ID='plhText' runat='server' Visible='false'>
      <table cellspacing='0' class='tbl03' align='center'>
         <thead><tr><td colspan='2'><asp:HyperLink ID='lnkArtist' runat='server' />&nbsp;-&nbsp;<asp:HyperLink ID='lnkAlbum' runat='server' /></td></tr></thead>
         <asp:Repeater id='rptTexts' runat='server' OnItemDataBound='rptTexts_ItemDataBound'>
            <ItemTemplate>
               <asp:PlaceHolder ID='plhHeader' runat='server'>
                  <tr><th><asp:Literal ID='litSongName' runat='server' /><asp:Literal ID='litSongIcons' runat='server' /></th>
                  <th class='tb' nowrap>
               </asp:PlaceHolder>
               <asp:PlaceHolder ID='plhData' runat='server'>
                  <tr><th class='var'><asp:Literal ID='litTitle' runat='server' /></th><th class='tb var'>
               </asp:PlaceHolder>
               <asp:HyperLink ID='lnkChordGen' runat='server' Text='&nbsp;' CssClass='chgen' ToolTip='Генератор аккордов' NavigateUrl='javascript:ChordsGen()' />
               <asp:HyperLink ID='lnkPrint' runat='server' Text='&nbsp;' CssClass='prn' ToolTip='Печать' NavigateUrl='<%# "javascript:PrintText(" + Eval( "SongId" ) + "," + Eval( "Id" )+ ")" %>' />               
               </th></tr>
               <tr><td colspan='2' class='txt'><asp:Literal ID='litText' runat='server' /></td></tr>
            </ItemTemplate>
         </asp:Repeater>
      </table>
   </asp:PlaceHolder>

   <asp:Literal ID='litNoText' runat='server' Visible='false'>
      <p>К сожалению, у меня пока что нет текстов к этой композиции.<br>Буду благодарен, если Вы сообщите мне как вам удалось попасть на эту страницу :)</p>
   </asp:Literal>

   <asp:Literal ID='litNotFound' runat='server' Visible='false'>
      <p>
         Дико извиняюсь, но запрашиваемая Вами песня не найдена.<br>
         Возможно она была перемещена в другой раздел/альбом. Попробуйте воспользоваться поиском по сайту.<br>
         Кроме того, все мы не безгрешны... Возможно имеет место быть ошибка на сайте. В таком случае огромная просьба cообщить мне.
      </p>
   </asp:Literal>

</asp:Panel>

</asp:Content>
