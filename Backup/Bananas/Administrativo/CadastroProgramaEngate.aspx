<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="CadastroProgramaEngate.aspx.cs" Inherits="Bananas.Administrativo.CadastroProgramaEngate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="plhHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhContent" runat="server">
    <UCAdmin:ToolBar runat="server" ID="ucToolbar" />
    <br />
    <br />
    <UCAdmin:CadastroProgramaEngate runat="server" ID="ucCadastroProgramaEngate" />
</asp:Content>
