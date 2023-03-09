using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        SqlConnection conn = new SqlConnection("Data Source=RUTY\\U20201501;Initial Catalog=clinic;Integrated Security=True");


        public SqlConnection abrirConexion()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            return conn;
        }
        public SqlConnection cerrarConexion()
        {

            if (conn.State == ConnectionState.Open)
                conn.Close();
            return conn;
        }
    }
}
