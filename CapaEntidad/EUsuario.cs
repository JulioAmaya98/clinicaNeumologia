using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Clase entidad para manejo de usuarios
    public class EUsuario
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string pass { get; set; }
        public string clave { get; set; }
        public int id_roles { get; set; }

    }
}
