<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Wanted.aspx.cs" Inherits="Pripev.Web.UI.Wanted.HtmlIndex" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>
<div class='Wanted'>
   <table class='tbl01' cellspacing='0' style='width:600px; margin-bottom:5px;' align='center'>
      <thead><tr><td>А что нам надо...</td></tr></thead>
      <tr><td>
         <p>
            Здесь вы видите список исполнителей/альбомов/треков, информацию о возможности приобретения которых в любом
            приемлемом виде :) я ищу. Приемлемым считается качество не ниже 128/44 и, естественно, без всяких сбоев/щелчков (если это не винил).
            Кроме того, информация нужна именно по указанному альбому, а не вообще. Потому как одна и та же песня в разных альбомах
            зачастую отличается аранжировкой, исполнением или чем-нибудь еще.
         </p>
         <p>
            Так же с благодарностью принимаются информация об исполнителях, которых на сайте пока нет,
            но которых Вы считаете достойными здесь находиться :)
         </p>
         <p><b>
            В связи с тем, что сейчас у меня гораздо меньше времени, которое я могу уделить сайту, чем раньше - для ускорения
            процесса добавления новой информации мне нужна Ваша помощь. Некоторые шаги, упрощающие жизнь, <a href='/WantedHelp.aspx'>описаны здесь</a>.
         </b></p>
         <p>
            Если у вас есть что-либо, <asp:Literal ID='litEmail' runat='server' />напишите мне</a>, и моя благодарность не будет иметь границ (в пределах возможностей :)
            А еще лучше - нажмите на линк "Загрузить" и сотворите разумное доброе вечное немедленно.
         </p>
         <p>Для тех, кто хочет сохранить этот список себе (он меняется периодически), - <a href='/WantedText.aspx' target='_blank'>здесь</a> можно взять текстовую версию.</p>
      </td></tr>
   </table>
   <table cellspacing="0" width="99%" class="tbl03" align='center'>
      <thead><tr><td colspan="5">
         <asp:DropDownList ID='lstTop' runat='server' AutoPostBack='true' OnSelectedIndexChanged='lstTop_SelectedIndexChanged'>
            <asp:ListItem Value='АД' Text='А - Д' />
            <asp:ListItem Value='ЕК' Text='Е - К' />
            <asp:ListItem Value='ЛП' Text='Л - П' />
            <asp:ListItem Value='РФ' Text='Р - Ф' />
            <asp:ListItem Value='ХЯ' Text='Х - Я' />
         </asp:DropDownList>
      </td></tr></thead>
      <pwc:Wanted ID='wntControl' runat='server' Letters='АД' />
      <tfoot><tr><td colspan="5">
         <asp:DropDownList ID='lstBottom' runat='server' AutoPostBack='true' OnSelectedIndexChanged='lstBottom_SelectedIndexChanged'>
            <asp:ListItem Value='АД' Text='А - Д' />
            <asp:ListItem Value='ЕК' Text='Е - К' />
            <asp:ListItem Value='ЛП' Text='Л - П' />
            <asp:ListItem Value='РФ' Text='Р - Ф' />
            <asp:ListItem Value='ХЯ' Text='Х - Я' />
         </asp:DropDownList>
      </td></tr></tfoot>
   </table>
</div>
</asp:Content>
