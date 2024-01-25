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
            if (!IsPostBack)
            {
                ArticuloNegocio datosArticulos = new ArticuloNegocio();
                MarcaNegocio datosMarcas = new MarcaNegocio();
                CategoriaNegocio datosCategorias = new CategoriaNegocio();
                Session.Add("listaArticulos", datosArticulos.listarArticulos());
                repArticulos.DataSource = Session["listaArticulos"];
                repArticulos.DataBind();
                

                cblMarca.DataSource = datosMarcas.listaMarcas();
                cblMarca.DataBind();

                List<Categoria> listaCategoria = datosCategorias.listaCategoria();
                listaCategoria.Insert(0,new Categoria { Id = -1, Descripcion = "Todos" });
                rblCategoria.DataSource = listaCategoria;
                rblCategoria.DataBind();
                ((RadioButtonList)rblCategoria).Items[0].Selected = true;
            }
            if (Request.QueryString["busqueda"] != null)
            {
                busquedaArticulo(Request.QueryString["busqueda"]);
            }
        }
        protected void ejecutarFiltros()
        {
            List<Articulo> listaFiltrada;

            if (Session["filtroCategoria"] != null)
                listaFiltrada = ((List<Articulo>)Session["listaArticulos"]).FindAll(x => x.Categoria.Descripcion == (string)Session["filtroCategoria"]);
            else
                listaFiltrada = (List<Articulo>)Session["listaArticulos"];
            if (Session["filtroMarca"] != null)
            {
                List<Articulo> aux = new List<Articulo>();
                foreach (string item in (List<string>)Session["filtroMarca"])
                    aux = aux.Concat(listaFiltrada.FindAll(x => x.Marca.Descripcion == item)).ToList();
                listaFiltrada = aux;
            }
            if (!string.IsNullOrEmpty(precioMax.Text))
                listaFiltrada = listaFiltrada.FindAll(x => x.Precio < decimal.Parse(precioMax.Text));
            if (!string.IsNullOrEmpty(precioMin.Text))
                listaFiltrada = listaFiltrada.FindAll(x => x.Precio > decimal.Parse(precioMin.Text));
            repArticulos.DataSource = listaFiltrada;
            repArticulos.DataBind();
        }

        protected void rango_Click(object sender, EventArgs e)
        {
            ejecutarFiltros();
        }

        protected void rblCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((RadioButtonList)sender).SelectedItem.Text == "Todos")
                Session.Remove("filtroCategoria");
            else
                Session["filtroCategoria"] = ((RadioButtonList)sender).SelectedItem.Text;
            ejecutarFiltros();
        }

        protected void cblMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((CheckBoxList)sender).SelectedIndex == -1)
                Session.Remove("filtroMarca");
            else
            {
                Session["filtroMarca"] = new List<string>();
                foreach (ListItem item in ((CheckBoxList)sender).Items)
                    if (item.Selected)
                    {
                        ((List<string>)Session["filtroMarca"]).Add(item.Text);
                    }

            }
            ejecutarFiltros();
        }
        protected void busquedaArticulo(string busqueda)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            listaFiltrada = ((List<Articulo>)Session["listaArticulos"]).FindAll
                (x => x.Nombre.ToUpper().Contains(busqueda.ToUpper()) ||
                x.Marca.Descripcion.ToUpper().Contains(busqueda.ToUpper()) || 
                x.Categoria.Descripcion.ToUpper().Contains(busqueda.ToUpper()));
            repArticulos.DataSource = listaFiltrada;
            repArticulos.DataBind();
        }
    }
}