<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Pripev.Web.UI.User.Account" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentMain' runat='server'>
<asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering='true' />

<table class='tbl01' width='500' cellspacing='0' align='center'>
   <thead><tr><td>Типа аккаунт</td></tr></thead>
   <tr><td>
      <p align="center" class='ni'><img src='/Images/HL/Account.gif' class='icon'>Мой (как это обычно пишут :), а на самом деле ВАШ аккаунт.<br>Можете поменять здесь что хотите. Точнее, что возможно :)</p>
      <hr size='1'>
      <table border="0" align='center' width='99%'>
         <tr>
            <td align="right" width='250'>Статус:</td>
            <td><strong><asp:Literal ID='litStatusDesc' runat='server' /></strong></td>
         </tr>
         <tr id='trAlert' runat='server' visible='false' enableviewstate='false'>
            <td colspan='2' align='center'><asp:Label ID='lblAlert' runat='server' CssClass='alert' /></td>
         </tr>
      </table>
      <asp:PlaceHolder ID='plhWaitStatus' runat='server' Visible='false'>
         <table border="0" align='center' width='99%'>
            <tr><td colspan='2'>
               <asp:Literal ID='litWaitStatus' runat='server'>
                  Вы должны были получить Email со ссылкой для подтверждения аккаунта. Если по каким-то причинам Вы его не
                  получили, то можете нажать кнопку "Повторить" для повторной отсылки или ввести Ваш новый Email адрес. Если и это не
                  поможет - пишите письма, будем разбираться.
               </asp:Literal>
            </td></tr>
            <tr id='trRetryEmail' runat='server'>
               <td width='250' align="right"><pwc:EmailValidator id='vldReqEmailRetry' runat='server' ControlToValidate='txtRetryEmail' ToolTip='Введите email адрес' Text='*' />Email:</td>
               <td><asp:TextBox ID='txtRetryEmail' runat='server' MaxLength='100' /></td>
            </tr>
         </table>
      </asp:PlaceHolder>
      <asp:PlaceHolder ID='plhActiveStatus' runat='server'>
         <table border="0" align='center' width='99%'>
            <tr>
               <td align="right" width='250'><asp:RequiredFieldValidator id='vldReqName' runat='server' ControlToValidate='txtUserName' ToolTip='Не указано имя' Text='*' /><span class='ReqFld'>*</span>Ваше имя:</td>
               <td><asp:TextBox ID='txtUserName' runat='server' MaxLength='100' /></td>
            </tr>
            <tr>
               <td align="right"><pwc:EmailValidator id='vldReqEmail' runat='server' ControlToValidate='txtUserEmail' ToolTip='Введите email адрес' Text='*' /><span class='ReqFld'>*</span>Email:<br><em>(при смене потребуется подтверждение)</em></td>
               <td><asp:TextBox ID='txtUserEmail' runat='server' MaxLength='100' /></td>
            </tr>
            <tr>
               <td align="right">Пароль:<br><em>(оставьте пустым, если не хотите сменить)</em></td>
               <td><asp:TextBox ID='txtPassword' runat='server' TextMode='Password' MaxLength='50' /></td>
            </tr>
            <tr>
               <td align="right"><asp:CompareValidator ID='vldCmpPass' runat='server' Type='String' ControlToValidate='txtPassword' ControlToCompare='txtConfirmPassword' ToolTip='Пароли должны совпадать' Text='*' />Подтвердить пароль:</td>
               <td><asp:TextBox ID='txtConfirmPassword' runat='server' TextMode='Password' MaxLength='50' /></td>
            </tr>
         </table>
         <asp:UpdatePanel ID='pnlUpdForm' runat='server'>
            <ContentTemplate>
               <table border="0" align='center' width='99%'>
                  <tr>
                     <td align="right" width='250'>Рассылка новостей:</td>
                     <td width="13%" align='left'><pwc:RadioButton ID='rbMailListY' runat='server' CssClass='radio' GroupName='rbMailList' OnCheckedChanged='rbMailList_CheckedChanged' AutoPostBack='true' />Да</td>
                     <td><asp:RadioButton ID='rbMailListN' runat='server' CssClass='radio' GroupName='rbMailList' OnCheckedChanged='rbMailList_CheckedChanged' AutoPostBack='true' />Нет</td>
                  </tr>
                  <tr id="trMailFormat" runat='server'>
                     <td align="right">Формат писем:</td>
                     <td><asp:RadioButton ID='rbMailFormatH' runat='server' CssClass='radio' GroupName='rbMailFormat' OnCheckedChanged='rbMailFormat_CheckedChanged' AutoPostBack='true' />HTML</td>
                     <td><asp:RadioButton ID='rbMailFormatT' runat='server' CssClass='radio' GroupName='rbMailFormat' OnCheckedChanged='rbMailFormat_CheckedChanged' AutoPostBack='true' />Текст</td>
                  </tr>
                  <tr id="trMailLinks" runat='server'>
                     <td align="right">Ссылки в письмах:<br><em>(сильно увеличивает размер письма,<br>но можно сразу перейти на нужное место)</em></td>
                     <td style='vertical-align:top'><asp:RadioButton ID='rbMailLinksY' runat='server' CssClass='radio' GroupName='rbMailLinks' />Да</td>
                     <td style='vertical-align:top'><asp:RadioButton ID='rbMailLinksN' runat='server' CssClass='radio' GroupName='rbMailLinks' />Нет</td>
                  </tr>
                  <tr><td colspan='3' align="center">Временная зона:</td></tr>
                  <tr><td colspan='3' align="center">
                     <asp:DropDownList ID='ddlTimeOffset' runat='server'>
                        <asp:ListItem Value='-720' Text='(GMT-12:00) Линия перемены даты' />
                        <asp:ListItem Value='-660' Text='(GMT-11:00) о. Мидуэй, Самоа' />
                        <asp:ListItem Value='-600' Text='(GMT-10:00) Гавайи' />
                        <asp:ListItem Value='-540' Text='(GMT-09:00) Аляска' />
                        <asp:ListItem Value='-480' Text='(GMT-08:00) Тихоокеанское время; Тихуана' />
                        <asp:ListItem Value='-420' Text='(GMT-07:00) Горное время' />
                        <asp:ListItem Value='-360' Text='(GMT-06:00) Центральное время' />
                        <asp:ListItem Value='-300' Text='(GMT-05:00) Восточное время' />
                        <asp:ListItem Value='-240' Text='(GMT-04:00) Атлантическое время (Канада)' />
                        <asp:ListItem Value='-190' Text='(GMT-03:30) Ньюфаундленд' />
                        <asp:ListItem Value='-180' Text='(GMT-03:00) Бразилия, Гренладния' />
                        <asp:ListItem Value='-120' Text='(GMT-02:00) Среднеатлантическое время' />
                        <asp:ListItem Value='-60' Text='(GMT-01:00) Азорские о-ва' />
                        <asp:ListItem Value='0' Text='(GMT) Среднее время по Гринвичу' />
                        <asp:ListItem Value='60' Text='(GMT+01:00) Амстердам, Берлин, Вена' />
                        <asp:ListItem Value='120' Text='(GMT+02:00) Киев, Минск, Прибалтика, Иерусалим' />
                        <asp:ListItem Value='180' Text='(GMT+03:00) Москва, Санкт-Петербург, Волгоград' />
                        <asp:ListItem Value='210' Text='(GMT+03:30) Тегеран' />
                        <asp:ListItem Value='240' Text='(GMT+04:00) Баку, Тбилиси, Ереван' />
                        <asp:ListItem Value='270' Text='(GMT+04:30) Кабул' />
                        <asp:ListItem Value='300' Text='(GMT+05:00) Екатеринбург, Ташкент' />
                        <asp:ListItem Value='330' Text='(GMT+05:30) Мадрас, Калькутта, Бомбей, Нью-Дели' />
                        <asp:ListItem Value='345' Text='(GMT+05:45) Катманду' />
                        <asp:ListItem Value='360' Text='(GMT+06:00) Алматы, Новосибирск' />
                        <asp:ListItem Value='390' Text='(GMT+06:30) Рангун' />
                        <asp:ListItem Value='420' Text='(GMT+07:00) Красноярск, Бангкок, Ханой, Джакарта' />
                        <asp:ListItem Value='480' Text='(GMT+08:00) Иркутск, Улан-Батор' />
                        <asp:ListItem Value='540' Text='(GMT+09:00) Якутск, Сеул, Осака, Токио' />
                        <asp:ListItem Value='570' Text='(GMT+09:30) Дарвин, Аделаида' />
                        <asp:ListItem Value='600' Text='(GMT+10:00) Владивосток, Мельбурн, Сидней' />
                        <asp:ListItem Value='660' Text='(GMT+11:00) Магадан, Соломоновы о-ва, Новая Каледония' />
                        <asp:ListItem Value='720' Text='(GMT+12:00) Фиджи, Камчатка, Маршалловы о-ва' />
                        <asp:ListItem Value='780' Text='(GMT+13:00) Нукуалофа' />
                     </asp:DropDownList>
                  </td></tr>
               </table>
            </ContentTemplate>
         </asp:UpdatePanel>
      </asp:PlaceHolder>   
      <br>
      <div align='center'>
         <asp:LinkButton ID='btnRetry' runat='server' CssClass='sbtn' Text='Повторить' Visible='false' EnableViewState='false' OnClick='btnRetry_Click' />
         <asp:LinkButton ID='btnSubmit' runat='server' CssClass='sbtn' Text='Вот так' Visible='false' EnableViewState='false' OnClick='btnSubmit_Click' />
      </div>
</table>

</asp:Content>
