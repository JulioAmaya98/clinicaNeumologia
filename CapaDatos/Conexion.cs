using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace CapaDatos
{
    public class Conexion
    {
<<<<<<< HEAD
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-EHTBUQ2;Initial Catalog=clinic;Integrated Security=True");
=======
        SqlConnection conn = new SqlConnection("Data Source=RUTY\\U20201501;Initial Catalog=clinic;Integrated Security=True");
>>>>>>> 6a468d77457e58772dbd0dfeab865ad07b6b7079

       
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
