<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="lab2.Alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="botonCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="botonCerrarSesion_Click" style="margin-left: 454px" Width="133px" />
            <br />
            <br />
            <br />
            <br />
        <asp:Button ID="botonVerTareasAlumno" runat="server" BackColor="#0066FF" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="57px" OnClick="Button1_Click" Text="Tareas genéricas" Width="202px" />
        <div style="margin-left: 480px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#0066FF" Text="Gestión Web de Tareas-Dedicación"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#0066FF" Text="Alumnos"></asp:Label>
        </div>
    </form>
</body>
</html>
