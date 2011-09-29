<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="ListaCliente.aspx.cs" Inherits="Bananas.Administrativo.ListaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="plhHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhContent" runat="server">
    <UCAdmin:ToolBar runat="server" ID="ucToolbar" />
    <br />
    <UCAdmin:ListaCliente runat="server" ID="ucListaCliente" />
</asp:Content>
