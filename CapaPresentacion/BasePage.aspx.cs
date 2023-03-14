using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Verificar si el usuario ha iniciado sesión
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}