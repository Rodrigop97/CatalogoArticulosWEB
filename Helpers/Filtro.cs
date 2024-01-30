using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Helpers
{
    public static class Filtro
    {
        public static List<Articulo> busquedaRapida (List<Articulo> lista, string busqueda = null)
        {
            if (string.IsNullOrEmpty(busqueda))
                return lista;
            else
                return lista.FindAll(
                    x => x.Nombre.ToUpper().Contains(busqueda.ToUpper()) ||
                    x.Marca.Descripcion.ToUpper().Contains(busqueda.ToUpper()) ||
                    x.Categoria.Descripcion.ToUpper().Contains(busqueda.ToUpper()) );
        }
        public static List<Articulo> filtroAvanzado(List<Articulo> lista, string categoria ,List<string> marca , string max , string min )
        {
            List<Articulo> listaFiltrada;

            if (categoria != null)
                listaFiltrada = lista.FindAll(x => x.Categoria.Descripcion == categoria);
            else
                listaFiltrada = lista;
            if (marca != null)
            {
                List<Articulo> aux = new List<Articulo>();
                foreach (string item in marca)
                    aux = aux.Concat(listaFiltrada.FindAll(x => x.Marca.Descripcion == item)).ToList();
                listaFiltrada = aux;
            }
            if (!string.IsNullOrEmpty(max))
                listaFiltrada = listaFiltrada.FindAll(x => x.Precio < decimal.Parse(max));
            if (!string.IsNullOrEmpty(min))
                listaFiltrada = listaFiltrada.FindAll(x => x.Precio > decimal.Parse(min));
            return listaFiltrada;
        }
    }
}
