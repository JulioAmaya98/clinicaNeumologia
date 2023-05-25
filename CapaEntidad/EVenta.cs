using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EVenta
    {
        public int id_venta { get; set; }
        public string comprobante { get; set; }
        public double total { get; set; }
        public DateTime fecha_venta { get; set; }
        public string documnto { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string direccion { get; set; }
    }
}
