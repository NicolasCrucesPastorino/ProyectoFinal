using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TiendaGrupo15Progra3
{
    public partial class DetalleProducto : System.Web.UI.Page
    {   public Articulo articuloDetalle = new Articulo();
        public int Rol {  get; set; }

        public void Page_Load(object sender, EventArgs e)
        {

            ArticuloService articuloService = new ArticuloService();
            ImagenService imagenService = new ImagenService();
            

            int idArticulo = int.Parse(Request.QueryString["idDetalle"]);

            articuloDetalle = articuloService.listarXid(idArticulo);

            articuloDetalle.Imagenes = imagenService.listarPorIdArticulo(idArticulo);

            if (Session["Rol"] != null)
            {
            string rolString = Session["Rol"].ToString();
            Rol = int.Parse(rolString);
            }
            
            

        }
    }
    }