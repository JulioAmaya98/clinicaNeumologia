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
    public class Proveedores
    {
        Conexion objConn = new Conexion();
        SqlDataReader leer;
        DataTable tablaDatos = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable mostraProveedores()
        {
            DataTable tablaDatosProd = new DataTable();

            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_mostrar_proveedores";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tablaDatosProd.Load(leer);
            objConn.cerrarConexion();
            return tablaDatosProd;
        }
        public void addProveedor(EUProveedor eUproveedor)
        {
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_insertar_proveedor";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", eUproveedor.nombre);
            comando.Parameters.AddWithValue("@direccion", eUproveedor.direccion);
            comando.Parameters.AddWithValue("@vendedor", eUproveedor.vendedor);
            comando.Parameters.AddWithValue("@telefono", eUproveedor.telefono);
            comando.Parameters.AddWithValue("@correo", eUproveedor.correo );
            comando.ExecuteNonQuery();
            objConn.cerrarConexion();
        }


		public DataTable modificarById(EUProveedor proveedor)
		{

			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_modificar_proveedorById";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@id", proveedor.Id);
			leer = comando.ExecuteReader();
			tablaDatos.Load(leer);
			objConn.cerrarConexion();
			return tablaDatos;

		}
		public void modificar(EUProveedor proveedor)
		{
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_modificar_proveedor";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@id", proveedor.Id);
			comando.Parameters.AddWithValue("@nombre", proveedor.nombre);
			comando.Parameters.AddWithValue("@direccion", proveedor.direccion);
			comando.Parameters.AddWithValue("@telefono", proveedor.telefono);
            comando.Parameters.AddWithValue("@vendedor", proveedor.vendedor);
			comando.Parameters.AddWithValue("@correo", proveedor.correo);
			comando.ExecuteNonQuery();
			objConn.cerrarConexion();
		}
		public bool delete(EUProveedor eUProveedor)
		{
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_eliminar_proveedor";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@id", eUProveedor.Id);
			int respuesta = comando.ExecuteNonQuery();
			objConn.cerrarConexion();
			if (respuesta > 0)
			{
				return true;
			}

			return false;
		}

		public DataTable viewProductSupp(EUProveedor proveedor)
		{
			DataTable tabla = new DataTable();
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_mostrar_producto_proveedor";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@id_proveedor", proveedor.Id);
			leer = comando.ExecuteReader();
			tabla.Load(leer);
			objConn.cerrarConexion();
			return tabla;
		}
		
		public DataTable dataProveedores(EUProveedor proveedor)
		{
			DataTable tabla = new DataTable();
			comando.Connection = objConn.abrirConexion();
			comando.CommandText = "sp_data_proveedores";
			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@id_proveedor", proveedor.Id);
			leer = comando.ExecuteReader();
			tabla.Load(leer);
			objConn.cerrarConexion();
			return tabla;
		}


	}
}