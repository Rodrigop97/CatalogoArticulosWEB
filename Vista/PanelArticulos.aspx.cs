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
    public partial class PanelArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null && ((Usuario)Session["usuario"]).Admin)
            {
                if (!IsPostBack)
                    if (Request.QueryString["id"] == null)
                        Response.Redirect("Catalogo.aspx");
                    else
                    {
                        try
                        {
                            // se guarda el id para que no se pueda alterar el articulo desde el link
                            Session.Add("idActual", Request.QueryString["id"].ToString()); 
            
                            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                            if (Session["listaArticulos"] == null)
                                Session.Add("listaArticulos", articuloNegocio.listarArticulos());
            
                            MarcaNegocio marcaNegocio = new MarcaNegocio();
                            ddlMarca.DataSource = marcaNegocio.listaMarcas();
                            ddlMarca.DataValueField = "Id";
                            ddlMarca.DataTextField = "Descripcion";
                            ddlMarca.DataBind();
            
                            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                            ddlCategoria.DataSource = categoriaNegocio.listaCategoria();
                            ddlCategoria.DataValueField = "Id";
                            ddlCategoria.DataTextField = "Descripcion";
                            ddlCategoria.DataBind();
            
                            if (int.Parse(Request.QueryString["id"]) != -1)
                            {
                                Articulo seleccionado = ((List<Articulo>)Session["listaArticulos"]).Find(x => x.Id == int.Parse(Request.QueryString["id"]));
                                txbCodigo.Text = seleccionado.Codigo;
                                txbNombre.Text = seleccionado.Nombre;
                                txbDescripcion.Text = seleccionado.Descripcion;
                                txbPrecio.Text = seleccionado.Precio.ToString();
                                ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                                ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                                imgArticulo.Src = seleccionado.Imagen;
            
                                titulo.InnerText = "Modificar articulo";
                            }
                            else
                                titulo.InnerText = "Nuevo articulo";
                        }
                        catch (Exception ex)
                        {
                            Session.Add("error", ex.ToString());
                            Response.Redirect("Error.aspx");
                        }
                    }
            }
            else
            {
                Session.Add("error", "No tiene permisos para acceder a esta pagina.");
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo seleccionado;
                if (int.Parse((string)Session["idActual"]) == -1)
                    seleccionado = new Articulo();
                else
                    seleccionado = ((List<Articulo>)Session["listaArticulos"]).Find(x => x.Id == int.Parse(Request.QueryString["id"]));

                seleccionado.Codigo = txbCodigo.Text;
                seleccionado.Nombre = txbNombre.Text;
                seleccionado.Descripcion = txbDescripcion.Text;
                seleccionado.Precio = Decimal.Parse(txbPrecio.Text);
                seleccionado.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                seleccionado.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (sImg.Value == "local")
                {
                    if (!string.IsNullOrEmpty(imgLocal.Value))
                    {
                        string rutaImg = Server.MapPath("./img/admin/articulos/");
                        imgLocal.PostedFile.SaveAs(rutaImg + seleccionado.Codigo + "-img.png");
                        seleccionado.Imagen = "/img/admin/articulos/" + seleccionado.Codigo + "-img.png";
                    }
                }
                else if (!string.IsNullOrEmpty(imgInternet.Value))
                    seleccionado.Imagen = imgInternet.Value;

                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                articuloNegocio.actualizarArticulo(seleccionado);
                Session.Add("listaArticulos", articuloNegocio.listarArticulos());
                Response.Redirect("GestionArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnArgergar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                nuevo.Codigo = txbCodigo.Text;
                nuevo.Nombre = txbNombre.Text;
                nuevo.Descripcion = txbDescripcion.Text;
                nuevo.Precio = Decimal.Parse(txbPrecio.Text);
                nuevo.Marca = new Marca { Id = int.Parse(ddlMarca.SelectedValue) };
                nuevo.Categoria = new Categoria { Id = int.Parse(ddlCategoria.SelectedValue) };

                if (sImg.Value == "local")
                {
                    if (!string.IsNullOrEmpty(imgLocal.Value))
                    {
                        string rutaImg = Server.MapPath("./img/admin/articulos/");
                        imgLocal.PostedFile.SaveAs(rutaImg + nuevo.Codigo + "-img.png");
                        nuevo.Imagen = "/img/admin/articulos/" + nuevo.Codigo + "-img.png";
                    }
                }
                else if (!string.IsNullOrEmpty(imgInternet.Value))
                    nuevo.Imagen = imgInternet.Value;

                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                articuloNegocio.agregarArticulo(nuevo);
                Session.Add("listaArticulos", articuloNegocio.listarArticulos());
                Response.Redirect("GestionArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                articuloNegocio.eliminarArticulo(int.Parse((string)Session["idActual"]));
                Session.Add("listaArticulos", articuloNegocio.listarArticulos());
                Response.Redirect("GestionArticulos.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}