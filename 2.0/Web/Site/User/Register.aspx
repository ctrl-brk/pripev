<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Pripev.Web.UI.User.Register" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentMain' runat='server'>
<asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering='true' />

<asp:MultiView ID='mvView1' runat='server' ActiveViewIndex='0'>
<asp:View id='viewRegistrtion' runat='server'>
<table class='tbl01' width='500' cellspacing='0' align='center'>
   <thead><tr><td>Припевная регистрация</td></tr></thead>
   <tr><td>
      <p align="justify"><img src='/Images/HL/Register.gif' class='icon'>Сначала пару слов без протокола. У Вас может возникнуть резонный вопрос: "Да задолбали уже все этими регистрациями, и на хрена они нужны - небось потом денег захотят..."</p>
      <p align="justify">Абсолютно с Вами согласен, но... так уж получается в силу разных причин. Как минимум хочу заверить, что ни о каких рассылках спама и прочих мерзостях тут разговора быть не может.</p>
      <p align="justify">За то, что Вам придется потратить драгоценное время на эту регистрацию Вы получите разные полезности в виде заказов, новостей и чего-нибудь еще (пока не придумал чего :)</p>
      <p align='center'>Так что, стиснув зубы - вперед!</p>
      <p><em>Кстати, регистрация на сайте не регистрирует Вас на <a href='/Forum'>форуме</a>. Там (если есть желание) надо будет зарегистрироваться отдельно.</em></p>
      <hr size='1'>
      <table border="0" width='99%'>
         <tr>
            <td align="right" width='250'><asp:RequiredFieldValidator id='vldReqName' runat='server' ControlToValidate='txtUserName' ToolTip='Не указано имя' Text='*' /><span class='ReqFld'>*</span>Ваше имя:</td>
            <td><asp:TextBox ID='txtUserName' runat='server' MaxLength='100' /></td>
         </tr>
         <tr>
            <td align="right"><pwc:EmailValidator id='vldReqEmail' runat='server' ControlToValidate='txtUserEmail' ToolTip='Введите email адрес' Text='*' /><span class='ReqFld'>*</span>Email:</td>
            <td><asp:TextBox ID='txtUserEmail' runat='server' MaxLength='100' /></td>
         </tr>
         <tr>
            <td align="right"><asp:RequiredFieldValidator id='vldReqPass' runat='server' ControlToValidate='txtPassword' ToolTip='Введите пароль' Text='*' /><span class='ReqFld'>*</span>Пароль:</td>
            <td><asp:TextBox ID='txtPassword' runat='server' MaxLength='50' TextMode='Password' /></td>
         </tr>
         <tr>
            <td align="right"><asp:CompareValidator ID='vldCmpPass' runat='server' Type='String' ControlToValidate='txtPassword' ControlToCompare='txtConfirmPassword' ToolTip='Пароли должны совпадать' Text='*' /><asp:RequiredFieldValidator EnableClientScript='false' id='vlReqPassConf' runat='server' ControlToValidate='txtConfirmPassword' ToolTip='Подтвердите пароль' Text='*' /><span class='ReqFld'>*</span>Подтвердить пароль:</td>
            <td><asp:TextBox ID='txtConfirmPassword' runat='server' MaxLength='50' TextMode='Password' /></td>
         </tr>
      </table>
      <asp:UpdatePanel ID='pnlUpdForm' runat='server'>
         <ContentTemplate>
            <table border="0" width='99%'>
               <tr>
                  <td align="right" width='250'>Рассылка новостей:</td>
                  <td width="13%"><pwc:RadioButton ID='rbMailListY' runat='server' CssClass='radio' GroupName='rbMailList' OnCheckedChanged='rbMailList_CheckedChanged' AutoPostBack='true' Checked='true' />Да</td>
                  <td><asp:RadioButton ID='rbMailListN' runat='server' CssClass='radio' GroupName='rbMailList' OnCheckedChanged='rbMailList_CheckedChanged' AutoPostBack='true' />Нет</td>
               </tr>
               <tr id="trMailFormat" runat='server'>
                  <td align="right">Формат писем:</td>
                  <td><asp:RadioButton ID='rbMailFormatH' runat='server' CssClass='radio' GroupName='rbMailFormat' OnCheckedChanged='rbMailFormat_CheckedChanged' AutoPostBack='true' Checked='true' />HTML</td>
                  <td><asp:RadioButton ID='rbMailFormatT' runat='server' CssClass='radio' GroupName='rbMailFormat' OnCheckedChanged='rbMailFormat_CheckedChanged' AutoPostBack='true' />Текст</td>
               </tr>
               <tr id="trMailLinks" runat='server'>
                  <td align="right">Ссылки в письмах:<br><em>(сильно увеличивает размер письма,<br>но можно сразу перейти на нужное место)</em></td>
                  <td style='vertical-align:top'><asp:RadioButton ID='rbMailLinksY' runat='server' CssClass='radio' GroupName='rbMailLinks' />Да</td>
                  <td style='vertical-align:top'><asp:RadioButton ID='rbMailLinksN' runat='server' CssClass='radio' GroupName='rbMailLinks' Checked='true' />Нет</td>
               </tr>
               <tr>
                  <td align="right" style='vertical-align:top'>Комментарии/пожелания:</td>
                  <td colspan="2"><asp:TextBox ID='txtUserComments' runat='server' TextMode='MultiLine' Columns='29' Rows='4' /></td>
               </tr>
               <tr><td colspan='3' align="center">Временная зона:</td></tr>
               <tr><td colspan='3' align='center'>
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
                     <asp:ListItem Value='180' Text='(GMT+03:00) Москва, Санкт-Петербург, Волгоград' Selected='True' />
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
      <br>
      <div align='center'><asp:LinkButton ID='btnSubmit' runat='server' CssClass='sbtn' Text='Вперед!' OnClick='btnSubmit_Click'/></div>
   </td></tr>
</table>
</asp:View>

<asp:View ID='viewError' runat='server'>
<table width="550" cellspacing="0" class='tbl01'>
   <thead><tr><td>Припевная регистрация</td></tr></thead>
   <tr><td><p align='justify'>Извините, но Email адрес <b><asp:Literal ID='litEmail' runat='server' /></b> уже зарегистрирован. Если Вы забыли пароль, то <a href='javascript:OnForgottenPassword("")'>Вам сюда</a>. Иначе даже не знаю что и думать. <asp:Literal ID='litContact' runat='server' />Пишите письма</a> - будем разбираться.</p></td>
</table>
</asp:View>
</asp:MultiView>
</asp:Content>
