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
            Articulo articulo = new Articulo();
            List<int> listaStock = new List<int>();
            

            int idArticulo = int.Parse(Request.QueryString["idDetalle"]);

            articuloDetalle = articuloService.listarXid(idArticulo);

            articuloDetalle.Imagenes = imagenService.listarPorIdArticulo(idArticulo);

            if (Session["Rol"] != null)
            {
            string rolString = Session["Rol"].ToString();
            Rol = int.Parse(rolString);
            }

            articulo=articuloService.listarXid(articuloDetalle.Id);


            if (!IsPostBack)
            {
                for (int i = 0; i < articuloDetalle.Stock; i++)
                {
                    listaStock.Add(i + 1);

                }

                DropDownListAgregarCarrito.DataSource = listaStock;
                DropDownListAgregarCarrito.DataBind();
                DropDownListAgregarCarrito.SelectedIndex = 0;
            }



            }

        protected void BtnLoguearseDesdeDetalleProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void BtnEliminarProdAdmin_Click(object sender, EventArgs e)
        {
            ImagenService imagenService = new ImagenService();
            ArticuloService articuloService = new ArticuloService();
            int idArticulo = int.Parse(Request.QueryString["idDetalle"]);

            imagenService.EliminarPorIdImagen(idArticulo);
            articuloService.EliminarArticuloPorId(idArticulo);

            fGlobales.MostrarAlerta(this, "Se ha eliminado el articulo del mercado.");
            Response.Redirect("ElegirProducto.aspx");

        }

        protected void BtnAgregarAlCarrito_Click(object sender, EventArgs e)
        {   
             CarritoService carritoService = new CarritoService();
            Usuario usuario = new Usuario();
            int cantidadParaCarrito;
            cantidadParaCarrito=int.Parse(DropDownListAgregarCarrito.SelectedValue);
            usuario=(Usuario)Session["Usuario"];

            int idProductoParaCarrito = articuloDetalle.Id;


            carritoService.GuardarEnCarritoArticulo(usuario.idUsuario, idProductoParaCarrito, cantidadParaCarrito);

           
        }
    }
    }