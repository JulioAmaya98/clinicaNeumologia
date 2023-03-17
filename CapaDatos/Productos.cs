using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Productos
    {
        Conexion objConn = new Conexion();
        SqlDataReader leer;
        DataTable tablaDatos = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable mostraProducto()
        {
            DataTable tablaDatosProd = new DataTable();

            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_mostrar_productos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tablaDatosProd.Load(leer);
            objConn.cerrarConexion();
            return tablaDatosProd;
        }
        public void addProducto(EProducto eProducto)
        {
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_ingresar_productos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", eProducto.nombre_producto);
            comando.Parameters.AddWithValue("@stock", eProducto.stock);
            comando.Parameters.AddWithValue("@fecha_vencimiento", eProducto.fecha_vencimiento);
            comando.Parameters.AddWithValue("@precio", eProducto.precio);
            comando.Parameters.AddWithValue("@descripcion", eProducto.descripcion);
            comando.ExecuteNonQuery();
            objConn.cerrarConexion();
        }
    }
}
