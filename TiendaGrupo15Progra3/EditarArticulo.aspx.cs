using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
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

                if (!IsPostBack)
                {
                    articuloService = new ArticuloService();
                    articulo = new Articulo();

                    UsuarioModificarArticulo = (Usuario)Session["Usuario"];
                    IdArticulo = Session["Id"].ToString();

                    try
                    {
                        if (CompletarArticulo() != null)
                        {
                            PrellenarCamposArticulo();

                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
                else
                {
                    articuloService = new ArticuloService();
                    articulo = new Articulo();

                }
            }
        }


        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {           
            try
            {
                actualizarArticulo();
                             
                lblMessage.Text = "Las caracteristicas del producto han sido actualizadas con exito";
                return;
                    
                
            }
            catch (Exception)
            {

                throw;
            }
            
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

        protected void PrellenarCamposArticulo()
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
        protected bool cambiosENcampos()
        {
            CategoriaService categoriaService = new CategoriaService();
            MarcaService marcaService = new MarcaService();
            Marca marca = new Marca();
            Categoria categoria = new Categoria();
            

            try
            {
                if (validarCamposEntrada())
                {
                    if ((int.TryParse(txtStock.Text, out int stock) &&
                    decimal.TryParse(PrecioTxt.Text, NumberStyles.Any, new CultureInfo("es-ES"), out decimal precio)))
                    {
                        articulo.Nombre = nombreArtTxt.Text;
                        articulo.CodigoArticulo = CodigoArticuloTxt.Text;
                        articulo.Descripcion = DescripcionTxt.Text;
                        articulo.Precio = decimal.Parse(PrecioTxt.Text);
                        articulo.Stock = int.Parse(txtStock.Text);

                        if (categoriaService.BuscarCategoria(TxtCategoria.Text) > 0)
                        {
                           

                            categoria.Id = categoriaService.BuscarCategoria(TxtCategoria.Text);
                            articulo.Categoria.Id = categoria.Id;

                        }
                        else
                        {
                            

                            categoriaService.AgregarCategoriaNueva(TxtCategoria.Text);
                            categoria.Id = categoriaService.BuscarCategoria(TxtCategoria.Text);
                            articulo.Categoria.Id = categoria.Id;
                        }
                        if (marcaService.BuscarMarca(TxtMarca.Text) > 0)
                        {
                            marca = new Marca();
                            articulo=new Articulo();

                            marca.Id = marcaService.BuscarMarca(TxtMarca.Text);
                            articulo.Marca.Id = marca.Id;

                        }
                        else
                        {
                            marca = new Marca();
                            articulo = new Articulo();

                            marcaService.AgregarMarcaNueva(TxtMarca.Text);
                            marca.Id = categoriaService.BuscarCategoria(TxtMarca.Text);
                            articulo.Marca.Id = marca.Id;
                        }

                        return true;
                    }
                    else
                    {
                        lblMessage.Text = "Alguno de los campos no se encuentra en el formato correcto. Recuerde que los precios llevan 2 decimales y el stock siempre es entero";
                        return false;
                    }
                }
                else
                {
                    lblMessage.Text = "Alguno de los campos no se encuentra en el formato correcto.";
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected bool validarCamposEntrada()
        {
            if(Validacion.validaTextoVacio(nombreArtTxt) ||
               Validacion.validaTextoVacio(CodigoArticuloTxt) ||
               Validacion.validaTextoVacio(DescripcionTxt) ||
               Validacion.validaTextoVacio(PrecioTxt) ||
               Validacion.validaTextoVacio(txtStock) ||
               Validacion.validaTextoVacio(TxtCategoria) ||
               Validacion.validaTextoVacio(TxtMarca))   
            {
                lblMessage.Text ="Es obligatorio rellenar todos los campos";
                return false;
            }

                return true;

        }

        protected void actualizarArticulo()
        {
            try
            {
                int idArticulo;


                if (int.TryParse(IdArticulo, out idArticulo) && idArticulo != 0)
                {
                    if (cambiosENcampos())
                    {

                        articuloService.ModificarArticulo(int.Parse(IdArticulo), articulo);

                        return;
                    }

                }

                return;
            }
            catch (Exception)
            {

                throw;
            }           
        }

    }
}
