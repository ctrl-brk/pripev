<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="Pripev.Web.UI.Popup.Chat" MasterPageFile="~/Popup.Master"%>
<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID='plhTitle' ID='contentTitle' runat='server'>Припевный чат</asp:Content>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>
   <asp:ScriptManager ID="ScriptManager1" runat="server" />
   <asp:Literal ID='litLogin' runat='server' Visible='false'>Пожалуйста, авторизуйтесь на сайте</asp:Literal>
   <div style="height:100%;">
      <asp:Silverlight ID="Chat1" runat="server" Source="~/ClientBin/Chat.xap" MinimumVersion="2.0.31005.0" Width="700" Height="500" PluginBackground='Transparent' Windowless='true' />
   </div>
</asp:Content>
