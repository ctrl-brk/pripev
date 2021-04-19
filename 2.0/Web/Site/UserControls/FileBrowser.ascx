<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="FileBrowser.ascx.cs" Inherits="Pripev.Web.UI.UserControls.FileBrowser" EnableViewState="false" %>

<asp:PlaceHolder ID='plhButtons' runat='server' />
<asp:Panel ID='pnlBrowser' runat='server' CssClass='FileBrowser'>
   <table cellspacing="0" width="100%" align="center" class='tbl01'>
      <tr><td runat="server" id="tdHdr">
         <table border='0' width='100%'>
            <tr>
               <td width='30%'>
                  <asp:LinkButton ID='lnkUp' runat='server' CssClass='up' Text='Up' OnClick='lnkUp_Click' />&nbsp;&nbsp;&nbsp;<asp:LinkButton ID='lnkRoot' runat='server' CssClass='root' Text='Root' OnClick='lnkRoot_Click' />
               </td>
               <td align='right'>Путь: <asp:Literal ID='litPath' runat='server' /></td>
            </tr>
         </table>
         <hr size='1'>
      </td></tr>
      <tr id='trFiles' runat='server' />
   </table>   
</asp:Panel>
