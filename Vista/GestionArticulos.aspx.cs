using Dominio;
using Helpers;
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
            if (!IsPostBack)
            {
                try
                {
                    // PRUEBA DE PAGINA --------------------------->
                    Usuario adimn = new Usuario();
                    adimn.Nombre = "Rodrigo";
                    adimn.Apellido = "Peralta";
                    adimn.Email = "ad@ad.com";
                    adimn.Contraseña = "1234";
                    adimn.Admin = true;
                    Session.Add("usuario", adimn);
                    //----------------------------------------------------------- > 
                    ArticuloNegocio datosArticulo = new ArticuloNegocio();
                    CategoriaNegocio datosCategoria = new CategoriaNegocio();
                    MarcaNegocio datosMarca = new MarcaNegocio();

                    if (Session["listaArticulos"] == null)
                        Session.Add("listaArticulos", datosArticulo.listarArticulos());
                    gvArticulos.DataSource = Session["listaArticulos"];
                    gvArticulos.DataBind();

                    List<Categoria> listCategoria = datosCategoria.listaCategoria();
                    listCategoria.Insert(0,new Categoria {Id=-1 });
                    ddlCategoria.DataSource = listCategoria;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    List<Marca> listMarca = datosMarca.listaMarcas();
                    listMarca.Insert(0, new Marca { Id = -1});
                    ddlMarca.DataSource = listMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
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

        protected void salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx");
        }

        protected void agregarNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            // Tomo el ID de la categoria seleccionada
            int idFiltroCategoria = int.Parse(ddlCategoria.SelectedItem.Value);
            // Tomo los ID de los filtro de marca
            List<int> idFiltroMarca = (int.Parse(ddlMarca.SelectedValue) != -1)
                ? new List<int> { int.Parse(ddlMarca.SelectedValue) }
                : null;
            // Tomo el valor de max y min de precio
            string precioMax = txbPrecioMax.Text;
            string precioMin = txbPrecioMin.Text;

            gvArticulos.DataSource = Filtro.filtroAvanzado
                (
                (List<Articulo>)Session["listaArticulos"],
                idFiltroCategoria,
                idFiltroMarca,
                precioMax,
                precioMin
                );
            gvArticulos.DataBind();
        }
        protected void busquedaRapida_Click(object sender, EventArgs e)
        {
            gvArticulos.DataSource = Filtro.busquedaRapida((List<Articulo>)Session["listaArticulos"], txbBusquedaRapida.Text);
            gvArticulos.DataBind();
        }
        
    }
}