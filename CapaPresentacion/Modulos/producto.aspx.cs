using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class producto : BasePage
    {
        NProductos nproductos = new NProductos();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                string encrypMedico = Encriptar("Medico");
                
                string encrypSecretaria = Encriptar("Secretaria");
                

                if (Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico)
                {
                    gridProducto.PageSize = 5;
                    gridProducto.DataSource = nproductos.mostrarProduct();
                    gridProducto.DataBind();
                }
                else if (Request.QueryString["rol"] == encrypSecretaria && Session["username"].ToString() == encrypSecretaria)
                {
                    gridProducto.PageSize = 5;
                    gridProducto.DataSource = nproductos.mostrarProduct();
                    gridProducto.DataBind();
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


        protected void gridProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProducto.PageIndex = e.NewPageIndex;


            gridProducto.DataBind();
        }

        protected void Cerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../Layout/Login.aspx");
        }
    }
}