<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="LoginPanel.aspx.cs" Inherits="Pripev.Web.UI.User.LoginPanel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
   <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
   <link rel="stylesheet" href="/Include/Styles.css" />
   <script src="/Include/Lib.js" type="text/javascript"></script>
   <script type="text/javascript">
      window.name = "LoginWindow";
   </script>
</head>

<body>
<form id="form2" runat="server" target="_parent">
<div class='menu'>
   <div class='user'>
      <asp:Panel ID='pnlUserNotRegistered' runat='server' DefaultButton='btnLogin'>
         Email: <pwc:EmailValidator ID='vsdReqEmail' runat='server' ControlToValidate='txtLoginEmail' ToolTip='������� email �����' ValidationGroup='grpLogin' Text='*' /><br/>
         <asp:TextBox ID='txtLoginEmail' runat='server' MaxLength='100' /><br />
         ������: <asp:RequiredFieldValidator ID='vldReqPassword' runat='server' ControlToValidate='txtLoginPassword' ToolTip='������� ������' ValidationGroup='grpLogin'>*</asp:RequiredFieldValidator><br/>
         <asp:TextBox ID='txtLoginPassword' runat='server' MaxLength='50' TextMode='Password' /><br />
         <asp:LinkButton ID='btnLogin' runat='server' CssClass='enter' Text='����!' PostBackUrl='/User/Login.aspx' ValidationGroup='grpLogin' />
         <p align="center"><a class='lnk01' href='/User/Register.aspx' target='_parent'>�����������</a></p>
         <p align="center"><a href="javascript:Redirect('/User/RemindPassword.aspx')" title="�������� ������" target='_parent'>������ ������?</a></p>
      </asp:Panel>
      <asp:Panel ID='pnlUserRegistered' runat='server'>
         <asp:Literal ID='litEditContent' runat='server'>
            <p align="center"><a class='lnk01' href='/CMS/Default.aspx' target='_parent'>�������</a></p>
         </asp:Literal>
         <asp:Literal ID='litAdmin' runat='server'>
            <p align="center"><a class='lnk01' href='/Admin/Orders.aspx' target='_parent'>|������|</a></p>
            <p align="center"><a class='lnk01' href='/Admin/Content.aspx' target='_parent'>�������</a></p>
         </asp:Literal>
         <p align="center"><a href='/User/Account.aspx' target='_parent'>��� �������</a></p>
         <asp:Literal ID='litOrders' runat='server'>
            <p align="center"><a class='lnk01' href='/User/OrdersProgress.aspx' target='_parent'>������</a></p>
         </asp:Literal>
         <p align="center"><a href='javascript:OpenChat()' id='chatLink'>���</a></p>
         <asp:HyperLink ID='lnkLogout' runat='server' CssClass='enter' NavigateUrl='/User/Logout.aspx' Text='�����' Target='_parent'/>
      </asp:Panel>
   </div>
</div>
</form>
</body>
</html>
