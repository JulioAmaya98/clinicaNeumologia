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
    public partial class Inicio : BasePage
    {
        NUsuarios objusuario = new NUsuarios();
        EUsuarios EUsuarios = new EUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                string encryp = Encriptar("Medico");
                if (Request.QueryString["rol"] ==encryp && Session["username"].ToString()==encryp)
                {
                    GridViewUsuarios.DataSource = objusuario.mostrarUsuarios();
                    GridViewUsuarios.DataBind();
                   
                    foreach (GridViewRow row in GridViewUsuarios.Rows)
                    {
                        if (row.Cells[4].Text == "JL")
                        {
                            row.Visible = false;
                        }
                    }
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

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarUsuarios.aspx?rol=" + Request.QueryString["rol"]);
        }
        public string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
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

            Response.Redirect("EditarUsuario.aspx?id_usuario=" + EUsuarios.id_usuario + "&rol=" + Request.QueryString["rol"]);

        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            NUsuarios obEliminar= new NUsuarios();
            EUsuarios obUsuario= new EUsuarios();
            Button btn = (Button)sender;
            GridViewRow selector = (GridViewRow)btn.NamingContainer;
            obUsuario.id_usuario = Convert.ToInt32(selector.Cells[1].Text);
            obEliminar.eliminarUsuarios(obUsuario);
            Response.Redirect("Empleados.aspx?rol=" + Request.QueryString["rol"]);
        }

        protected void GridViewUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Cerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../Layout/Login.aspx");    
        }
       
    }
}