<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pripev.Web.UI.User.Login" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentMain' runat='server'>

<table class='tbl01' width='500' cellspacing='0' align='center'>
   <thead><tr><td>Что-то тут не так...</td></tr></thead>
   <tr><td>
      <p align="justify"><img src='/Images/HL/LoginErr.gif' class='icon'></p>
      <asp:MultiView ID='mvView1' runat='server'>
         <asp:View ID='view1' runat='server'>
            <p>Сожалею, но имеет место быть какая-то беда.
            Причин тому на сегодняшний день может быть две. Или Вы ошиблись при наборе Email/пароля или не зарегистрированы. Если первое - то попробуйте еще,
            а если второе - то Вам:</p>
            <div align='center'><a class='sbtn' href='/User/Register.asp'>Сюда</a></div>
         </asp:View>
         <asp:View ID='view2' runat='server'>
            <asp:PlaceHolder ID='plhStatus' runat='server'>
               Статус вашего аккаунта: <strong><asp:Literal ID='litStatusDesc' runat='server' /></strong><br/><br/>
            </asp:PlaceHolder>   
            <asp:PlaceHolder ID='plhAlert' runat='server'>
               <span class='alert'><asp:Literal ID='litAlert' runat='server' /></span><br/><br/>
            </asp:PlaceHolder>
            Если есть сложности/вопросы - пишите письма, разберемся.
         </asp:View>
         <asp:View ID='view3' runat='server'>
            <p>Пожалуйста, авторизируйтесь на сайте. Если вы еще не зарегистрированы - то вам <a href='/User/Register.aspx'>сюда</a>.</p>
            <asp:Panel ID='pnlLogin' runat='server' DefaultButton='btnSubmit'>
               <input type="text" style="display:none"/>
               <table border='0' align='center'>
                  <tr>
                     <td align='right'><asp:RequiredFieldValidator ID='vldReqEmail' runat='server' ToolTip='Введите email' ControlToValidate='txtEmail' Text='*' />Email:</td>
                     <td><asp:TextBox ID='txtEmail' runat='server' MaxLength='100' /></td>
                  </tr>
                  <tr>
                     <td align='right'><asp:RequiredFieldValidator ID='vldReqPassword' runat='server' ToolTip='Введите пароль' ControlToValidate='txtPassword'  Text='*' />Password:</td>
                     <td><asp:TextBox ID='txtPassword' runat='server' TextMode='Password' MaxLength='50' /></td>
                  </tr>
                  <tr><td colspan='2' align='center'><asp:LinkButton ID='btnSubmit' runat='server' CssClass='sbtn' Text='Войти' CausesValidation='true' OnClick='btnSubmit_Click' /></td></tr>
               </table>
            </asp:Panel>   
         </asp:View>
      </asp:MultiView>
   </td></tr>
</table>

</asp:Content>
