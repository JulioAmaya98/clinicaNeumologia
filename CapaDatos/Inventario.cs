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
    public class Inventario
    {
        Conexion objConn = new Conexion();
        SqlDataReader leer;
        DataTable tablaDatos = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable mostraProducto()
        {
            DataTable tablaDatosProd = new DataTable();

            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_mostrar_productos_inventario";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tablaDatosProd.Load(leer);
            objConn.cerrarConexion();
            return tablaDatosProd;
        }
        public void addProducto_Inventario(EInventario eInventario)
        {
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_ingresar_productos_inventario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo_producto", eInventario.codigo_producto);
            comando.Parameters.AddWithValue("@id_proveedor", eInventario.id_proveedor);
            comando.Parameters.AddWithValue("@cantidad", eInventario.cantidad);
            comando.Parameters.AddWithValue("@fecha_vencimiento", eInventario.fecha_vencimiento);
            comando.Parameters.AddWithValue("@ubicacion", eInventario.ubicacion);
			comando.Parameters.AddWithValue("@lote", eInventario.lote);
			comando.ExecuteNonQuery();
            objConn.cerrarConexion();
        }

        public DataTable editarInventarioByID(EInventario inventario)
        {
            DataTable tabla = new DataTable();
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_actualizar_inventarioByID";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@id_inventario", inventario.id_inventario);
			leer = comando.ExecuteReader();
			tabla.Load(leer);
			objConn.cerrarConexion();
			return tabla;
        }

		public void editarInventario(EInventario eInventario)
		{
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_actualizar_inventario";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@id_inventario", eInventario.id_inventario);
			comando.Parameters.AddWithValue("@codigo_producto", eInventario.codigo_producto);
			comando.Parameters.AddWithValue("@id_proveedor", eInventario.id_proveedor);
			comando.Parameters.AddWithValue("@cantidad", eInventario.cantidad);
			comando.Parameters.AddWithValue("@fecha_entrada", eInventario.fecha_entrada);
			comando.Parameters.AddWithValue("@fecha_vencimiento", eInventario.fecha_vencimiento);
			comando.Parameters.AddWithValue("@ubicacion", eInventario.ubicacion);
			comando.Parameters.AddWithValue("@lote", eInventario.lote);
			comando.ExecuteNonQuery();
			objConn.cerrarConexion();
		}

        public bool eliminar(EInventario inventario)
        {
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_eliminar_inventario";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@id_inventario", inventario.id_inventario);
			int resp=comando.ExecuteNonQuery();
			objConn.cerrarConexion();
            if (resp > 0)
            {
                return true;
            }
			return false;
        }

	}
}
