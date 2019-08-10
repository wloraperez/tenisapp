<%@ Page Title="Registro de Categorías" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AgregarCategoria.aspx.vb" Inherits="TenisApp.AgregarCategoria" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <h1><%: Title %>.</h1>
    <%--<section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
            </hgroup>
            <p>
            </p>
        </div>
    </section>--%>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="updRegistro" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <table>
                <tr>
                    <td>
                        <h3>Nombre de categoría</h3>
                    </td>
                    <td class="req">
                        <asp:TextBox ID="txtIDCategoria" runat="server" MaxLength="5"></asp:TextBox>*</td>
                </tr>
                <tr>
                    <td>
                        <h3>Descripción de categoría</h3>
                    </td>
                    <td class="req">
                        <asp:TextBox ID="txtCategoria" runat="server" MaxLength="50"></asp:TextBox>*</td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" Text="Crear Categoría" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" /></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
