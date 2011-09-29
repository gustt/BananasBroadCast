<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolBar.ascx.cs" Inherits="Bananas.Administrativo.UserControls.ToolBar" %>
<table>
    <tr>
        <td>
            <asp:LinkButton runat="server" ID="lnkNovo" OnClick="lnkNovo_Click" Text="Novo" ForeColor="#FDC029"></asp:LinkButton>
        </td>
        <td>
            <asp:LinkButton runat="server" ID="lnkSalvar" OnClick="lnkSalvar_Click" Text="Salvar" ForeColor="#FDC029"></asp:LinkButton>
        </td>
        <td>
            <asp:LinkButton runat="server" ID="lnkDeletar" OnClick="lnkDeletar_Click" Text="Deletar" ForeColor="#FDC029"></asp:LinkButton>
        </td>
    </tr>
</table>
