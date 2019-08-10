<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenimientos.aspx.vb" Inherits="TenisApp.Mantenimientos" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <h1>Mantenimientos básicos</h1>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <ul>
        <li><a href="ListadoCategorias">Categorías</a></li>
        <li><a href="ListadoEmpresas">Empresas</a></li>
        <li><a href="ListadoDepartamentos">Departamentos</a></li>
    </ul>
</asp:Content>
