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
                gvArticulos.DataSource = datosArticulo.listarArticulos();
                gvArticulos.DataBind();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void gvArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


        }
    }
}