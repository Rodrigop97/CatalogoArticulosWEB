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
    public partial class VistaDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se supone que solo se accede con un id de articulo, sino, hay que cambiar el "try catch"
            if(Request.QueryString["Id"] != null)
            {
                Articulo seleccionado = ((List<Articulo>)Session["listaArticulos"]).Find(x => x.Id == int.Parse(Request.QueryString["Id"]));
                txtNombre.InnerText = seleccionado.Nombre;
                txtDescripcion.InnerText = seleccionado.Descripcion;
                txtPrecio.InnerText = "$ " + seleccionado.Precio.ToString();
                imgArticulo.Src = seleccionado.Imagen;
            }
        }
    }
}