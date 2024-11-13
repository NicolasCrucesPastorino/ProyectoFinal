using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGrupo15Progra3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        int RolTraido {  get; set; }    

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
         
            string usuario = LoginTextUsuario.Text;
            string contrasenia = LoginTextContrasenia.Text;
            UsuarioService usuarioService = new UsuarioService();

            if (usuarioService.LoginSoloUsuarioYcontrasenia(usuario,contrasenia)==2)
            {
                Session["Rol"]=2;
                Session["Usuario"] = usuario;
                Response.Redirect("Default.aspx");
                
               
            }
            else if(usuarioService.LoginSoloUsuarioYcontrasenia(usuario,contrasenia)==1)
            {
                Session["Rol"] = 1;
                Session["Usuario"] = usuario;
                Response.Redirect("Default.aspx");
                
            }
            else
            {
                fGlobales.MostrarAlerta(this, "El Usuario no existe");
            }


        }
    }
}