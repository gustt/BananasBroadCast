<%@ Page Title="" Language="C#" MasterPageFile="Admin.Master" AutoEventWireup="true"
    CodeBehind="ListaCliente.aspx.cs" Inherits="Bananas.Administrativo.ListaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="plhHead" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="plhMenuSuperior">
    <UCAdmin:ToolBar runat="server" ID="ucToolbar" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhContent" runat="server">
    <UCAdmin:ListaCliente runat="server" ID="ucListaCliente" />
</asp:Content>
