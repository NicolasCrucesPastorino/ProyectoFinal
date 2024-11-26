using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("42d30669a9c2fd", "9e5ca20e6f4f46");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "sandbox.smtp.mailtrap.io";
        }

        public void armarMail(string mailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noResponderTransformaTienda@gmail.com");
            email.To.Add(mailDestino);
            email.Subject = asunto;
            email.Body = cuerpo;
        }

        public bool ExisteMail(string mailusuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearConsulta("select FechaRegistro,Correo from USUARIO where correo=@mailExistente");
                datos.setearParametro("@mailExistente", mailusuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    return true;


                }

                return false;

            }
            catch (Exception ex)
            {

                throw new Exception("Error (UsuarioService) ExisteMail: " + ex.Message); ;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Error enviar mail (EmailService)" + ex.Message);
            }
        }
    }

}
