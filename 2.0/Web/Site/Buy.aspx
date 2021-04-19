<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Buy.aspx.cs" Inherits="Pripev.Web.UI.Buy" MasterPageFile="~/Main.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID='contentScript' runat='server' EnableViewState='false'>

<div class='Buy'>
<table cellspacing="0" align="center" class="tbl03">
   <thead><tr><td colspan="2">Купить чуток припевов</td></tr></thead>
   <asp:PlaceHolder ID='plhData' runat='server'>
      <tr><th colspan="2"><asp:Literal ID='litTitle' runat='server' /></th></tr>
      <asp:Repeater ID='rptData' runat='server'>
         <ItemTemplate>
            <tr>
               <td><asp:HyperLink ID='lnkPartnerImage' runat='server' NavigateUrl='<%# Eval( "PartnerURL" ) %>' ImageUrl='<%# Eval( "Logo" ) %>' />&nbsp;</td>
               <td><asp:HyperLink ID='lnkPartner' runat='server' NavigateUrl='<%# Eval( "PartnerURL" ) %>' Target="_blank" Text='<%# "Купить с " + Eval( "Name" ) %>' /></td>
            </tr>
         </ItemTemplate>
      </asp:Repeater>
   </asp:PlaceHolder>      
   <asp:PlaceHolder ID='plhNotFound' runat='server' Visible='false'>
      <tr><td colspan='2'>
         <br/>Дико извиняюсь, но запрашиваемый Вами товар не найден.<br/>
         Огромная просьба <asp:Literal ID='litEmail' runat='server' />сообщить мне</a>  об этом.
         <br>&nbsp;
      </td></tr>
   </asp:PlaceHolder>
</table>
</div>

</asp:Content>
