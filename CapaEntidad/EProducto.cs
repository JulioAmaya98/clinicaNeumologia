using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
	public class EProducto
	{
		public string codigo_producto { get; set; }
		public string nombre { get; set; }
		public int id_proveedor { get; set; }
		public double precio { get; set; }
		public string descripcion { get; set; }


	}
}
