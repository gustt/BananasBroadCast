<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstanciaPrograma.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.InstanciaPrograma" %>
    
<table>
    <tr>
        <th>
            <label>
                Nome Programa:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtNomePrograma" Width="274px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <label>
                Descrição:</label>
        </th>
        <td>
            <asp:TextBox runat="server" ID="txtDescricao" Width="522px"></asp:TextBox>
        </td>
    </tr>
        <tr>
        <th>
            <label>
                Logo:</label>
        </th>
        <td>
           <asp:FileUpload runat="server" ID="fpLogo" />
        </td>
    </tr>
</table>

<UCAdmin:ListaProgramacao runat="server" ID="ucListaProgramcao" />