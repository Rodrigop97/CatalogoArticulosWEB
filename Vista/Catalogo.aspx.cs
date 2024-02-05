using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Helpers;
using System.Web.DynamicData;


namespace Vista
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                ArticuloNegocio datosArticulos = new ArticuloNegocio();
                MarcaNegocio datosMarcas = new MarcaNegocio();
                CategoriaNegocio datosCategorias = new CategoriaNegocio();
                Session.Add("listaArticulos", datosArticulos.listarArticulos());

                //repArticulos.DataSource = Session["listaArticulos"];
                repArticulos.DataSource = Request.QueryString["favoritos"] == null ? 
                    Session["listaArticulos"] // --> Si no se solicito ver a los favoritos 
                    : datosArticulos.listarArticulos().Where
                    (
                        art => ((List<int>)Session["favoritos"]).Contains(art.Id) // --> Si se solicito ver a los favoritos, se filtran
                    ).ToList();
                repArticulos.DataBind();

                cblMarca.DataSource = datosMarcas.listaMarcas();
                cblMarca.DataValueField = "Id";
                cblMarca.DataTextField = "Descripcion";
                cblMarca.DataBind();

                List<Categoria> listaCategoria = datosCategorias.listaCategoria();
                listaCategoria.Insert(0,new Categoria { Id = -1, Descripcion = "Todos" });
                rblCategoria.DataSource = listaCategoria;
                rblCategoria.DataValueField = "Id";
                rblCategoria.DataTextField = "Descripcion";
                rblCategoria.DataBind();
                ((RadioButtonList)rblCategoria).Items[0].Selected = true;
                }
                catch (Exception ex)
                {
                    Session.Add("error",ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }
            if (Request.QueryString["busqueda"] != null)
            {
                busquedaArticulo(Request.QueryString["busqueda"]);
            }
        }
        protected void ejecutarFiltros(object sender, EventArgs e)
        {
            try
            {
                // Tomo el ID de la categoria seleccionada
                int idFiltroCategoria = int.Parse(rblCategoria.SelectedItem.Value);
                // Tomo los ID de los filtro de marca
                List<int> idFiltroMarca = new List<int>();
                foreach (var item in cblMarca.Items)
                    if (((ListItem)item).Selected)
                        idFiltroMarca.Add(int.Parse(((ListItem)item).Value));
                if (idFiltroMarca.Count == 0)
                    idFiltroMarca = null;
                // Tomo el valor de max y min de precio
                string precioMax = txbPrecioMax.Text;
                string precioMin = txbPrecioMin.Text;

                repArticulos.DataSource = Filtro.filtroAvanzado
                    (
                    Request.QueryString["favoritos"] == null ?
                        ((List<Articulo>)Session["listaArticulos"])  // Si se solicito ver el catalogo paso los articulos de la sesion
                        : ((List<Articulo>)Session["listaArticulos"]).Where // Si se solicito ver los favoritos filtro aquellos que lo sean
                        (
                            art => ((List<int>)Session["favoritos"]).Contains(art.Id)
                        ).ToList(),
                    idFiltroCategoria,
                    idFiltroMarca,
                    precioMax,
                    precioMin
                    );
                repArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void busquedaArticulo(string busqueda)
        {
            try
            {
                repArticulos.DataSource = Filtro.busquedaRapida((List<Articulo>)Session["listaArticulos"], busqueda);
                repArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}