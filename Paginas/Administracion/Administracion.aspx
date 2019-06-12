<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Administracion.aspx.cs" Inherits="Paginas_Administracion_Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<asp:LinkButton ID="LinkButton1" runat="server" CssClass="button" PostBackUrl="~/Paginas/Administracion/AdministracionProducto.aspx">AGREGAR NUEVO PRODUCTO</asp:LinkButton>
    <br />
    <br />
<asp:GridView ID="grdProductos" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="sdsProductos" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowEditing="grdProductos_RowEditing" style="margin-top: 0px">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
        <asp:BoundField DataField="TipoId" HeaderText="TipoId" SortExpression="TipoId" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
        <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
    </Columns>
    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <SortedAscendingCellStyle BackColor="#FDF5AC" />
    <SortedAscendingHeaderStyle BackColor="#4D0000" />
    <SortedDescendingCellStyle BackColor="#FCF6C0" />
    <SortedDescendingHeaderStyle BackColor="#820000" />
</asp:GridView>
<asp:SqlDataSource ID="sdsProductos" runat="server" ConnectionString="<%$ ConnectionStrings:AjedrezDBConnectionString %>" DeleteCommand="DELETE FROM [Producto] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Producto] ([TipoId], [Nombre], [Precio], [Descripcion], [Image]) VALUES (@TipoId, @Nombre, @Precio, @Descripcion, @Image)" SelectCommand="SELECT * FROM [Producto]" UpdateCommand="UPDATE [Producto] SET [TipoId] = @TipoId, [Nombre] = @Nombre, [Precio] = @Precio, [Descripcion] = @Descripcion, [Image] = @Image WHERE [Id] = @Id">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="TipoId" Type="Int32" />
        <asp:Parameter Name="Nombre" Type="String" />
        <asp:Parameter Name="Precio" Type="Int32" />
        <asp:Parameter Name="Descripcion" Type="String" />
        <asp:Parameter Name="Image" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="TipoId" Type="Int32" />
        <asp:Parameter Name="Nombre" Type="String" />
        <asp:Parameter Name="Precio" Type="Int32" />
        <asp:Parameter Name="Descripcion" Type="String" />
        <asp:Parameter Name="Image" Type="String" />
        <asp:Parameter Name="Id" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
<br />
    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="button" PostBackUrl="~/Paginas/Administracion/AdministracionTipoProducto.aspx">AGREGAR NUEVO TIPO PRODUCTO</asp:LinkButton>
    <br />
<br />
<asp:GridView ID="grdTipoProductos" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="sdsTipoProducto" Width="50%" CellPadding="4" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
    </Columns>
    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <SortedAscendingCellStyle BackColor="#FDF5AC" />
    <SortedAscendingHeaderStyle BackColor="#4D0000" />
    <SortedDescendingCellStyle BackColor="#FCF6C0" />
    <SortedDescendingHeaderStyle BackColor="#820000" />
</asp:GridView>
<asp:SqlDataSource ID="sdsTipoProducto" runat="server" ConnectionString="<%$ ConnectionStrings:AjedrezDBConnectionString %>" DeleteCommand="DELETE FROM [TipoProducto] WHERE [Id] = @Id" InsertCommand="INSERT INTO [TipoProducto] ([Nombre]) VALUES (@Nombre)" SelectCommand="SELECT * FROM [TipoProducto]" UpdateCommand="UPDATE [TipoProducto] SET [Nombre] = @Nombre WHERE [Id] = @Id">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Nombre" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Nombre" Type="String" />
        <asp:Parameter Name="Id" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
    <br />
    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="button" PostBackUrl="~/Paginas/Administracion/AdministracionNoticia.aspx">AGREGAR NUEVA NOTICIA</asp:LinkButton>
    <br />
    <asp:GridView ID="grdNoticia" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="sdsNoticias" ForeColor="#333333" GridLines="None" OnRowEditing="grdNoticia_RowEditing" Width="100%">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="FechaPublicacion" HeaderText="FechaPublicacion" SortExpression="FechaPublicacion" />
            <asp:BoundField DataField="Imagen" HeaderText="Imagen" SortExpression="Imagen" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <asp:SqlDataSource ID="sdsNoticias" runat="server" ConnectionString="<%$ ConnectionStrings:AjedrezDBConnectionString %>" DeleteCommand="DELETE FROM [Noticia] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Noticia] ([Titulo], [Descripcion], [FechaPublicacion], [Imagen]) VALUES (@Titulo, @Descripcion, @FechaPublicacion, @Imagen)" SelectCommand="SELECT * FROM [Noticia]" UpdateCommand="UPDATE [Noticia] SET [Titulo] = @Titulo, [Descripcion] = @Descripcion, [FechaPublicacion] = @FechaPublicacion, [Imagen] = @Imagen WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Titulo" Type="String" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="FechaPublicacion" Type="DateTime" />
            <asp:Parameter Name="Imagen" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Titulo" Type="String" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="FechaPublicacion" Type="DateTime" />
            <asp:Parameter Name="Imagen" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
<br />
</asp:Content>

