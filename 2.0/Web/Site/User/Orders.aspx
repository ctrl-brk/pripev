<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Orders.aspx.cs" Inherits="Pripev.Web.UI.User.Orders" MasterPageFile="~/Main.Master" %>
<%@ Register TagPrefix="puc" Namespace="Pripev.Web.UI.UserControls" Assembly="Site" %>

<asp:Content ContentPlaceHolderID='plhScript' ID='contentScript' runat='server'>

<script type="text/javascript">

var iNormal=new Image, iOver=new Image, iDown=new Image;
iNormal.src="/Images/Buttons/Browse.gif";
iOver.src="/Images/Buttons/BrowseOver.gif";
iDown.src="/Images/Buttons/BrowseDown.gif";

function ArtistListBox() {
   window.open("/User/ArtistListBox.aspx", "", "directories=no,height=220,width=350,location=no,menubar=no,status=0,toolbar=no,resizable=yes,scrollbars=yes");
}

function OnDelete(nId) {
   Redirect("/User/DelOrder.aspx?Id=" + nId);
}

function OnComment(nOrderId) {
   window.open("/User/SoundComment.aspx?OrderId=" + nOrderId, "", "directories=no,height=350,width=350,location=no,menubar=no,status=0,toolbar=no,resizable=yes,scrollbars=yes");
}

function OnHistory() {
   var url = "/User/OrdersProgress.aspx?Hst=" + GetControlValue("Hst");
   if (GetControlValue("AllOrd", true)) url += "&AllOrd=Y"
   Redirect(url);
}

function OnLoad() {
   SetControlValue("Hst", Request("Hst"));
}
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentMain' runat='server'>
<asp:ScriptManager ID='ScriptManager1' runat='server' EnablePartialRendering='true' CompositeScript-ScriptMode="Release" ScriptMode="Release" />

<asp:MultiView ID='mvOrders' runat='server' ActiveViewIndex='0'>

