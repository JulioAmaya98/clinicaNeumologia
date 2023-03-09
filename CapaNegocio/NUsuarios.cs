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
    }
}
