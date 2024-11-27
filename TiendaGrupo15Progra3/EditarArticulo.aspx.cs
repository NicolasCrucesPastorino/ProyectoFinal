/*

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
        public Articulo articulo { get; set; }
        public ArticuloService articuloService { get; set; }

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
                    

                }
            }
        }


        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {           
            try
            {
                actualizarArticulo();
                             
                lblMessage.Text = "Las caracteristicas del producto han sido actualizadas con exito";
                
                    
                
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
                    PrecioTxt.Text = Math.Round(articulo.Precio,2).ToString();
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
                        articulo.Precio = Math.Round(precio, 2);
                        articulo.Stock = stock;

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
                            articulo = new Articulo();

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
                int idArticulo=0;
                if (IdArticulo != null  IdArticulo.Length > 0) {
                    idArticulo = int.Parse(IdArticulo);
                }

                if (idArticulo != 0)
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
*/

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
        public Articulo articulo = new Articulo();
        public Articulo articuloNuevo = new Articulo();
        public ArticuloService articuloService = new ArticuloService();

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
                    articuloService = new ArticuloService();
                    IdArticulo = Session["Id"].ToString();


            }
        }


        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarArticulo();

                lblMessage.Text = "Las caracteristicas del producto han sido actualizadas con exito";



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
                    PrecioTxt.Text = Math.Round(articulo.Precio, 2).ToString();
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
                        
                        articuloNuevo.Nombre = nombreArtTxt.Text;
                        articuloNuevo.CodigoArticulo = CodigoArticuloTxt.Text;
                        articuloNuevo.Descripcion = DescripcionTxt.Text;
                        articuloNuevo.Precio = Math.Round(precio, 2);
                        articuloNuevo.Stock = stock;
                        
                        

                        if (categoriaService.BuscarCategoria(TxtCategoria.Text) != 0)
                        {


                            categoria.Id = categoriaService.BuscarCategoria(TxtCategoria.Text);
                            articuloNuevo.Categoria = new Categoria();
                            articuloNuevo.Categoria.Id = categoria.Id;

                        }
                        else
                        {


                            categoriaService.AgregarCategoriaNueva(TxtCategoria.Text);
                            categoria.Id = categoriaService.BuscarCategoria(TxtCategoria.Text);
                            articuloNuevo.Categoria = new Categoria();
                            articuloNuevo.Categoria.Id = categoria.Id;
                        }
                        if (marcaService.BuscarMarca(TxtMarca.Text) != 0)
                        {
                            
                            Marca marcaM= new Marca();

                            marcaM.Id = marcaService.BuscarMarca(TxtMarca.Text);
                            articuloNuevo.Marca = new Marca();
                            articuloNuevo.Marca.Id = marcaM.Id;

                        }
                        else
                        {
                            Marca marcaM = new Marca();
                            articulo = new Articulo();

                            marcaService.AgregarMarcaNueva(TxtMarca.Text);
                            marcaM.Id = categoriaService.BuscarCategoria(TxtMarca.Text);
                            articuloNuevo.Marca = new Marca();
                            articuloNuevo.Id = marcaM.Id;
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
            if (Validacion.validaTextoVacio(nombreArtTxt) ||
               Validacion.validaTextoVacio(CodigoArticuloTxt) ||
               Validacion.validaTextoVacio(DescripcionTxt) ||
               Validacion.validaTextoVacio(PrecioTxt) ||
               Validacion.validaTextoVacio(txtStock) ||
               Validacion.validaTextoVacio(TxtCategoria) ||
               Validacion.validaTextoVacio(TxtMarca))
            {
                lblMessage.Text = "Es obligatorio rellenar todos los campos";
                return false;
            }

            return true;

        }

        protected void actualizarArticulo()
        {
            try
            {
                int idArticulo = 0;
                if (IdArticulo != null ){
                    idArticulo = int.Parse(IdArticulo);
                }

                if (idArticulo != 0)
                {
                    if (cambiosENcampos())
                    {

                        articuloService.ModificarArticulo(int.Parse(IdArticulo), articuloNuevo);

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