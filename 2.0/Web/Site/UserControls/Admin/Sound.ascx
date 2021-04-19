<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sound.ascx.cs" Inherits="Pripev.Web.UI.Admin.UserControls.Sound" %>

<table class='tbl01'>
   <thead><tr><th colspan='3'>Звук</th></tr></thead>
   <tr><td>ID</td><td><asp:Literal ID='litSoundId' runat='server' /></td></tr>
   <tr><td>Type</td><td><asp:TextBox ID='txtType' runat='server' MaxLength='5' Width='20px'/></td></tr>
   <tr><td>Path</td><td><asp:TextBox ID='txtPath' runat='server' MaxLength='255' /></td></tr>
   <tr><td>Bitrate</td><td><asp:TextBox ID='txtBitrate' runat='server' MaxLength='5' /></td></tr>
   <tr><td>Size</td><td><asp:TextBox ID='txtSize' runat='server' /></td></tr>
   <tr><td>Length</td><td><asp:TextBox ID='txtLength' runat='server' MaxLength='5' /></td></tr>
</table>
