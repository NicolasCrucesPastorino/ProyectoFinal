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


            if (usuario == "admin" && contrasenia == "1234")
            {
                Session["Rol"]=2;
                Response.Redirect("Default.aspx");
                
               
            }
            else
            {

                Response.Write("<script>alert('Usuario o contraseña incorrectos');</script>");
            }


        }
    }
}