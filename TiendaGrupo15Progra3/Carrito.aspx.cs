using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGrupo15Progra3
{
    public partial class Carrito : Page
    {

        protected List<ProductoCarrito> CarritoProductos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {

            CarritoProductos = Session["Carrito"] as List<ProductoCarrito>;

            if (CarritoProductos == null)
            {
                CarritoProductos = new List<ProductoCarrito>();
            }

            RepeaterCarrito.DataSource = CarritoProductos;
            RepeaterCarrito.DataBind();

            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (var producto in CarritoProductos)
            {
                total += producto.PrecioUnitario * producto.Cantidad;
            }

            // totalCarrito.InnerText = total.ToString("C");
        }

        protected void CantidadChanged(object sender, EventArgs e)
        {
            var txtCantidad = sender as TextBox;
            var fila = (RepeaterItem)txtCantidad.NamingContainer;
            var idProducto = Convert.ToInt32((fila.FindControl("btnEliminar") as Button).CommandArgument);


            int nuevaCantidad = Convert.ToInt32(txtCantidad.Text);

            var producto = CarritoProductos.Find(p => p.IDProducto == idProducto);
            if (producto != null)
            {
                producto.Cantidad = nuevaCantidad;
            }


            CargarCarrito();
        }

        protected void EliminarProducto(object sender, EventArgs e)
        {
            var btnEliminar = sender as Button;
            var idProducto = Convert.ToInt32(btnEliminar.CommandArgument);


            var producto = CarritoProductos.Find(p => p.IDProducto == idProducto);
            if (producto != null)
            {
                CarritoProductos.Remove(producto);
            }


            CargarCarrito();
        }

        protected void ProcederPago(object sender, EventArgs e)
        {

            Response.Redirect("Checkout.aspx");
        }
    }

    public class ProductoCarrito
    {
        public int IDProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal TotalProducto => PrecioUnitario * Cantidad;
    }
}
