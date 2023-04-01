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
			NProducto nProducto = new NProducto();
			EProducto producto=new EProducto();

				string encrypMedico = Encriptar("Medico");

				string encrypSecretaria = Encriptar("Secretaria");


			if (Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico)
			{
				proveedor.Id = Convert.ToInt32(Request.QueryString["id_proveedor"].ToString());
				gridViewProductSupplier.DataSource = nProveedores.viewProductSupp(proveedor);
				gridViewProductSupplier.DataBind();

				if (Request["codigo"] != null)
				{

					string codigo = Request["codigo"];
					producto.codigo_producto = codigo;
					producto.id_proveedor = Convert.ToInt32(Request["id_proveedor"]);


					if (nProducto.eliminarProductoP(producto))
					{
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
					else
					{
						string alertError = "Swal.fire({";
						alertError += "icon: 'error',";
						alertError += "title: 'Oops...',";
						alertError += "text: 'El producto no pudo ser eliminado',";
						alertError += "footer: '<a>Ingresa aqui para obtener más información?</a>'";
						alertError += "})";

						ScriptManager.RegisterClientScriptBlock(
							this, this.GetType(), "script", alertError, true
						);
					}

				}


			}
			else if (Request.QueryString["rol"] == encrypSecretaria && Session["username"].ToString() == encrypSecretaria)
			{
				proveedor.Id = Convert.ToInt32(Request.QueryString["id_proveedor"].ToString());
				gridViewProductSupplier.DataSource = nProveedores.viewProductSupp(proveedor);
				gridViewProductSupplier.DataBind();
				navEmpleados.Visible = false;
				navInventario.Visible = false;


				if (Request["codigo"] != null)
				{

					string codigo = Request["codigo"];
					producto.codigo_producto = codigo;
					producto.id_proveedor = Convert.ToInt32(Request["id_proveedor"]);


					if (nProducto.eliminarProductoP(producto))
					{
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
					else
					{
						string alertError = "Swal.fire({";
						alertError += "icon: 'error',";
						alertError += "title: 'Oops...',";
						alertError += "text: 'El producto no pudo ser eliminado',";
						alertError += "footer: '<a>Ingresa aqui para obtener más información?</a>'";
						alertError += "})";

						ScriptManager.RegisterClientScriptBlock(
							this, this.GetType(), "script", alertError, true
						);
					}

				}

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

       

       
    }
}