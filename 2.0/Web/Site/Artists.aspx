<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Artists.aspx.cs" Inherits="Pripev.Web.UI.Artists" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<div class='Artists'>
   <pwc:ArtistList id='lstArtists' runat='server' LinkTemplate='/Artist.aspx?Id=' />
</div>

</asp:Content>
