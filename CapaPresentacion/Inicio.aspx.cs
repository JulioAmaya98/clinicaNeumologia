using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Inicio : System.Web.UI.Page
    {
        NUsuarios objusuario = new NUsuarios();
        EUsuarios EUsuarios = new EUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewUsuarios.DataSource = objusuario.mostrarUsuarios();
            GridViewUsuarios.DataBind();
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarUsuarios.aspx");
        }

        protected void GridViewUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
            }
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[1].Visible = false;
                }
            }
        }

        protected void ButtonEditar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow selector = (GridViewRow)btn.NamingContainer;
            EUsuarios.id_usuario = Convert.ToInt32(selector.Cells[1].Text);

            Response.Redirect("EditarUsuario.aspx?id_usuario=" + EUsuarios.id_usuario );

        }
    }
}