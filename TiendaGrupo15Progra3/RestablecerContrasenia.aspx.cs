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
    public partial class RestablecerContrasenia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRestablecerPasword_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();
            UsuarioService ParaRecuperarContrasenia = new UsuarioService();

            bool enviarContraseniaNueva = false;

            try
            {
                enviarContraseniaNueva = emailService.ExisteMail(TxtEmail.Text);


                if (enviarContraseniaNueva)
                {
                    ParaRecuperarContrasenia.CambiarContrasenia(TxtEmail.Text);

                    emailService.armarMail(TxtEmail.Text, "Restablecimiento de Contraseña", "Su nueva Contrasenia es 12345");
                    emailService.enviarEmail();


                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    fGlobales.MostrarAlerta(this, "El mail ingresado no se encuentra registrado, registrese");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("error btnRestablecer Contraseña" + ex.Message);
            }

        }
    }
}