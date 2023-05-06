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
    public class Compra
    {
        Conexion objConn = new Conexion();
        SqlDataReader leer;
        DataTable tablaDatos = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void insertar(ECompra compra)
        {
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "noje_compra";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@producto", compra.codigo_producto);
            comando.Parameters.AddWithValue("@id_proveedor", compra.id_proveedor);
            comando.Parameters.AddWithValue("@cantidad", compra.cantidad);
			comando.Parameters.AddWithValue("@comprobante", compra.comprobante_compra);
			comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            objConn.cerrarConexion();
        }

        public DataTable Subtotal(ECompra compra)
        {
			DataTable tabla = new DataTable();
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_subtotal";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@comprobante", compra.comprobante_compra);
			leer = comando.ExecuteReader();
			tabla.Load(leer);
			objConn.cerrarConexion();
			return tabla;
		}

        public bool Comprobante(ECompra compra)
        {
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_insert_compras";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@id_detalle_compra", compra.id_detalle_compra);
			comando.Parameters.AddWithValue("@total", compra.total);
			comando.Parameters.AddWithValue("@fecha", compra.fecha);
			comando.Parameters.AddWithValue("@comprovantes", compra.comprobante_compra);
			int respuesta = comando.ExecuteNonQuery();
			objConn.cerrarConexion();
			if (respuesta > 0)
			{
				return true;
			}

			return false;
			
        }

		public bool ExistenciaCompra(ECompra compra)
		{
			
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_validar_compra";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@comprobante", compra.comprobante_compra);
			int respuesta = Convert.ToInt32(comando.ExecuteScalar());



			objConn.cerrarConexion();
			if (respuesta <= 0)
			{
				return true;
			}

			return false;
		}

		public DataTable MostarCompra(ECompra compras)
		{
			
			DataTable tabla = new DataTable();
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_noje_detalle_compra";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@comprobante", compras.comprobante_compra);
			leer = comando.ExecuteReader();
			tabla.Load(leer);
			objConn.cerrarConexion();
			return tabla;

		}

		public void GuardarCompra(ECompra compras)
		{
			
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_guardar_compra";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@comprobante", compras.comprobante_compra);
			comando.Parameters.AddWithValue("@total", compras.total);
			comando.ExecuteNonQuery();
			objConn.cerrarConexion();
		}


		public DataTable mostrarHistoryCompras()
		{

			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_mostrar_historial_compras";
			comando.CommandType = CommandType.StoredProcedure;
			leer = comando.ExecuteReader();
			tablaDatos.Load(leer);
			objConn.cerrarConexion();
			return tablaDatos;
		}

		public bool eliminarDetalleVenta(int id)
		{
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_eliminar_detalleVenta";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@id_detalle", id);
			int res=comando.ExecuteNonQuery();
			objConn.cerrarConexion();
			if (res > 0)
			{
				return true;
			}
			return false;
		}

		public bool editStock_detalleCompra(ECompra eCompra) 
		{
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_editCantidad_detalle_compra";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", eCompra.id_detalle_compra);
            comando.Parameters.AddWithValue("@cantidad", eCompra.cantidad);
            int res = comando.ExecuteNonQuery();
            objConn.cerrarConexion();
            if (res > 0)
            {
                return true;
            }
            return false;
        }

		public bool EliminarCompra(int id,string comprobante)
		{
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_eliminar_compra";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id",id);
            comando.Parameters.AddWithValue("@comprobante", comprobante);
            int res = comando.ExecuteNonQuery();
            objConn.cerrarConexion();
            if (res > 0)
            {
                return true;
            }
            return false;
        }

	}
}
