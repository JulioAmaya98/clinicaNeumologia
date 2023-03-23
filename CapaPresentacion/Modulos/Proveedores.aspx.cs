using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Modulos
{
    public partial class Proveedores : System.Web.UI.Page
    {
        NProveedores nProveedores = new NProveedores();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                string encrypMedico = Encriptar("Medico");

                string encrypSecretaria = Encriptar("Secretaria");


                if (Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico)
                {
                    gridProveedores.PageSize = 5;
                    gridProveedores.DataSource = nProveedores.mostrarProveedores();
                    gridProveedores.DataBind();
                }
                else if (Request.QueryString["rol"] == encrypSecretaria && Session["username"].ToString() == encrypSecretaria)
                {
                    gridProveedores.PageSize = 5;
                    gridProveedores.DataSource = nProveedores.mostrarProveedores();
                    gridProveedores.DataBind();
                    navEmpleados.Visible = false;
                    navInventario.Visible = false;

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


        protected void gridProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProveedores.PageIndex = e.NewPageIndex;
            gridProveedores.DataBind();
        }

        protected void Cerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../Layout/Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProveedor.aspx");
        }
    }
}