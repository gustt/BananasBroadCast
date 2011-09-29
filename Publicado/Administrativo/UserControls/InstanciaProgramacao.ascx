<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstanciaProgramacao.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.InstanciaProgramacao" %>
<asp:Panel runat="server" ID="plContent">
    <table>
    <tr>
        <th>
            <label>
                Titulo:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtTitulo"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Campo titulo obrigatório" Text="*"></asp:RequiredFieldValidator>
            
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Descrição:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtDescricao"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDescricao" runat="server" ControlToValidate="txtDescricao" ErrorMessage="Campo descrição obrigatório" Text="*"></asp:RequiredFieldValidator>
            
        </td>
    </tr>
</table>
</asp:Panel>
