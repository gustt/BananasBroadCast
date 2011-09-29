<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstanciaUsuario.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.InstanciaUsuario" %>
<asp:Panel runat="server" ID="pnContent">
    <table>
    <tr>
        <th>
            <label>
                Nome:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtNomeAdmin" Width="177px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNomeAdmin" ErrorMessage="Campo nome obrigatório" Text="*"></asp:RequiredFieldValidator>
            
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Login:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtLogin"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ControlToValidate="txtLogin" ErrorMessage="Campo login obrigatório" Text="*"></asp:RequiredFieldValidator>
            <asp:CustomValidator runat="server" ID="cvLogin" ErrorMessage="Login já existe na base." Text="*" ControlToValidate="txtLogin" OnServerValidate="cvLogin_ServerValidate">
            </asp:CustomValidator>
            
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Senha:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtSenha" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ControlToValidate="txtSenha" ErrorMessage="Campo senha obrigatório" Text="*"></asp:RequiredFieldValidator>
            
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Digite a Senha Novamente:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtSenhaNovamente" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator runat="server" ID="cpSenha" ControlToValidate="txtSenhaNovamente" ControlToCompare="txtSenha" Operator="Equal" ErrorMessage="Campo senha estão diferentes" Text="*" Display="Dynamic"></asp:CompareValidator>
            
        </td>
    </tr>
</table>
</asp:Panel>
