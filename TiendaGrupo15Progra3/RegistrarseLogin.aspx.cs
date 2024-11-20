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
        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            string Nombreusuario =TextBoxUsuario.Text.Trim();
            string email = TxtMail.Text.Trim();
            string contrasenia = TextBoxPassword.Text.Trim();
            string confirmarContrasenia = TextBoxConfirmPassword.Text.Trim();
            UsuarioService usuarioService = new UsuarioService();
            Usuario nuevoUsuario = new Usuario();
            bool confirmarContraseniaBool = false;
            bool existeUsuario=false;

            
            try
            {
                if (contrasenia == confirmarContrasenia)
                {
                    confirmarContraseniaBool = true;
                }
                existeUsuario = usuarioService.ExisteUsuario(email);

                if (existeUsuario == false && confirmarContraseniaBool == true)
                {
                    nuevoUsuario.nombreUsuario = Nombreusuario;
                    nuevoUsuario.clave = contrasenia;
                    nuevoUsuario.correo = email;
                    nuevoUsuario.rol = 1;

                    usuarioService.RegistrarUsuario(nuevoUsuario);
                    Session["Rol"] = 1;
                    fGlobales.MostrarAlerta(this, "Se ha creado con exito el usuario. Y desde ahora se encuentra logueado. BIENVENIDO!!!");
                    Session["Usuario"] = usuarioService.LoginUsuarioYcontraseniaDevuelveUsuario(nuevoUsuario.nombreUsuario, nuevoUsuario.clave);
                    
                   // 
                    Response.Redirect("/Default.aspx",false);
                    //Context.ApplicationInstance.CompleteRequest();
                  //

                }
                else if( confirmarContraseniaBool == false )
                {
                    fGlobales.MostrarAlerta(this,"Ocurrió un error:Las contraseñas no coinciden");
                } else if (existeUsuario == true)
                {
                    fGlobales.MostrarAlerta(this, "Ocurrió un error:El usuario ya existe");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Registrar Cliente (RegistrarseLogin) Linea 68 " + ex.Message);
            }
          
           
        }
    }
}