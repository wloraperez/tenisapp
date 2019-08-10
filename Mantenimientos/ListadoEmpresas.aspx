<%@ Page Title="Listado de Empresas" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListadoEmpresas.aspx.vb" Inherits="TenisApp.ListadoEmpresas" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <h1><%: Title %></h1>
    <h2></h2>
    <%--<section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2></h2>
            </hgroup>
            <p>
            </p>
        </div>
    </section>--%>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="updRegistro" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <table>
                <tr>
                    <td>
                        <a id="AgregarEmpresa" runat="server" href="AgregarEmpresa" style="float: right;">Nueva Empresa</a>
                    </td>
                </tr>
                <tr>
                    <td>Nombre de la Empresa</td>
                    <td>
                        <asp:TextBox ID="txtEmpresa" runat="server" Width="84%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvEmpresas" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros que coincidan con su seleccion"
                ForeColor="Black" GridLines="None" Width="100%" BackColor="White" BorderColor="#999999"
                PageSize="25" PagerSettings-Visible="false" AllowPaging="true" BorderStyle="Solid"
                BorderWidth="1px" CellPadding="3" AllowSorting="true">
                <Columns>
                    <asp:BoundField DataField="Descripcion" HeaderText="Nombre de Empresa" SortExpression="Descripcion"></asp:BoundField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="cmdEditRecord" runat="server" CommandArgument='<%# Eval("IDEmpresa")%>'
                                CommandName="EditRecord" ImageUrl='<%# "~/images/edit.gif" %>' Width="20px" BorderStyle="None" />
                            <%--<asp:ImageButton ID="cmdViewRecord" runat="server" CommandArgument='<%# Eval("IDCategoria")%>'
                                CommandName="ViewRecord" ImageUrl='<%# "~/images/view.gif"%>' Width="20px" BorderStyle="None" />--%>
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
