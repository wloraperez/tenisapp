<%@ Page Title="Listado de Departamentos" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListadoDepartamentos.aspx.vb" Inherits="TenisApp.ListadoDepartamentos" %>


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
                        <a id="AgregarDepartamento" runat="server" href="AgregarDepartamento" style="float: right;">Nuevo Departamento</a>
                    </td>
                </tr>
                <tr>
                    <td>Empresa</td>
                    <td>
                        <asp:DropDownList ID="ddlEmpresa" runat="server" DataValueField="IDEmpresa" DataTextField="Descripcion" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </td>
                    <td>Departamento</td>
                    <td>
                        <asp:TextBox ID="txtDepartamento" runat="server" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvDepartamentos" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros que coincidan con su seleccion"
                ForeColor="Black" GridLines="None" Width="100%" BackColor="White" BorderColor="#999999"
                PageSize="25" PagerSettings-Visible="false" AllowPaging="true" BorderStyle="Solid"
                BorderWidth="1px" CellPadding="3" AllowSorting="true">
                <Columns>
                    <asp:BoundField DataField="Empresa" HeaderText="Empresa" SortExpression="Empresa"></asp:BoundField>
                    <asp:BoundField DataField="Departamento" HeaderText="Empresa" SortExpression="Empresa"></asp:BoundField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="cmdEditRecord" runat="server" CommandArgument='<%# Eval("IDDepartamento")%>'
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
