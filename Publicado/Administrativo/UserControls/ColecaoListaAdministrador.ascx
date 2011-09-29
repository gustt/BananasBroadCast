<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ColecaoListaAdministrador.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.ColecaoListaAdministrador" %>
<asp:Panel runat="server" ID="pnlLista">
    <fieldset>
    <legend>Pesquisa</legend>
    <table>
    <tr>
        <th>
            <label>
                Administrador:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtAdministrador"></asp:TextBox>
        </td>
        <td>
            <asp:Button runat="server" ID="btnPesquisar" text="Pesquisar" OnClick="btnPesquisar_Click"></asp:Button>
        </td>
    </tr>
    </table>
    </fieldset>
    <br />
    <br />
    <asp:GridView runat="server" ID="grdLista" EmptyDataText="Nenhum registro encontrado." OnRowEditing="grdLista_RowEditing" AllowPaging="true" PageSize="6"
        AutoGenerateColumns="false" DataKeyNames="UserID" OnPageIndexChanging="grdLista_PageIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="UserID" DataField="UserID" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
            <asp:CommandField HeaderText="Editar" EditText="Editar" ShowEditButton="true" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
        </Columns>
    </asp:GridView>
</asp:Panel>