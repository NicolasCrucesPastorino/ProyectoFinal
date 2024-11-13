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

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            string usuario =TextBoxUsuario.Text.Trim();
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
                existeUsuario = usuarioService.ExisteUsuario(usuario);
                
                if (existeUsuario == false && confirmarContraseniaBool == true)
                {
                    nuevoUsuario.idUsuario = 177;
                    nuevoUsuario.nombre = usuario;
                    nuevoUsuario.contrasenia = contrasenia;
                    nuevoUsuario.rol = 1;

                    usuarioService.RegistrarUsuario(nuevoUsuario);

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

                throw new Exception("Error Registrar Cliente Back " + ex.Message);
            }
          
           
        }
    }
}