<asp:View ID='viewOrder' runat='server'>
   <div class='Orders'>
      <table cellspacing="0" width="98%" align="center" class="tbl01">
         <thead><tr><td colspan='2'>Заказы</td></tr></thead>
         <asp:PlaceHolder ID='plhMsg' runat='server' Visible='false'>
            <tr><td class='alert' colspan='2'><asp:Literal ID='litMsg' runat='server' /></td></tr>
         </asp:PlaceHolder>
         <tr>
         <tr><td colspan='2'>
            <p>Если нижеследующий текст не совсем понятен, то <a href='/Help/Video/Orders/Orders.html' target='_blank'>вот здесь можно посмотреть видео объяснялки</a>.</p>
            <p>Здесь вы можете заказать (на левой панели) какую-нибудь совершенно необходимую Вам композицию (к примеру, вы забыли мелодию или 
            аранжировку и не можете правильно проорать припев), которую Вы не смогли приобрести ни каким из возможных способов при
            всем Вашем старании.</p>
            <p>Если Вы уверены, что все возможные шаги Вами уже предприняты и не принесли результата - тогда попробуем Вам помочь.
            Заказать можно отнюдь не что угодно, а только те композиции, которые имееются в наличии.
            Данные композиции отмечены на сайте специконками (типа иконок винампа и.т.п. Расшифровка всех иконок доступна в разделе "<a href='/About.aspx'>О проекте</a>").
            Поэтому сначала проверьте или <b>пользуйтесь кнопками выбора</b>.</p>
            <p>Результат поисков может быть разным. Если следы отыщутся - Вам будет сообщено по email. На всякий случай проверяйте результаты работы Ваших спам-фильтров :)</p>
            <p>Кроме того, на правой панели вы можете выбрать интересующую Вас композицию напрямую, если вам не лень покликать по ссылкам. Это гораздо быстрее, чем ждать выполнения заказа :)</p>
            <p>В свою очередь - если вы обладаете интересной (для сайта) информацией - просьба ею делиться. Особо интересующая указана
            в разделе "<a href='javascript:Redirect("/Wanted.aspx")'>Помочь</a>".</p>
            <p>Как Вы понимаете - вся эта потеха требует сил и времени, которых как всегда нет. Так что просьба не злоупотреблять (это
            включает множественную регистрацию). На злоупотребления мы будем обижаться. Кроме того, результаты поиска публикуются с разными временными промежутками (может быть день, два или иногда и больше). Но не отчаивайтесь - объявлять что-то в розыск вы можете каждый день.</p>
            <p>Периодически почитывайте <a href='http://www.pripev.ru/Forum/forum_posts.asp?TID=122&PN=1' target='_blank'>ветку нашего форума</a>, чтобы не забыть откуда такие сложности :)</p>
            На данный момент ограничения таковы:<br>
            &nbsp;&nbsp;&nbsp;- за период в <b>24 часа</b> Вы можете объявить в розыск не более <b>10</b>-ти композиций.<br>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(eсли Вам позарез нужно больше, то напишите мне письмо.)
            <p><em>Да, и постарайтесь не пользоваться кнопками браузера (мыши) Back/Назад и Forward/Вперед на этой странице. Они могут неправильно работать.</em></p>
            <div style='text-align:center'><br />Если чего не так или есть вопросы - <asp:Literal ID='litContact' runat='server' />пишите письма</a>.</div>
            <br />
         </td>
         <tr><th style='text-align:center;width:310px'>Объявить в розыск</th><th style='text-align:center'>Выбрать из найденного</th></tr>
         <tr>
            <td valign='top' style='border-right:1px dashed #FACDB1;width:310px'>
               <table border="0" align="center" style='width:300px'>
                  <tr><td align="right"><asp:RequiredFieldValidator ID='vldReqArtist' runat='server' ControlToValidate='txtArtist' Text='*' ToolTip='Выберите исполнителя' ValidationGroup='grpVldOrder' /><span class='ReqFld'>*</span>Исполнитель:</td><td><asp:TextBox ID='txtArtist' runat='server' MaxLength='50' /></td><td><img src="/images/Buttons/Browse.gif" onMouseOver="src=iOver.src" onMouseOut="src=iNormal.src" onMouseDown="src=iDown.src" onClick="ArtistListBox()"></td></tr>
                  <tr><td align="right"><asp:RequiredFieldValidator ID='vldReqAlbum' runat='server' ControlToValidate='txtAlbum' Text='*' ToolTip='Выберите альбом' ValidationGroup='grpVldOrder' /><span class='ReqFld'>*</span>Альбом:</td><td><asp:TextBox ID='txtAlbum' runat='server' MaxLength='100' /></td><td><img src="/images/Buttons/Browse.gif" onMouseOver="src=iOver.src" onMouseOut="src=iNormal.src" onMouseDown="src=iDown.src" onClick="AlbumListBox()"></td></tr>
                  <tr><td align="right"><asp:RequiredFieldValidator ID='vldReqSong' runat='server' ControlToValidate='txtSong' Text='*' ToolTip='Выберите композицию' ValidationGroup='grpVldOrder' /><span class='ReqFld'>*</span>Композиция:</td><td><asp:TextBox ID='txtSong' runat='server' MaxLength='100' /></td><td><img src="/images/Buttons/Browse.gif" onMouseOver="src=iOver.src" onMouseOut="src=iNormal.src" onMouseDown="src=iDown.src" onClick="SongListBox()"></td></tr>
                  <tr><td align="right">Уточнения:<br><small><em>(к примеру, если в альбоме два трека<br>с одинаковым названием)</em></small></td><td colspan='2' valign='top'><asp:TextBox ID='txtComment' runat='server' MaxLength='250' /></td></tr>
                  <tr><td align="center" colspan='2'><asp:LinkButton ID='btnSubmit' runat='server' CssClass='sbtn' Text='В розыск!' ValidationGroup='grpVldOrder' OnClick='btnSubmit_Click' /></td></tr>
               </table>
            </td>
            <td valign='top' width='100%'>
               <asp:UpdatePanel ID='upnlFileBrowser' runat="server">
                  <ContentTemplate>
                     <puc:FileBrowser ID='FileBrowser1' runat='server' OnFileSelected='FileBrowser_FileSelected' />
                  </ContentTemplate>   
               </asp:UpdatePanel>
            </td>
         </tr>
      </table>
      <br>
      <table cellspacing="0" align="center" class="tbl03">
         <thead><tr>
            <td colspan='2' style='text-align:left; padding-left:5px;'>Ваш розыск</td>
            <td colspan='5' style='text-align:right'>
               <select id='Hst' onChange='OnHistory()'>
                  <option value=''>Текущий</option>
                  <option value='1'>24 часа</option>
                  <option value='2'>48 часов</option>
                  <option value='7'>За неделю</option>
               </select>
         </tr></thead>
         <tr>
            <th>Дата</th>
            <th>Исполнитель</th>
            <th>Альбом</th>
            <th>Композиция</th>
            <th>Статус</th>
            <th>Коммент</th>
            <th>&nbsp;</th>
         </tr>
         <asp:Repeater ID='rptUserOrders' runat='server' OnItemDataBound='rptUserOrders_ItemDataBound' EnableViewState='false'>
            <ItemTemplate>
               <tr>
                  <td class='date' nowrap><%# Eval( "OrderDate" )%></td>
                  <asp:PlaceHolder ID='plhDirectOrder' runat='server'>
                     <td colspan='3' id='tdDirectPath' runat='server'><%# Eval( "DirectPath" )%></td>
                  </asp:PlaceHolder>
                  <asp:PlaceHolder ID='plhNormalOrder' runat='server'>
                     <td id='tdArtist' runat='server'><%# Eval( "ArtistName" ) %></td>
                     <td id='tdAlbum' runat='server'><%# Eval( "AlbumName" ) %></td>
                     <td id='tdSong' runat='server'><%# Eval( "SongName" ) %></td>
                  </asp:PlaceHolder>
                  <td class='ico'><%# Eval( "IconHtml" )%></td>
                  <td class='ico'><asp:HyperLink ID='lnkComment' runat='server' NavigateUrl='#' ToolTip='Комментировать' ImageUrl='/Images/Icons/Comment1.gif' border='0' onclick='<%# "OnComment(" + Eval( "Id" ) + ")" %>'/>&nbsp;</td>
                  <td class='ico'><asp:HyperLink ID='lnkDelete' runat='server' NavigateUrl='#' ToolTip='Удалить' ImageUrl='/Images/Delete.gif' border='0' onclick='<%# "OnDelete(" + Eval( "Id" ) + ")" %>'/>&nbsp;</td>
               </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
               <tr class='st01'>
                  <td class='date' nowrap><%# Eval( "OrderDate" )%></td>
                  <asp:PlaceHolder ID='plhDirectOrder' runat='server'>
                     <td colspan='3' id='tdDirectPath' runat='server'><%# Eval( "DirectPath" )%></td>
                  </asp:PlaceHolder>
                  <asp:PlaceHolder ID='plhNormalOrder' runat='server'>
                     <td id='tdArtist' runat='server'><%# Eval( "ArtistName" ) %></td>
                     <td id='tdAlbum' runat='server'><%# Eval( "AlbumName" ) %></td>
                     <td id='tdSong' runat='server'><%# Eval( "SongName" ) %></td>
                  </asp:PlaceHolder>
                  <td class='ico'><%# Eval( "IconHtml" )%></td>
                  <td class='ico'><asp:HyperLink ID='lnkComment' runat='server' NavigateUrl='#' ToolTip='Комментировать' ImageUrl='/Images/Icons/Comment1.gif' border='0' onclick='<%# "OnComment(" + Eval( "Id" ) + ")" %>'/>&nbsp;</td>
                  <td class='ico'><asp:HyperLink ID='lnkDelete' runat='server' NavigateUrl='#' ToolTip='Удалить' ImageUrl='/Images/Delete.gif' border='0' onclick='<%# "OnDelete(" + Eval( "Id" ) + ")" %>'/>&nbsp;</td>
               </tr>
            </AlternatingItemTemplate>
         </asp:Repeater>
         <asp:PlaceHolder ID='plhAllOrders' runat='server' Visible='false'>
            <table cellspacing="0" align="center" class="tbl03" style='margin-top:5px'>
               <thead>
                  <tr><td colspan='6' style='text-align:left'>
                     &nbsp;<asp:CheckBox ID='cbAllOrders' runat='server' Text='Остальной розыск' OnCheckedChanged='cbAllOders_CheckedChanged' AutoPostBack='true' />
                  </td></tr>
               </thead>
               <tr>
                  <th>Дата</th>
                  <th>Исполнитель</th>
                  <th>Альбом</th>
                  <th>Композиция</th>
                  <th>Статус</th>
                  <th>Коммент</th>
               </tr>
               <asp:Repeater ID='rptAllOrders' runat='server' OnItemDataBound='rptUserOrders_ItemDataBound' EnableViewState='false'>
                  <ItemTemplate>
                     <tr>
                        <td class='date' nowrap><%# Eval( "OrderDate" )%></td>
                        <asp:PlaceHolder ID='plhDirectOrder' runat='server'>
                           <td colspan='3' id='tdDirectPath' runat='server'><%# Eval( "DirectPath" )%></td>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID='plhNormalOrder' runat='server'>
                           <td id='tdArtist' runat='server'><%# Eval( "ArtistName" ) %></td>
                           <td id='tdAlbum' runat='server'><%# Eval( "AlbumName" ) %></td>
                           <td id='tdSong' runat='server'><%# Eval( "SongName" ) %></td>
                        </asp:PlaceHolder>
                        <td class='ico'><%# Eval( "IconHtml" )%></td>
                        <td class='ico'><asp:HyperLink ID='lnkComment' runat='server' NavigateUrl='#' ToolTip='Комментировать' ImageUrl='/Images/Icons/Comment1.gif' border='0' onclick='<%# "OnComment(" + Eval( "Id" ) + ")" %>'/>&nbsp;</td>
                     </tr>
                  </ItemTemplate>
                  <AlternatingItemTemplate>
                     <tr class='st01'>
                        <td class='date' nowrap><%# Eval( "OrderDate" )%></td>
                        <asp:PlaceHolder ID='plhDirectOrder' runat='server'>
                           <td colspan='3' id='tdDirectPath' runat='server'><%# Eval( "DirectPath" )%></td>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID='plhNormalOrder' runat='server'>
                           <td id='tdArtist' runat='server'><%# Eval( "ArtistName" ) %></td>
                           <td id='tdAlbum' runat='server'><%# Eval( "AlbumName" ) %></td>
                           <td id='tdSong' runat='server'><%# Eval( "SongName" ) %></td>
                        </asp:PlaceHolder>
                        <td class='ico'><%# Eval( "IconHtml" )%></td>
                        <td class='ico'><asp:HyperLink ID='lnkComment' runat='server' NavigateUrl='#' ToolTip='Комментировать' ImageUrl='/Images/Icons/Comment1.gif' border='0' onclick='<%# "OnComment(" + Eval( "Id" ) + ")" %>'/>&nbsp;</td>
                     </tr>
                  </AlternatingItemTemplate>
               </asp:Repeater>
            </table>
         </asp:PlaceHolder>
      </table>
   </div>
</asp:View>

<asp:View ID='viewNoAccess' runat='server'>
   В данный момент этот раздел недоступен, зайдите через денек-другой.<br>
   <a href='/Forum/forum_posts.asp?TID=122&PN=1&TPN=1'>Причины всех сложностей изложены здесь.</a><br>
   Просьба делиться мнениями, оставлять комментарии и советы.
</asp:View>

</asp:MultiView>

</asp:Content>
