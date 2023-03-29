using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        NProducto NProductos=new NProducto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

				dropProveedor.DataSource = NProductos.mostrarProductoProveedor();
				dropProveedor.DataTextField = "Vendedor";
				dropProveedor.DataValueField = "IdProveedor";
				dropProveedor.DataBind();
				dropProveedor.SelectedIndexChanged += new EventHandler(dropProveedor_SelectedIndexChanged);

				EProducto producto = new EProducto();
                producto.id_proveedor = 1;
				dropCodigoProducto.DataSource = NProductos.mostrarProductosDrop(producto);
				dropCodigoProducto.DataTextField = "codigo_producto";
				dropCodigoProducto.DataValueField = "codigo_producto";
				dropCodigoProducto.DataBind();


			}
		}

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
			
				eProducto.codigo_producto = dropCodigoProducto.SelectedValue.ToString();
				eProducto.id_proveedor = Convert.ToInt32(dropProveedor.SelectedValue.ToString());
				eProducto.cantidad = Convert.ToInt32(TextBoxStock.Text);
				eProducto.fecha_vencimiento =Convert.ToDateTime(TextBoxFechaVencimiento.Text);
				eProducto.lote = Convert.ToInt32(txtLote.Text);
				eProducto.ubicacion = txtUbicacion.Text;
				objnProductos.agregarProductos(eProducto);
				string alertError = "Swal.fire({";
				alertError += "icon: 'success',";
				alertError += "title: 'successful',";
				alertError += "text: 'El registro se pudo agregar correctamente',";
				alertError += "})";

				ScriptManager.RegisterClientScriptBlock(
					this, this.GetType(), "script", alertError, true
				);
				limpiarCampos();
				
			
			
        }
        public void limpiarCampos()
        {
            txtUbicacion.Text = "";
            TextBoxStock.Text = "";
            TextBoxFechaVencimiento.Text = "";
            txtLote.Text = "";
        }

		protected void dropProveedor_SelectedIndexChanged(object sender, EventArgs e)
		{
			EProducto producto = new EProducto();
			producto.id_proveedor = Convert.ToInt32(dropProveedor.SelectedValue.ToString());
			dropCodigoProducto.DataSource = NProductos.mostrarProductosDrop(producto);
			dropCodigoProducto.DataTextField = "codigo_producto";
			dropCodigoProducto.DataValueField = "codigo_producto";
			dropCodigoProducto.DataBind();
		}
	}
}