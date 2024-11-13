using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio;

namespace Negocio
{
    public class UsuarioService
    {
        public int Login(Usuario usuario)
        {
            int rol = 0;
            AccesoDatos datos = new AccesoDatos();          
            try
            {
                datos.setearConsulta("SELECT Rol from USUARIOS WHERE Nombre = @nombre AND Contrasenia = @contrasenia");
                datos.setearParametro("@nombre", usuario.nombre);
                datos.setearParametro("@contrasenia", usuario.contrasenia);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                  
                   rol = (int)datos.Lector["Rol"];
                   
                   
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

        public bool ExisteUsuario(string usuarioEntrante)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("select Nombre from USUARIOS where Nombre=@usuario");
            datos.setearParametro("@usuario",usuarioEntrante);
            datos.ejecutarLectura();
            while (datos.Lector.Read())
            {

                return true;


            }

            return false;
          
        }

        public void RegistrarUsuario (Usuario usuario)
        { 
            AccesoDatos datos = new AccesoDatos ();
            
            try
            {
                datos.setearConsulta (@"Insert into usuarios(Nombre, Contrasenia, Rol) VALUES
                                        (@Nombre,  @Contrasenia, @Rol)");

                datos.setearParametro("@Nombre", usuario.nombre);
                datos.setearParametro("@Contrasenia", usuario.contrasenia);
                datos.setearParametro("@Rol", usuario.rol);

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
