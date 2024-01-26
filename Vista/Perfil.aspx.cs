using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Dominio;

namespace Vista
{
    public partial class Default : System.Web.UI.Page
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
                    repArticulos.DataSource = Session["listaArticulos"];
                    repArticulos.DataBind();

                    //cblMarca.DataSource = datosMarcas.listaMarcas();
                    //cblMarca.DataBind();

                    //List<Categoria> listaCategoria = datosCategorias.listaCategoria();
                    //listaCategoria.Insert(0, new Categoria { Id = -1, Descripcion = "Todos" });
                    //rblCategoria.DataSource = listaCategoria;
                    //rblCategoria.DataBind();
                    //((RadioButtonList)rblCategoria).Items[0].Selected = true;
                    Usuario user = (Usuario)Session["usuario"];
                    txbEmail.Text = user.Email;
                    //txbContraseña.Text = user.Contraseña;
                    txbNombre.Text = user.Nombre != null ? user.Nombre : "";
                    txbApellido.Text = user.Apellido != null ? user.Apellido : "";
                    h1Bienvenida.InnerText = user.Nombre != null ? "Bienvenido " + user.Nombre + "!" : "Bienvenido " + user.Email.Split('@')[0];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void iniciarSesion_Click(object sender, EventArgs e)
        {
            
            UsuarioNegocio datosUsuario = new UsuarioNegocio();
            Usuario user = new Usuario();
            //user.Email = txbEmail.Text;
            //user.Contraseña = txbContraseña.Text;
            try
            {
                if (!datosUsuario.login(user))
                {
                    //Response.Redirect("Error.aspx", false);
                }
                else
                {
                    Session.Add("Usuario",user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                
                ((Usuario)Session["usuario"]).Nombre = txbNombre.Text;
                ((Usuario)Session["usuario"]).Apellido = txbApellido.Text;
                //((Usuario)Session["usuario"]).Imagen = txbImagen.Text;
                usuarioNegocio.actualizarDatos((Usuario)Session["usuario"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}