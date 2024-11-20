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
    public partial class ElijeTuPremio : System.Web.UI.Page
    {
        public List<Articulo> Productos;
        ArticuloService articuloService = new ArticuloService();
        bool FiltradoAvanzado = false;
        

        protected void Page_Load(object sender, EventArgs e)
        {       
            CategoriaService categoriaService = new CategoriaService();
            MarcaService marcaService = new MarcaService();
            List<Categoria> DropDownListCategoriaGlobal = new List<Categoria>();
            List<Marca> DropDownListMarca = new List<Marca>();

            DropDownListCategoriaGlobal = categoriaService.getCategorias();
            DropDownListFiltroAvanzadoCategoria.DataSource = DropDownListCategoriaGlobal;
            DropDownListFiltroAvanzadoCategoria.DataBind();
            DropDownListMarca = marcaService.getMarcas();
            DropDownListFiltroAvanzadoMarca.DataSource = DropDownListMarca;
            DropDownListFiltroAvanzadoMarca.DataBind();
            if(CheckBoxElijeTuProductoBuscar.Checked == true)
            {
                FiltradoAvanzado=true;
            }
            else
            {
                FiltradoAvanzado = false;
            }
            Productos=articuloService.GetArticulos();

        }

        protected void ProductoBoton_Click(object sender, EventArgs e)
        {
           // Response.Redirect("/ElijeTuPremio.aspx?articulo=" + );
            //Session["Articulo"] = 
        }

        protected void CheckBoxElijeTuProductoBuscar_CheckedChanged(object sender, EventArgs e)
        {
            FiltradoAvanzado = !FiltradoAvanzado;
            TextElijeTuProductoBuscar.Enabled = FiltradoAvanzado;
        }
    }
}
public partial class ElegirProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int articuloId;
            if (int.TryParse(Request.QueryString["id"], out articuloId))
            {
                // Aquí deberías obtener el objeto articulo de tu base de datos o lista
                // Ejemplo:
                var articulo = ObtenerArticuloPorId(articuloId);
                if (articulo != null)
                {
                    // Mostrar los detalles del artículo en la página
                    //NombreArticulo.Text = articulo.Nombre;
                    // Otros detalles del artículo...
                }
            }
        }
    }

    public Articulo ObtenerArticuloPorId(int id)
    {
        // Implementa este método para obtener el artículo por ID
        // Puede ser una consulta a la base de datos o una búsqueda en una lista
        
        ArticuloService articuloService = new ArticuloService();
        
        Articulo articulo = new Articulo();
        articulo=articuloService.listarXid(id);
        return articulo; // Ejemplo de objeto de retorno

    }
}
