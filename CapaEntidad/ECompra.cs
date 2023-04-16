using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ECompra
    {
        public int id_detalle_compra { get; set; }
        public string codigo_producto { get; set; }
        public int id_proveedor { get; set; }
        public int cantidad { get; set; }
        public int id_compra { get; set; }
        public double subTotal { get; set; }
        public double total { get; set; }
        public string fecha { get; set; }
        public string comprobante_compra { get;set; }
        

    }
}
