using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Dominio;
using System.Data.SqlClient;
using System.Collections;

namespace Negocio
{
    public class ArticuloService
    {

        public List<Articulo> GetArticulos()
        {
            List<Articulo> ArticulosFinal = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            ImagenService imagenArticulos = new ImagenService();
            Marca Maraux = new Marca();
            Categoria CatAux = new Categoria();

            try
            {
                datos.setearConsulta("SELECT ART.Id, ART.Nombre, ART.Codigo, ART.Descripcion, ART.Precio,ART.Stock,ART.IdUsuario, MAR.Descripcion AS MarcaDescripcion, CAT.Descripcion AS CategoriaDescripcion " +
                                     "FROM ARTICULOS ART " +
                                     "INNER JOIN CATEGORIAS CAT ON ART.IdCategoria = CAT.Id " +
                                     "INNER JOIN MARCAS MAR ON ART.IdMarca = MAR.Id");
                datos.ejecutarLectura();
             
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = Convert.ToInt32(datos.Lector["Id"]);
                    aux.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    aux.CodigoArticulo = Convert.ToString(datos.Lector["Codigo"]);
                    aux.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);
                    aux.Precio = (decimal)(datos.Lector["Precio"]);
                    Maraux.Descripcion = Convert.ToString(datos.Lector["MarcaDescripcion"]);
                    CatAux.Descripcion = Convert.ToString(datos.Lector["CategoriaDescripcion"]);
                    aux.Marca = Maraux;
                    aux.Categoria = CatAux;

                    ArticulosFinal.Add(aux);
                }

                foreach (Articulo a in ArticulosFinal)
                {
                    List<Imagen> listaimagenesArticulos = imagenArticulos.listarPorIdArticulo(a.Id);
                    a.Imagenes = listaimagenesArticulos;
                }

                return ArticulosFinal;
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


        public List<Articulo> GetArticulos2()
        {
            List<Articulo> ArticulosFinal = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
           ImagenService imagenArticulos = new ImagenService();

            try
            {
                datos.setearConsulta("select ARTICULOS.Id, ARTICULOS.Nombre, ARTICULOS.Codigo ,ARTICULOS.Descripcion, ARTICULOS.Precio, MARCAS.Descripcion,CATEGORIAS.Descripcion from ARTICULOS" +
                    " INNER JOIN CATEGORIAS on ARTICULOS.IdCategoria = CATEGORIAS.Id" +
                    " INNER JOIN MARCAS on ARTICULOS.IdMarca=MARCAS.Id");
                datos.ejecutarLectura();
            


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = Convert.ToInt32(datos.Lector["Id"]);
                    aux.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    aux.CodigoArticulo = Convert.ToString(datos.Lector["Codigo"]);
                    aux.Descripcion = Convert.ToString(datos.Lector["ARTICULOS.Descripcion"]); aux.Precio = (decimal)(datos.Lector["Precio"]);
                    aux.Marca.Descripcion = Convert.ToString(datos.Lector["MARCAS.Descripcion"]);
                    aux.Categoria.Descripcion = Convert.ToString(datos.Lector["CATEGORIAS.Descripcion"]);
                   
                    ArticulosFinal.Add(aux);
                }

                foreach (Articulo a in ArticulosFinal)
                {
                    List<Imagen> listaimagenesArticulos = imagenArticulos.listarPorIdArticulo(a.Id);
                    a.Imagenes = listaimagenesArticulos;
                   
                }

                return ArticulosFinal;

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
        public Articulo listarXid (int ArticuloID)
        {
          
            AccesoDatos accesoDatos = new AccesoDatos();
            ImagenService imagenService = new ImagenService();
            List <Imagen>  lista = new List<Imagen>();

            try
            {
                accesoDatos.setearConsulta("SELECT A.Id, Codigo, Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, M.Descripcion Nombre_Marca,C.Descripcion Nombre_Categoria, M.Id Id_Marca, C.Id Id_Categoria, A.Precio,A.Stock FROM ARTICULOS A JOIN CATEGORIAS C ON A.IdCategoria = C.Id JOIN MARCAS M ON A.IdMarca = M.Id WHERE A.id=@idArticulo");
                accesoDatos.setearParametro("@idArticulo",ArticuloID);
                accesoDatos.ejecutarLectura();
                Articulo articulo = new Articulo();
                while (accesoDatos.Lector.Read())
                {
                    

                    articulo.Id = (int)accesoDatos.Lector["Id"];
                    articulo.CodigoArticulo = (string)accesoDatos.Lector["Codigo"];
                    articulo.Nombre = (string)accesoDatos.Lector["Nombre"];
                    articulo.Descripcion = (string)accesoDatos.Lector["Descripcion"];

                    //Creacion de Marca y relacion en datagrid
                    articulo.Marca = new Marca();
                    articulo.Marca.Descripcion = (string)accesoDatos.Lector["Nombre_Marca"];
                    articulo.Marca.Id = (int)accesoDatos.Lector["IdMarca"];

                    //Creacion de Categoria y relacion en datagrid
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Descripcion = (string)accesoDatos.Lector["Nombre_Categoria"];
                    articulo.Categoria.Id = (int)accesoDatos.Lector["IdCategoria"];

                    articulo.Precio = (decimal)accesoDatos.Lector["Precio"];
                    articulo.Stock = (int)accesoDatos.Lector["Stock"];

                }

                foreach (var a in lista)
                {
                    List<Imagen> imagenes = imagenService.listarPorIdArticulo(articulo.Id);
                    articulo.Imagenes = imagenes;
                }
                return articulo ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();

            }

           
        }

        public void AgregarArticulo (Articulo nuevoArticulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta(@"INSERT INTO Articulos (Codigo, Nombre, Descripcion,IdMarca,IdCategoria,Precio, Stock, IdUsuario)
                VALUES (@codigo,@nombre,@descripcion,@IdMarca,@IdCategoria,@precio,@stock,@IdUsuario)");

                accesoDatos.setearParametro("@codigo", nuevoArticulo.CodigoArticulo);
                accesoDatos.setearParametro("@nombre", nuevoArticulo.Nombre);
                accesoDatos.setearParametro("@descripcion", nuevoArticulo.Descripcion);
                accesoDatos.setearParametro("@IdMarca", nuevoArticulo.Marca.Id);
                accesoDatos.setearParametro("@IdCategoria", nuevoArticulo.Categoria.Id);
                accesoDatos.setearParametro("@precio", nuevoArticulo.Precio);
                accesoDatos.setearParametro("@stock", nuevoArticulo.Stock);
                accesoDatos.setearParametro("@IdUsuario", nuevoArticulo.IdUsuario);
                accesoDatos.ejecutarAccion(); 
    
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar nuevo producto: " + ex.Message);
            }
            finally { accesoDatos.cerrarConexion();}
        }
        
        public void ModificarArticulo (int IdArticulo, string Modificacion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS set Descripcion=@Modificacion where Id=@IdArticulo");
                datos.setearParametro("@Modificacion", Modificacion);
                datos.setearParametro("@IdArticulos", IdArticulo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

               throw new Exception("Error al modificar producto: " + ex.Message);
            }
          
        }
        public void EliminarArticuloPorId(int IdArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE from ARTICULOS where Id=@IdArticulo");
                datos.setearParametro("@IdArticulo", IdArticulo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar producto: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
