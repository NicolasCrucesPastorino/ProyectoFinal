﻿using Dominio;
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
        public List<ParaRepeter> paraRepeterList = new List<ParaRepeter>();
        public string mensajesAlerta;
        public void AgregarMensajeAlerta(string mensaje)
        {
            mensajesAlerta += mensaje + "\\n";
        }

        public void MostrarAlertas()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + mensajesAlerta + "');", true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                
                Session["loMandamosLogin"] = true;
                Response.Redirect("Login.aspx");

            }


            Usuario usuario =(Usuario) Session["Usuario"];
            VentaService ventaService = new VentaService();
            List<Venta> listaVentasCompradas = new List<Venta>();
            Venta venta = new Venta();
            DetalleVenta detalleVenta = new DetalleVenta();
            DetalleVentaService detalleVentaService = new DetalleVentaService();
            
           
            
            ArticuloService articuloService = new ArticuloService();

            listaVentasCompradas= ventaService.buscarComprado(usuario.idUsuario);

            foreach(Venta ventaItem in listaVentasCompradas)
            {
                if (detalleVentaService.BuscarPorIdVenta(ventaItem.idVenta) != null)
                {
                detalleVenta= detalleVentaService.BuscarPorIdVenta(ventaItem.idVenta);
                    Articulo articulo = new Articulo();
                    ParaRepeter paraRepeter = new ParaRepeter();
                    articulo = articuloService.listarXid(detalleVenta.idProducto);
                paraRepeter.producto = articulo.Nombre;
                paraRepeter.precio = articulo.Precio;
                paraRepeter.cantidad = detalleVenta.cantidad;
                paraRepeter.Total = detalleVenta.cantidad * articulo.Precio;
                paraRepeterList.Add(paraRepeter);
                }
                

            }
            RepeaterComprado.DataSource = paraRepeterList;
           
            RepeaterComprado.DataBind();



        }
    }
}