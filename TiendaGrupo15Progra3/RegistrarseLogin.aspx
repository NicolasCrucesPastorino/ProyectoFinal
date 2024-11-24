<%@ Page Title="Registro de Usuario" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistrarseLogin.aspx.cs" Inherits="TiendaGrupo15Progra3.RegistrarseLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Puedes añadir estilos personalizados aquí si deseas */
        .register-container {
            max-width: 400px;
            margin: 0 auto;
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
            background-color: #ffffff;
        }
        .padding-botom{
    padding-bottom: 100px;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex align-items-center justify-content-center" style="min-height: 100vh;">
        <div class="register-container padding-botom">
            <h2 class="text-center mb-4">Registro de Usuario</h2>

            <asp:Label ID="LabelUsuario" runat="server" Text="Usuario" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TextBoxUsuario" runat="server" CssClass="form-control" placeholder="Ingresa tu usuario"></asp:TextBox>

             <asp:Label ID="LblEmail" runat="server" Text="Mail" CssClass="form-label"></asp:Label>
             <asp:TextBox ID="TxtMail" runat="server" CssClass="form-control" placeholder="Ingresa tu mail"></asp:TextBox>

            <asp:Label ID="LabelPassword" runat="server" Text="Contraseña" CssClass="form-label mt-3"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingresa tu contraseña"></asp:TextBox>

            <asp:Label ID="LabelConfirmPassword" runat="server" Text="Confirmar Contraseña" CssClass="form-label mt-3"></asp:Label>
            <asp:TextBox ID="TextBoxConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirma tu contraseña"></asp:TextBox>

            <asp:Button ID="ButtonRegister" runat="server" CssClass="btn btn-primary w-100 mt-4" Text="Registrarse" OnClick="ButtonRegister_Click" />
        </div>
    </div>
</asp:Content>
