using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class Ventas
    {

        Conexion objConn = new Conexion();
        SqlDataReader leer;
        DataTable tablaDatos = new DataTable();
        SqlCommand comando = new SqlCommand();


        public DataTable mostrarProductosBuscados()
        {

            DataTable tabla = new DataTable();

            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "buscar_productos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            objConn.cerrarConexion();
            return tabla;
        }



        public DataTable mostrarTipoPago()
        {
            DataTable tabla = new DataTable();

            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_mostarTipoPago";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            objConn.cerrarConexion();
            return tabla;
        }

        public DataTable correlativoFactura(int tipo)
        {
            DataTable tabla = new DataTable();

            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_mostrar_correlativo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", tipo);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            objConn.cerrarConexion();
            return tabla;
        }
        public DataTable verProveedor(EVentas ventas)
        {
            DataTable tabla = new DataTable();

            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_ver_venta_producto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_producto", ventas.id_producto);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            objConn.cerrarConexion();
            return tabla;
        }

        public bool InsertDetalleVenta(EVentas ventas)
        {
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_insert_venta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@comprobante", ventas.comrprobante_venta);
            comando.Parameters.AddWithValue("@codigo_producto", ventas.codigo_producto);
            comando.Parameters.AddWithValue("@id_proveedor", ventas.id_proveedor);
            comando.Parameters.AddWithValue("@cantidad", ventas.cantidad);
            int res = comando.ExecuteNonQuery();
            objConn.cerrarConexion();
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public DataTable MostrarDetalleVenta(EVentas ventas)
        {
            DataTable tabla = new DataTable();

            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_mostrar_detalle_venta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@comprobante", ventas.comrprobante_venta);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            objConn.cerrarConexion();
            return tabla;
        }



    }
}
