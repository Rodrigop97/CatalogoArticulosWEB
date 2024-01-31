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
        public static List<Articulo> filtroAvanzado(List<Articulo> lista, int categoria ,List<int> marca , string max , string min )
        {
            List<Articulo> listaFiltrada;

            if (categoria != -1)
                listaFiltrada = lista.FindAll(x => x.Categoria.Id == categoria);
            else
                listaFiltrada = lista;
            if (marca != null )
            {
                List<Articulo> aux = new List<Articulo>();
                foreach (int item in marca)
                    aux = aux.Concat(listaFiltrada.FindAll(x => x.Marca.Id == item)).ToList();
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
