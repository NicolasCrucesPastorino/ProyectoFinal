using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaService
    {
        public List<Marca> getMarcas()
        {
            List<Marca> ListaMarcas = new List<Marca>();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Descripcion from MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);
                    ListaMarcas.Add(marca);
                }

                return ListaMarcas;
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
