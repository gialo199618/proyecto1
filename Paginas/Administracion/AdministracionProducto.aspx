<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministracionProducto.aspx.cs" Inherits="Paginas_Administracion_AdministracionProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p>
        &nbsp;Nombre:</p>
    <p>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    </p>
    <p>
        Tipo:</p>
    <p>
        <asp:DropDownList ID="ddlTipo" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nombre" DataValueField="Id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AjedrezDBConnectionString %>" SelectCommand="SELECT * FROM [TipoProducto] ORDER BY [Nombre]"></asp:SqlDataSource>
    </p>
    <p>
        Precio:</p>
    <p>
        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
    </p>
    <p>
        Imagen:</p>
    <p>
        <asp:DropDownList ID="ddlImagen" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Descripcion:</p>
    <p>
        <asp:TextBox ID="txtDescripcion" runat="server" Height="82px" TextMode="MultiLine" Width="279px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="ENVIAR" />
    </p>
    <p>
        <asp:Label ID="lblResultado" runat="server"></asp:Label>
    </p>
</asp:Content>

