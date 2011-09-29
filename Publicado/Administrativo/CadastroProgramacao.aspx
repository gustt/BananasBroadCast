<%@ Page Title="" Language="C#" MasterPageFile="Admin.Master" AutoEventWireup="true"
    CodeBehind="CadastroProgramacao.aspx.cs" Inherits="Bananas.Administrativo.CadastroProgramacao" %>

<%@ Register Src="~/Administrativo/UserControls/InstanciaProgramacao.ascx" TagName="CadastroProgramacao"
    TagPrefix="UserControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="plhHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="plhMenuSuperior">
    <UCAdmin:ToolBar runat="server" ID="ucToolbar" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhContent" runat="server">
    <UserControls:CadastroProgramacao runat="server" ID="ucCadastroProgramacao2" />
</asp:Content>
