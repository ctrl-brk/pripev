<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="TestMail.aspx.cs" Inherits="Pripev.Web.Temp.TestMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       From: <asp:TextBox ID='txtEmail1' runat='server' Text='webmaster@pripev.ru' /><br />
       To: <asp:TextBox ID='txtEmail2' runat='server' Text='aleksey_grachev@yahoo.com' /><br />
       To: <asp:TextBox ID='txtEmail3' runat='server' Text='alx.grachev@gmail.com' /><br />
       To: <asp:TextBox ID='txtEmail4' runat='server' />
    </div>
    <asp:CheckBox ID='cbHtml' runat='server' Text='HTML' Checked='true' /><br />
    <asp:Button ID='btnSubmit' runat="server" Text='Send' />
    </form>
</body>
</html>
