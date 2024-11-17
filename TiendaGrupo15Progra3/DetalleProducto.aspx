<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TiendaGrupo15Progra3.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2><%= articuloDetalle.Nombre %> <%= articuloDetalle.Imagenes.Count %></h2>
    <!-- Carousel -->
    <div id="carousel<%= articuloDetalle.Id %>" class="carousel slide mb-3" data-bs-ride="carousel">
        <div class="carousel-inner">
            <% for (int i = 0; i < articuloDetalle.Imagenes.Count; i++) { %>
                <div class="carousel-item <%= i == 0 ? "active" : "" %>">
                    <img src="<%= articuloDetalle.Imagenes[i] %>" class="d-block w-100" alt="imagen" style="height: 250px; object-fit: contain; object-position: center;">
                </div>
            <% } %>
        </div>
        <!-- Controles de Carousel-->
        <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%= articuloDetalle.Id %>" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Anterior</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carousel<%= articuloDetalle.Id %>" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Siguiente</span>
        </button>
    </div>
    <p><%= articuloDetalle.Descripcion %></p>
    <h3>Precio : <%= Math.Round(articuloDetalle.Precio,2) %></h3>
    <p>Marca: <%= articuloDetalle.Marca.ToString() %></p>
    <p>Categoria: <%= articuloDetalle.Categoria %></p>
     <%if(Rol == 1)
     {  %>
 <div>
 <asp:Button ID="BtnEliminarProdAdmin" runat="server" Text="Eliminar Producto" OnClick="BtnEliminarProdAdmin_Click" />

 </div>
 <%} %>
 <%if(Rol == 2)
    {  %>
<div>
<asp:Button ID="BtnAgregarAlCarrito" runat="server" Text="Agregar Producto al Carrito" />

</div>
<%} %>
       <%if(Rol == 0)
    {  %>
<div>
<asp:Button ID="BtnLoguearseDesdeDetalleProducto" runat="server" Text="No esta logueado,logueese aqui" OnClick="BtnLoguearseDesdeDetalleProducto_Click" />

</div>
<%} %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
</asp:Content>

