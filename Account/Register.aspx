<%@ Page Title="Registrar usuario" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.vb" Inherits="TenisApp.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Favor complete el siguiente formulario.</h2>
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
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>*<br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUsuario"
                            CssClass="field-validation-error" ErrorMessage="El campo Nombre de usuario es requerido." />
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Nombre completo</h3>
                    </td>
                    <td class="req">
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>*<br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre"
                            CssClass="field-validation-error" ErrorMessage="El campo Nombre completo es requerido." />
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>E-Mail</h3>
                    </td>
                    <td class="req">
                        <asp:TextBox ID="txtMail" runat="server" TextMode="Email"></asp:TextBox>*<br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMail"
                            CssClass="field-validation-error" ErrorMessage="El campo E-Mail es requerido." />
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
                        <asp:Button ID="btnGuardar" runat="server" Text="Crear Usuario" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <p class="message-info">
                        Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
                    </p>

                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <fieldset>
                        <legend>Registration Form</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Email">Email address</asp:Label>
                                <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="The email address field is required." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="The password field is required." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                            </li>
                        </ol>
                        <asp:Button runat="server" CommandName="MoveNext" Text="Register" />
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>--%>
</asp:Content>
