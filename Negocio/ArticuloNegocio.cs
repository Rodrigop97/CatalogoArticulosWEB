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

                    //articuloAux.Imagen = (string)datos.Lector["ImagenUrl"];
                    articuloAux.Imagen = (Convert.IsDBNull(datos.Lector["ImagenUrl"]) ? string.Empty : (string)datos.Lector["ImagenUrl"]);
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
        public void eliminarArticulo(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.establecerConsulta("Delete from ARTICULOS where Id = @id");
                datos.establecerParametros("@id", id);
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
        public void actualizarArticulo(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //Consulta completa datos.establecerConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @img, Precio = @precio");
                datos.establecerConsulta("update ARTICULOS set Nombre = @nombre, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @img, Precio = @precio where Id = @id");
                datos.establecerParametros("@id", articulo.Id);
                datos.establecerParametros("@codigo", (object)articulo.Codigo ?? DBNull.Value);
                datos.establecerParametros("@nombre", (object)articulo.Nombre ?? DBNull.Value);
                datos.establecerParametros("@desc", (object)articulo.Descripcion ?? DBNull.Value);
                datos.establecerParametros("@idMarca", (object)articulo.Marca.Id ?? DBNull.Value);
                datos.establecerParametros("@idCategoria", (object)articulo.Categoria.Id ?? DBNull.Value);
                datos.establecerParametros("@img", (object)articulo.Imagen ?? DBNull.Value);
                datos.establecerParametros("@precio", (object)articulo.Precio ?? DBNull.Value);
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
        public void agregarArticulo(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.establecerConsulta("insert into ARTICULOS values(@codigo, @nombre, @desc, @idMarca, @idCategoria, @img, @precio)");
                datos.establecerParametros("@codigo", (object)nuevo.Codigo ?? DBNull.Value);
                datos.establecerParametros("@nombre", (object)nuevo.Nombre ?? DBNull.Value);
                datos.establecerParametros("@desc", (object)nuevo.Descripcion ?? DBNull.Value);
                datos.establecerParametros("@idMarca", (object)nuevo.Marca.Id ?? DBNull.Value);
                datos.establecerParametros("@idCategoria", (object)nuevo.Categoria.Id ?? DBNull.Value);
                datos.establecerParametros("@img", (object)nuevo.Imagen ?? DBNull.Value);
                datos.establecerParametros("@precio", (object)nuevo.Precio ?? DBNull.Value);
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
