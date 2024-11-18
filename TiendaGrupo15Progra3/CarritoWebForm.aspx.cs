using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TiendaGrupo15Progra3
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected List<Dominio.Carrito> CarritoProductos = new List<Dominio.Carrito>();
        protected List<CarritoSubMenu> carritoSubMenusGlobal = new List<CarritoSubMenu>();
        protected decimal TotalCarritoGlobal = new Decimal(0);

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
                CargarCarrito();
            
        }

        private void CargarCarrito()
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            CarritoService carritoService = new CarritoService();
            List<Dominio.Carrito> listaCarrito = carritoService.BuscarEnCarritoporIdUsuario(usuario.idUsuario);
            List<CarritoSubMenu> listaSubMenu = new List<CarritoSubMenu>();

            if (listaCarrito != null)
            {
                CarritoProductos = listaCarrito;
            }

            foreach (Dominio.Carrito carrito in CarritoProductos)
            {
                    CarritoSubMenu carritoSubMenu = new CarritoSubMenu();
                ArticuloService articuloService = new ArticuloService();
                carritoSubMenu.IdCarrito = carrito.Id;
                carritoSubMenu.IdProducto = carrito.IdProducto;
                carritoSubMenu.Nombre = articuloService.listarXid(carrito.IdProducto).Nombre;
                carritoSubMenu.Precio = Math.Round(articuloService.listarXid(carrito.IdProducto).Precio,2);
                carritoSubMenu.Cantidad = carrito.Cantidad;
                carritoSubMenu.Total = Math.Round(carrito.Cantidad * articuloService.listarXid(carrito.IdProducto).Precio,2);
                listaSubMenu.Add(carritoSubMenu);

            }
            carritoSubMenusGlobal = listaSubMenu;
            foreach ( CarritoSubMenu item in listaSubMenu)
            {
                TotalCarritoGlobal= TotalCarritoGlobal+item.Total;
            }
            TotalCarritoGlobal = Math.Round(TotalCarritoGlobal,2);

                RepeaterCarrito.DataSource = listaSubMenu;
            RepeaterCarrito.DataBind();

        }

        protected void ProcederPago(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }
    }
}
