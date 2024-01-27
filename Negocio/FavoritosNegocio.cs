using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FavoritosNegocio
    {
        public List<int> listarArticulosFavoritos(int idUser)
        {
            List<int> listaIdArticulos = new List<int>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.establecerConsulta("select IdArticulo from FAVORITOS where IdUser = @idUser");
                datos.establecerParametros("@idUser", idUser);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    listaIdArticulos.Add((int)datos.Lector["IdArticulo"]);
                }
                return listaIdArticulos;
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
        public void quitarFavorito(int idUser, int idArt)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.establecerConsulta("delete from FAVORITOS where IdUser = @idUser and IdArticulo = @idArt");
                datos.establecerParametros("@idUser", idUser);
                datos.establecerParametros("@idArt", idArt);
                datos.ejecutarAccion();
            }
            catch (Exception ex )
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregarFavorito(int idUser, int idArt)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.establecerConsulta("insert into FAVORITOS values (@idUser,@idArt)");
                datos.establecerParametros("@idUser", idUser);
                datos.establecerParametros("@idArt", idArt);
                datos.ejecutarAccion();
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
