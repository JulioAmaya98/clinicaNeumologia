using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data;

namespace CapaNegocio
{

    public class NVentas
    {
        Ventas ObjVentas = new Ventas();


        public DataTable mostrarHistorialVenta()
        {
            DataTable tabla = new DataTable();
            tabla = ObjVentas.mostrarHistorialVenta();
            return tabla;
        }
        public DataTable mostrarProductosBuscados()
        {
            DataTable tabla = new DataTable();
            tabla = ObjVentas.mostrarProductosBuscados();
            return tabla;
        }


        public DataTable mostrarTipoPago()
        {
            DataTable tabla = new DataTable();
            tabla = ObjVentas.mostrarTipoPago();
            return tabla;
        }

        public DataTable mostrarCorrelativo(int tipo)
        {
            DataTable tabla = new DataTable();
            tabla = ObjVentas.correlativoFactura(tipo);
            return tabla;
        }

        public DataTable verProveedor(EVentas ventas)
        {
            DataTable tabla = new DataTable();
            tabla = ObjVentas.verProveedor(ventas);
            return tabla;
        }

        public bool InsertDetalleVenta(EVentas ventas)
        {
            return ObjVentas.InsertDetalleVenta(ventas);
        }

        public DataTable MostrarDetalleVenta(EVentas ventas)
        {
            DataTable tabla = new DataTable();
            tabla = ObjVentas.MostrarDetalleVenta(ventas);
            return tabla;
        }

        public DataTable MostrarSumaSubTotal(EVentas ventas)
        {
            DataTable tabla = new DataTable();
            tabla = ObjVentas.MostrarSumaSubTotal(ventas);
            return tabla;
        }
        public bool InsertVenta(EVenta venta)
        {
            return ObjVentas.InsertVenta(venta);
        }

        public bool EliminarVenta(int id, string comprobante)
        {
            return ObjVentas.EliminarVenta(id, comprobante);
        }
        public DataTable VerDetalleVenta(EVenta venta)
        {
            DataTable table = new DataTable();
            table = ObjVentas.VerDetalleVenta(venta);
            return table;
        }

        public DataTable VerClienteData(EVenta venta)
        {
            DataTable table = new DataTable();
            table = ObjVentas.VerClienteData(venta);
            return table;
        }
    }
}
