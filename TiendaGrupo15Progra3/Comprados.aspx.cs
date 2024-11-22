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
    public partial class Comprados : System.Web.UI.Page
    {
        public List<ParaRepeter> paraRepeterList = new List<ParaRepeter>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario =(Usuario) Session["Usuario"];
            VentaService ventaService = new VentaService();
            List<Venta> listaVentasCompradas = new List<Venta>();
            Venta venta = new Venta();
            DetalleVenta detalleVenta = new DetalleVenta();
            DetalleVentaService detalleVentaService = new DetalleVentaService();
            
            ParaRepeter paraRepeter = new ParaRepeter();
            Articulo articulo = new Articulo();
            ArticuloService articuloService = new ArticuloService();

            listaVentasCompradas= ventaService.buscarComprado(usuario.idUsuario);

            foreach(Venta ventaItem in listaVentasCompradas)
            {
                detalleVenta= detalleVentaService.BuscarPorIdVenta(ventaItem.idVenta);
                articulo = articuloService.listarXid(detalleVenta.idProducto);
                paraRepeter.producto = articulo.Nombre;
                paraRepeter.precio = articulo.Precio;
                paraRepeter.cantidad = detalleVenta.cantidad;
                paraRepeter.Total = detalleVenta.cantidad * articulo.Precio;
                paraRepeterList.Add( paraRepeter );

            }
            RepeaterComprado.DataSource = paraRepeterList;
           
            RepeaterComprado.DataBind();



        }
    }
}