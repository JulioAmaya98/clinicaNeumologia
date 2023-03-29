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
    public class NProveedores
    {
        Proveedores proveedores = new Proveedores();
        public DataTable mostrarProveedores()
        {
            DataTable tablaproducto = new DataTable();
            tablaproducto = proveedores.mostraProveedores();
            return tablaproducto;
        }
        public void agregarProveedor(EUProveedor euproveedor)
        {
            proveedores.addProveedor(euproveedor);
        }

        public DataTable modificarByID(EUProveedor proveedor)
        {
            DataTable tabla = new DataTable();
            tabla = proveedores.modificarById(proveedor);
            return tabla;
        }

        public void modificar(EUProveedor proveedor)
        {
            proveedores.modificar(proveedor);
        }

        public bool eliminar(EUProveedor eUProveedor)
        {
            return proveedores.delete(eUProveedor);
        }
        public DataTable viewProductSupp(EUProveedor proveedor)
        {
            DataTable tabla = new DataTable();
            tabla=proveedores.viewProductSupp(proveedor);
            return tabla;
        }
    }
}
