﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EUsuarios
    {

        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string pass { get; set; }
        public string clave { get; set; }
        public int id_roles { get; set; }
    }
}
