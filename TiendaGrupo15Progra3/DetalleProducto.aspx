<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TiendaGrupo15Progra3.DetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    <h2><%=articuloDetalle.Nombre %></h2>
    <p><%=articuloDetalle.Descripcion %></p>
    <h3>Precio : <%=articuloDetalle.Precio %></h3>
    <p>Marca: <%=articuloDetalle.Marca.ToString() %></p>
    <p>Categoria: <%=articuloDetalle.Categoria %></p>
    
    


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
