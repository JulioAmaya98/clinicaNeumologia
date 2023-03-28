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
	public partial class AgregarProducto : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{

				string encrypMedico = Encriptar("Medico");

				string encrypSecretaria = Encriptar("Secretaria");


				if (Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico)
				{
				}
				else if (Request.QueryString["rol"] == encrypSecretaria && Session["username"].ToString() == encrypSecretaria)
				{


				}
				else
				{
					Response.Redirect("../Layout/Login.aspx");
				}

			}
			catch (Exception)
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

		protected void ButtonAgregar_Click(object sender, EventArgs e)
		{
			EProducto eProducto = new EProducto();
			NProducto nProducto = new NProducto();

			int idProveedor = Convert.ToInt32(Request.QueryString["id_proveedor"].ToString());

			eProducto.codigo_producto = codigoProducto.Text;
			eProducto.nombre = NombreProducto.Text;
			eProducto.id_proveedor = idProveedor;
			eProducto.precio = Convert.ToDouble(precioProducto.Text);
			eProducto.descripcion = TextBoxDescripcion.Text;

			nProducto.agregarProducto(eProducto);
			limpiarCampos();

			string alertError = "Swal.fire({";
			alertError += "icon: 'success',";
			alertError += "title: 'successful',";
			alertError += "text: 'El registro se pudo agregar correctamente',";
			alertError += "})";

			ScriptManager.RegisterClientScriptBlock(
				this, this.GetType(), "script", alertError, true
			);
		}

		public void limpiarCampos()
		{
			codigoProducto.Text = "";
			NombreProducto.Text = "";
			precioProducto.Text = "";
			TextBoxDescripcion.Text = "";
		}
	}
}