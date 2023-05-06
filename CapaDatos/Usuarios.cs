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

        public DataTable obtenerUsuarios()
        {
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_mostrar_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tablaDatos.Load(leer);
            objConn.cerrarConexion();
            return tablaDatos;
        }
       
        public void addUsuarios(EUsuarios eUsuario)
        {
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_agregar_usuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre",eUsuario.nombre);
            comando.Parameters.AddWithValue("@apellido", eUsuario.apellido);
            comando.Parameters.AddWithValue("@username", eUsuario.username);
            comando.Parameters.AddWithValue("@telefono", eUsuario.telefono);
            comando.Parameters.AddWithValue("@pass", eUsuario.pass);
            comando.Parameters.AddWithValue("@clave", eUsuario.clave);
            comando.Parameters.AddWithValue("@id_roles", eUsuario.id_roles);
            comando.Parameters.AddWithValue("@estado", eUsuario.estado);
            comando.ExecuteNonQuery();
            objConn.cerrarConexion();
        }

        public DataTable comprobarUsuarios(EUsuarios user)
        {
            DataTable tabla = new DataTable();
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_login_usuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", user.username);
            comando.Parameters.AddWithValue("@pass", user.pass);
            comando.Parameters.AddWithValue("@clave", user.clave);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            objConn.cerrarConexion();
            return tabla;
        }
        
        public void actualizarEstado()
        {
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_estado_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            objConn.cerrarConexion();
        }
        public void registroSesion(EUsuarios user)
        {
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_registrar_sesion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@username", user.username);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            objConn.cerrarConexion();
        }
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

        public DataTable existenciaUsername(EUsuarios user)
        {
            DataTable tabla = new DataTable();
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_existencia_username";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@username", user.username);
            leer=comando.ExecuteReader();
            tabla.Load(leer);      
            objConn.cerrarConexion();
            return tabla;
        }


        public void modificarUsuario(EUsuarios eUsuario)
        {
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_modificar_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", eUsuario.id_usuario);
            comando.Parameters.AddWithValue("@nombre", eUsuario.nombre);
            comando.Parameters.AddWithValue("@apellido", eUsuario.apellido);
            comando.Parameters.AddWithValue("@username", eUsuario.username);
            comando.Parameters.AddWithValue("@telefono", eUsuario.telefono);
           
            comando.Parameters.AddWithValue("@id_rol", eUsuario.id_roles);
            comando.Parameters.AddWithValue("@estado", eUsuario.estado);
            comando.ExecuteNonQuery();
            objConn.cerrarConexion();
        }


        public DataTable sp_modificarById(EUsuarios eUsuarios)
        {

            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_modificarById";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", eUsuarios.id_usuario);
            leer = comando.ExecuteReader();
            tablaDatos.Load(leer);
            objConn.cerrarConexion();
            return tablaDatos;

        }

        public bool eliminarUsuario(EUsuarios user)
        {
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_eliminar_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_usuario", user.id_usuario);
            int resp=comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            objConn.cerrarConexion();

            if (resp  > 0)
            {
                return true;
            }

            return false;
        }

        public DataTable ObtenerIdUSer(EUsuarios usuario)
        {
            
            DataTable tabla = new DataTable();
            comando.Connection = objConn.abrirConexion();
            comando.CommandText = "sp_obtenerIdUser";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", usuario.username);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            objConn.cerrarConexion();
            return tabla;
        }
    }
}
