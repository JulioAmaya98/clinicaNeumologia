using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}