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
	public partial class Proveedores : System.Web.UI.Page
	{
		NProveedores nProveedores = new NProveedores();
		protected void Page_Load(object sender, EventArgs e)
		{
			EUProveedor proveedo = new EUProveedor();
			NProveedores nProveedor = new NProveedores();

			string encrypMedico = Encriptar("Medico");

			string encrypSecretaria = Encriptar("Secretaria");


			if (Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico)
			{

				if (Request["id"] != null)
				{

					int id = int.Parse(Request["id"]);
					proveedo.Id = id;


					if (nProveedor.eliminar(proveedo))
					{
						//refrecamos nustra pagina
						Response.Redirect("Proveedores.aspx?rol=" + Request.QueryString["rol"]);

					}
					else
					{
						string alertError = "Swal.fire({";
						alertError += "icon: 'error',";
						alertError += "title: 'Oops...',";
						alertError += "text: 'El registro de pudo ser eliminado',";
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
				navEmpleados.Visible = false;
				navInventario.Visible = false;

				if (Request["id"] != null)
				{

					int id = int.Parse(Request["id"]);
					proveedo.Id = id;


					if (nProveedor.eliminar(proveedo))
					{
						//refrecamos nustra pagina
						Response.Redirect("Proveedores.aspx?rol=" + Request.QueryString["rol"]);

					}
					else
					{
						string alertError = "Swal.fire({";
						alertError += "icon: 'error',";
						alertError += "title: 'Oops...',";
						alertError += "text: 'El registro de pudo ser eliminado',";
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


		protected void gridProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gridProveedores.PageIndex = e.NewPageIndex;
			gridProveedores.DataBind();
		}

		protected void Cerrar_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Response.Redirect("../Layout/Login.aspx");
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Response.Redirect("AgregarProveedor.aspx?rol=" + Request.QueryString["rol"]);
		}

		protected void ButtonEditar_Click(object sender, EventArgs e)
		{
			EUProveedor proveedor = new EUProveedor();
			Button btn = (Button)sender;
			GridViewRow selector = (GridViewRow)btn.NamingContainer;
			proveedor.Id = Convert.ToInt32(selector.Cells[1].Text);

			Response.Redirect("EditarProveedor.aspx?id_proveedor=" + proveedor.Id + "&rol=" + Request.QueryString["rol"]);
		}

		protected void gridProveedores_RowDataBound(object sender, GridViewRowEventArgs e)
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
	}
}