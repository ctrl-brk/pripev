<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Upload.aspx.cs" Inherits="Pripev.Web.UI.Popup.Upload" MasterPageFile="~/Popup.Master"%>
<%@ Register assembly="FileUploadLibrary" namespace="darrenjohnstone.net.FileUpload" tagprefix="fup" %>

<asp:Content ContentPlaceHolderID='plhTitle' ID='contentTitle' runat='server'>Загрузка припевов</asp:Content>

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
Огромное спасибо, что добрались сюда. Вот на таких людях и держится сайт :)<br>
Ведите, пожалуйста, e-mail (необязательно), тогда я смогу с вами связаться если загрузка пройдет неудачно.<br>
Есть два пути аплоада:
<ol>
   <li>
      Загрузить на FTP сервер (для тех, кто знает что это такое). На мой взгляд это проще и автоматически решаются всякие
      проблемы таймаутов и прочего. Короче, заливать сюда: <asp:HyperLink ID='lnkFTP' runat='server' /> (используйте passive (пассивное) соединение).<br>
      Кстати, скачать с этого сервера ничего нельзя. Так что не дергайте его без дела :)
   </li>
   <li>
      Загрузить из этого окошка. Большая просьба заполнить все поля формы. Мне так будет легче разобраться что это за файл
      и откуда он. Потом выбирайте имя файла и нажимайте на кнопку "Загрузить".<br>
      В принципе, используя кнопку "Добавить", Вы можете загрузить до 5-ти файлов одновременно, но в связи с низкой пропускной способностью канала этого делать не рекомендуется.<br><br />
      Масксимальный размер загрузки - 100 мегабайт. Если размер Вашего файла больше - свяжитесь со мной или загружайте по ftp.<br>
      Время на загрузку - 1 час.
    </li>
</ol>
</asp:PlaceHolder>

<asp:Literal ID='litResults' runat='server' EnableViewState='false' />

<table cellspacing="0" align="center" class="tbl01" style='width:500px'>
   <thead><tr><td colspan='2'>Чего закачиваем?</td></tr></thead>
   <tr>
      <td align="right">Исполнитель:</td>
      <td><asp:TextBox ID='txtArtist' runat='server' Width='200' /></td>
   </tr>
   <tr>
      <td align="right">Альбом:</td>
      <td><asp:TextBox ID='txtAlbum' runat='server' Width='200' /></td>
   </tr>
   <tr>
      <td align="right">Композиция:</td>
      <td><asp:TextBox ID='txtSong' runat='server' Width='200' /></td>
   </tr>
   <tr>
      <td align="right">E-mail:</td>
      <td><asp:TextBox ID='txtEmail' runat='server' Width='200' /></td>
   </tr>
   <tr>
      <td align="right" valign='top'>Комментарий:</td>
      <td><asp:TextBox ID='txtComment' runat='server' Width='200' Rows='5' TextMode='MultiLine' /></td>
   </tr>
   <tr>
      <td align="right" valign='top'>Файл(ы):</td>
      <td><fup:DJFileUpload ID="fileUpload1" runat="server" ShowAddButton="true" ShowUploadButton="false"/></td>
   </tr>
   <tr><td colspan='2'>&nbsp;</td></tr>
   <tr><td colspan='2' align='center'><asp:LinkButton ID='btnSubmit' runat='server' CssClass='sbtn' Text='Загрузить' /></td></tr>   
</table>

</asp:Content>
