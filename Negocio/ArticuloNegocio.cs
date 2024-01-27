using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.establecerConsulta("select ARTICULOS.Id, ARTICULOS.Codigo,ARTICULOS.Nombre,ARTICULOS.Descripcion,ARTICULOS.IdMarca,MARCAS.Descripcion as Marca,ARTICULOS.IdCategoria,CATEGORIAS.Descripcion as Categoria,ARTICULOS.ImagenUrl,ARTICULOS.Precio from ARTICULOS join CATEGORIAS on (CATEGORIAS.Id = ARTICULOS.IdCategoria) join MARCAS on (MARCAS.Id = ARTICULOS.IdMarca)");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo articuloAux = new Articulo();
                    articuloAux.Id = (int)datos.Lector["Id"];
                    articuloAux.Codigo = (string)datos.Lector["Codigo"];
                    articuloAux.Nombre = (string)datos.Lector["Nombre"];
                    articuloAux.Descripcion = (string)datos.Lector["Descripcion"];

                    articuloAux.Marca = new Marca();
                    articuloAux.Marca.Id = (int)datos.Lector["IdMarca"];
                    articuloAux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    articuloAux.Categoria = new Categoria();
                    articuloAux.Categoria.Id = (int)datos.Lector["idCategoria"];
                    articuloAux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    articuloAux.Imagen = (string)datos.Lector["ImagenUrl"];
                    articuloAux.Precio = (Decimal)datos.Lector["Precio"];

                    lista.Add(articuloAux);
                }
                return lista;
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
    }
}
