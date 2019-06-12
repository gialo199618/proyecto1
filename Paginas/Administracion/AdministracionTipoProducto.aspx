<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministracionTipoProducto.aspx.cs" Inherits="Paginas_Administracion_AdministracionTipoProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p>
        Nombre:</p>
    <p>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="ENVIAR" />
    </p>
    <p>
        <asp:Label ID="lblResultado" runat="server"></asp:Label>
    </p>
</asp:Content>

