<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="Paginas_Cuenta_Registro" %>

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
<asp:Label ID="Label3" runat="server" Text="CONFIRMAR CONTRASEÑA:"></asp:Label>
<br />
<asp:TextBox ID="txtConfirma" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
<asp:Label ID="label4" runat="server" Text="NOMBRES:"></asp:Label>
    <br />
    <asp:TextBox ID="txtNombres" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
<asp:Label ID="Label5" runat="server" Text="APELLIDO PATERNO:"></asp:Label>
    <br />
    <asp:TextBox ID="txtApePaterno" runat="server" CssClass="inputs"></asp:TextBox>
<br />
    <br />
<asp:Label ID="Label6" runat="server" Text="APELLIDO MATERNO:"></asp:Label>
    <br />
    <asp:TextBox ID="txtApeMaterno" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
<asp:Label ID="Label7" runat="server" Text="DIRECCIÓN:"></asp:Label>
    <br />
    <asp:TextBox ID="txtDireccion" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
<asp:Label ID="Label8" runat="server" Text="CÓDIGO POSTAL:"></asp:Label>
    <br />
    <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
<br />
<asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="Button" />
<br />
<br />
</asp:Content>

