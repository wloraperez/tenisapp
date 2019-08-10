<%@ Page Title="Ativar Usuario" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActivarUsuario.aspx.vb" Inherits="TenisApp.ActivarUsuario" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <asp:UpdatePanel ID="updRegistro" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGuardar" />
        </Triggers>
        <ContentTemplate>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <table>
                <tr>
                    <td>
                        <h3>Usuario</h3>
                    </td>
                    <td class="req">
                        <asp:DropDownList ID="ddlUsuario" runat="server" DataValueField="IDUsuario" DataTextField="NombreCompleto"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" Text="Activar Usuario" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
