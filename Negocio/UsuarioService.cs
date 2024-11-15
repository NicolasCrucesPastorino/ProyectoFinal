using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio;

using Negocio;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Negocio
{
    public class UsuarioService
    {    
        //Revisada: Okey
        public int Login(Usuario usuario)
        {
            int rol = 0;
            AccesoDatos datos = new AccesoDatos();          
            try
            {
                datos.setearConsulta("SELECT Rol from USUARIOS WHERE Nombre = @nombre AND Contrasenia = @contrasenia");
                datos.setearParametro("@nombre", usuario.nombre);
                datos.setearParametro("@contrasenia", usuario.clave);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                  
                   rol = (int)datos.Lector["idRol"];
                   
                   
                }
                return rol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                datos.cerrarConexion();
            } 
        }
        //Revisada: Okey
        public int LoginSoloUsuarioYcontrasenia(string usuario,string contrasenia)
        {
            int rol = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT idRol from USUARIO WHERE Nombre = @nombre AND Clave=@contrasenia");
                datos.setearParametro("@nombre", usuario);
                datos.setearParametro("@contrasenia", contrasenia);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    rol = int.Parse( datos.Lector["idRol"].ToString());


                }
                
                return rol;
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
       
        public bool ExisteUsuario(string UsuarioEmail)
        {
           AccesoDatos datos = new AccesoDatos();

           try
            {


            datos.setearConsulta("select FechaRegistro,Correo,EsActivo from USUARIO where Correo=@mail and EsActivo=@Inactivo and (FechaRegistro IS NULL OR FechaRegistro ='')");
            datos.setearParametro("@mail", UsuarioEmail);
            datos.setearParametro("@Inactivo", 0);
            datos.ejecutarLectura();
            while (datos.Lector.Read())
            {

                return true;


            }

                return false;

            }
            catch (Exception ex)
            {

               throw new Exception("Error en Existe Cliente (UsuarioService) Linea 108: " + ex.Message); ;
            }
            finally
            {
                datos.cerrarConexion();
            }
          
        }

        public void RegistrarUsuario (Usuario usuario)
        { 
            AccesoDatos datos = new AccesoDatos ();
            DateTime dateTime = DateTime.Now;

            try
            {
                datos.setearConsulta (@"Insert into USUARIO(nombre,correo, clave, idRol,esActivo,fechaRegistro) VALUES
                                        (@Nombre,@Correo,@Contrasenia, @idRol,@esActivo,@FechaRegistro)");

                datos.setearParametro("@Nombre", usuario.nombre);
                datos.setearParametro("Correo",usuario.correo);
                datos.setearParametro("@Contrasenia", usuario.clave);
                datos.setearParametro("@idRol", usuario.rol);
                datos.setearParametro("@esActivo", 1);
                datos.setearParametro("@fechaRegistro", dateTime);

                datos.ejecutarAccion(); 

            }
            catch (Exception ex)
            {

                throw new Exception("Error al Registrar cliente: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
           
        }
    } 
}
