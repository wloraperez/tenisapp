<%@ Page Title="Listado de Torneos" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListadoTorneos.aspx.vb" Inherits="TenisApp.ListadoTorneos" %>


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
                        <a id="AgregarTorneo" runat="server" href="AgregarTorneo" style="float: right;">Nuevo Torneo</a>
                    </td>
                </tr>
                <tr>
                    <td>Nombre del torneo</td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="84%"></asp:TextBox></td>
                    <td>Activo?</td>
                    <td>
                        <asp:CheckBox ID="chkEstado" runat="server"></asp:CheckBox></td>
                </tr>
                <tr>
                    <td>
                    Fecha aprox.</td>
                    <td colspan="3">
                        <asp:Calendar ID="cFecha" runat="server"></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
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
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion"></asp:BoundField>
                    <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" SortExpression="FechaInicio" DataFormatString="{0:d}"></asp:BoundField>
                    <asp:BoundField DataField="FechaFinal" HeaderText="Fecha Final" SortExpression="FechaFinal" DataFormatString="{0:d}"/>
                    <asp:BoundField DataField="EstadoDescripcion" HeaderText="Estado" SortExpression="Categoria" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="cmdEditRecord" runat="server" CommandArgument='<%# Eval("IDTorneo")%>'
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
