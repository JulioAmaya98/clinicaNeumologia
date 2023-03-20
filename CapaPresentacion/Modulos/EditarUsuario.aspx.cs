using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class EditarUsuario : BasePage
    {
        NRoles objnroles = new NRoles();
        NUsuarios objRoles = new NUsuarios();
        EUsuarios EUsuarios = new EUsuarios();
        NUsuarios objusuario = new NUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                string encrypMedico = Encriptar("Medico"); 

                if (Request.QueryString["id_usuario"] != null && Request.QueryString["rol"]==encrypMedico && Session["username"].ToString() == encrypMedico)
                {
                    var id = Request.QueryString["id_usuario"].ToString();
                    Label1.Text = id;
                    Label1.Visible=false;

                    
                    DropDownListRol.DataSource = objRoles.obtenerRoles();
                    DropDownListRol.DataTextField = "nombre_rol";
                    DropDownListRol.DataValueField = "id_roles";
                    DropDownListRol.DataBind();

                    EUsuarios.id_usuario = Convert.ToInt32(Label1.Text);
                    DataTable tabla = new DataTable();
                    tabla = objusuario.verTablaById(EUsuarios);
                    TextBoxNombre.Text = tabla.Rows[0]["nombre"].ToString();
                    TextBoxApellido.Text = tabla.Rows[0]["apellido"].ToString();
                    TextBoxuserName.Text = tabla.Rows[0]["username"].ToString();
                    TextBoxTelefono.Text = tabla.Rows[0]["telefono"].ToString();
                    DropDownListRol.SelectedValue = tabla.Rows[0]["id_roles"].ToString();

                }else
                {
                    Response.Redirect("../Layout/Login.aspx");
                }
            }

        }
        public string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            EUsuarios.id_usuario = Convert.ToInt32(Label1.Text);
            EUsuarios.nombre = TextBoxNombre.Text;
            EUsuarios.apellido = TextBoxApellido.Text;
            EUsuarios.username = TextBoxuserName.Text;
           
            EUsuarios.telefono = TextBoxTelefono.Text;
            EUsuarios.estado = "Activo";
            EUsuarios.id_roles = Convert.ToInt32( DropDownListRol.SelectedValue.ToString());
            objusuario.modifiUsuarios(EUsuarios);
            Response.Redirect("Empleados.aspx?rol=" + Request.QueryString["rol"]);
        }

        protected void Cerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../Layout/Login.aspx");
        }
    }
}