<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="lab2.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml%22%3E
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 407px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="botonCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="botonCerrarSesion_Click" style="margin-left: 454px" Width="133px" />
         <br />
            <br />
            <br />
            <br />
        <asp:Button ID="botonVerTareasAlumno" runat="server" BackColor="#0066FF" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="57px" OnClick="Button1_Click" Text="Tareas" Width="202px" />
        <div style="margin-left: 480px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#0066FF" Text="Gestión Web de Tareas-Dedicación"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#0066FF" Text="Profesores"></asp:Label>
            <br />
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" BackColor="#0066FF" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="53px" OnClick="Button1_Click1" Text="Estadisticas" Width="196px" />
        </p>
        <p style="height: 96px">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Importar" />
        </p>
        <p style="height: 96px">
            <asp:Button ID="Button3" runat="server" Text="Exportar" OnClick="Button3_Click1" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>