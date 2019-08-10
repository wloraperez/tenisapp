<%@ Page Title="Cambiar Contraseña" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.vb" Inherits="TenisApp.ChangePassword" %>

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
                        <h3>Nombre de usuario</h3>
                    </td>
                    <td class="req">
                        <asp:Label runat="server" ID="lblID" Visible="false" ></asp:Label>
                        <asp:TextBox ID="txtUsuario" runat="server" Enabled="false"></asp:TextBox>*<br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUsuario"
                            CssClass="field-validation-error" ErrorMessage="El campo Nombre de usuario es requerido." />
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Contraseña anterior</h3>
                    </td>
                    <td class="req">
                        <asp:TextBox ID="txtContrasenaAnt" runat="server" TextMode="Password"></asp:TextBox>*<br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContrasenaAnt"
                            CssClass="field-validation-error" ErrorMessage="El campo Contraseña anterior es requerido." />
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Contraseña</h3>
                    </td>
                    <td class="req">
                        <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox>*<br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtContrasena"
                            CssClass="field-validation-error" ErrorMessage="El campo Contraseña es requerido." />
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Confirmar Contraseña</h3>
                    </td>
                    <td class="req">
                        <asp:TextBox ID="txtContraseñaConfirma" runat="server" TextMode="Password"></asp:TextBox>*<br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContraseñaConfirma"
                            CssClass="field-validation-error" ErrorMessage="El campo Confirmar contraseña es requerido." Display="Dynamic" />
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtContrasena" ControlToValidate="txtContraseñaConfirma"
                            CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden." />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" Text="Cambiar contraseña" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>   
</asp:Content>
