<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Upload.aspx.cs" Inherits="Pripev.Web.UI.Popup.Upload" MasterPageFile="~/Popup.Master"%>
<%@ Register assembly="FileUploadLibrary" namespace="darrenjohnstone.net.FileUpload" tagprefix="fup" %>

<asp:Content ContentPlaceHolderID='plhTitle' ID='contentTitle' runat='server'>�������� ��������</asp:Content>

<asp:Content ContentPlaceHolderID='plhStyle' ID='contentStyle' runat='server'>
   <link rel="stylesheet" href="/Include/StyleS.css">
   <style>
      body {background:white; margin:5px 5px 0 5px;}
      table.tbl01 {width:300px}
   </style>
</asp:Content>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>
<fup:DJUploadController ID="UploadController1" runat="server" ShowCancelButton="true" />
<fup:DJAccessibleProgressBar ID="AccessibleProgrssBar1" runat="server" />

<asp:PlaceHolder ID='plhText' runat='server' EnableViewState='false'>
�������� �������, ��� ��������� ����. ��� �� ����� ����� � �������� ���� :)<br>
������, ����������, e-mail (�������������), ����� � ����� � ���� ��������� ���� �������� ������� ��������.<br>
���� ��� ���� �������:
<ol>
   <li>
      ��������� �� FTP ������ (��� ���, ��� ����� ��� ��� �����). �� ��� ������ ��� ����� � ������������� �������� ������
      �������� ��������� � �������. ������, �������� ����: <asp:HyperLink ID='lnkFTP' runat='server' /> (����������� passive (���������) ����������).<br>
      ������, ������� � ����� ������� ������ ������. ��� ��� �� �������� ��� ��� ���� :)
   </li>
   <li>
      ��������� �� ����� ������. ������� ������� ��������� ��� ���� �����. ��� ��� ����� ����� ����������� ��� ��� �� ����
      � ������ ��. ����� ��������� ��� ����� � ��������� �� ������ "���������".<br>
      � ��������, ��������� ������ "��������", �� ������ ��������� �� 5-�� ������ ������������, �� � ����� � ������ ���������� ������������ ������ ����� ������ �� �������������.<br><br />
      ������������� ������ �������� - 100 ��������. ���� ������ ������ ����� ������ - ��������� �� ���� ��� ���������� �� ftp.<br>
      ����� �� �������� - 1 ���.
    </li>
</ol>
</asp:PlaceHolder>

<asp:Literal ID='litResults' runat='server' EnableViewState='false' />

<table cellspacing="0" align="center" class="tbl01" style='width:500px'>
   <thead><tr><td colspan='2'>���� ����������?</td></tr></thead>
   <tr>
      <td align="right">�����������:</td>
      <td><asp:TextBox ID='txtArtist' runat='server' Width='200' /></td>
   </tr>
   <tr>
      <td align="right">������:</td>
      <td><asp:TextBox ID='txtAlbum' runat='server' Width='200' /></td>
   </tr>
   <tr>
      <td align="right">����������:</td>
      <td><asp:TextBox ID='txtSong' runat='server' Width='200' /></td>
   </tr>
   <tr>
      <td align="right">E-mail:</td>
      <td><asp:TextBox ID='txtEmail' runat='server' Width='200' /></td>
   </tr>
   <tr>
      <td align="right" valign='top'>�����������:</td>
      <td><asp:TextBox ID='txtComment' runat='server' Width='200' Rows='5' TextMode='MultiLine' /></td>
   </tr>
   <tr>
      <td align="right" valign='top'>����(�):</td>
      <td><fup:DJFileUpload ID="fileUpload1" runat="server" ShowAddButton="true" ShowUploadButton="false"/></td>
   </tr>
   <tr><td colspan='2'>&nbsp;</td></tr>
   <tr><td colspan='2' align='center'><asp:LinkButton ID='btnSubmit' runat='server' CssClass='sbtn' Text='���������' /></td></tr>   
</table>

</asp:Content>
