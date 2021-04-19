<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Artist.ascx.cs" Inherits="Pripev.Web.UI.Admin.UserControls.Artist" %>

<table class='tbl01'>
   <thead><tr><th colspan='3'>Исполнитель</th></tr></thead>
   <tr>
      <td>ID</td>
      <td><asp:Literal ID='litArtistId' runat='server' /></td>
      <td rowspan='6'>
         <asp:ListBox ID='lstAlbums' runat='server' DataValueField='Id' DataTextField='Name' Rows='10' AutoPostBack='true' OnSelectedIndexChanged='lstAlbums_SelectedIndexChanged' />
      </td>
   </tr>
   <tr><td>Letter</td><td><asp:TextBox ID='txtLetter' runat='server' MaxLength='1' Width='20px'/></td></tr>
   <tr><td>Name</td><td><asp:TextBox ID='txtName' runat='server' MaxLength='50' /></td></tr>
   <tr><td>Alt.names</td><td><asp:TextBox ID='txtName1' runat='server' MaxLength='50' /></td></tr>
   <tr><td>Image</td><td><asp:TextBox ID='txtImage' runat='server' MaxLength='20' /></td></tr>
   <tr><td>AKA</td><td><asp:TextBox ID='txtAKA' runat='server' MaxLength='4' Width='50px'/></td></tr>
   <tr><td colspan='3'>Info<br /><asp:TextBox ID='txtInfo' runat='server' TextMode='MultiLine' Rows='10' Width='600px' /></td></tr>
   <tr><td colspan='3'>Links<br /><asp:TextBox ID='txtLinks' runat='server' TextMode='MultiLine' Rows='10' Width='600px' /></td></tr>
   <tr><td colspan='3'><asp:Button ID='btnNew' runat='server' Text='New' OnClick='btnNew_Click' />&nbsp;&nbsp;&nbsp;<asp:Button ID='btnSave' runat='server' Text='Save' OnClick='btnSave_Click' /></td></tr>
</table>
