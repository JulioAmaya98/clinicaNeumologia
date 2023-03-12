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
    public class NRoles
    {
        Roles objroles = new Roles();
        public DataTable mostrarRoles()
        {
            DataTable tabla = new DataTable();
            tabla = objroles.obtenerRoles();
            return tabla;
        }

        public DataTable MostarRolPorUsuarios(EUsuarios usuarios)
        {
            DataTable tabla = new DataTable();
            tabla = objroles.RolesPorUsuairo(usuarios);
            return tabla;
        }
    }
}
