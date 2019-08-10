<%@ Page Title="Listado de Jugadores" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListadoJugadores.aspx.vb" Inherits="TenisApp.ListadoJugadores" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <h1><%: Title %></h1>
    <h2></h2>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="updRegistro" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <table>
                <tr>
                    <td colspan="4">
                        <a id="AgregarJugador" runat="server" href="AgregarJugador" style="float: right;">Nuevo Jugador</a>
                    </td>
                </tr>
                <tr>
                    <td>Nombres</td>
                    <td>
                        <asp:TextBox ID="txtNombres" runat="server" Width="84%"></asp:TextBox></td>
                    <td>Apellidos</td>
                    <td>
                        <asp:TextBox ID="txtApellidos" runat="server" Width="84%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Empresa</td>
                    <td>
                        <asp:DropDownList ID="ddlEmpresa" runat="server" DataValueField="IDEmpresa" DataTextField="Descripcion" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </td>
                    <td>Departamento</td>
                    <td>
                        <asp:DropDownList ID="ddlDepartamento" runat="server" DataValueField="IDDepartamento" DataTextField="Descripcion" Width="90%"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Categoría</td>
                    <td>
                        <asp:DropDownList ID="ddlCategoria" runat="server" DataValueField="IDCategoria" DataTextField="Descripcion" Width="90%"></asp:DropDownList>*
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvJugadores" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros que coincidan con su seleccion"
                ForeColor="Black" GridLines="None" Width="100%" BackColor="White" BorderColor="#999999"
                PageSize="100" PagerSettings-Visible="false" AllowPaging="true" BorderStyle="Solid"
                BorderWidth="1px" CellPadding="3" AllowSorting="true">
                <Columns>
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres"></asp:BoundField>
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos"></asp:BoundField>
                    <asp:BoundField DataField="Categoria" HeaderText="Categoria" SortExpression="Categoria" />
                    <%--  <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" />--%>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="cmdEditRecord" runat="server" CommandArgument='<%# Eval("IDJugador")%>'
                                CommandName="EditRecord" ImageUrl='<%# "~/images/edit.gif" %>' Width="20px" BorderStyle="None" />
                            <asp:ImageButton ID="cmdViewRecord" runat="server" CommandArgument='<%# Eval("IDJugador")%>'
                                CommandName="ViewRecord" ImageUrl='<%# "~/images/view.gif"%>' Width="20px" BorderStyle="None" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle HorizontalAlign="Left" />
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#285412" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <AlternatingRowStyle BackColor="#ECEBE8" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
