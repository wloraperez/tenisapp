<%@ Page Title="Registro de Jugador" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AgregarJugador.aspx.vb" Inherits="TenisApp.AgregarJugador" %>


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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGuardar" />
        </Triggers>
        <ContentTemplate>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <table>
                <tr>
                    <td>
                        <h3>Nombres</h3>
                    </td>
                    <td class="req">
                        <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox>*</td>
                </tr>
                <tr>
                    <td>
                        <h3>Apellidos</h3>
                    </td>
                    <td class="req">
                        <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>*</td>
                </tr>
                <tr>
                    <td>
                        <h3>Empresa</h3>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEmpresa" runat="server" DataValueField="IDEmpresa" DataTextField="Descripcion" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Departamento</h3>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDepartamento" runat="server" DataValueField="IDDepartamento" DataTextField="Descripcion"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Categoría</h3>
                    </td>
                    <td class="req">
                        <asp:DropDownList ID="ddlCategoria" runat="server" DataValueField="IDCategoria" DataTextField="Descripcion"></asp:DropDownList>*
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Teléfono</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <h3>Correo Electrónico</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <h3>Twitter</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTwitter" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <h3>Instagram</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInstagram" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <h3>Mano</h3>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMano" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <h3>Size T-Shirt</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTshirt" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <h3>Size Pantalón</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPantalon" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <h3>Foto</h3>
                    </td>
                    <td>
                        <asp:FileUpload ID="ImageUploadToDB" Width="300px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" Text="Crear Jugador" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" /></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
