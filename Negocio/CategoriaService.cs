using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaService
    {
        public List<Categoria> getCategorias()
        {   List<Categoria> ListaCategorias = new List<Categoria>();
            
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {   
                    Categoria categoria = new Categoria(); 
                    categoria.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);
                    ListaCategorias.Add(categoria);
                }

                return ListaCategorias;
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
