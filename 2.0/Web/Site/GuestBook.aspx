<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestBook.aspx.cs" Inherits="Pripev.Web.UI.GuestBook" MasterPageFile="~/Main.Master" ValidateRequest='false'%>
<%@ Register TagPrefix="cc1" Namespace="WebControlCaptcha" Assembly="WebControlCaptcha" %>

<asp:Content ContentPlaceHolderID='cntStyle' ID='contentStyle' runat='server'>
   <link id="cssPager" rel="stylesheet" href="/Include/PagerLight.css" type="text/css" runat="server" media="all"/>
</asp:Content>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<div class='GuestBook'>
   <table cellspacing="0" class="tbl01" align='center'>
      <thead><tr><td colspan='2'>�������� �����</td></tr></thead>
      <tr id='trMsg' runat='server'><td colspan='2' align='center'><asp:Label ID='lblAlert' runat='server' CssClass='alert' EnableViewState='false' /></td></tr>
      <tr id='trNote' runat='server'><td colspan='2'><em>����������, �� ��������� ���� ��������� ���� "� ��� �����..." ���<br>"�������� ���..." - ��� ����� ���� ����� � ������ "������".</em><br>&nbsp;</td></tr>
      <tr>
         <td align='right'>���� ���:</td>
         <td><asp:TextBox ID='txtName' runat='server' MaxLength='50' /></td>
      </tr>
      <tr>
         <td align="right">E-Mail:</td>
         <td><asp:TextBox ID='txtEmail' runat='server' MaxLength='50' /></td>
      </tr>
      <tr><td colspan="2" align="center">
         <asp:RequiredFieldValidator ID='valReqMsg' runat='server' ControlToValidate='txtMsg' ToolTip='������� ���������'>*</asp:RequiredFieldValidator><span class='ReqFld'>*</span>C��������:<br>
         <asp:TextBox ID='txtMsg' runat='server' Columns='60' Rows='7' TextMode='MultiLine' />
      </td></tr>
      <tr>
         <td align="right"><span class='ReqFld'>*</span>��������:</td>
         <td><cc1:captchacontrol id="CaptchaControl1" runat="server" Width='100%' Text='������� ���<br>� �������� �����' CacheStrategy='Session' /></td>
      </tr>
      <tr><td colspan='2' align='center' style='padding-top:5px'><asp:LinkButton ID='btnSubmit' runat='server' CssClass='sbtn' OnClick='btnSubmit_Click'>��������</asp:LinkButton>
      </td></tr>
   </table>
   
   <table cellspacing="0" width="99%" align='center'>
      <tr><td align='right'><pwc:Pager ID='Pager1' runat='server' PageSize='10' ShowFirstLast='true' ShowAllLink='true' OnCommand='Pager1_Command' /></td></tr>
   </table>

   <asp:Repeater ID='rptBook' runat='server' EnableViewState='false' OnItemDataBound='rptBook_ItemDataBound'>
      <ItemTemplate>
         <table cellspacing="0" width="99%" class="tbl01" align='center'>
            <thead><tr><td><asp:Literal ID='litHead' runat='server' /></td></tr></thead>
            <tr><td><asp:Literal ID='litText' runat='server' /></td></tr>
         </table>
      </ItemTemplate>
   </asp:Repeater>
</div>

</asp:Content>
