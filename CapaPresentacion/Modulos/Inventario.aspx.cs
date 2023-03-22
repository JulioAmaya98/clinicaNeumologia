using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class ProductosBodega : BasePage
    {
        NProductos nproductos = new NProductos();
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {

                string encrypMedico = Encriptar("Medico");
                string encryBodeguero = Encriptar("Bodeguero");

                if (Request.QueryString["rol"]==encrypMedico &&  Session["username"].ToString() == encrypMedico)
                {
                    gridProducto.PageSize = 5;
                    gridProducto.DataSource = nproductos.mostrarProduct();
                    gridProducto.DataBind();
                }
                else if (Request.QueryString["rol"]==encryBodeguero &&  Session["username"].ToString() == encryBodeguero)
                {
                    gridProducto.PageSize = 5;
                    gridProducto.DataSource = nproductos.mostrarProduct();
                    gridProducto.DataBind();
                    navEmpleados.Visible = false;
                    navProductos.Visible=false;

                }
                else
                {
                    Response.Redirect("../Layout/Login.aspx");
                }




            }
            catch (Exception)
            {

                throw;
            }



        }

        protected void gridProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProducto.PageIndex = e.NewPageIndex;


            gridProducto.DataBind();
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

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProductos.aspx");
        }
    }
}
