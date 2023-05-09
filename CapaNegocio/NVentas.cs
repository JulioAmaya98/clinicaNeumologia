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


    }
}
