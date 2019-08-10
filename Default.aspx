<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="TenisApp._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <h1>Bienvenido al sistema de Tenistas en Línea</h1> 
	<p>Esta es una plataforma en donde podrá administrar todo lo relacionado a los torneos de Tenis.</p>	  
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="content_images_text">	  
	    <div class="content_image">
		    <img src="images/content_image.jpg" alt="content image" />
	    </div>
		  
	    <div class="image_text">
		    <%--<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin vehicula a nunc id euismod. Fusce enim ligula, facilisis nec gravida in, feugiat sit amet risus. Vivamus ornare leo convallis lorem posuere ullamcorper. Nunc convallis ultrices lacus sed faucibus. Vestibulum imperdiet non felis quis dapibus.</p>--%>
	    </div>	
    </div>
    
    <div class="content_container">
	<%--<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque cursus tempor enim. Aliquam facilisis neque non nunc posuere eget volutpat metus tincidunt.</p>--%>
	</div><!--close content_container-->
          
	<div class="content_container">
	</div><!--close content_container-->		
		  
	<div class="content_container">
	</div><!--close content_container-->
          
	<div class="content_container">
	</div><!--close content_container-->			  		
</asp:Content>
