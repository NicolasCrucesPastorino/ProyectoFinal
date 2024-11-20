using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class VentaService
    {
        public void CargarVenta(Venta nuevaVenta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO venta (idUsuario, nombreCliente, subTotal,Total, fechaRegistro, Id_cliente) VALUES (@idUsuario, @nombreCliente, @subTotal, @Total, @fechaRegistro, @Id_cliente);");
                
                datos.setearParametro("@idUsuario", nuevaVenta.idUsuario);             
                datos.setearParametro("@nombreCliente", nuevaVenta.nombreCliente);
                datos.setearParametro("@subTotal", nuevaVenta.subTotal);
                datos.setearParametro("@Total", nuevaVenta.Total);
                datos.setearParametro("@fechaRegistro", nuevaVenta.fechaRegistro);
                datos.setearParametro("@Id_cliente", nuevaVenta.Id_cliente);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar una nueva venta:" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
