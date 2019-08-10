<%@ Page Title="Registro de Torneo" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AgregarTorneo.aspx.vb" Inherits="TenisApp.AgregarTorneo" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <h1><%: Title %>.</h1>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="updRegistro" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <asp:MultiView ActiveViewIndex="0" runat="server" ID="mvTorneo">
                <asp:View runat="server" ID="vTorneos">
                    <table>
                        <tr>
                            <td>
                                <h3>Nombre del Torneo</h3>
                            </td>
                            <td class="req">
                                <asp:TextBox ID="txtDescripción" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Fecha inicio</h3>
                            </td>
                            <td>
                                <asp:Calendar ID="cIni" runat="server"></asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Fecha final</h3>
                            </td>
                            <td>
                                <asp:Calendar ID="cFinal" runat="server"></asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnTorneo" runat="server" Text="Siguiente" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" /></td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View runat="server" ID="vTorneosCat">
                    <div>
                        <h3>Categorías</h3>
                        <asp:CheckBoxList ID="cblCategorias" runat="server">
                        </asp:CheckBoxList>
                        <asp:Button ID="btnTorneoCat" runat="server" Text="Siguiente" />
                        <asp:Button ID="btnBackTorneo" runat="server" Text="Atrás" />
                    </div>
                </asp:View>
                <asp:View runat="server" ID="vTorneosJugadores">
                    <div>
                        <h3>Jugadores</h3>
                        <asp:GridView ID="gvJugadores" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros que coincidan con su seleccion"
                            ForeColor="Black" GridLines="None" Width="100%" BackColor="White" BorderColor="#999999"
                            PageSize="100" PagerSettings-Visible="false" AllowPaging="true" BorderStyle="Solid"
                            BorderWidth="1px" CellPadding="3" AllowSorting="true" OnRowDataBound="OnRowDataBound">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkID" />
                                        <asp:Label runat="server" ID="lblIDJugador" Text='<%# Eval("IDJugador")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres"></asp:BoundField>
                                <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos"></asp:BoundField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Categoría">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblIDCategoria" Text='<%# Eval("IDCategoria")%>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlCategoria" runat="server" DataValueField="IDCategoria" DataTextField="Descripcion"></asp:DropDownList>
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
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Torneo" />
                        <asp:Button ID="btnBackCateg" runat="server" Text="Atrás" />
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
