<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlbumList.ascx.cs" Inherits="Pripev.Web.UI.Admin.UserControls.AlbumList" %>

<asp:ListBox ID='lstAlbums' runat='server' DataTextField='NAME' DataValueField='ALBUM_ID' AutoPostBack='true' />
