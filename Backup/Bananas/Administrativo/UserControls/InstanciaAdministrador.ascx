<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstanciaAdministrador.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.InstanciaAdministrador" %>
<table>
    <tr>
        <th>
            <label>
                Nome ADM:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtNomeAdmin" Width="177px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Login:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtLogin"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Senha:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtSenha" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Digite a Senha Novamente:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtSenhaNovamente" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
</table>
