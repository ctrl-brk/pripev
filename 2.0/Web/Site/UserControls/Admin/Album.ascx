<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Album.ascx.cs" Inherits="Pripev.Web.UI.Admin.UserControls.Album" %>

<table class='tbl01'>
   <thead><tr><th colspan='3'>Альбом</th></tr></thead>
   <tr>
      <td>ID</td>
      <td><asp:Literal ID='litAlbumId' runat='server' /></td>
      <td rowspan='7'>
         <asp:ListBox ID='lstSongs' runat='server' DataValueField='Id' DataTextField='Name' Rows='12' AutoPostBack='true' OnSelectedIndexChanged='lstSongs_SelectedIndexChanged' />
      </td>
   </tr>
   <tr><td>Name</td><td><asp:TextBox ID='txtName' runat='server' MaxLength='60' /></td></tr>
   <tr><td>LImage</td><td><asp:TextBox ID='txtLImage' runat='server' MaxLength='50' /></td></tr>
   <tr><td>SImage</td><td><asp:TextBox ID='txtSImage' runat='server' MaxLength='50' /></td></tr>
   <tr>
      <td>Y/G</td>
      <td>
         <asp:TextBox ID='txtYear' runat='server' MaxLength='4' Width='40px' />
         <asp:TextBox ID='txtGenre' runat='server' MaxLength='3' Width='30px' />
         <asp:CheckBox ID='cbWanted' runat='server' Text='Wt' />
         <asp:CheckBox ID='cbCD' runat='server' Text='CD' />
      </td>
   </tr>
   <tr><td>Prod</td><td><asp:TextBox ID='txtProducer' runat='server' MaxLength='50' /></td></tr>
   <tr><td>Lst</td><td><asp:TextBox ID='txtListen' runat='server' MaxLength='100' /></td></tr>
   <tr><td colspan='3'>Info<br /><asp:TextBox ID='txtInfo' runat='server' TextMode='MultiLine' Rows='10' Width='600px' /></td></tr>
   <tr><td colspan='3'>
      <asp:Button ID='btnNew' runat='server' Text='New' OnClick='btnNew_Click' />
      <asp:Button ID='btnSave' runat='server' Text='Save' OnClick='btnSave_Click' />
      <asp:Button ID='btnDelete' runat='server' Text='Del' OnClick='btnDelete_Click' />
   </td></tr>
</table>
