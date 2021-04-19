<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Album.aspx.cs" Inherits="Pripev.Web.UI.Album" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<script type="text/javascript">

function OnAlbumChange( obj )
{
   Redirect( "/Album.aspx?Id=" + obj.options[obj.selectedIndex].value + "&Art=<%=Request["Art"]%>" );
}

function OnSongSoundComment( nSongId )
{
   window.open( "/User/SoundComment.aspx?SongId=" + nSongId, "", "directories=no,height=350,width=350,location=no,menubar=no,status=0,toolbar=no,resizable=yes,scrollbars=yes" );
}
</script>

   <div class='Album'>
      <asp:Literal ID='litNotFound' runat='server' Visible='false' EnableViewState='false'><p>Извиняемся, но такого не найдено :(((</p></asp:Literal>
      <asp:PlaceHolder ID='plhAlbum' runat='server' EnableViewState='false'>
         <pwc:AlbumImageList ID='lstAlbums' runat='server' DataTextField='NAME' DataValueField='ALBUM_ID' ArtistLinkFormat='/Artist.aspx?Id=' />
         <table cellspacing="0" class="tbl03" align='center'>
            <thead><tr>
               <td ID='tdHeaderSongs' runat="server">Песни</td><td class='lst'><asp:HyperLink ID='lnkListen' runat='server' ToolTip='Слушать' ImageUrl='/Images/Listen.gif' /></td>
            </tr></thead>
            <tr>
               <th>№</th>
               <th>Название</th>
               <th id="thSounds" runat="server" class="snd">&nbsp;</th>
               <asp:Literal ID='litComments' runat='server' Visible='false'><th class='cmt' title='Комментировать'>&nbsp;</th></asp:Literal>
            </tr>
            <asp:Repeater ID='rptSongs' runat='server' OnItemDataBound='rptSongs_ItemDataBound'>
               <ItemTemplate>
                  <tr>
                     <td id='tdTrackNum' runat='server' class='trk'><%# Eval( "TrackNumber" ) %></td>
                     <td id='tdShareInfo' runat='server'></td>
                     <td id='tdSounds' runat='server'></td>
                     <td id='tdComment' runat='server' class='cmt'><a href='javascript:OnSongSoundComment(<%#Eval( "Id" ) %>)' title='Комментировать'><img src='/Images/Icons/Comment1.gif' border='0' alt=''></a></td>
                  </tr>
               </ItemTemplate>
               <AlternatingItemTemplate>
                  <tr class='st01'>
                     <td id='tdTrackNum' runat='server' class='trk'><%# Eval( "TrackNumber" ) %></td>
                     <td id='tdShareInfo' runat='server'></td>
                     <td id='tdSounds' runat='server'></td>
                     <td id='tdComment' runat='server' class='cmt'><a href='javascript:OnSongSoundComment(<%#Eval( "Id" ) %>)' title='Комментировать'><img src='/Images/Icons/Comment1.gif' border='0' alt=''></a></td>
                  </tr>
               </AlternatingItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder ID='plhNoInfo' runat='server' Visible='false'>
               <tr><td id="tdNoInfo" runat="server">К сожалению, у меня нет информации по этому альбому :(&nbsp;&nbsp;</td></tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID='plhFooter' runat='server' Visible='false'>
               <tfoot><tr><td ID='tdFooter' runat='server'>
                  <asp:HyperLink id='lnkAllSongs' runat='server' ToolTip='Тексты всех песен альбома' NavigateUrl='/AlbumSongs.aspx?Id=' />
               </td></tr></tfoot>
           </asp:PlaceHolder>
         </table>
      </asp:PlaceHolder>
      <br />
      <asp:Panel ID='pnlInfo' runat='server' CssClass='info' EnableViewState='false'>
         <h1>Дополнительная информация</h1>
         <table id='tblInfoHeader' runat='server' class='tblInfo' cellspacing='0'>
            <tr>
               <td class='st01'><asp:Literal ID='litYearPrinted' runat='server' Text='&nbsp;' /></td>
               <td class='st02'><asp:Literal ID='litProducer' runat='server' Text='&nbsp;' /></td>
            </tr>
         </table>
         <hr id='hrInfo' runat='server' />
         <asp:Literal ID='litInfo' runat='server' />
      </asp:Panel>
   </div>
   
</asp:Content>
