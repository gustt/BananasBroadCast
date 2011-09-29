<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstanciaPrograma.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.InstanciaPrograma" %>
<asp:Panel runat="server" ID="pnContent">
    <table>
    <tr>
        <th>
            <label>
                Nome Programa:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtNomePrograma" Width="274px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNomePrograma" ErrorMessage="Campo nome obrigatório" Text="*"></asp:RequiredFieldValidator>
            
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Descrição:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtDescricao" Width="522px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescricao" ErrorMessage="Campo descrição obrigatório" Text="*"></asp:RequiredFieldValidator>
            
        </td>
    </tr>
        <tr>
        <th>
            <label>
                Logo:</label>
        </th>
        <td>
           <asp:FileUpload runat="server" ID="fpLogo" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fpLogo" ErrorMessage="Campo logo obrigatório" Text="*"></asp:RequiredFieldValidator>
           
        </td>
    </tr>
</table>
    <UCAdmin:ListaProgramacao runat="server" ID="ucListaProgramcao" />
</asp:Panel>
