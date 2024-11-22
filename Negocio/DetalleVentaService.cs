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
                datos.setearConsulta("INSERT INTO DetalleVenta (idProducto,idVenta, marcaProducto, descripcionProducto, categoriaProducto, cantidad, precio, total) VALUES ( @idProducto, @idVenta,@marcaProducto, @descripcionProducto, @categoriaProducto, @cantidad, @precio, @total);");

                
                datos.setearParametro("@idProducto", nuevaVenta.idProducto);
                datos.setearParametro("@idVenta", nuevaVenta.idVenta);
                datos.setearParametro("@marcaProducto", nuevaVenta.marcaProducto);
                datos.setearParametro("@descripcionProducto", nuevaVenta.descripcionProducto);
                datos.setearParametro("@categoriaProducto", nuevaVenta.categoriaProducto);
                datos.setearParametro("@cantidad", nuevaVenta.cantidad);
                datos.setearParametro("@precio", nuevaVenta.precio);
                datos.setearParametro("@total", nuevaVenta.total);

                datos.ejecutarLectura();

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
