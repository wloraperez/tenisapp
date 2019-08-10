<%@ Page Title="Ingreso al sistema" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.vb" Inherits="TenisApp.Login" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <h2>Digite su usuario y contraseña</h2>
    <asp:UpdatePanel ID="updRegistro" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <table>
                <tr>
                    <td>
                        <h3>Usuario</h3>
                    </td>
                    <td class="req">
                        <asp:TextBox runat="server" ID="txtUsuario" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUsuario" CssClass="field-validation-error" ErrorMessage="El campo Usuario es obligatorio." />
                    </td>
                </tr>

                <tr>
                    <td>
                        <h3>Contraseña</h3>
                    </td>
                    <td class="req">
                        <asp:TextBox runat="server" ID="txtContrasena" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContrasena" CssClass="field-validation-error" ErrorMessage="El campo Contraseña es obligatorio." />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnAcceso" runat="server" Text="Acceder" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Registrar</asp:HyperLink>
                        si no tiene sus credenciales.</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
            <LayoutTemplate>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend>Log in Form</legend>
                    <ol>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="UserName">Usuario</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="El campo Usuario es obligatorio." />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password">Contraseña</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="El campo Contraseña es obligatorio." />
                        </li>
                                                <li>
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Recordar?</asp:Label>
                        </li>
                    </ol>
                </fieldset>
            </LayoutTemplate>
        </asp:Login>--%>
</asp:Content>
