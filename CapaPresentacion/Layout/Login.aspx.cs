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
        public  string Encriptar( string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        protected void boton_Click(object sender, EventArgs e)
        {
            EUsuarios objUsersesion = new EUsuarios();
            NUsuarios objsesion = new NUsuarios();
            DataTable tabla = new DataTable();



            user.username = txtNombre.Value;
            user.pass = txtContra.Value;
            user.clave = clave;
            objUsersesion.username = txtNombre.Value;
            tabla = objsesion.loginUsuario(user);



           
            

            if (tabla.Rows.Count > 0)
            {
                DataTable tablaIdUser = new DataTable();
                NUsuarios nIdUser = new NUsuarios();
                EUsuarios usuario2 = new EUsuarios();
                
                objNUsuario.registroSesion(objUsersesion);
                Session["username"]=txtNombre.Value;


                usuario2.username = txtNombre.Value;
                tablaIdUser = nIdUser.ObtenerIdUser(usuario2);
                string id =tablaIdUser.Rows[0]["id_usuario"].ToString();

                Session["idUser"] = id;


                DataTable tablaRol = new DataTable();
                tablaRol = objRoles.MostarRolPorUsuarios(user);
                Label1.Text = tablaRol.Rows[0]["nombre_rol"].ToString();
                string i = Label1.Text;
                string encr = Encriptar(Label1.Text);


                if (i == "Medico")
                {
                    Session["username"] = encr;
                    Response.Redirect("../Modulos/Inicio.aspx?rol="+encr);
                }
                else if (i == "Secretaria")
                {
                    Session["username"] = encr; 
                    Response.Redirect("../Modulos/Inicio.aspx?rol="+encr);
                   

                }
                else if (i == "Bodeguero")
                {
                    Session["username"] = encr;
                    Response.Redirect("../Modulos/Inicio.aspx?rol="+encr);
                    
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