using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EInventario
    {
        public int id_inventario { get; set; }
        public string codigo_producto { get; set; }
        public int id_proveedor { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha_entrada { get; set; }
		public DateTime fecha_vencimiento { get; set; }
		public string ubicacion { get; set; }
        public int lote { get; set; }
    }
}
