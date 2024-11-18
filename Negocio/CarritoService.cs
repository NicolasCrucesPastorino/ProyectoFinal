
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
        public void GuardarEnCarritoArticulo(int idUsuarioEntrante, int idArticuloEntrante, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Carrito(idUsuario,idProducto,Cantidad) values(@idUsuario,@idArticulo,@Cantidad)");
                datos.setearParametro("@idUsuario", idUsuarioEntrante);
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

        public List<Carrito> BuscarEnCarritoporIdUsuario(int idUsuarioEntrante)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Dominio.Carrito> listaCarrito = new List<Dominio.Carrito>();
            
            try
            {
                datos.setearConsulta("SELECT id,idUsuario,idProducto,Cantidad from Carrito where idUsuario=@idUsuario");
                datos.setearParametro("@idUsuario", idUsuarioEntrante);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    Carrito carrito = new Carrito();
                    carrito.Id = (int)datos.Lector["id"];
                    carrito.IdUsuario = (int)datos.Lector["idUsuario"];
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


