using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Login : System.Web.UI.Page
    {
        String clave = "clinic_neumologia";
        NUsuarios objNUsuario = new NUsuarios();
        EUsuarios user = new EUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;
        }

        protected void boton_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            user.nombre = txtNombre.Value;
            user.pass = txtContra.Value;
            user.clave = clave;
            tabla = objNUsuario.loginUsuario(user);
            if (tabla.Rows.Count > 0)
            {
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                error.Visible = true;
                txtNombre.Value = "";
            }
        }
    }
}