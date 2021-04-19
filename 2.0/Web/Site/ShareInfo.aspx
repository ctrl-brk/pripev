<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShareInfo.aspx.cs" Inherits="Pripev.Web.UI.ShareInfo" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<table class='tbl02' width='500' cellspacing='0' align='center'>
   <thead><tr><td>Поделиться вкусностями</td></tr></thead>
   <tr><td>
      Если у Вас есть тексты, аккорды (другие варианты аккордов), ноты, картинки обложек и вообще что-нибудь вкусное,
      чего нет на сайте, то большая просьба прислать это дело <asp:Literal ID='litEmail' runat='server' />мне</a>.<br/>
      Заранее большое Вам спасибо.
   </td></tr>
</table>

</asp:Content>
