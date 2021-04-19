<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="Pripev.Web.UI.Home" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID='cplhMenu1' ID='contentMenu1' runat='server'>
   <asp:Panel ID='pnlComm' runat='server' CssClass='comm' Visible='false'>
      <h1>�������</h1>
      � ����� ����� �� ���� ���� �������
   </asp:Panel>
</asp:Content>

<asp:Content ContentPlaceHolderID='ContentPlaceHolder1' ID='contentBody' runat='server'>

<div class='Home'>

<table border="0" cellpadding="0" width='99%'>
   <tr>
      <td width='305' valign='top'>
         <table border="0" cellspacing="0" class="tbl01 stat" width='100%'>
            <thead><tr><td colspan="4">���� ��� ����</td></tr></thead>
            <tr>
               <td>������������:</td><td><asp:Label ID='lblArtists' runat='server' EnableViewState='false' /></td>
               <td>��������:</td><td><asp:Label ID='lblAlbums' runat='server' EnableViewState='false' /></td>
            </tr>
            <tr>
               <td>T������:</td><td><asp:Label ID='lblTexts' runat='server' EnableViewState='false' /></td>
               <td>...� ������:</td><td><asp:Label ID='lblChords' runat='server' EnableViewState='false' /></td>
            </tr>
            <tr>
               <td>������:</td><td><asp:Label ID='lblMP3All' runat='server' EnableViewState='false' /></td>
               <td>...online:</td><td><asp:Label ID='lblMP3Online' runat='server' EnableViewState='false' /></td>
            </tr>
            <tr>
               <td>MIDI:</td><td><asp:Label ID='lblMidi' runat='server' EnableViewState='false' /></td>
               <td>Karaoke:</td><td><asp:Label ID='lblKaraoke' runat='server' EnableViewState='false' /></td>
            </tr>
            <tr>
               <td>CD:</td><td><asp:Label ID='lblCDs' runat='server' EnableViewState='false' /></td>
               <td><asp:Label ID='lblSSN' runat='server' EnableViewState='false' Text="ssn/usr:" /></td>
               <td><asp:Label ID='lblSSNData' runat='server' EnableViewState='false' /><asp:HyperLink ID='lnkUsers' runat='server' EnableViewState='false' Visible='false' NavigateUrl='/Admin/LoggedUsers.aspx' Target='_blank' /></td>
            </tr>

            <tr><th colspan="4" nowrap="nowrap">
               <a href='/rss'><img src='/Images/RSS.gif' border='0' align='absmiddle' alt='' /></a>
               ���������� ��
               <asp:DropDownList ID='lstNewsDays' runat='server' AutoPostBack='true'>
                  <asp:ListItem Text='�������' Value='1' />
                  <asp:ListItem Text='2 ���' Value='2' />
                  <asp:ListItem Text='3 ���' Value='3' />
                  <asp:ListItem Text='4 ���' Value='4' />
                  <asp:ListItem Text='5 ����' Value='5' />
                  <asp:ListItem Text='6 ����' Value='6' />
                  <asp:ListItem Text='������' Value='7' />
               </asp:DropDownList>
               <a href='/atom'><img src='/Images/Atom.gif' border='0' align='absmiddle' alt='Atom' /></a>
            </th></tr>
            <tr>
               <td><asp:HyperLink ID='lnkNewArtists' runat='server' ToolTip='����� �����������'>������������</asp:HyperLink>:</td>
               <td><asp:Label ID='lblNewArtists' runat='server' /></td>
               <td><asp:HyperLink ID='lnkNewAlbums' runat='server' ToolTip='����� �������'>��������</asp:HyperLink>:</td>
               <td><asp:Label ID='lblNewAlbums' runat='server' /></td>
            </tr>
            <tr>
               <td><asp:HyperLink ID='lnkNewTexts' runat='server' ToolTip='����� ������'>�������</asp:HyperLink>:</td>
               <td><asp:Label ID='lblNewTexts' runat='server' /></td>
               <td><asp:HyperLink ID='lnkNewFiles' runat='server' ToolTip='����� �����'>������</asp:HyperLink>:</td>
               <td><asp:Label ID='lblNewFiles' runat='server' /></td>
            </tr>
         </table>
      </td>
      <td valign='top'>
         <table width='100%' cellspacing="0" class="tbl01">
            <thead><tr><td>����������� �������</td></tr></thead><tr><td height='100%'><iframe frameborder='0' width='100%' height='138' scrolling='yes' src='/News/YandexMusic.aspx'></iframe></td></tr>
         </table>
      </td>
   </tr>
</table>

<table width="550" cellspacing="0" class="tbl01 adm" align='center'>
   <thead><tr><td colspan="2">������� ������</td></tr></thead><tr><th>����</th><th>����</th></tr><tr>
       <tr>
          <td valign="top">23.10.11</td><td>
             ���, ��������� �� ���� � � ���� ����� :)<br>
             �� ������� ���������� ����� ���� ��� � ��������� ������... �����.<br>
             �� ���, �������, ��������� � ��� �����, �� ��� ���� �� �������� :(<br />
             ��� ��� ����� ��������� ��������� ��� ����. �� ������� �������� �� ��� ����� - ������, ��� ����� �� �������� � ����� ������ (���� �� � ������). ��������� ����, ���� ��� �� ���, � �� ��� �� ������ ������.<br />
             ������� ����� ������ ��� ��������� ������ � ���������.
          </td>
       </tr>

</table>

<br><br>
<table border="0" align="center">
   <tr>
      <td align="center"><pwc:Banner id="bnr1" runat="server" Provider="Music" /></td>
      <td align="center"><pwc:Banner id="bnr2" runat="server" Provider="SpyLog" /></td>
      <td align="center"><pwc:Banner id="bnr3" runat="server" Provider="Rambler" /></td>
      <td align="center"><pwc:Banner id="bnr4" runat="server" Provider="MailRu" /></td>
      <td align="center"><pwc:Banner id="bnr5" runat="server" Provider="HotLog" /></td></tr>
</table>
</div>

</asp:Content>
