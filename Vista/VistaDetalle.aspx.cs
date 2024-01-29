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
            if (Request.QueryString["id"] != null)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                if (Session["listaArticulos"] == null)
                    Session.Add("listaArticulos", articuloNegocio.listarArticulos());
                // Se supone que solo se accede con un id de articulo, sino, hay que cambiar el "try catch"
                Articulo seleccionado = ((List<Articulo>)Session["listaArticulos"]).Find(x => x.Id == int.Parse(Request.QueryString["id"]));
                if (((Usuario)Session["usuario"]).Admin)
                {
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    ddlMarca.DataSource = marcaNegocio.listaMarcas();
                    ddlMarca.DataBind();
                    ddlCategoria.DataSource = categoriaNegocio.listaCategoria();
                    ddlCategoria.DataBind();

                    txbNombre.Text = seleccionado.Nombre;
                    txbDescripcion.Text = seleccionado.Descripcion;
                    txbPrecio.Text = seleccionado.Precio.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Descripcion;
                    ddlMarca.SelectedValue = seleccionado.Marca.Descripcion;
                }
                else
                {
                    txtNombre.InnerText = seleccionado.Nombre;
                    txtDescripcion.InnerText = seleccionado.Descripcion;
                    txtPrecio.InnerText = "$ " + seleccionado.Precio.ToString();
                }
                imgArticulo.Src = seleccionado.Imagen;
            }
            else
            {
                Response.Redirect("Catalogo.aspx");
            }
        }

        protected void guardar_Click(object sender, EventArgs e)
        {

        }

        protected void favoritos_Click(object sender, EventArgs e)
        {

        }
    }
}