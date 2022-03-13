<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="lab2.WebForm2" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Button ID="botonCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="botonCerrarSesion_Click" style="margin-left: 454px" Width="133px" />
        </div>
        <p>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="ESTADISTICAS"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0066FF" Text="Total de horas reales que ha hecho cada alumno"></asp:Label>
        </p>
        <p>
            <asp:Chart ID="Chart1" runat="server" DataMember="DefaultView" DataSourceID="SqlDataSource1" Height="390px" OnLoad="Chart1_Load" Palette="None" Width="639px">
                <series>
                    <asp:Series Name="Series1" XValueMember="email" YValueMembers="HorasReales" YValuesPerPoint="6">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="X-Large" NavigateUrl="~/Profesor.aspx">Atrás</asp:HyperLink>
        </p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hads22-09ConnectionString %>" SelectCommand="SELECT SUM( [hReales]) AS HorasReales, [email] FROM [EstudianteTarea] GROUP BY email"></asp:SqlDataSource>
    </form>
</body>
</html>
