<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="DomPriv.aspx.cs" Inherits="Pripev.Web.RooK.Y.DomPriv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Для служебного пользования</title>
   <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
   <script type="text/javascript" src="/jwplayer/jwplayer.js"></script>

</head>
<body>
    <form id="form1" runat="server">

    <asp:Panel ID="pnlLogin" runat="server">
        Password: <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" /><br/><br/>
        <asp:Button runat="server" ID="btnOk" Text="OK" OnClick="btnOk_Click"/>
    </asp:Panel>
    
    <asp:Panel ID="pnlVideo" runat="server" Visible="false">
        <div id="flvDiv1">Загрузка...</div>
        <script type="text/javascript">
            jwplayer("flvDiv1").setup({
                    width: 1360,
                    height: 720,
                    listbar: { position: 'right', size: 80 },
                    playlist: [{
                        image: "/Storage/Y/DomPriv/Melon.jpg",
                        file: "/Storage/Y/DomPriv/Melon.mp4"
                    },{
                        image: "/Storage/Y/DomPriv/Pool.jpg",
                        file: "/Storage/Y/DomPriv/Pool.mp4"
                    },{
                        image: "/Storage/Y/DomPriv/Suck.jpg",
                        file: "/Storage/Y/DomPriv/Suck.mp4"
                    },{
                        image: "/Storage/Y/DomPriv/Fuck.jpg",
                        file: "/Storage/Y/DomPriv/Fuck.mp4"
                    },{
                        image: "/Storage/Y/DomPriv/Pet.jpg",
                        file: "/Storage/Y/DomPriv/Pet.mp4"
                    },{
                        image: "/Storage/Y/DomPriv/Y.jpg",
                        file: "/Storage/Y/DomPriv/Y.mp4"
                    }]
                });
        </script>
    </asp:Panel>

    </form>
</body>
</html>
