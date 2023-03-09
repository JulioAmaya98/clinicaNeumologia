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
    public class Usuarios
    {
        Conexion objConn = new Conexion();
        SqlDataReader leer;
        DataTable tablaDatos = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void insertUsuarios()
        {

        }

        public DataTable comprobarUsuarios(EUsuarios user)
        {
            DataTable tabla = new DataTable();
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_login_usuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", user.nombre);
            comando.Parameters.AddWithValue("@pass", user.pass);
            comando.Parameters.AddWithValue("@clave", user.clave);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            objConn.cerrarConexion();
            return tabla;
        }
    }
}
