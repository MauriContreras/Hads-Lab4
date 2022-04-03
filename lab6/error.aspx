<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="lab2.error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="ERROR,  NO TIENES ACCESO A ESTA PÁGINA"></asp:Label>
        <p>
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Redirigiendo al login..."></asp:Label>
        </p>
        <asp:Image ID="Image1" runat="server" Height="312px" ImageUrl="~/error.png" Width="344px" />
    </form>
</body>
</html>
