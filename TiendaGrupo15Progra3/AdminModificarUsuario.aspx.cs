using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGrupo15Progra3
{
    public partial class AdminModificarUsuario : System.Web.UI.Page
    {
        private bool SoloLetras(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }

        public string ArticuloId { get; set; }
        public Usuario UsuarioIngresaTusDatos = new Usuario();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] != null)
            {

                Usuario usuarioCheck = (Usuario)Session["Usuario"];
                if (usuarioCheck.rol != 1)
                {
                    Response.Redirect("Login.aspx");
                }
                

            }
            else
            {

                
                Session["loMandamosLogin"] = true;
                Response.Redirect("Login.aspx");
            }
            Usuario usuario = new Usuario();

            UsuarioService usuarioService = new UsuarioService();
            usuario = usuarioService.TraerUsuarioPorId(int.Parse(Session["userId"].ToString()));




            nombreText.Text = usuario.nombre;
            apellidoText.Text = usuario.apellido;
            TextNombreUsuario.Text = usuario.nombreUsuario;
            TxtClave.Text = usuario.clave;
            EmailInput.Text = usuario.correo;

            usuario.rol = 2;
            TxtTelefono.Text = usuario.telefono;





            UsuarioIngresaTusDatos = usuario;

        }

        public void AceptarButton_Click(object sender, EventArgs e)
        {


           
            if (string.IsNullOrWhiteSpace(nombreText.Text) ||
                string.IsNullOrWhiteSpace(apellidoText.Text) ||
                string.IsNullOrWhiteSpace(TextNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(TxtClave.Text) ||
                string.IsNullOrWhiteSpace(EmailInput.Text) ||
                string.IsNullOrWhiteSpace(TxtTelefono.Text))
            {
                fGlobales.MostrarAlerta(this, "Todos los campos son obligatorios.");
                return;
            }


            if (!SoloLetras(nombreText.Text.Trim()))
            {
                string script = "alert('El campo \\\"Nombre\\\" solo puede contener letras.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "AlertNombre", script, true);
                return;
            }
            if (!SoloLetras(apellidoText.Text.Trim()))
            {
                string script = "alert('El campo \\\"Apellido\\\" solo puede contener letras.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "AlertApellido", script, true);
                return;
            }


            if (!EmailInput.Text.Contains("@") || !EmailInput.Text.Contains("."))
            {
                fGlobales.MostrarAlerta(this, "Ingrese un correo electrónico válido.");
                return;
            }




            if (!long.TryParse(TxtTelefono.Text, out _))
            {
                fGlobales.MostrarAlerta(this, "El número de teléfono debe contener solo números");
                return;
            }


            try
            {
                


                




               

                //Response.Redirect("/Default.aspx");

            }

            catch (Exception ex)
            {
                new Exception("Error al modificar producto:" + ex.Message);

            }
        }
        protected void CancelarClickButton_Click(object sender, EventArgs e)
        {
            



        }
    }
}