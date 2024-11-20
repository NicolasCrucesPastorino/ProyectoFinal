using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DetalleVentaService
    {
        public void CargarDetalleVenta (DetalleVenta nuevaVenta)
        {
            AccesoDatos datos = new AccesoDatos ();

            try
            {
                datos.setearConsulta("INSERT INTO DetalleVenta (idVenta, idProducto, marcaProducto, descripcionProducto, categoriaProducto, cantidad, precio, total) VALUES (@idVenta, @idProducto, @marcaProducto, @descripcionProducto, @categoriaProducto, @cantidad, @precio, @total);");

                datos.setearParametro("@idVenta", nuevaVenta.idVenta);
                datos.setearParametro("@idProducto", nuevaVenta.idProducto);
                datos.setearParametro("@marcaProducto", nuevaVenta.marcaProducto);
                datos.setearParametro("@descripcionProducto", nuevaVenta.descripcionProducto);
                datos.setearParametro("@categoriaProducto", nuevaVenta.categoriaProducto);
                datos.setearParametro("@cantidad", nuevaVenta.cantidad);
                datos.setearParametro("@precio", nuevaVenta.precio);
                datos.setearParametro("@total", nuevaVenta.total);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw new Exception("Error linea 23" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
