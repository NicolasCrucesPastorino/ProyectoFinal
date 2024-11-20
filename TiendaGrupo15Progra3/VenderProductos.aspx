<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VenderProductos.aspx.cs" Inherits="TiendaGrupo15Progra3.VenderProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
    .bg-custom {
        background-image: url('images/fondoAmarillo.png');
        background-size: cover;
        background-position: center center;
        background-repeat: no-repeat;
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        z-index: -1;
    }
    .main-content 
    { 
      margin-top: 70px; /* Ajusta este valor según la altura de tu navbar */
    }
    .image-size 
    {
      width: 100px;
      height: 50px;
    }
    .contenedor {
    display: flex;
    flex-direction: inherit; /* Alinea los elementos en fila */
    justify-content: space-around; /* Espacio alrededor de los elementos */
    align-items: center; /* Centra verticalmente los elementos */
}

.img-container {
    margin: 10px; /* Margen entre imágenes */
}

.img-container img {
    width: 200px; /* Ancho fijo para las imágenes */
    height: auto; /* Mantiene la proporción */
}


</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content"></div>
    <div class="bg-custom"></div>
        <div class="contenedor">
            <div class="img-container">
                 <asp:ImageButton ID="IMGagregarProducto" runat="server" ImageUrl="~/images/AgregarArticulo.png" class="rounded float-start" alt="Agregar Articulo" OnClick="IMGagregarProducto_Click"/>
                 <asp:ImageButton ID="IMGactualizarArticulo" runat="server" ImageUrl="~/images/actualizarArticulo.png" class="rounded float-start" alt="Actualizar Articulo" OnClick="IMGactualizarArticulo_Click"/>
                 <asp:ImageButton ID="IMGeliminarArticulo" runat="server" ImageUrl="~/images/eliminarArticulo.png" class="rounded float-start" alt="Eliminar Articulo" OnClick="IMGeliminarArticulo_Click"/>
            </div>   
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
