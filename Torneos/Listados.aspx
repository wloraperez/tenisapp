<%@ Page Title="Torneos" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listados.aspx.vb" Inherits="TenisApp.Listados" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <h1>Opciones para torneos</h1>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <ul>
        <li><a href="ListadoTorneos">Torneos</a></li>
        <li><a href="ListadoCanchas">Canchas</a></li>
        <li><a href="ListadoTorneoJuego">Juegos de los Torneos</a></li>
    </ul>
</asp:Content>
