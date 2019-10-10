using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV1.Entities
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreCliente  { get; set; }
        public int IdUsuario { get; set; }
        public IList<FacturaDetalle> FacturaDetalle { get; set; }
        public double SubTotal { get; set; }
        public double Descuento { get; set; }
        public double ImporteTotal
        {
            get
            {
                return SubTotal - SubTotal * Descuento / 100;
            }
        }

        public override string ToString()
        {
            return  NroFactura.ToString("0001-00000000");
        }
    }
}
