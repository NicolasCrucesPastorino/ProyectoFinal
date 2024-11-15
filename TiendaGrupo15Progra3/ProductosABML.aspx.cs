using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TiendaGrupo15Progra3
{
    public partial class ProductosABML : System.Web.UI.Page
    {
        public int Rol { get; set; }
        public int Id_Vendedor { get; set; }
        public List<Articulo> ArticulosxVendedor; 

        public void Page_Load(object sender, EventArgs e)
        {
            
            Rol = int.Parse(Session["Rol"].ToString());

            //Id_Vendedor = int.Parse(Session["Rol"].ToString());
            /* cambiar a Id_vendedor cuando se actualice la base de datos*/
            ArticulosxVendedor = Session["ListaArticulosVendedor"] as List<Articulo>;
            



        }
    }
}