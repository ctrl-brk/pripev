<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Content.aspx.cs" Inherits="Pripev.Web.UI.Admin.Content" MasterPageFile="~/Main.Master" ValidateRequest="false"%>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID='contentScript' runat='server'>
<div class='admin'>
<table border='0' width='100%'>
   <tr>
      <td>
         <auc:ArtistList id='lstArtists' runat='server' OnArtistChanged='lstArtists_ArtistChanged' Rows='60' />
      </td>
      <td valign='top' align='left'>
         <auc:Artist id='ctlArtist' runat='server' OnAlbumChanged='ctlArtist_AlbumChanged' />
      </td>
      <td valign='top' align='left' width='100%'>
         <auc:Album id='ctlAlbum' runat='server' OnSongChanged='ctlAlbum_SongChanged' /><br />
         <auc:Sound id='ctlSound' runat='server' />
      </td>
   </tr>
</table>
</div>
</asp:Content>
