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
    public partial class Acceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            try
            {
                validarCampos();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();
                usuario.Email = txbEmail.Text;
                usuario.Contraseña = txbContraseña.Text;
                usuario.Nombre = txbNombre != null ? txbNombre.Text : null ;
                usuario.Apellido = txbApellido != null ? txbApellido.Text : null;
                if (usuarioNegocio.login(usuario))
                {
                    Session.Add("usuario",usuario);
                    FavoritosNegocio favoritosNegocio = new FavoritosNegocio();
                    Session.Add("favoritos", favoritosNegocio.listarArticulosFavoritos(usuario.Id));
                    Response.Redirect("Catalogo.aspx",false);
                }
                else
                {
                    Session.Add("Error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void signin_Click(object sender, EventArgs e)
        {
            try
            {
                validarCampos();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();
                usuario.Email = txbEmail.Text;
                usuario.Contraseña = txbContraseña.Text;
                usuario.Nombre = txbNombre != null ? txbNombre.Text : null;
                usuario.Apellido = txbApellido != null ? txbApellido.Text : null;
                if (usuarioNegocio.signin(usuario))
                {
                    Session.Remove("signin");
                    Session.Add("usuario", usuario);
                    Response.Redirect("Catalogo.aspx", false);
                }
                else
                {
                    Session.Add("Error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        private void validarCampos()
        {
            if (Validador.camposVacios(new string []{ txbEmail.Text, txbContraseña.Text }))
                throw new Exception("Los campos Email y contraseña no deben estar vacios");
            if (!Validador.contraseñaValida(txbContraseña.Text))
                throw new Exception("La contraseña ingresada no es valida.\n La contraseña debe tener al menos 4 caracteres");
            if (!Validador.formatoEmail(txbEmail.Text))
                throw new Exception("El formato de Email no es correcto.");
        }
    }
}