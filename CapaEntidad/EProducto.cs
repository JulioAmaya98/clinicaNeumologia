using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EProducto
    {
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public int stock { get; set; }
        public string fecha_ingreso { get; set; }
        public string fecha_vencimiento { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
    }
}
