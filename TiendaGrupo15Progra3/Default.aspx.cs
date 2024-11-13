using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGrupo15Progra3
{
    public partial class Default : System.Web.UI.Page
    {
        public int RolDefault;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Rol"] != null)
                {
                    RolDefault = int.Parse(Session["Rol"].ToString());
                }
               else
                {
                    RolDefault = 0;
                }
            }
            catch(Exception ex)
            {
                fGlobales.MostrarAlerta(this, "ERROR IFELSE");
            }
            
        }

        protected void btnParticipa_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ElegirProducto.aspx");
        }
    }
}