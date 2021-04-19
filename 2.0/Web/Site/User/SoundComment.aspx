<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoundComment.aspx.cs" Inherits="Pripev.Web.UI.User.SoundComment" MasterPageFile="~/Popup.Master" %>

<asp:Content ContentPlaceHolderID='plhTitle' ID='contentTitle' runat='server'>Комментарий</asp:Content>

<asp:Content ContentPlaceHolderID='plhStyle' ID='contentStyle' runat='server'>
<link rel="stylesheet" href="/Include/Styles.css">
<style>
   body {background-image:none; margin:5px; padding:0;}
   .cmt {width:310px;height:100px}
</style>
</asp:Content>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<table cellspacing="0" align="center" class="tbl01">
   <thead><tr><td>Оставить комментарий</td></tr></thead>
   <tr><td style='padding:5px'>
      <asp:PlaceHolder ID='plhComment' runat='server'>
         Здесь Вы можете оставить комментарий о качестве звукового файла<asp:Literal ID='litSong' runat='server' />,
         если Вы его скачали с этого сайта. Только о плохом качестве :) Т.е. если Вы услышали какие-нибудь щелчки/сбои/странные шумы и т.п.
         Или если что-нибудь еще не так.<br><br>
         <asp:Literal ID='litOrder' runat='server'>
            Кроме того, Вы можете оставить комментарий о качестве текста/подбора. Или разместить свой вариант аккордов или добавить/исправить текст композиции.<br><br>
         </asp:Literal>
         <asp:TextBox ID='txtComment' runat='server' CssClass='cmt' TextMode='MultiLine' />
      </asp:PlaceHolder>
      <asp:Literal ID='litConfirm' runat='server'>Большое спасибо за помощь сайту! Ваши замечания будут учтены.</asp:Literal>    
   </td></tr>
   <tr><td style='text-align:center'>
      <asp:LinkButton ID='btnSubmit' runat='server' CssClass='sbtn' Text='OK' />
      <asp:HyperLink ID='lnkClose' runat='server' CssClass='sbtn' Text='Закрыть' NavigateUrl='javascript:window.close()' />
   </td></tr>
</table>

</asp:Content>
