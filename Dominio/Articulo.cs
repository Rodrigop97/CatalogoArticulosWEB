using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca{ get; set; }
        public Categoria Categoria { get; set; }
        public string Imagen { get; set; }
        private Decimal precio;
        //public string Nombre
        //{
        //    get { return nombre; }
        //    set
        //    {
        //        if (string.IsNullOrEmpty(value))
        //            throw new Exception("El campo 'Nombre' no puede estar vacio.");
        //        nombre = value;
        //    }
        //}
        public Decimal Precio
        {
            get { return Decimal.Round(precio, 2); }
            set { precio = value; }
        }
    }
}
