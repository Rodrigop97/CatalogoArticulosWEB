using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Maestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txbBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbBusqueda.Text))
            {
                Response.Redirect("Catalogo.aspx?busqueda=" + txbBusqueda.Text);
                txbBusqueda.Text = "";
            }
        }
    }
}