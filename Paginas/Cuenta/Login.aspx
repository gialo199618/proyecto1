<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Paginas_Cuenta_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Literal ID="litStatus" runat="server"></asp:Literal>
<br />
<br />
<asp:Label ID="Label1" runat="server" Text="USUARIO:"></asp:Label>
<br />
<asp:TextBox ID="txtUsuario" runat="server" CssClass="inputs"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="CONTRASEÑA:"></asp:Label>
<br />
<asp:TextBox ID="txtContraseña" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
<br />
<br />
<asp:Button ID="btnIniciar" runat="server" CssClass="button" OnClick="btnIniciar_Click" Text="INICIAR SESIÓN" />
<br />
<br />
</asp:Content>

