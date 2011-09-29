<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="CadastroAdministrador.aspx.cs" Inherits="Bananas.Administrativo.CadastroAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="plhHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhContent" runat="server">
    <UCAdmin:ToolBar runat="server" ID="ucToolbar" />
     <br />
    <br />
    <UCAdmin:CadastroAdministrador runat="server" ID="ucCadastroAdministrador" />
</asp:Content>

