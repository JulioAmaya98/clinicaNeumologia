using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EVentas
    {

        public int id_detalle_ventas { get; set; }
        public string codigo_producto { get; set; }
        public int id_proveedor { get; set; }
        public int cantidad { get; set; }
        public int id_compra { get; set; }
        public double subTotal { get; set; }
        public double total { get; set; }
        public string fecha { get; set; }
        public string comrprobante_venta { get; set; }

        public int id_producto { get; set; }
    }

}
