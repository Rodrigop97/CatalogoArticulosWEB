using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Vista
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio datos = new ArticuloNegocio();
            repRepetidor.DataSource = datos.listarArticulos();
            repRepetidor.DataBind();
            
        }
    }
}