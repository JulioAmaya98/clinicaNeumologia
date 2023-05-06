using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Modulos
{
	public partial class HistorialCompras : System.Web.UI.Page
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
					if (Request.QueryString["id"]!=null)
					{
						int id = Convert.ToInt32(Session["idUser"].ToString());
                        Label1.Text = Session["idUser"].ToString();
						int idCompra = Convert.ToInt32(Request.QueryString["id"].ToString());
						string comprobante = Request.QueryString["comprobante"].ToString();

						NCompra eliminarCompra = new NCompra();

						if (eliminarCompra.EliminarCompra(id,comprobante))
						{

                            string alertError = "Swal.fire({";
                            alertError += "icon: 'success',";
                            alertError += "title: 'Eliminado',";
                            alertError += "text: 'Compra eliminada exitosamente',";
                            alertError += "confirmButtonColor: '#3085d6',";
                            alertError += "confirmButtonText: 'OK'";
                            alertError += "}).then((result) => {";
                            alertError += "if (result.isConfirmed) {";
                            alertError += "window.location.href = 'HistorialCompras.aspx?rol=" + Request.QueryString["rol"] + "';";
                            alertError += "}";
                            alertError += "});";

                            ScriptManager.RegisterStartupScript(
                                this, this.GetType(), "script", alertError, true
                            );

						}
						else
						{
                            string alertError = "Swal.fire({";
                            alertError += "icon: 'error',";
                            alertError += "title: 'Error',";
                            alertError += "text: 'No tienes los permisos necesarios para eliminar esta compra',";
                            alertError += "confirmButtonColor: '#3085d6',";
                            alertError += "confirmButtonText: 'OK'";
                            alertError += "}).then((result) => {";
                            alertError += "if (result.isConfirmed) {";
                            alertError += "window.location.href = 'HistorialCompras.aspx?rol=" + Request.QueryString["rol"] + "';";
                            alertError += "}";
                            alertError += "});";

                            ScriptManager.RegisterStartupScript(
                                this, this.GetType(), "script", alertError, true
                            );
                        }






					}
					
				}
				else if (Request.QueryString["rol"] == encrypSecretaria && Session["username"].ToString() == encrypSecretaria)
				{
                    if (Request.QueryString["id"] != null)
                    {
                        int id = Convert.ToInt32(Session["idUser"]);
                        int idCompra = Convert.ToInt32(Request.QueryString["id"].ToString());
                        string comprobante = Request.QueryString["comprobante"].ToString();

                        NCompra eliminarCompra = new NCompra();

                        if (eliminarCompra.EliminarCompra(id, comprobante))
                        {

                            string alertError = "Swal.fire({";
                            alertError += "icon: 'success',";
                            alertError += "title: 'Eliminado',";
                            alertError += "text: 'Compra eliminada exitosamente',";
                            alertError += "confirmButtonColor: '#3085d6',";
                            alertError += "confirmButtonText: 'OK'";
                            alertError += "}).then((result) => {";
                            alertError += "if (result.isConfirmed) {";
                            alertError += "window.location.href = 'HistorialCompras.aspx?rol=" + Request.QueryString["rol"] + "';";
                            alertError += "}";
                            alertError += "});";

                            ScriptManager.RegisterStartupScript(
                                this, this.GetType(), "script", alertError, true
                            );

                        }
                        else
                        {
                            string alertError = "Swal.fire({";
                            alertError += "icon: 'error',";
                            alertError += "title: 'Error',";
                            alertError += "text: 'No tienes los permisos necesarios para eliminar esta compra',";
                            alertError += "confirmButtonColor: '#3085d6',";
                            alertError += "confirmButtonText: 'OK'";
                            alertError += "}).then((result) => {";
                            alertError += "if (result.isConfirmed) {";
                            alertError += "window.location.href = 'HistorialCompras.aspx?rol=" + Request.QueryString["rol"] + "';";
                            alertError += "}";
                            alertError += "});";

                            ScriptManager.RegisterStartupScript(
                                this, this.GetType(), "script", alertError, true
                            );
                        }






                    }

                    navEmpleados.Visible = false;
					navInventario.Visible = false;

				}
				else
				{
					Response.Redirect("/Historial.aspx");
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
