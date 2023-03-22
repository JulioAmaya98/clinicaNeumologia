using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class AgregarProductos : System.Web.UI.Page
    {
        NProductos objnProductos = new NProductos();
        EProducto eProducto = new EProducto();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            eProducto.nombre_producto = TextBoxNombreProducto.Text;
            eProducto.stock = Convert.ToInt32(TextBoxStock.Text);
            eProducto.fecha_vencimiento = TextBoxFechaVencimiento.Text;
            eProducto.precio = Convert.ToDouble(TextBoxPrecio.Text);
            eProducto.descripcion = TextBoxDescripcion.Text;
            objnProductos.agregarProductos(eProducto);
            Response.Redirect("ProductosBodega.aspx");
            limpiarCampos();
        }
        public void limpiarCampos()
        {
            TextBoxNombreProducto.Text = "";
            TextBoxStock.Text = "";
            TextBoxFechaVencimiento.Text = "";
            TextBoxPrecio.Text = "";
            TextBoxDescripcion.Text = "";
        }
    }
}