<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="ListaAdministrador.aspx.cs" Inherits="Bananas.Administrativo.ListaAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="plhHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhContent" runat="server">
    <UCAdmin:ToolBar runat="server" ID="ucToolbar" />
    <br />
    <UCAdmin:ListaAdministrador runat="server" ID="ucListaAdministrador"  />
</asp:Content>
