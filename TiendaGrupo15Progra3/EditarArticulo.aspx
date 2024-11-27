<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarArticulo.aspx.cs" Inherits="TiendaGrupo15Progra3.EditarArticulo" %>
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

        .main-content {
            margin-top: 70px; 
        }

        .form-container {
            background-color: #fff; 
            padding: 20px;
            border-radius: 8px; 
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); 
            max-width: 600px; 
            margin: 0 auto; 
        }

        .row {
            display: flex;
            flex-direction: row;
            gap: 15px; 
            margin-bottom: 15px; 
        }

        .col {
            flex: 1;
        }

        .form-label {
            display: block;
            margin-bottom: 5px;
        }

        .form-control {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
    .padding-botom{
    padding-bottom: 100px;
}
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="main-content padding-botom">
    <div class="center-container">
        <div class="form-container">
            <h1 class="header-custom">Modificar Artículo</h1>

            <div class="row">
                <div class="col">
                    <label for="CodigoArticuloText" class="form-label">Código Artículo:</label>
                    <asp:TextBox ID="CodigoArticuloTxt" CssClass="form-control" placeholder="Código Artículo" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <label for="nombreArticuloTxt" class="form-label">Nombre Artículo:</label>
                    <asp:TextBox ID="nombreArtTxt" CssClass="form-control" placeholder="Nombre Artículo" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <label for="Descripcion" class="form-label">Descripción:</label>
                    <asp:TextBox ID="DescripcionTxt" CssClass="form-control" placeholder="Descripción" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <label for="MarcaText" class="form-label">Marca:</label>
                    <asp:TextBox ID="TxtMarca" CssClass="form-control" placeholder="Marca Nuevo Artículo" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <label for="CategoriaTxt" class="form-label">Categoría:</label>
                    <asp:TextBox ID="TxtCategoria" CssClass="form-control" placeholder="Categoría" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <label for="PrecioTxt" class="form-label">Precio:</label>
                    <asp:TextBox ID="PrecioTxt" type="text" pattern="^\d+([,\.]\d{1,2})?$" title="El precio debe tener un formato válido, por ejemplo, 1234,56" CssClass="form-control" placeholder="Precio" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <label for="StockTxt" class="form-label">Stock:</label>
                    <asp:TextBox ID="txtStock" CssClass="form-control" placeholder="Stock" runat="server" />
                    <asp:RegularExpressionValidator 
                        ID="regexValidator" 
                        runat="server" 
                        ControlToValidate="txtStock"
                        ErrorMessage="El número debe tener un formato válido de números enteros." 
                        ValidationExpression="^\d+$" 
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-group">
                <asp:Button type="submit" ID="btnGuardarCambios" CssClass="btn btn-primary" runat="server" Text="Guardar Cambios" OnClick="btnGuardarCambios_Click" />
            </div>
            <h4><asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label></h4>
        </div>
    </div>
</div>
</asp:Content>

