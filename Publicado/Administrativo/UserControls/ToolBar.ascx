<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolBar.ascx.cs" Inherits="Bananas.Administrativo.UserControls.ToolBar" %>
<div id="bar-content">
    <table>
        <tr>
            <td runat="server" ID="tdNovo">
                <asp:LinkButton runat="server" ID="lnkNovo" OnClick="lnkNovo_Click" CausesValidation="false" SkinID="BtNovo"></asp:LinkButton>
            </td>
            <td runat="server" ID="tdSalvar">
                <asp:LinkButton runat="server" ID="lnkSalvar" OnClick="lnkSalvar_Click" SkinID="BtSalvar"></asp:LinkButton>
            </td>
            <td runat="server" ID="tdExcluir">
                <asp:LinkButton runat="server" ID="lnkDeletar" SkinID="BtExcluir" OnClick="lnkDeletar_Click" CausesValidation="false"></asp:LinkButton>
            </td>
        </tr>
    </table>
</div>
