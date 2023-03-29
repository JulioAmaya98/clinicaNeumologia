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
    public class NInventario
    {
        Inventario productos = new Inventario();

        public DataTable mostrarProduct()
        {
            DataTable tablaproducto = new DataTable();
            tablaproducto = productos.mostraProducto();
            return tablaproducto;
        }

        public void agregarProductos(EInventario eProducto)
        {
            productos.addProducto_Inventario(eProducto);
        }

        public DataTable editarInventarioByID(EInventario inventario)
        {
            DataTable tabla = new DataTable();
            tabla = productos.editarInventarioByID(inventario);
            return tabla;
        }

        public void editarInventario(EInventario inventario)
        {
            productos.editarInventario(inventario);
        }

        public bool eliminarInventario(EInventario inventario)
        {
            return productos.eliminar(inventario);
        }
	}
}
