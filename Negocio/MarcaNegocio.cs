using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listaMarcas()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Marca> lista = new List<Marca>();
            try
            {
                datos.establecerConsulta("select Id, Descripcion from MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca nueva = new Marca();
                    nueva.Id = (int)datos.Lector["Id"];
                    nueva.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(nueva);
                }
                return lista;
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
        public void agregarMarca(Marca nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.establecerConsulta("insert into MARCAS values ('@Desc')");
                datos.establecerParametros("@Desc", nueva.Descripcion);
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
