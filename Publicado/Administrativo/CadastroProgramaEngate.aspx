<%@ Page Title="" Language="C#" MasterPageFile="Admin.Master" AutoEventWireup="true"
    CodeBehind="CadastroProgramaEngate.aspx.cs" Inherits="Bananas.Administrativo.CadastroProgramaEngate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="plhHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="plhMenuSuperior">
    <UCAdmin:ToolBar runat="server" ID="ucToolbar" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhContent" runat="server">
    <UCAdmin:CadastroProgramaEngate runat="server" ID="ucCadastroProgramaEngate" />
    <hr></hr>
    <UCAdmin:ToolBar runat="server" ID="ucToolbarComunicado" />
    <br />
    <UCAdmin:CadastroComunicado runat="server" ID="ucCadastroComunicacao" />
</asp:Content>
