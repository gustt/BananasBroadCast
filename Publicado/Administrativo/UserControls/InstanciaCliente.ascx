<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstanciaCliente.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.InstanciaCliente" %>
<script type="text/javascript">

    function mascaraCNPJ(obj) {
        if (event.keyCode == 8)
            return false;

        var vr = obj.value;
        var tam = vr.length;
        if (tam == 2) obj.value += ".";
        if (tam == 6) obj.value += ".";
        if (tam == 10) obj.value += "/";
        if (tam == 15) obj.value += "-";

    }

    function Numero(e) {
        navegador = /msie/i.test(navigator.userAgent);
        if (navegador)
            var tecla = event.keyCode;
        else
            var tecla = e.which;
        if (tecla > 47 && tecla < 58)

            return true;
        else {
            if (tecla != 8)
                return false;
            else
                return true;
        }
    }

    function mascaraTelefone(obj) {
        if (event.keyCode == 8)
            return false;

        var vr = obj.value;
        var tam = vr.length;
        if (tam == 0) obj.value += "(";
        if (tam == 3) obj.value += ")";
        if (tam == 8) obj.value += "-";

    }

    function validaCNPJ() {

        CNPJ = document.getElementById("txtCnpj").value;
        erro = new String;
        if (CNPJ.length < 18)
            return false;

        if ((CNPJ.charAt(2) != ".") || (CNPJ.charAt(6) != ".") || (CNPJ.charAt(10) != "/") || (CNPJ.charAt(15) != "-")) {
            if (erro.length == 0)
                return false;

            if (document.layers && parseInt(navigator.appVersion) == 4) {
                x = CNPJ.substring(0, 2);
                x += CNPJ.substring(3, 6);
                x += CNPJ.substring(7, 10);
                x += CNPJ.substring(11, 15);
                x += CNPJ.substring(16, 18);
                CNPJ = x;
            }
        }

        else {
            CNPJ = CNPJ.replace(".", "");
            CNPJ = CNPJ.replace(".", "");
            CNPJ = CNPJ.replace("-", "");
            CNPJ = CNPJ.replace("/", "");
        }

        var nonNumbers = /\D/;

        if (nonNumbers.test(CNPJ))
            return false;

        var a = [];
        var b = new Number;
        var c = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

        for (i = 0; i < 12; i++) {
            a[i] = CNPJ.charAt(i);
            b += a[i] * c[i + 1];
        }

        if ((x = b % 11) < 2) {
            a[12] = 0
        }
        else {
            a[12] = 11 - x
        }

        b = 0;

        for (y = 0; y < 13; y++) {
            b += (a[y] * c[y]);
        }

        if ((x = b % 11) < 2) {
            a[13] = 0;
        }
        else {
            a[13] = 11 - x;
        }

        return true;


    }

    function validaCampos() {
        if (!validaCNPJ()) {
            alert("CNPJ inválido!");
            return false;
        }

    }

</script>
<asp:Panel runat="server" ID="pnContent">
    <asp:TextBox runat="server" ID="txtCodigoCliente" Visible="false"></asp:TextBox>
    <table>
    <tr>
        <th>
            <label>
                Razão Social:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtRazaoSocial" Width="416px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRazaoSocial" ErrorMessage="Campo razão obrigatório" Text="*"></asp:RequiredFieldValidator>
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
            <asp:TextBox runat="server" ID="txtCnpj" Width="188px" onkeypress="mascaraCNPJ(this); return Numero(event)" MaxLength="18"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCnpj" ErrorMessage="Campo CNPJ cobrigatório" Text="*"></asp:RequiredFieldValidator>
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
            <asp:TextBox runat="server" ID="txtEstado" Width="36px" MaxLength="2"></asp:TextBox>
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
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo email obrigatório" Text="*"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="revEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="*Informe um email válido." ForeColor="#FF0000"
                                    SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Telefone Estudio:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtTelefoneEstudio" Width="140px" MaxLength="13" onkeypress="mascaraTelefone(this); return Numero(event);"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Telefone Escritorio:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtTelefoneEscritorio" Width="140px" MaxLength="13" onkeypress="mascaraTelefone(this); return Numero(event);"></asp:TextBox>
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
