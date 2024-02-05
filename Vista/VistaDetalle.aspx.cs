using Dominio;
using Microsoft.SqlServer.Server;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class VistaDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
                if (Request.QueryString["id"] != null )
                {
                    try
                    {
                        Session.Add("idActual", Request.QueryString["id"]);

                        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                        if (Session["listaArticulos"] == null)
                            Session.Add("listaArticulos", articuloNegocio.listarArticulos());
                        Articulo seleccionado = ((List<Articulo>)Session["listaArticulos"]).Find(x => x.Id == int.Parse(Request.QueryString["id"]));
                        txtNombre.InnerText = seleccionado.Nombre;
                        txtDescripcion.InnerText = seleccionado.Descripcion;
                        txtPrecio.InnerText = "$ " + seleccionado.Precio.ToString();
                        txtMarca.InnerText = seleccionado.Marca.Descripcion;
                        txtCategoria.InnerText = seleccionado.Categoria.Descripcion;
                        imgArticulo.Src = seleccionado.Imagen;
                    }
                    catch (Exception ex)
                    {
                        Session.Add("error", ex.ToString());
                        Response.Redirect("Error.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Catalogo.aspx");
                }
        }

        protected void favoritos_Click(object sender, EventArgs e)
        {
            try
            {
                FavoritosNegocio favoritosNegocio = new FavoritosNegocio();
                int idUsuario = ((Usuario)Session["usuario"]).Id;
                int idArticulo = int.Parse((string)Session["idActual"]);
                favoritosNegocio.agregarFavorito(idUsuario, idArticulo);
                Session.Add("favoritos", favoritosNegocio.listarArticulosFavoritos(idUsuario));
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void quitarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                FavoritosNegocio favoritosNegocio = new FavoritosNegocio();
                int idUsuario = ((Usuario)Session["usuario"]).Id;
                int idArticulo = int.Parse((string)Session["idActual"]);
                favoritosNegocio.quitarFavorito(idUsuario, idArticulo);
                Session.Add("favoritos", favoritosNegocio.listarArticulosFavoritos(idUsuario));
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}