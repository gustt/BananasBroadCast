<%@ Page Title="" Language="C#" MasterPageFile="Admin.Master" AutoEventWireup="true"
    CodeBehind="CadastroPrograma.aspx.cs" Inherits="Bananas.Administrativo.CadastroPrograma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="plhHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="plhMenuSuperior">
    <UCAdmin:ToolBar runat="server" ID="ucToolbar" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhContent" runat="server">
    <UCAdmin:CadastroPrograma runat="server" ID="ucCadastroPrograma" />
</asp:Content>
