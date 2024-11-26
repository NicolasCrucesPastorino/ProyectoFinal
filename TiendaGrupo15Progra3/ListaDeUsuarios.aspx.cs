using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
namespace TiendaGrupo15Progra3
{

    public partial class ListaDeUsuarios : System.Web.UI.Page
    {
        public List<Usuario> ListaUsuarios = new List<Usuario>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)            
                {
                    Session["loMandamosLogin"] = true;
                    Response.Redirect("Login.aspx");
                }
            else
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario) Session["Usuario"];
                if (usuario.rol != 1)
                {
                    Response.Redirect("Login.aspx");
                }


            }


            UsuarioService usuarioService = new UsuarioService();
            ListaUsuarios =usuarioService.listarUsuarios();

            RepeaterUsuarios.DataSource = ListaUsuarios;
            RepeaterUsuarios.DataBind();

            
            
        }
        protected void btnAbrirModalModificar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string userId = btn.CommandArgument;
            Session["userId"] = userId;
            Response.Redirect("AdminMOdificarUsuario.aspx");


        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            //string userId = hiddenUserId.Value;
            //string nombre = txtNombre.Text;
            //string apellido = txtApellido.Text;
            //string correo = txtCorreo.Text;
            //string telefono = txtTelefono.Text;

            // Guardar cambios en la base de datos
            // Aquí llamas a tu lógica para actualizar el usuario

            // Opcional: Mostrar un mensaje de confirmación
            fGlobales.MostrarAlerta(this, "Cambios guardados con exito");

        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string userId = btn.CommandArgument;
            UsuarioService usuarioObj = new UsuarioService();
            usuarioObj.EliminarUsuario(int.Parse(userId));
               
                   
           

            fGlobales.MostrarAlerta(this, "Usuario eliminado con exito");
            Page_Load(sender, e);
        }
    }
}