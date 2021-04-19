<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="PrintText.aspx.cs" Inherits="Pripev.Web.UI.Popup.PrintText" MasterPageFile="~/Popup.Master"%>

<asp:Content ContentPlaceHolderID='plhTitle' ID='contentTitle' runat='server'>Печать (pripev.ru)</asp:Content>

<asp:Content ContentPlaceHolderID='plhStyle' ID='contentStyle' runat='server'>
   <style>
   body {padding:0; margin:0; background-color:white; font:normal 13px Verdana;}
   p {padding:10px}
   h1 {font:bold 12px Verdana; text-align:center; text-decoration:underline;}
   .txt {font-size:12px}
   .tb {border-bottom:1px solid black; padding:10px;}
   .tb a {margin-right:10px;}
   .Chords, .tabs {font-weight:bold;}
   .ChordsComment {color:#331DFC; font-style:italic;}
   .Riff {font-weight:bold;}
   .Chorus {font-weight:bold;}
   .SComment {color:gray; font-style:italic;}
   .copy {display:none;}
   @media print
   {
   .tb {display:none}
   }
   </style>
</asp:Content>

<asp:Content ContentPlaceHolderID='plhScript' ID='contentScript' runat='server'>
   <script type="text/javascript">

      var nSize = 12;

      function OnPrint() {
         window.print();
      }

      function SetSize() {
         document.getElementById("h1Title").style.fontSize = "" + nSize + "px";
         document.getElementById("divText").style.fontSize = "" + nSize + "px";
      }

      function SizeUp() {
         nSize += 2;
         SetSize();
      }
      function SizeDn() {
         nSize = (nSize >= 8) ? nSize - 2 : 6;
         SetSize();
      }
   </script>
</asp:Content>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<p id='pSongNotFound' runat='server' visible='false'>Извиняюсь, но такой композиции не найдено :(((</p>
<p id='pTextNotFound' runat='server' visible='false'>Извиняюсь, но текста к этой композиции не найдено :(((</p>
<asp:PlaceHolder ID='plhPrint' runat='server' Visible='false' EnableViewState='false'>
   <div class='tb'>
      <a href="javascript:SizeUp()"><img src="/Images/FontSizeUp.gif" align="absmiddle" border="0" title="Увеличить размер шрифта"></a>
      <a href="javascript:SizeDn()"><img src="/Images/FontSizeDn.gif" align="absmiddle"border="0" title="Уменьшить размер шрифта"></a>
      <a href="javascript:OnPrint()"><img src="/Images/PrintLarge.gif" align="absmiddle" border="0" title="Печатать"></a>
   </div>
      <h1 id='h1Title'><asp:Literal ID='litH1' runat='server' /></h1>
      <div class='txt' id='divText'><asp:Literal ID='litText' runat='server' /></div>
</asp:PlaceHolder>

</asp:Content>
