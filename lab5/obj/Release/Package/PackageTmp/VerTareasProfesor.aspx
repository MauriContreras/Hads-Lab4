<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTareasProfesor.aspx.cs" Inherits="lab2.VerTareasProfesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="PROFESOR"></asp:Label>
        <asp:Button ID="botonCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="botonCerrarSesion_Click" style="margin-left: 328px" Width="124px" />
            <br />
            <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="GESTIÓN DE TAREAS GENÉRICAS"></asp:Label>
            <br />
            <br />
            <br />
            <b>Seleccionar Asignatura:</b></div>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig" Height="19px" style="margin-left: 40px" Width="171px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hads22-09ConnectionString %>" SelectCommand="SELECT GrupoClase.codigoAsig FROM GrupoClase INNER JOIN ProfesorGrupo ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo WHERE ProfesorGrupo.email=@email">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="Small" Height="57px" OnClick="Button1_Click" style="margin-left: 37px" Text="INSERTAR NUEVA TAREA" Width="290px" />
        </p>
        <p>
            &nbsp;</p>
        <div style="margin-left: 40px">
            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="codigo" DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="codigo" HeaderText="codigo" ReadOnly="True" SortExpression="codigo" />
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                    <asp:BoundField DataField="codAsig" HeaderText="codAsig" SortExpression="codAsig" />
                    <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas" />
                    <asp:CheckBoxField DataField="explotacion" HeaderText="explotacion" SortExpression="explotacion" />
                    <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea" />
                </Columns>
                <EditRowStyle BackColor="#666666" />
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
        </div>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:hads22-09ConnectionString %>" DeleteCommand="DELETE FROM [TareaGenerica] WHERE [codigo] = @codigo" InsertCommand="INSERT INTO [TareaGenerica] ([codigo], [descripcion], [codAsig], [hEstimadas], [explotacion], [tipoTarea]) VALUES (@codigo, @descripcion, @codAsig, @hEstimadas, @explotacion, @tipoTarea)" SelectCommand="SELECT * FROM [TareaGenerica] WHERE ([codAsig] = @codAsig)" UpdateCommand="UPDATE [TareaGenerica] SET [descripcion] = @descripcion, [codAsig] = @codAsig, [hEstimadas] = @hEstimadas, [explotacion] = @explotacion, [tipoTarea] = @tipoTarea WHERE [codigo] = @codigo">
            <DeleteParameters>
                <asp:Parameter Name="codigo" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="codigo" Type="String" />
                <asp:Parameter Name="descripcion" Type="String" />
                <asp:Parameter Name="codAsig" Type="String" />
                <asp:Parameter Name="hEstimadas" Type="Int32" />
                <asp:Parameter Name="explotacion" Type="Boolean" />
                <asp:Parameter Name="tipoTarea" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="codAsig" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="descripcion" Type="String" />
                <asp:Parameter Name="codAsig" Type="String" />
                <asp:Parameter Name="hEstimadas" Type="Int32" />
                <asp:Parameter Name="explotacion" Type="Boolean" />
                <asp:Parameter Name="tipoTarea" Type="String" />
                <asp:Parameter Name="codigo" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
