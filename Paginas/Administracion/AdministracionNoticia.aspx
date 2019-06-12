<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministracionNoticia.aspx.cs" Inherits="Paginas_Administracion_AdministracionNoticia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Título"></asp:Label>
    <br />
    <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
    <br />
    <asp:TextBox ID="txtDescripcion" runat="server" Height="155px" TextMode="MultiLine" Width="475px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Fecha Publicación"></asp:Label>
    <br />
    <asp:Calendar ID="cFecha" runat="server"></asp:Calendar>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Imagen"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlImagen" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnEnviar" runat="server" CssClass="button" OnClick="btnEnviar_Click" Text="Enviar" />
    <br />
    <br />
    <asp:Label ID="lblResultado" runat="server"></asp:Label>
    <br />
    <br />
</asp:Content>

