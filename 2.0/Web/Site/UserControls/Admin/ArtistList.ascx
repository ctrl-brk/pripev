<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArtistList.ascx.cs" Inherits="Pripev.Web.UI.Admin.UserControls.ArtistList" %>

<asp:ListBox ID='lstArtists' runat='server' DataTextField='NAME' DataValueField='ARTIST_ID' AutoPostBack='true' OnSelectedIndexChanged='lstArtists_SelectedIndexChanged' />
