using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Modulos
{
    public partial class AgregarProveedor : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            EUProveedor provee = new EUProveedor();
            NProveedores proveedores= new NProveedores();

                provee.nombre = TextBoxNombre.Text;
                provee.direccion = TextBoxDireccion.Text;
                provee.vendedor = TextBoxVendedor.Text;
                provee.telefono = TextBoxTelefono.Text;
                provee.correo = TextBoxCorreo.Text;
                proveedores.agregarProveedor(provee);
            Response.Redirect("proveedores.aspx");
        }
        public void limpiarCampos()
        {
            TextBoxNombre.Text = "";
            TextBoxDireccion.Text = "";
            TextBoxTelefono.Text = "";
            TextBoxCorreo.Text = "";
            TextBoxVendedor.Text = "";
        }

    }
}
