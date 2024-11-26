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
    public partial class ModificarArticulo : System.Web.UI.Page
    {
        List<Articulo> articulosDelUsuario=new List<Articulo>();
      
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("/Login.aspx", false);
                return;
            }
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["Usuario"];

            List<Articulo> Listatemporal = new List<Articulo>();
            ArticuloService articuloService = new ArticuloService();
            Listatemporal = articuloService.GetArticulos();
            List<Articulo> ListatemporalFiltrada = new List<Articulo>();

            foreach(Articulo articulo in Listatemporal)
            {   
                

                if (articulo.IdUsuario == usuario.idUsuario)
                {
                    ListatemporalFiltrada.Add(articulo);
                }
            }

            articulosDelUsuario = ListatemporalFiltrada;
            RepeaterArticulosUsuario.DataSource = articulosDelUsuario;
            RepeaterArticulosUsuario.DataBind();

        }

        protected void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            
        }
    }
}