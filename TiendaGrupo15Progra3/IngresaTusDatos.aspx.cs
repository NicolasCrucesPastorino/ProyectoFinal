using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TiendaGrupo15Progra3
{
    public partial class IngresaTusDatos : System.Web.UI.Page
    {

        public string ArticuloId { get; set; }
        public Usuario UsuarioIngresaTusDatos = new Usuario();
 

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] != null)
            {

                UsuarioIngresaTusDatos = (Usuario)Session["Usuario"];
                
            }
            else
            {
                UsuarioIngresaTusDatos.nombre = "No se encuentra";
                UsuarioIngresaTusDatos.apellido = "Registrado";
            }

        }

        public void AceptarButton_Click(object sender, EventArgs e)
        {


            if (!terminosCheckBox.Checked)
            {
                fGlobales.MostrarAlerta(this, "Por favor, acepte los términos y condiciones.");
                return;
            }

            try
            {
                if (Session["Usuario"] == null)
                {

                    string script = "alert('No se encuentra logueado debe loguearse para actualizar perfil.'); window.location='Login.aspx';"; 
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true); 
                    return; 

                }


                Usuario usuario = new Usuario();
                Usuario usuarioTraidoSession = new Usuario();
                UsuarioService usuarioService = new UsuarioService();

                usuarioTraidoSession = (Usuario)Session["Usuario"];
         

                usuario.nombre = nombreText.Text.Trim();
                usuario.apellido = apellidoText.Text.Trim();
                usuario.nombreUsuario = TextNombreUsuario.Text.Trim();
                usuario.clave = TxtClave.Text.Trim();
                usuario.correo = EmailInput.Text.Trim();
                usuario.urlFoto = txtFotoPerfil.Text.Trim();
                usuario.nombreFoto = TxtDescripcionFoto.Text.Trim();
                usuario.idUsuario = usuarioTraidoSession.idUsuario;
                usuario.rol = 1;
                usuario.telefono = TxtTelefono.Text.Trim();



                usuarioService.ActualizarPerfil(usuario, UsuarioIngresaTusDatos.idUsuario);

                UsuarioIngresaTusDatos = usuario;
               

                

                    fGlobales.MostrarAlerta(this, "Perfil actualizado con exito");

                    Session["Usuario"] = usuarioService.LoginUsuarioYcontraseniaDevuelveUsuario(usuario.nombreUsuario, usuario.clave);

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