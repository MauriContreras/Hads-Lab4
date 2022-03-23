<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportarTareas.aspx.cs" Inherits="lab2.ExportarTareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 41px">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="PROFESOR"></asp:Label>
        <asp:Button ID="botonCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="botonCerrarSesion_Click" style="margin-left: 454px" Width="133px" />
        </div>
        <p>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="EXPORTAR TAREAS GENÉRICAS"></asp:Label>
        </p>
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Seleccionar Asignatura a Exportar:"></asp:Label>
        <div style="margin-left: 40px">
            <br />
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="19px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="margin-left: 64px" Width="123px">
        </asp:DropDownList>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="margin-left: 529px" Width="616px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" BackColor="#0066FF" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="60px" OnClick="Button1_Click" Text="Exportar" Width="175px" />
        <p>
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" Visible="False"></asp:Label>
        </p>
    </form>
</body>
</html>
