using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NCompra
    {
        Compra compra=new Compra();
        public void Insertar(ECompra compras)
        {
            compra.insertar(compras);
        }

        public DataTable Subtotal(ECompra compras)
        {
            DataTable table = new DataTable();
            table=compra.Subtotal(compras);
            return table;
        }

        public bool Comprobante(ECompra compras)
        {
            return compra.Comprobante(compras);
        }

        public bool ExistenciaCompra(ECompra compras)
        {
            return compra.ExistenciaCompra(compras);
        }

        public DataTable MostrarDetalleCompra(ECompra compras)
        {
			DataTable table = new DataTable();
			table = compra.MostarCompra(compras);
			return table;
		}

        public void GuardarCompra(ECompra compras)
        {
            compra.GuardarCompra(compras);
        }

		public DataTable mostrarHistorialCompras()
		{

			DataTable tabla = new DataTable();
			tabla = compra.mostrarHistoryCompras();
			return tabla;
		}
	}
}
