<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="CadastroCliente.aspx.cs" Inherits="Bananas.Administrativo.CadastroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="plhHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhContent" runat="server">
    <UCAdmin:ToolBar runat="server" ID="ucToolbar" />
    <br />
    <br />
    <UCAdmin:CadastroCliente runat="server" ID="ucCadastroCliente" />
</asp:Content>
