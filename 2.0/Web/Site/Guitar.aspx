<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guitar.aspx.cs" Inherits="Pripev.Web.UI.Guitar.Index" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID='contentScript' runat='server'>

<div class='Guitar'>
<table cellspacing="0" align="center" class="tbl01">
   <thead><tr><td colspan="2">Гитарные ссылки</td></tr></thead>
   <tr><td colspan='2'>Здесь вы видите ссылки на различные сайты, или на материалы моего сайта, содержащие полезную гитарную информацию.</td></tr>
   <tr>
      <th>Ссылка</th>
      <th>Описание</th>
   </tr>
   <tr>
      <td><a href="http://www.guitar.ru" target="_blank">Guitar.ru</a></td>
      <td>Главный гитарный сайт :)</td>
   </tr>
   <tr>
      <td><a href="/Guitar/Tabs.aspx">Табулатуры</a></td>
      <td>Что такое табулатуры. Краткое описание</td>
   </tr>
   <tr>
      <td><a href="/Guitar/Tepping.aspx">Теппинг</a></td>
      <td>FAQ по теппингу</td>
   </tr>
   <tr>
      <td><a href="/Guitar/Alter.aspx">Альтерация аккордов</a></td>
      <td>Неплохое описание для начинающих</td>
   </tr>
   <tr>
      <td><a href="/Guitar/ChordsFAQ.aspx">Аккорды - FAQ</a></td>
      <td>FAQ по аккордам</td>
   </tr>
   <tr>
      <td><a href="/Guitar/Chords.aspx">Аккорды</a></td>
      <td>Сборная информация по аккордам и аппликатурам</td>
   </tr>
   <tr>
      <td><a href="/Guitar/Lyrics.aspx">LYRICS</a></td>
      <td>Описание формата LYRICS</td>
   </tr>
   <tr>
      <td><a href="/Guitar/Samouchit.zip">Самоучитель</a></td>
      <td>Самоучитель аккомпанемента на 6-ти струнной гитаре (файл в формате zip)</td>
   </tr>
   <tr>
      <td><a href="/Guitar/TabRead.aspx">Табулатуры</a></td>
      <td>Как читать табулатуры. С миру по нитке.</td>
   </tr>
</table>
</div>

</asp:Content>
