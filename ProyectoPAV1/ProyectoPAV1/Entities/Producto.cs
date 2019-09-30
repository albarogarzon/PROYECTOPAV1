using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV1.Entities
{
     public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescripciónProducto { get; set; }
        public string StockProducto { get; set; }
        public string PrecioProducto { get; set; }

        public Marca MarcaProducto { get; set; }

        public override string ToString()
        {
            return NombreProducto;
        }
    }
}
