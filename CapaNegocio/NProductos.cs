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
    public class NProductos
    {
        Productos productos = new Productos();

        public DataTable mostrarProduct()
        {
            DataTable tablaproducto = new DataTable();
            tablaproducto = productos.mostraProducto();
            return tablaproducto;
        }

        public void agregarProductos(EProducto eProducto)
        {
            productos.addProducto(eProducto);
        }
    }
}
