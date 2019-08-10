<%@ Page Title="Registro de Canchas" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AgregarCancha.aspx.vb" Inherits="TenisApp.AgregarCancha" %>


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
                        <h3>Torneo</h3>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTorneo" runat="server" DataValueField="IDTorneo" DataTextField="Descripcion"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Cancha</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCancha" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" Text="Crear Cancha" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Atrás" />
                        <asp:Button ID="btnNueva" runat="server" Text="Nueva Cancha" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
