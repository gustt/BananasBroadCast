<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ColecaoListaCliente.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.ColecaoListaCliente" %>
<asp:Panel runat="server" ID="pnlLista">
    <fieldset>
    <legend>Pesquisa</legend>
    <table>
        <tr>
            <th>
                <label>
                    Razão Social:</label>
            </th>
            <td>
                <asp:TextBox runat="server" ID="txtRazaoSocial"></asp:TextBox>
            </td>
            <th>
                <label>
                    Nome Fantasia:</label>
            </th>
            <td>
                <asp:TextBox runat="server" ID="txtNomeFantasia"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:Button runat="server" ID="btnPesquisar" Text="Pesquisar" OnClick="btnPesquisar_Click" />
            </td>
        </tr>
    </table>
    </fieldset>
    <br />
    <br />
    <asp:GridView runat="server" ID="grdLista" EmptyDataText="Nenhum registro encontrado." OnRowEditing="grdLista_RowEditing"
        AutoGenerateColumns="false" DataKeyNames="Codigo">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
            <asp:BoundField HeaderText="Razão Social" DataField="RazaoSocial" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
            <asp:BoundField HeaderText="Nome Fantasia" DataField="NomeFantasia" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"  />
            <asp:BoundField HeaderText="Telefone Estúdio" DataField="TelefoneEstudio" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
            <asp:BoundField HeaderText="Telefone Escritório" DataField="TelefoneEscritorio" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
            <asp:CommandField HeaderText="Editar" EditText="Editar" ShowEditButton="true" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"   />
        </Columns>
    </asp:GridView>
</asp:Panel>
