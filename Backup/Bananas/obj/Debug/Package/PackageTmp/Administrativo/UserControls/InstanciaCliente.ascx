<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstanciaCliente.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.InstanciaCliente" %>
<asp:TextBox runat="server" ID="txtCodigoCliente" Visible="false"></asp:TextBox>
<table>
    <tr>
        <th>
            <label>
                Razão Social:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtRazaoSocial" Width="416px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Nome Fantasia:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtNomeFantasia" Width="370px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                CNPJ:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtCnpj" Width="188px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Logradouro:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtLogradouro" Width="410px"></asp:TextBox>
        </td>
    </tr>
        <tr>
        <th>
            <label>
                Bairro:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtBairro" Width="198px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Complemento:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtComplemento" Width="367px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Cidade:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtCidade" Width="178px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Estado:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtEstado" Width="36px"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <th>
            <label>
                Responsável:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtResponsavel" Width="246px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Email:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtEmail" Width="246px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Telefone Estudio:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtTelefoneEstudio" Width="140px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Telefone Escritorio:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtTelefoneEscritorio" Width="140px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Alcance:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtAlcance" Width="37px"></asp:TextBox>
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
