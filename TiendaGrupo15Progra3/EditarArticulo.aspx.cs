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
    public partial class EditarArticulo : System.Web.UI.Page
    {
        protected Articulo articulo { get; set; }
        protected ArticuloService articuloService { get; set; }

        public string IdArticulo { get; set; }
        public Usuario UsuarioModificarArticulo = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Session["DebeLoguearse"] = true;
                Response.Redirect("Login.aspx");
            }
            else
            {
                articuloService = new ArticuloService();
                articulo = new Articulo();

                UsuarioModificarArticulo = (Usuario)Session["Usuario"];
                IdArticulo = Session["Id"].ToString();
            }

            if (!IsPostBack)
            {
                try
                {
                    if (CompletarArticulo() != null)
                    {
                        RellenarCamposArticulo();

                    }

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }


        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            actualizarArticulo();
        }

        protected Articulo CompletarArticulo()
        {
            Articulo aux = new Articulo();

            try
            {
                int idArticulo;


                if (int.TryParse(IdArticulo, out idArticulo) && idArticulo != 0)
                {
                    aux = articuloService.listarXid(int.Parse(IdArticulo));

                    return aux;
                }

                else { return null; }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void RellenarCamposArticulo()
        {
            articulo = CompletarArticulo();

            try
            {
                if (articulo != null)
                {
                    nombreArtTxt.Text = articulo.Nombre;
                    TxtCategoria.Text = articulo.Categoria.Descripcion;
                    TxtMarca.Text = articulo.Marca.Descripcion;
                    CodigoArticuloTxt.Text = articulo.CodigoArticulo;
                    DescripcionTxt.Text = articulo.Descripcion;
                    PrecioTxt.Text = articulo.Precio.ToString();
                    txtStock.Text = articulo.Stock.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        protected void cambiosENcampos()
        {
            
        }

        protected void actualizarArticulo()
        {
            try
            {
                int idArticulo;


                if (int.TryParse(IdArticulo, out idArticulo) && idArticulo != 0)
                {

                    articuloService.ModificarArticulo(int.Parse(IdArticulo), articulo);

                }
            }
            catch (Exception)
            {

                throw;
            }           
        }
    }
}
