<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstanciaProgramaEngate.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.InstanciaProgramaEngate" %>
<asp:Panel runat="server" ID="pnContent">
    <asp:TextBox runat="server" ID="txtCodigoCliente" Visible="false"></asp:TextBox>
    <table>
<tr>
    <th>
        <span>Programa:</span>
    </th>
<td>
    <asp:DropDownList runat="server" ID="ddlProgramas">
    </asp:DropDownList>
</td>
</tr>
    <tr>
        <th>
            <label>
                Hora:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtHora" Width="14px" MaxLength="2"></asp:TextBox>:
            <asp:TextBox runat="server" ID="txtMinuto" Width="14px" MaxLength="2"></asp:TextBox>:
            <asp:TextBox runat="server" ID="txtSegundo" Width="14px" MaxLength="2"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Tipo:
            </label>
        </th>
        <td>
            <asp:RadioButtonList runat="server" ID="rblTipoEngate">
                <asp:ListItem Text="Engate" Value="0"></asp:ListItem>
                <asp:ListItem Text="Desengate" Value="1"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
</asp:Panel>
