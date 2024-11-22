<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Comprados.aspx.cs" Inherits="TiendaGrupo15Progra3.Comprados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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
        background-color: #f2f2f2;
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

    .btn-checkout:hover {
        background-color: #ffcc00;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
    <h2>Tus Productos Comprados</h2>
    <table class="cart-table">
        <thead>
            <tr>
                <th>Producto</th>
                <th>Categoria</th>                
                <th>Marca</th>
                <th>Precio</th>
                <th>Cantidad Comprada</th>
                <th>Mail Vendedor</th>
                <th>Telefono Vendedor</th>
                <th>Stock Restante</th>
                <th>Monto Total</th>                

            </tr>
        </thead>
        <tbody>
            <!-- Repeater para mostrar productos en el carrito -->
            <asp:Repeater ID="RepeaterComprado" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("producto") %></td>
                        <td><%# Eval("categoria") %></td>
                        <td><%# Eval("marca") %></td>
                        <td><%# Eval("precio") %> $</td>
                        <td><%# Eval("cantidad") %></td>
                        <td><%# Eval("correo") %></td>
                        <td><%# Eval("telefono") %></td>
                        <td><%# Eval("Stock") %></td>
                        <td><%# Eval("Total") %> $</td>                       
                            
                                               
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>









</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
