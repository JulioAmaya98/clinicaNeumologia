using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Runtime.Remoting.Messaging;

namespace CapaDatos
{
	public class Producto
	{
		Conexion objConn = new Conexion();
		SqlDataReader leer;
		DataTable tablaDatos = new DataTable();
		SqlCommand comando = new SqlCommand();

		public DataTable mostrarAll()
		{
			
			DataTable tabla = new DataTable();

			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_mostrar_all";
			comando.CommandType = CommandType.StoredProcedure;
			leer = comando.ExecuteReader();
			tabla.Load(leer);
			objConn.cerrarConexion();
			return tabla;
		}

		public void addProducto(EProducto eProducto)
		{
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_InsertarProducto";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@codigo_producto", eProducto.codigo_producto);
			comando.Parameters.AddWithValue("@nombre", eProducto.nombre);
			comando.Parameters.AddWithValue("@id_proveedor", eProducto.id_proveedor);
			comando.Parameters.AddWithValue("@precio", eProducto.precio);
			comando.Parameters.AddWithValue("@descripcion", eProducto.descripcion);
			comando.ExecuteNonQuery();
			objConn.cerrarConexion();
		}

		public DataTable mostrarProductoProveedor()
		{
			DataTable tabla = new DataTable();

			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_mostrar_proveedorPorProducto";
			comando.CommandType = CommandType.StoredProcedure;
			leer = comando.ExecuteReader();
			tabla.Load(leer);
			objConn.cerrarConexion();
			return tabla;
		}
		public DataTable mostrarProductosDrop(EProducto producto)
		{
			DataTable tabla = new DataTable();
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_mostrar_producto_proveedor";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@id_proveedor", producto.id_proveedor);
			leer = comando.ExecuteReader();
			tabla.Load(leer);
			objConn.cerrarConexion();
			return tabla;
		}
        public bool eliminarProductoP(EProducto Producto)
        {
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_eliminar_producto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo_producto", Producto.codigo_producto);
            comando.Parameters.AddWithValue("@id_proveedor", Producto.id_proveedor);
            int rep=comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            objConn.cerrarConexion();

			if (rep > 0)
			{
				return true;
			}

			return false;
        }

        public List<EProducto> ObtenerProductos(int idProveedor)
        {
            List<EProducto> listaProductos = new List<EProducto>();
            string consulta = "SELECT * FROM Productos WHERE id_roveedor = @idProveedor";
            SqlCommand comando = new SqlCommand(consulta, objConn.abrirConexion());
            comando.Parameters.AddWithValue("@idProveedor", idProveedor);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                EProducto producto = new EProducto();
                producto.codigo_producto = reader["codigo_producto"].ToString();
                producto.nombre = reader["nombre"].ToString();
                producto.precio = Convert.ToDouble(reader["precio"]);
				producto.descripcion = reader["descripcion"].ToString();
                

                listaProductos.Add(producto);
            }

            return listaProductos;
        }

    }
}
