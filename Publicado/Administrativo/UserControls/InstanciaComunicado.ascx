<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstanciaComunicado.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.InstanciaComunicado" %>
<asp:Panel runat="server" ID="pnContent">
    <asp:TextBox Visible="false" ID="txtCodigo" runat="server"></asp:TextBox>
    <table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <th>
            <span>Mensagem:</span>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtMensagem" TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox>
        </td>
    </tr>
</table>
</asp:Panel>
