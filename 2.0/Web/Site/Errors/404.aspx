<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="404.aspx.cs" Inherits="Pripev.Web.UI.Errors.Error404" EnableViewState="false"%>

<html>
<head runat="server">
    <title>�� ������� �������� :(</title>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
</head>
<body>
   <form id="form1" runat="server">
      <center>
         �������� ����������, �� ������������ ����
         <asp:Literal ID='litUrl' runat="server" /> �� ����������.<br>
         �������� ���� ����� ���� ��� ������ �� �����, ��� � ����������� ��������� ����� ��� ����������� ��������� �����.<br>
         ������������� ��������� � ����������� � �������� ��� ���� ���������.<br>
         <a href="/">������� �����</a>, ����� ������� �� ������� �������� �����.
      </center>
   </form>
</body>
</html>
