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
	}
}