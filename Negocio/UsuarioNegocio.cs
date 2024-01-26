using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool login(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.establecerConsulta("Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where email = @email and pass = @pass");
                datos.establecerParametros("@email", user.Email);
                datos.establecerParametros("@pass", user.Contraseña);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["Id"];
                    user.Email = (string)datos.Lector["email"];
                    user.Contraseña = (string)datos.Lector["pass"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        user.Imagen = (string)datos.Lector["urlImagenPerfil"];
                    user.Admin = (bool)datos.Lector["admin"];

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool validarNuevoUsuario(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.establecerConsulta("Select email from USERS where email = @email");
                datos.establecerParametros("@email", email);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool signin(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // VERIFICAMOS QUE NO EXISTA EL EMAIL
                datos.establecerConsulta("Select email from USERS where email = @email");
                datos.establecerParametros("@email", nuevo.Email);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    return false;
                }
                // SI NO EXISTE EL EMAIL CARGAMOS NUEVO EMAIL Y CONTRASEÑA
                datos.establecerConsulta("insert into USERS (email,pass) values (@email,@pass)");
                datos.establecerParametros("@email",nuevo.Email);
                datos.establecerParametros("@pass", nuevo.Contraseña);
                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
