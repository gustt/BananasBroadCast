<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ColecaoListaPrograma.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.ColecaoListaPrograma" %>
<asp:Panel runat="server" ID="pnlLista">
    <fieldset>
    <legend>Pesquisa</legend>
    <table>
    <tr>
        <th>
            <label>
                Nome Programa:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtPrograma"></asp:TextBox>
        </td>
        <td>
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
            <asp:BoundField HeaderText="Nome Programa" DataField="NomePrograma" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
            <asp:BoundField HeaderText="Descrição" DataField="Descricao" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
            <asp:CommandField HeaderText="Editar" EditText="Editar" ShowEditButton="true" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"   />
        </Columns>
    </asp:GridView>
</asp:Panel>