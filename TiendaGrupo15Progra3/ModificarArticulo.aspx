<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ModificarArticulo.aspx.cs" Inherits="TiendaGrupo15Progra3.ModificarArticulo" %>
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
.padding-botom{
    padding-bottom: 100px;
}
    .cart-table {
        width: 100%;
        margin-top: 20px;
        border-collapse: collapse;
    }

    .cart-table th, .cart-table td {
        padding: 15px;
        text-align: center;
        border: 1px solid #ddd;
    }

    
    .cart-table th {
    background-color: lightslategrey;
}

    .cart-total {
        font-size: 1.5rem;
        margin-top: 20px;
        text-align: right;
    }

    .btn-update, .btn-remove {
        background-color: black;
        color: yellow;
        border: none;
        padding: 8px 16px;
        cursor: pointer;
        border-radius: 5px;
    }

    .btn-update:hover, .btn-remove:hover {
        background-color: darkgray;
    }

    .btn-checkout {
        background-color: #ffd700;
        color: black;
        font-size: 1.5rem;
        padding: 15px 30px;
        border: none;
        cursor: pointer;
        border-radius: 5px;
    }
    .paraTabla{
    color:whitesmoke;
    background-color:#1a1a1a;
    border-color:black;
}

    .btn-checkout:hover {
        background-color: #ffcc00;
    }
        .main-content { 
                margin-top: 100px; /* Ajusta este valor según la altura de tu navbar */

    }
     

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-custom"></div>

    <div class="main-content">

<div class="container">
 <h2>Tus Productos Personales.</h2>
<table class="cart-table">
    <thead class="paraTabla">
        <tr>
            <th>Producto</th>
            <th>Marca</th>
            <th>Categoria</th>   
            <th>Descripcion</th>            
            <th>Precio</th>           
            <th>Stock Restante</th>
            <th>Acciones</th>            

        </tr>
    </thead>
    <tbody class="paraTabla">
        <!-- Repeater para mostrar productos en el carrito -->
        <asp:Repeater ID="RepeaterArticulosUsuario" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Nombre") %></td>
                    <td><%# Eval("Marca.Descripcion") %></td>
                    <td><%# Eval("Categoria.Descripcion") %></td>
                    <td><%# Eval("Descripcion") %></td>
                    <td>$<%# Eval("Precio") %></td>                    
                    <td><%# Eval("Stock") %></td>
                                          
                        
                                           
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>




    <div class="padding-botom"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
