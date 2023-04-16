using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Modulos
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		NCompra objHistoryCompras = new NCompra();
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{

				string encrypMedico = Encriptar("Medico");

				string encrypSecretaria = Encriptar("Secretaria");


				if (Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico)
				{

					GridViewHistory.DataSource = objHistoryCompras.mostrarHistorialCompras();
					GridViewHistory.DataBind();
				}
				else if (Request.QueryString["rol"] == encrypSecretaria && Session["username"].ToString() == encrypSecretaria)
				{

					GridViewHistory.DataSource = objHistoryCompras.mostrarHistorialCompras();
					GridViewHistory.DataBind();
					navEmpleados.Visible = false;
					navInventario.Visible = false;

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


		protected void Cerrar_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Response.Redirect("../Layout/Login.aspx");
		}

		

		protected void add_Click(object sender, EventArgs e)
		{
			Response.Redirect("CompraN.aspx?rol=" + Request.QueryString["rol"]);

		}
	}
}
