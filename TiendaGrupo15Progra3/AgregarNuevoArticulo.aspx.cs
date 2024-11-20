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
    public partial class AgregarNuevoArticulo : System.Web.UI.Page
    {   
        public Usuario usuarioAgregarProducto = new Usuario();

        public void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {

                usuarioAgregarProducto = (Usuario)Session["Usuario"];

            }
            else
            {
                usuarioAgregarProducto.nombre = "No se encuentra";
                usuarioAgregarProducto.apellido = "Registrado";
            }

        }

        protected void AgregarProductoNuevo_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                string script = "alert('No se encuentra logueado debe loguearse para agregar producto.'); window.location='Login.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                return;
            }
            usuarioAgregarProducto = (Usuario)Session["Usuario"];

            
            try
            {  
                ArticuloService articuloService =new ArticuloService();
                int CategoriaId,MarcaId;       
                Marca marca = new Marca();
                MarcaService marcaService =new MarcaService();  
                Categoria categoria = new Categoria();
                CategoriaService categoriaService = new CategoriaService();
                Articulo nuevoArticulo = new Articulo
                {
                    Categoria = new Categoria(), // Inicializa la propiedad
                    Marca = new Marca() // Inicializa la propiedad Marca };
                };

                nuevoArticulo.CodigoArticulo=CodigoArticuloTxt.Text.Trim();
                nuevoArticulo.Nombre=nombreArtTxt.Text.Trim();
                nuevoArticulo.Descripcion = DescripcionTxt.Text.Trim();
                
                categoria.Descripcion=TxtCategoria.Text.Trim();
                marca.Descripcion=TxtMarca.Text.Trim();

                nuevoArticulo.Precio = decimal.Parse(PrecioTxt.Text.Trim());
                nuevoArticulo.Stock=int.Parse(txtStock.Text.Trim());
                nuevoArticulo.IdUsuario = usuarioAgregarProducto.idUsuario;
                

                CategoriaId=categoriaService.BuscarCategoria(categoria.Descripcion);
                MarcaId=marcaService.BuscarMarca(marca.Descripcion);

                if (CategoriaId != 0)
                {
                    categoriaService.AgregarCategoriaNueva(categoria.Descripcion);
                    
                    nuevoArticulo.Categoria.Id = categoriaService.BuscarCategoria(categoria.Descripcion);
                   
                } 
                else
                {
                    nuevoArticulo.Categoria.Id = CategoriaId;
                }
                if (MarcaId != 0)
                {
                    marcaService.AgregarMarcaNueva(marca.Descripcion);

                    nuevoArticulo.Marca.Id = marcaService.BuscarMarca(marca.Descripcion);

                }
                else
                {
                    nuevoArticulo.Marca.Id = MarcaId;
                }

                articuloService.AgregarArticulo(nuevoArticulo);
                fGlobales.MostrarAlerta(this, "Articulo con nombre " + nuevoArticulo.Nombre + " agregado con exito.");



            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar un nuevo producto:"+ ex.Message);
            }
        }
    }
}