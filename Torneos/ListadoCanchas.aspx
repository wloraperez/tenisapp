<%@ Page Title="Listado de Canchas" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListadoCanchas.aspx.vb" Inherits="TenisApp.ListadoCanchas" %>


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
                        <a id="AgregarCancha" runat="server" href="AgregarCancha" style="float: right;">Nueva Cancha</a>
                    </td>
                </tr>
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
                        <h3>Nombre de la cancha</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="96%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" />
                        <asp:Button ID="btnAtras" runat="server" Text="Atrás" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros que coincidan con su seleccion"
                ForeColor="Black" GridLines="None" Width="100%" BackColor="White" BorderColor="#999999"
                PageSize="25" PagerSettings-Visible="false" AllowPaging="true" BorderStyle="Solid"
                BorderWidth="1px" CellPadding="3" AllowSorting="true">
                <Columns>
                    <asp:BoundField DataField="Cancha" HeaderText="Cancha" SortExpression="Cancha"></asp:BoundField>
                    <asp:BoundField DataField="Torneo" HeaderText="Torneo" SortExpression="Torneo"></asp:BoundField>
                    <asp:BoundField DataField="EstadoTorneo" HeaderText="Estado Torneo" SortExpression="EstadoTorneo" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="cmdEditRecord" runat="server" CommandArgument='<%# Eval("IDCancha")%>'
                                CommandName="EditRecord" ImageUrl='<%# "~/images/edit.gif" %>' Width="20px" BorderStyle="None" />
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
