
using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Negocio
{
    public class CarritoService
    {
        public void GuardarEnCarritoArticulo(int idCarritoEntrante, int idArticuloEntrante, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Carrito(idCarrito,idProducto,Cantidad) values(@idCarrito,@idArticulo,@Cantidad)");
                datos.setearParametro("@idCarrito", idCarritoEntrante);
                datos.setearParametro("@idArticulo", idArticuloEntrante);
                datos.setearParametro("@Cantidad", cantidad);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }
    }
}


