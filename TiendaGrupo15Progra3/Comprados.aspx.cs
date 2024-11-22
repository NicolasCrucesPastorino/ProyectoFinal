using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGrupo15Progra3
{
    public partial class Comprados : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario =(Usuario) Session["Usuario"];
            VentaService ventaService = new VentaService();
            List<Venta> listaVentasCompradas = new List<Venta>();

            listaVentasCompradas= ventaService.buscarComprado(usuario.idUsuario);


                
        }
    }
}