﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="ListaPrograma.aspx.cs" Inherits="Bananas.Administrativo.ListaPrograma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="plhHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhContent" runat="server">
    <UCAdmin:ToolBar runat="server" ID="ucToolbar" />
    <br />
    <UCAdmin:ListaPrograma runat="server" ID="ucListaPrograma"  />
</asp:Content>
