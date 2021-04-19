<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SongListBox.aspx.cs" Inherits="Pripev.Web.UI.Popup.User.SongListBox" MasterPageFile="~/Popup.Master"%>

<asp:Content ContentPlaceHolderID='plhTitle' ID='contentTitle' runat='server'>Выберите композицию</asp:Content>

<asp:Content ContentPlaceHolderID='plhStyle' ID='contentStyle' runat='server'>
<link rel="stylesheet" href="/Include/Styles.css">
<style type="text/css">
body {background-image:none; margin:5px; padding:0;}
</style>
</asp:Content>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<table cellspacing="0" align="center" class="tbl01">
   <thead><tr><td>Выберите композицию</td></tr></thead>
   <tr><td>
      <asp:Literal ID='litSelSong' runat='server' EnableViewState='false' />
      <asp:Literal ID='litNotFound' runat='server' Visible='false' />
   </td></tr>
   <tr><td align="center"><asp:HyperLink ID='lnkSubmit' runat='server' CssClass='sbtn' /></td></tr>
</table>

</asp:Content>
