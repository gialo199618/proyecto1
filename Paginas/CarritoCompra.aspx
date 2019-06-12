<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CarritoCompra.aspx.cs" Inherits="Paginas_CarritoCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Panel ID="pnlCarritoCompra" runat="server">

    </asp:Panel>

    <table>
        <tr>
            <td><b>Subtotal: </b></td>
            <td><asp:literal ID="litSubtotal" runat="server" Text=""></asp:literal></td>
        </tr>

        <tr>
            <td><b>I.G.V.: </b></td>
            <td><asp:literal ID="litIGV" runat="server" Text=""></asp:literal></td>
        </tr>

        <tr>
            <td><b>ENVIO: </b></td>
            <td>S/. 1</td>
        </tr>

        <tr>
            <td><b>Total: </b></td>
            <td><asp:literal ID="litTotal" runat="server" Text=""></asp:literal></td>
        </tr>
        
        <tr>
            <td>
                <asp:linkbutton ID="lnkContinuar" runat="server" PostBackUrl="~/Index.aspx" Text="Continuar Comprando" />
                O
                <asp:button ID="btnRevisarCompra" runat="server" PostBackUrl="~/Paginas/Success.aspx"
                    CssClass="button" width="250px" Text="RealizarCompra" />
            </td>
        </tr>

    </table>
</asp:Content>

