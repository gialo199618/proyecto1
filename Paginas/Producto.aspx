<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Producto.aspx.cs" Inherits="Paginas_Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table>
        <tr>
            <td rowspan="4">
                <asp:Image ID="imgProducto" runat="server" CssClass="detallesImagen"/></td>
            <td>
                <h2>
                    <asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label>
                    <hr />
                </h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescripcion" runat="server" CssClass="detallesDescripcion"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPrecio" runat="server" CssClass="detallesPrecio"></asp:Label><br />
            Cantidad: 
            <asp:DropDownList ID="ddlCantidad" runat="server"></asp:DropDownList><br />
            <asp:button ID="btnEnviar" runat="server" text="AÑADIR A LA CESTA" width="184px" CssClass="button" OnClick="btnEnviar_Click" />
                <br />
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Número de Producto: <asp:Label ID="lblNrItem" runat="server" Text="Label"></asp:Label>
            </td>   
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Disponible" CssClass="productoPrecio" ></asp:Label>
            </td>
        </tr>

    </table>
</asp:Content>

