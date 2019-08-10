<%@ Page Title="Registro de Departamento" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AgregarDepartamento.aspx.vb" Inherits="TenisApp.AgregarDepartamento" %>


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
                        <h3>Empresa</h3>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEmpresa" runat="server" DataValueField="IDEmpresa" DataTextField="Descripcion"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Departamento</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDepartamento" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" Text="Crear Departamento" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Atrás" /></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
