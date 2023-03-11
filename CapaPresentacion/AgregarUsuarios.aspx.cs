using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class AgregarUsuarios : System.Web.UI.Page
    {
        NRoles objnroles = new NRoles();
        NUsuarios objRoles=new NUsuarios();
        String clave = "clinic_neumologia";
        NUsuarios objusuario = new NUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListRol.DataSource = objRoles.obtenerRoles();
                DropDownListRol.DataTextField = "nombre_rol";
                DropDownListRol.DataValueField = "id_roles";
                DropDownListRol.DataBind();
            }
            mensajeError.Visible = false;
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            EUsuarios usuarios = new EUsuarios();
            NUsuarios obExistencia = new NUsuarios();
            EUsuarios obUserExistencia = new EUsuarios();
            DataTable tablita = new DataTable();
           
            obUserExistencia.username= TextBoxuserName.Text;
            tablita = obExistencia.existenciaUser(obUserExistencia);
            if (tablita.Rows.Count > 0)
            {
                mensajeError.InnerText = "El nombre de usuario ya esta registrado";
                mensajeError.Visible = true;

                limpiarCampos();
            }
            else
            {
                usuarios.nombre = TextBoxNombre.Text;
                usuarios.apellido = TextBoxApellido.Text;
                usuarios.username = TextBoxuserName.Text;
                usuarios.telefono = TextBoxTelefono.Text;
                usuarios.pass = TextBoxPassword.Text;
                usuarios.clave = clave;
                usuarios.id_roles = Convert.ToInt32(DropDownListRol.SelectedValue.ToString());
                usuarios.estado = "Activo";
                objusuario.agregarUsuarios(usuarios);
                Response.Redirect("Empleados.aspx");
            }
            
        }

        public void limpiarCampos()
        {
            TextBoxNombre.Text = "";
            TextBoxApellido.Text = "";
            TextBoxTelefono.Text = "";
            TextBoxuserName.Text = "";
            TextBoxPassword.Text = "";
        }
    }
}