using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Modulos
{
	public partial class EditarProveedor : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			NProveedores nProveedor=new NProveedores();
			EUProveedor proveedor=new EUProveedor();
			if (!IsPostBack)
			{

				string encrypMedico = Encriptar("Medico");
				string encrupSecreataria = Encriptar("Secretaria");
				if (Request.QueryString["id_proveedor"] != null && Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico)
				{
					var id = Request.QueryString["id_proveedor"].ToString();
					Label1.Text = id;
					Label1.Visible = false;

					proveedor.Id = Convert.ToInt32(Label1.Text);
					DataTable tabla = new DataTable();
					tabla = nProveedor.modificarByID(proveedor);
					txtNombre.Text = tabla.Rows[0]["NombreEmpresa"].ToString();
					txtDireccion.Text = tabla.Rows[0]["Direccion"].ToString();
					txtVendedor.Text = tabla.Rows[0]["Vendedor"].ToString();
					TextBoxTelefono.Text = tabla.Rows[0]["Contacto"].ToString();
					txtCorreo.Text = tabla.Rows[0]["CorreoElectronico"].ToString();
				
					

				}else if (Request.QueryString["id_proveedor"] != null && Request.QueryString["rol"] == encrupSecreataria && Session["username"].ToString() == encrupSecreataria)
				{
					navEmpleados.Visible = false;

					var id = Request.QueryString["id_proveedor"].ToString();
					Label1.Text = id;
					Label1.Visible = false;

					proveedor.Id = Convert.ToInt32(Label1.Text);
					DataTable tabla = new DataTable();
					tabla = nProveedor.modificarByID(proveedor);
					txtNombre.Text = tabla.Rows[0]["NombreEmpresa"].ToString();
					txtDireccion.Text = tabla.Rows[0]["Direccion"].ToString();
					txtVendedor.Text = tabla.Rows[0]["Vendedor"].ToString();
					TextBoxTelefono.Text = tabla.Rows[0]["Contacto"].ToString();
					txtCorreo.Text = tabla.Rows[0]["CorreoElectronico"].ToString();

				}
				else
				{
					Response.Redirect("../Layout/Login.aspx");
				}
			}
		}

		public string Encriptar(string _cadenaAencriptar)
		{
			string result = string.Empty;
			byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
			result = Convert.ToBase64String(encryted);
			return result;
		}

		protected void ButtonGuardar_Click(object sender, EventArgs e)
		{
			NProveedores nProveedor = new NProveedores();
			EUProveedor proveedor = new EUProveedor();

			proveedor.Id = Convert.ToInt32(Label1.Text);
			proveedor.nombre = txtNombre.Text;
			proveedor.direccion = txtDireccion.Text;
			proveedor.correo=txtCorreo.Text;
			proveedor.telefono = TextBoxTelefono.Text;
			proveedor.vendedor = txtVendedor.Text;
			nProveedor.modificar(proveedor);
			Response.Redirect("Proveedores.aspx?rol=" + Request.QueryString["rol"]);


		}

		protected void Cerrar_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Response.Redirect("../Layout/Login.aspx");
		}
	}
}