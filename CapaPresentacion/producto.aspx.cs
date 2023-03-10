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
    public partial class producto : System.Web.UI.Page
    {
        NUsuarios usuario= new NUsuarios(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            gridProducto.DataSource = usuario.mostrarProduct();
            gridProducto.DataBind();
        }
    }
}