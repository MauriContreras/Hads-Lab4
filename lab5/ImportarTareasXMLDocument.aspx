<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportarTareasXMLDocument.aspx.cs" Inherits="lab2.ImportarTareasXMLDocument" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 536px">
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="PROFESOR"></asp:Label>
        <asp:Button ID="botonCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="botonCerrarSesion_Click" style="margin-left: 454px" Width="133px" />
        </div>
        <p>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="IMPORTAR TAREAS GENÉRICAS"></asp:Label>
        </p>
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Seleccionar Asignatura a Importar:"></asp:Label>
        <div>
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="30px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" style="margin-left: 50px" Width="108px">
        </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div style="margin-left: 480px">
            <asp:Xml ID="Xml1" runat="server"></asp:Xml>
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>
        <br />
        <p>
        <asp:Button ID="Button1" runat="server" BackColor="#0066FF" Font-Bold="True" ForeColor="White" Height="74px" Text="IMPORTAR (XMLD)" Width="252px" OnClick="Button1_Click" />
        </p>
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/Profesor.aspx">Menu Profesor</asp:HyperLink>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
