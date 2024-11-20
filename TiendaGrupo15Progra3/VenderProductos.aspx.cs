using Dominio;
using System;
using System.Web.Configuration;

namespace TiendaGrupo15Progra3
{
    public partial class VenderProductos : System.Web.UI.Page
    {
        Usuario usuarioVendedor = new Usuario();

        public void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {

                usuarioVendedor = (Usuario)Session["Usuario"];

            }
            else
            {
                usuarioVendedor.nombre = "No se encuentra";
                usuarioVendedor.apellido = "Registrado";
            }
        }

        protected void IMGagregarProducto_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("/AgregarNuevoArticulo.aspx");

        }

        protected void IMGactualizarArticulo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

        }

        protected void IMGeliminarArticulo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

        }
    }
}