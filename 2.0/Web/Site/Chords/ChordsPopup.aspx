<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="ChordsPopup.aspx.cs" Inherits="Pripev.Web.UI.Popup.Chords" MasterPageFile="~/Popup.Master"%>

<asp:Content ContentPlaceHolderID='plhTitle' ID='contentTitle' runat='server'>Определитель аккордов</asp:Content>

<asp:Content ContentPlaceHolderID='plhStyle' ID='contentStyle' runat='server'>
   <style type="text/css">
   .fretno {font-family:Helvetica,Arial,Helvetica,Geneva,Verdana,Tahoma; font-size:10px; color:#333333; text-align:center}
   .n_img {}
   .n_txt {margin-top:-16px; margin-bottom:-16px; height:0; font-family:Helvetica,Verdana,Arial,Helvetica,Geneva,Verdana,Tahoma; font-size:9px; color:white; text-align: center}
   .ta {background-color:#FDF6D1; font-family:monospace; font-size:12px;}
   .bb {font-size:0.8em; letter-spacing:-1;}
   .rb {font-family:Arial,Helvetica,Geneva; font-size:8pt; font-weight:normal; color:#333333; text-align:left;}
   acronym, abbr {border-bottom:0px; cursor:help;}

   body {margin:0; padding:0; background-color:#F4F0EE}
   a {color:black;}
   h1 {vertical-align:top; padding:2px 0 0 0; font:13px Verdana; color:#BE9175; background:url(/Images/Bkgs/Header.gif); font-weight:bold; text-align:center; height:26px;}
   </style>
</asp:Content>

<asp:Content ContentPlaceHolderID='plhScript' ID='contentScript' runat='server'>
   <script language="JavaScript" src="Chords.js" charset='windows-1251'></script>
</asp:Content>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<h1>Определитель аккордов</h1>
<script language="JavaScript">buildit();</script>

</asp:Content>
