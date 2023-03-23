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
    }
}
