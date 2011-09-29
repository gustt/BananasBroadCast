<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ColecaoListaProgramacao.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.ColecaoListaProgramacao" %>
<%@ Register TagPrefix="UserControls" TagName="ToolBar" Src="~/Administrativo/UserControls/ToolBar.ascx" %>
<br />
<br />
<UserControls:ToolBar runat="server" ID="ucToolBar" />
<asp:GridView runat="server" ID="grdListaProgramacao" EmptyDataText="Nenhum registro encontrado."
    DataKeyNames="Codigo" AutoGenerateColumns="false" OnRowEditing="grdListaProgramacao_RowEditing">
    <Columns>
        <asp:BoundField HeaderText="Titulo" DataField="Titulo" ItemStyle-HorizontalAlign="Left"
            HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="Descricao" DataField="Descricao" ItemStyle-HorizontalAlign="Left"
            HeaderStyle-HorizontalAlign="Left" />
        <asp:CommandField EditText="Editar" ShowEditButton="true" ItemStyle-HorizontalAlign="Left"
            HeaderStyle-HorizontalAlign="Left" />
    </Columns>
</asp:GridView>
