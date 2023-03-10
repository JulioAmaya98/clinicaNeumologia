using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
