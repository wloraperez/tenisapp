<%@ Page Title="Registro de Empresa" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AgregarEmpresa.aspx.vb" Inherits="TenisApp.AgregarEmpresa" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <h1><%: Title %>.</h1>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="updRegistro" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <table>
                <tr>
                    <td>
                        <h3>Nombre de la empresa</h3>
                    </td>
                    <td class="req">
                        <asp:TextBox ID="txtEmpresa" runat="server" MaxLength="50"></asp:TextBox>*</td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" Text="Crear Empresa" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Atrás" /></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
