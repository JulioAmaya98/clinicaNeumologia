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

        NRoles objRoles = new NRoles();
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;

        }

        protected void boton_Click(object sender, EventArgs e)
        {
            EUsuarios objUsersesion = new EUsuarios();
            SqlCommand comando = new SqlCommand();
            NUsuarios objsesion = new NUsuarios();
            DataTable tabla = new DataTable();



            user.username = txtNombre.Value;
            user.pass = txtContra.Value;
            user.clave = clave;
            objUsersesion.username = txtNombre.Value;
            tabla = objsesion.loginUsuario(user);


            if (tabla.Rows.Count > 0)
            {
                objNUsuario.registroSesion(objUsersesion);
                Session["username"]=txtNombre.Value;

                DataTable tablaRol = new DataTable();
                tablaRol = objRoles.MostarRolPorUsuarios(user);
                Label1.Text = tablaRol.Rows[0]["nombre_rol"].ToString();
                string i = Label1.Text;



                if (i == "Medico")
                {
                    Response.Redirect("Inicio.html");
                }
                else if (i == "Secretaria")
                {
                    Response.Redirect("InicioSec.html");

                }
                else if (i == "Bodeguero")
                {
                    Response.Redirect("InicioBod.html");
                }


               
            }
            else
            {
                error.Visible = true;
                txtNombre.Value = "";
            }

        }
    }
}