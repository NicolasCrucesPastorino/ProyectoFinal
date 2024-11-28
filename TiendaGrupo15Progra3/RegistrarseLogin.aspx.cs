using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TiendaGrupo15Progra3
{
    public partial class RegistrarseLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Revisada: Ok. Se agregael mail para evitar conflictos de nombres iguales
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            string Nombre = nombreText.Text.Trim();
            string Apellido = apellidoText.Text.Trim();
            string Username = TextNombreUsuario.Text.Trim();
            string Clave = TxtClave.Text.Trim();
            string RepetirClave = TxtRepetirClave.Text.Trim();
            string Email = EmailInput.Text.Trim();
            string Telefono = TxtTelefono.Text.Trim();

            UsuarioService usuarioService = new UsuarioService();
            Usuario nuevoUsuario = new Usuario();
            bool confirmarContraseniaBool = false;
            bool UsuarioPrimeraVez=false;

            
            try
            {
                if (Clave == RepetirClave)
                {
                    confirmarContraseniaBool = true;
                }
                UsuarioPrimeraVez = usuarioService.NoExisteUsuario(Email);

                if (UsuarioPrimeraVez == true && confirmarContraseniaBool == true)
                {
                    nuevoUsuario.nombre = Nombre;
                    nuevoUsuario.apellido = Apellido;
                    nuevoUsuario.nombreUsuario = Username;
                    nuevoUsuario.clave = Clave;
                    nuevoUsuario.correo = Email;
                    nuevoUsuario.telefono = Telefono;
                    nuevoUsuario.rol = 1;

                    usuarioService.RegistrarUsuario(nuevoUsuario);
                    Session["Rol"] = 1;
                    string script = "alert('Se ha creado con exito su usuario'); window.location='RegistrarseLogin.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                    Session["Usuario"] = usuarioService.LoginUsuarioYcontraseniaDevuelveUsuario(nuevoUsuario.nombreUsuario, nuevoUsuario.clave);
                    
                   // 
                    Response.Redirect("/Default.aspx",false);
                    //Context.ApplicationInstance.CompleteRequest();
                  //

                }
                else if( confirmarContraseniaBool == false )
                {
                    fGlobales.MostrarAlerta(this,"Ocurrió un error:Las contraseñas no coinciden");

                } else if (UsuarioPrimeraVez == false)
                {
                    fGlobales.MostrarAlerta(this, "Ocurrió un error:El mail ya se encuentra registrado, si olvido su contraseña puede recuperarla en Login");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Registrar Cliente (RegistrarseLogin) Linea 68 " + ex.Message);
            }
          
           
        }

        protected void CancelarClickButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx",false);
        }
    }
}