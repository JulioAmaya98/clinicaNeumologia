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
        NInventario objnProductos = new NInventario();
        EInventario eProducto = new EInventario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            //cambiar
            eProducto.codigo_producto = TextBoxNombreProducto.Text;
            eProducto.cantidad = Convert.ToInt32(TextBoxStock.Text);
            eProducto.ubicacion = TextBoxFechaVencimiento.Text;
            eProducto.lote = Convert.ToInt32(TextBoxPrecio.Text);
            eProducto.ubicacion = TextBoxDescripcion.Text;
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