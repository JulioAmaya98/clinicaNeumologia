using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public  class NUsuarios
    {

        Usuarios usuarios = new Usuarios();
        public DataTable loginUsuario(EUsuarios user)
        {
            DataTable tabla = new DataTable();
            tabla = usuarios.comprobarUsuarios(user);
            return tabla;
        }

        public DataTable mostrarUsuarios()
        {
            DataTable tabla = new DataTable();
            tabla = usuarios.obtenerUsuarios();
            return tabla;
        }
        public void actualizarEstado()
        {
            usuarios.actualizarEstado();
        }
        public void registroSesion(EUsuarios user)
        {
            usuarios.registroSesion(user);
        }
        public DataTable obtenerRoles()
        {
            DataTable tabla = new DataTable();
            tabla= usuarios.obtenerRoles();
            return tabla;
        }

        public void agregarUsuarios(EUsuarios eusuario)
        {
            usuarios.addUsuarios(eusuario);
        }

        public DataTable existenciaUser(EUsuarios user)
        {
            DataTable tabla = new DataTable();
            tabla = usuarios.existenciaUsername(user);
            return tabla;
        }

        public void modifiUsuarios(EUsuarios eusuario)
        {
            usuarios.modificarUsuario(eusuario);
        }

        public DataTable verTablaById(EUsuarios eUsuarios)
        {
            DataTable tabla = new DataTable();
            tabla = usuarios.sp_modificarById( eUsuarios);
            return tabla;
        }
        public void EliminarUser(string id)
        {
            usuarios.EliminarUsuario(Convert.ToInt32(id));
        }
    }
}
