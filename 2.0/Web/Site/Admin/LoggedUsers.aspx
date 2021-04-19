<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggedUsers.aspx.cs" Inherits="Pripev.Web.UI.Admin.LoggedUsers" MasterPageFile="~/Popup.Master"%>

<asp:Content ContentPlaceHolderID='plhTitle' ID='contentTitle' runat='server'>Юзера онлайн</asp:Content>

<asp:Content ContentPlaceHolderID='plhStyle' ID='contentStyle' runat='server'>

<asp:Repeater id='rptUsers' runat='server'>
   <HeaderTemplate>
      <table border='1'>
         <tr><th>UserId</th><th>SessionId</th><th>Name</th><th>Email</th></tr>
   </HeaderTemplate>
   <ItemTemplate>
      <tr>
         <td><%# Eval( "UserId" ) %></td>
         <td><%# Eval( "SessionId" ) %></td>
         <td><%# Eval( "Name" ) %></td>
         <td><%# Eval( "Email" ) %></td>
      </tr>
   </ItemTemplate>
   <FooterTemplate>
      </table>
   </FooterTemplate>
</asp:Repeater>

</asp:Content>
