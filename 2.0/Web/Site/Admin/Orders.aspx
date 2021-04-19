<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Orders.aspx.cs" Inherits="Pripev.Web.UI.Admin.Orders" MasterPageFile="~/Main.Master" ValidateRequest='false'%>

<asp:Content ID='cntMain' runat='server' ContentPlaceHolderID='ContentPlaceHolder1'>
<asp:ScriptManager ID='ScriptManager1' runat='server' EnablePartialRendering='true' />

<div class='admin'>
   <div class='orders'>
      <asp:Repeater ID='rptOrders' runat='server' OnItemCommand='rptOrders_ItemCommand'>
         <HeaderTemplate>
            <table border="0" cellspacing="0" cellpadding="0" class='tbl03'>
               <tr><th>Date</th><th>Name</th><th>Email</th><th>Artist</th><th>Album</th><th>Song</th><th>&nbsp;</th><th>Sound</th><th>Link</th></tr>
         </HeaderTemplate>
         <ItemTemplate>
            <tr>
               <td nowrap class='date'><%# Eval("DATE")%></td>
               <td><%# Eval("NAME")%></td>
               <td><%# Eval("Email")%></a></td>
               <td><%# Eval("ARTIST")%></td>
               <td><%# Eval("ALBUM")%>&nbsp;</td>
               <td><asp:LinkButton ID='btnEdit' runat='server' Text='<%# Eval("SONG")%>' CommandName='Edit' CommandArgument='<%# Eval("ORDER_ID")%>' /></td>
               <td><asp:LinkButton ID='btnDelete' runat='server' Text='X' CommandName='Delete' CommandArgument='<%# Eval("ORDER_ID")%>' /></td>
               <td><%# Eval("SOUND_ID")%>&nbsp;</td>
               <td><%# Eval("ExternalLink")%>&nbsp;</td>
            </tr>
         </ItemTemplate>
         <FooterTemplate>
            </table>
         </FooterTemplate>
      </asp:Repeater>
   </div>
</div>
<br />
<asp:UpdatePanel ID='pnlUserOrders' runat='server'>
   <ContentTemplate>
      <table border="0" cellspacing="0" cellpadding="0" align='left' class='tbl01' width='1550'>
         <tr>
            <td valign="top">
               <table border="1" cellspacing="0" cellpadding="0">
                  <tr><td>Usr.</td><td><asp:Literal ID='litUser' runat='server' /></td></tr>
                  <tr><td>Исп.</td><td><asp:Literal ID='litArtist' runat='server' /></td></tr>
                  <tr><td>Алб.</td><td><asp:Literal ID='litAlbum' runat='server' /></td></tr></td></tr>
                  <tr><td>Комп.</td><td><asp:Literal ID='litSong' runat='server' /></td></tr></td></tr>
                  <tr><td>Cmt.</td><td><font color='red'><asp:Literal ID='litComments' runat='server' /></font></td></tr>
               </table>
            </td>      
            <td valign='top' align='left'>
               <asp:ListBox ID='lstFiles' runat='server' Rows='3' DataTextField="Path" DataValueField="Id" /><br />
               <asp:Label ID='lblMsg' runat='server' CssClass='msg' EnableViewState='false'/>
            </td>
            <td valign='top'>
               <asp:Repeater ID='rptUserOrders' runat='server' OnItemCommand='rptUserOrders_ItemCommand'>
                  <HeaderTemplate>
                     <table border="1" cellspacing="0" cellpadding="0" valign='top'>
                  </HeaderTemplate>
                  <ItemTemplate>
                     <tr>
                        <td><%#Eval( "ARTIST" )%></td>
                        <td><%#Eval( "ALBUM" )%></td>
                        <td><asp:LinkButton ID='lnkEdit' runat='server' CommandName='Edit' CommandArgument='<%#Eval( "ORDER_ID" )%>' Text='<%#Eval( "SONG" ) %>' /></td>
                        <td><%#Eval( "DATE" )%></td>
                        <td><%#Eval( "SOUND_ID" )%></td>
                        <td><asp:LinkButton ID='lnkDelete' runat='server' CommandName='Delete' CommandArgument='<%#Eval( "ORDER_ID" )%>' Text='X' /></td>
                     </tr>
                  </ItemTemplate>
                  <FooterTemplate>
                     </table>
                  </FooterTemplate>
               </asp:Repeater>
            </td>
         </tr>
         <tr><td colspan='3'>
            <asp:UpdatePanel ID='pnlFileBrowser' runat='server'>
               <ContentTemplate>
                  <puc:FileBrowser ID='FileBrowser1' runat='server' OnFileSelected='FileBrowser_FileSelected' FilesMode="Everything" />
               </ContentTemplate>
            </asp:UpdatePanel>
         </td></tr>
      </table>
   </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
