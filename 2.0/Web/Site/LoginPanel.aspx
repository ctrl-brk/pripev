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
         Email: <pwc:EmailValidator ID='vsdReqEmail' runat='server' ControlToValidate='txtLoginEmail' ToolTip='Введите email адрес' ValidationGroup='grpLogin' Text='*' /><br/>
         <asp:TextBox ID='txtLoginEmail' runat='server' MaxLength='100' /><br />
         Пароль: <asp:RequiredFieldValidator ID='vldReqPassword' runat='server' ControlToValidate='txtLoginPassword' ToolTip='Введите пароль' ValidationGroup='grpLogin'>*</asp:RequiredFieldValidator><br/>
         <asp:TextBox ID='txtLoginPassword' runat='server' MaxLength='50' TextMode='Password' /><br />
         <asp:LinkButton ID='btnLogin' runat='server' CssClass='enter' Text='Вход!' PostBackUrl='/User/Login.aspx' ValidationGroup='grpLogin' />
         <p align="center"><a class='lnk01' href='/User/Register.aspx' target='_parent'>Регистрация</a></p>
         <p align="center"><a href="javascript:Redirect('/User/RemindPassword.aspx')" title="Получить пароль" target='_parent'>Забыли пароль?</a></p>
      </asp:Panel>
      <asp:Panel ID='pnlUserRegistered' runat='server'>
         <asp:Literal ID='litEditContent' runat='server'>
            <p align="center"><a class='lnk01' href='/CMS/Default.aspx' target='_parent'>Контент</a></p>
         </asp:Literal>
         <asp:Literal ID='litAdmin' runat='server'>
            <p align="center"><a class='lnk01' href='/Admin/Orders.aspx' target='_parent'>|заказы|</a></p>
            <p align="center"><a class='lnk01' href='/Admin/Content.aspx' target='_parent'>Контент</a></p>
         </asp:Literal>
         <p align="center"><a href='/User/Account.aspx' target='_parent'>Мой аккаунт</a></p>
         <asp:Literal ID='litOrders' runat='server'>
            <p align="center"><a class='lnk01' href='/User/OrdersProgress.aspx' target='_parent'>Заказы</a></p>
         </asp:Literal>
         <p align="center"><a href='javascript:OpenChat()' id='chatLink'>ЧАТ</a></p>
         <asp:HyperLink ID='lnkLogout' runat='server' CssClass='enter' NavigateUrl='/User/Logout.aspx' Text='Выход' Target='_parent'/>
      </asp:Panel>
   </div>
</div>
</form>
</body>
</html>
