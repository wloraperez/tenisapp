<%@ Page Title="Detalle de Jugador" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DetalleJugador.aspx.vb" Inherits="TenisApp.DetalleJugador" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <h1><%: Title %></h1>
    <h2></h2>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div style="float: left; width: auto; margin-right: 10px;">
        <asp:DetailsView ID="dvJugador" runat="server" Width="100%" DataKeyNames="IDJugador"
            AutoGenerateRows="false" BorderStyle="Inset" BorderWidth="1px" BorderColor="White">
            <Fields>
                <asp:BoundField
                    DataField="Nombres"
                    HeaderText="Nombres" />
                <asp:BoundField
                    DataField="Apellidos"
                    HeaderText="Apellidos" />
                <asp:BoundField
                    DataField="Empresa"
                    HeaderText="Empresa" />
                <asp:BoundField
                    DataField="Departamento"
                    HeaderText="Departamento" />
                <asp:BoundField
                    DataField="Categoria"
                    HeaderText="Categoria" />
                <asp:BoundField
                    DataField="Telefono"
                    HeaderText="Telefono" />
                <asp:BoundField
                    DataField="Correo"
                    HeaderText="Correo" />
                <asp:BoundField
                    DataField="Twitter"
                    HeaderText="Twitter" />
                <asp:BoundField
                    DataField="Instagram"
                    HeaderText="Instagram" />
                <asp:BoundField
                    DataField="Mano"
                    HeaderText="Mano" />
                <asp:BoundField
                    DataField="Size_TShirt"
                    HeaderText="Size T-Shirt" />
                <asp:BoundField
                    DataField="Size_Pantalon"
                    HeaderText="Size Pantalón" />
            </Fields>
            <AlternatingRowStyle BackColor="#ECEBE8" />
            <FieldHeaderStyle Font-Bold="true" />
        </asp:DetailsView>
    </div>
    <div>
        <asp:Image runat="server" ID="imgFoto" CssClass="foto" />
    </div>
</asp:Content>
