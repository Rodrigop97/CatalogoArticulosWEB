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
    public partial class Acceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAcceso_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();
            usuario.Email = txbEmail.Text;
            usuario.Contraseña = txbContraseña.Text;
            usuario.Nombre = txbNombre != null ? txbNombre.Text : null ;
            usuario.Apellido = txbApellido != null ? txbApellido.Text : null;
            //try
            //{

            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            if (Request.QueryString["signin"] == null && usuarioNegocio.login(usuario))
            {
                Session.Add("Usuario",usuario);
                Response.Redirect("Catalogo.aspx");
            }
            else if (Request.QueryString["signin"] != null && usuarioNegocio.signin(usuario))
            {
                Session.Remove("signin");
                Session.Add("Usuario", usuario);
                Response.Redirect("Catalogo.aspx");
            }
            else
            {
                Session.Add("Error", "Usuario o contraseña incorrectos");
                Response.Redirect("Error.aspx");
            }
        }
    }
}