
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

        public List<Carrito> BuscarEnCarritoporIdCarrito(int idCarritoEntrante)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Carrito> listaCarrito = new List<Carrito>();
            
            try
            {
                datos.setearConsulta("SELECT idCarrito,idProducto,Cantidad from Carrito where idCarrito=@idCarrito");
                datos.setearParametro("@idCarrito", idCarritoEntrante);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    Carrito carrito = new Carrito();
                    carrito.IdCarrito = (int)datos.Lector["idCarrito"];
                    carrito.IdProducto = (int)datos.Lector["idProducto"];
                    carrito.Cantidad = (int)datos.Lector["Cantidad"];
                    listaCarrito.Add(carrito);

                }
                return listaCarrito;
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


