using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUDProducto
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public double existencia { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }

        public Producto(string nombre, double precio, double existencia, string codigo, string descripcion)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.existencia = existencia;
            this.codigo = codigo;
            this.descripcion = descripcion;
        }

        public Producto(int id, string nombre, double precio, double existencia, string codigo, string descripcion)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.existencia = existencia;
            this.codigo = codigo;
            this.descripcion = descripcion;
        }
    }
}
