using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class GestionArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio datosArticulo = new ArticuloNegocio();
                Session.Add("listaArticulos", datosArticulo.listarArticulos());
                gvArticulos.DataSource = Session["listaArticulos"];
                gvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvArticulos_SelectedIndexChanged(object sender,EventArgs e)
        {
            int indice = ((GridView)sender).SelectedIndex;
            string id = ((List<Articulo>)((GridView)sender).DataSource)[indice].Id.ToString();
            Response.Redirect("VistaDetalle.aspx?id=" + id);
        }
        protected void gvArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int indice = e.RowIndex;
            int id = ((List<Articulo>)((GridView)sender).DataSource)[indice].Id;

            // colocar una confimacion antes de eliminar

            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            articuloNegocio.eliminarArticulo(id);
        }
    }
}