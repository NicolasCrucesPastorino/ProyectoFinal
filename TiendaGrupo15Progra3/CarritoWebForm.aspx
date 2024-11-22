<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CarritoWebForm.aspx.cs" Inherits="TiendaGrupo15Progra3.CarritoWebForm" EnableEventValidation="false"%>

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
        <h2>Tu Carrito de Compras</h2>
        <table class="cart-table">
            <thead>
                <tr>
                    <th>Producto</th>
                    <th>Precio</th>
                    <th>Cantidad</th>
                    <th>SubTotal</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <!-- Repeater para mostrar productos en el carrito -->
                <asp:Repeater ID="RepeaterCarrito" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("producto") %></td>
                            <td><%# Eval("precio") %></td>
                            <td><%# Eval("cantidad") %></td>
                            <td><%# Eval("Total") %></td>
                            <td>
                                
                                
                                <asp:Button ID="BTNCarritoEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("IdCarrito") %>' OnClick="BTNCarritoEliminar_Click" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <div class="cart-total">
            <strong>Total:</strong> <asp:Literal ID="LiteralTotalCarrito" runat="server"></asp:Literal>

        </div>

        <div class="text-center">
            <asp:Button ID="btnCheckout" runat="server" Text="Proceder a Pago" CssClass="btn-checkout" OnClick="ProcederPago" />
        </div>
    </div>
</asp:Content>
