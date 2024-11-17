using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TiendaGrupo15Progra3
{
    public partial class Carrito : Page
    {
        protected List<Dominio.Carrito> CarritoProductos = new List<Dominio.Carrito>();
        protected int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            CarritoService carritoService = new CarritoService();

            CarritoProductos = carritoService.BuscarEnCarritoporIdCarrito(usuario.idUsuario);

            if (CarritoProductos == null)
            {
                CarritoProductos = new List<Dominio.Carrito>();
            }

            RepeaterCarrito.DataSource = CarritoProductos;
            RepeaterCarrito.DataBind();
        }

        protected void ProcederPago(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }
    }
}
