<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemindPassword.aspx.cs" Inherits="Pripev.Web.UI.User.RemindPassword" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentMain' runat='server'>

<table class='tbl01' width='300' cellspacing='0' align='center'>
   <thead><tr><td>Напомнить пароль</td></tr></thead>
   <tr><td>
      <p align='center'>
         <img src='/Images/HL/LostPwd.gif' class='icon'>
         <asp:PlaceHolder ID='plhMsg' runat='server' Visible='false'>
            <asp:Literal ID='litMsg' runat='server'/>
            </p><hr size='1'><p align='center'>
         </asp:PlaceHolder>
         
         <asp:RequiredFieldValidator id='vldReqEmail' runat='server' ControlToValidate='txtUserEmail' ToolTip='Введите email адрес' Text='*' /><span class='ReqFld'>*</span>Email: <asp:TextBox ID='txtUserEmail' runat='server' MaxLength='100' />
         <div align='center'><asp:LinkButton ID='btnSubmit' runat='server' CssClass='sbtn' Text='Прислать' OnClick='btnSubmit_Click'/></div>
      </p>
   </td></tr>
</table>

</asp:Content>
