<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Pripev.Web.UI.Payment" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID="cntStyle" id='content1' runat='server'>
<style>
.tbl01 tbody td {padding:5px}
</style>
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" id='contentStyle' runat='server'>
<table cellspacing="0" align="center" class="tbl01">
   <thead><tr><td>Мани, мани, мани</td></tr></thead>
   <tr><td>
      Спасибо, что добрались до этой страницы! Это значит, что Вы очень хороший человек<br>
      Как известно, "даже немножечко, чайная ложечка..." :)<br><br>
      Ниже перечислены все возможные на текущий день способы.
   </td></tr>
   <tr><td>
      <table border='0'>
         <tr>
            <td align='right'><a href="https://www.paypal.com/xclick/business=aleksey_grachev%40yahoo.com&no_note=1&currency_code=USD" target='_blank'><img src="/Images/PayPal.gif" border="0"></a></td>
            <td><a href="https://www.paypal.com/xclick/business=aleksey_grachev%40yahoo.com&no_note=1&currency_code=USD" target='_blank'>PayPal</a>. E-mail aleksey_grachev@yahoo.com.</td>
         </tr>
         <tr>
            <td><a href='http://www.webmoney.ru' target='_blank'><img src="/Images/WebMoney.gif" border="0"></a></td>
            <td><a href='http://www.webmoney.ru' target='_blank'>WebMoney</a>. Номера кошельков: Z134580659322, R469774054088, E268587262218, U296290904930</td>
         </tr>
         <tr>
            <td><a href='http://www.rupay.com' target='_blank'><img src="/Images/RuPay.gif" border="0"></a></td>
            <td><a href='http://www.rupay.com' target='_blank'>RuPay</a>. В "E-Mail получателя" вводить aleksey_grachev@yahoo.com</td>
         </tr>
         <tr>
            <td><a href='http://money.yandex.ru' target='_blank'>Яндекс.деньги</a></td>
            <td>Номер счета: 4100171460078, E-mail все тот-же</td>
         </tr>
      </table>
   </td></tr>
   <tr><td>Так же с благодарностью принимаются любые другие способы. Если Вы их знаете - пишите письма.</td></tr>
</table>
</asp:Content>
