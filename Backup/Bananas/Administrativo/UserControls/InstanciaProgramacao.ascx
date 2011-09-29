<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstanciaProgramacao.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.InstanciaProgramacao" %>
<table>
    <tr>
        <th>
            <label>
                Titulo:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtTitulo"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Descrição:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtDescricao"></asp:TextBox>
        </td>
    </tr>
</table>
