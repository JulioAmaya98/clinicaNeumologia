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

           
            gridProducto.PageSize = 5;
            gridProducto.DataSource = nproductos.mostrarProduct();
            gridProducto.DataBind();

           
            
        }

        protected void gridProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProducto.PageIndex = e.NewPageIndex;


            gridProducto.DataBind();
        }

        protected void Cerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}