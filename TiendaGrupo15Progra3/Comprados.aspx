<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Comprados.aspx.cs" Inherits="TiendaGrupo15Progra3.Comprados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
    <h2>Tus Productos Comprados</h2>
    <table class="cart-table">
        <thead>
            <tr>
                <th>Producto</th>
                <th>Precio</th>
                <th>Cantidad</th>              
                <th>Total</th>
                

            </tr>
        </thead>
        <tbody>
            <!-- Repeater para mostrar productos en el carrito -->
            <asp:Repeater ID="RepeaterComprado" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("producto") %></td>
                        <td><%# Eval("precio") %></td>
                        <td><%# Eval("cantidad") %></td>
                        <td><%# Eval("Total") %></td>                       
                            
                            
                            <!-- <asp:Button ID="BTNCarritoEliminar" runat="server" Text="Eliminar" CommandArgument=' OnClick="BTNCarritoEliminar_Click" /> -->
                                                
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
