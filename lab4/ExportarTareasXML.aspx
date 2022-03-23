<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportarTareasXML.aspx.cs" Inherits="lab2.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="PROFESOR"></asp:Label>
        <asp:Button ID="botonCerrarSesion" runat="server" OnClick="botonCerrarSesion_Click" style="margin-left: 328px" Text="Cerrar sesión" Width="124px" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="EXPORTAR TAREAS GENÉRICAS"></asp:Label>
    </form>
</body>
</html>
