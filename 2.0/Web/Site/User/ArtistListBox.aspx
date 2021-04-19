<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArtistListBox.aspx.cs" Inherits="Pripev.Web.UI.Popup.User.ArtistListBox" MasterPageFile="~/Popup.Master"%>

<asp:Content ContentPlaceHolderID='plhTitle' ID='contentTitle' runat='server'>Выберите исполнителя</asp:Content>

<asp:Content ContentPlaceHolderID='plhStyle' ID='contentStyle' runat='server'>
<link rel="stylesheet" href="/Include/Styles.css">
<style type="text/css">
body {background-image:none; margin:5px; padding:0;}
</style>
</asp:Content>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<table cellspacing="0" align="center" class="tbl01">
   <thead><tr><td>Выберите исполнителя</td></tr></thead>
   <tr><td>
      <asp:ListBox ID='lbArtist' runat='server' Rows='10' EnableViewState='false' ondblclick='SelectArtist()' />
   </td></tr>
   <tr><td align="center"><a href='javascript:SelectArtist()' class='sbtn'>Выбрать</a></td></tr>
</table>

</asp:Content>
