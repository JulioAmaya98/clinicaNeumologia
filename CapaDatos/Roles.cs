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
    public class Roles
    {
        Conexion objConn = new Conexion();
        SqlDataReader leer;
        DataTable tablaDatos = new DataTable();
        SqlCommand comando = new SqlCommand();
       

        public DataTable obtenerRoles()
        {
            DataTable tabla = new DataTable();
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_mostrar_roles";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            objConn.cerrarConexion();
            return tabla;
        }

        public DataTable RolesPorUsuairo( EUsuarios usuarios )
        {
            DataTable tabla = new DataTable();
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_mostrar_rol_por_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@username", usuarios.username);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            objConn.cerrarConexion();
            return tabla;

        }
    }
}
