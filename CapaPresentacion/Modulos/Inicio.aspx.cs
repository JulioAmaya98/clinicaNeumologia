using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Modulos
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            try
            {

                string encryp = Encriptar("Medico");
                string encrypSecretaria = Encriptar("Secretaria");
                string encrypBodeguero = Encriptar("Bodeguero");
                if (Request.QueryString["rol"] == encryp && Session["username"].ToString() == encryp)
                {
                 
                }
                else if(Request.QueryString["rol"] == encrypSecretaria && Session["username"].ToString() == encrypSecretaria)
                {
                   
                    navEmpleados.Visible= false;
                    navInventario.Visible= false;
                    
                   

                }
                else if (Request.QueryString["rol"] == encrypBodeguero && Session["username"].ToString() == encrypBodeguero)
                {
                    navProductos.Visible= false;
                    navEmpleados.Visible = false;
                    navProveedores.Visible= false;
                    navCompras.Visible= false;
                    

                }
                else
                {
                    Response.Redirect("../Layout/Login.aspx");
                }

            }
            catch (Exception)
            {

                Response.Redirect("../Layout/Login.aspx");
            }



        }


        public string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }
        protected void Cerrar_Click(object sender, EventArgs e)
        {

            Session.Clear();
            Response.Redirect("../Layout/Login.aspx");
        }
    }
}