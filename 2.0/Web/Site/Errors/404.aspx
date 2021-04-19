<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="404.aspx.cs" Inherits="Pripev.Web.UI.Errors.Error404" EnableViewState="false"%>

<html>
<head runat="server">
    <title>Не нашлось припевов :(</title>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
</head>
<body>
   <form id="form1" runat="server">
      <center>
         Печально осознавать, но запрошенного Вами
         <asp:Literal ID='litUrl' runat="server" /> не обнаружено.<br>
         Причиной тому может быть как ошибка на сайте, так и неправильно набранный адрес или последствия редизайна сайта.<br>
         Администратор поставлен в известность и работает над этой проблемой.<br>
         <a href="/">Нажмите здесь</a>, чтобы перейти на главную страницу сайта.
      </center>
   </form>
</body>
</html>
