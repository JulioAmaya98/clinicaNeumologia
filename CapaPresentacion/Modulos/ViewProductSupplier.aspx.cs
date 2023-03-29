using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Modulos
{
	public partial class ViewProductSupplier : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			NProveedores nProveedores= new NProveedores();
			EUProveedor proveedor= new EUProveedor();
			
			

				string encrypMedico = Encriptar("Medico");

				string encrypSecretaria = Encriptar("Secretaria");


				if (Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico)
				{
					proveedor.Id = Convert.ToInt32(Request.QueryString["id_proveedor"].ToString());
					gridViewProductSupplier.DataSource = nProveedores.viewProductSupp(proveedor);
					gridViewProductSupplier.DataBind();
				}
				else if (Request.QueryString["rol"] == encrypSecretaria && Session["username"].ToString() == encrypSecretaria)
				{
					proveedor.Id = Convert.ToInt32(Request.QueryString["id_proveedor"].ToString());
					gridViewProductSupplier.DataSource = nProveedores.viewProductSupp(proveedor);
					gridViewProductSupplier.DataBind();
					navEmpleados.Visible = false;
					navInventario.Visible = false;

				}
				else
				{
					Response.Redirect("../Layout/Login.aspx");
				}

			
		

		}

		public string Encriptar(string _cadenaAencriptar)
		{
			string result = string.Empty;
			byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
			result = Convert.ToBase64String(encryted);
			return result;
		}

		protected void gridViewProductSupplier_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.Header)
			{
				e.Row.Cells[2].Visible = false;
				e.Row.Cells[3].Visible = false;

			}
			{
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					e.Row.Cells[2].Visible = false;
					e.Row.Cells[3].Visible = false;
				}
			}
		}

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
			EProducto Producto = new EProducto();
			NProducto nProducto = new NProducto();
            Button btn = (Button)sender;
            GridViewRow selector = (GridViewRow)btn.NamingContainer;
            Producto.codigo_producto = (selector.Cells[1].Text);
			Producto.id_proveedor = Convert.ToInt32(Request.QueryString["id_proveedor"].ToString());
			nProducto.eliminarProductoP(Producto);

            string alertSuccess = "Swal.fire({";
            alertSuccess += "icon: 'success',";
            alertSuccess += "title: 'Successful',";
            alertSuccess += "text: 'El producto se elimino correctamente',";
            alertSuccess += "confirmButtonText: 'OK'";
            alertSuccess += "}).then((result) => {";
            alertSuccess += "if (result.isConfirmed) {";
            alertSuccess += "window.location.href = 'Proveedores.aspx?rol=" + Request.QueryString["rol"] + "';";
            alertSuccess += "}";
            alertSuccess += "});";

            ScriptManager.RegisterStartupScript(
                this, this.GetType(), "script", alertSuccess, true
            );
        }

       
    }
}