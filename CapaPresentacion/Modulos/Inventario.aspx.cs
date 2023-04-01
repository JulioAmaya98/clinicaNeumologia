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
    public partial class ProductosBodega : BasePage
    {
        NInventario nproductos = new NInventario();
        protected void Page_Load(object sender, EventArgs e)
        {


			EInventario inventario = new EInventario();
			NInventario nInventario = new NInventario();
			string encrypMedico = Encriptar("Medico");
			string encryBodeguero = Encriptar("Bodeguero");

			if (Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico)
			{
				if (Request["id"] != null)
				{

					int id = int.Parse(Request["id"]);
					inventario.id_inventario = id;


					if (nInventario.eliminarInventario(inventario))
					{
						string alertSuccess = "Swal.fire({";
						alertSuccess += "icon: 'success',";
						alertSuccess += "title: 'Successful',";
						alertSuccess += "text: 'El producto se elimino correctamente',";
						alertSuccess += "confirmButtonText: 'OK'";
						alertSuccess += "}).then((result) => {";
						alertSuccess += "if (result.isConfirmed) {";
						alertSuccess += "window.location.href = 'Inventario.aspx?rol=" + Request.QueryString["rol"] + "';";
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
						alertError += "text: 'El producto no pudo ser eliminado. Tienes una cantidad mayor a 0',";
						alertError += "confirmButtonColor: '#3085d6',";
						alertError += "confirmButtonText: 'OK'";
						alertError += "}).then((result) => {";
						alertError += "if (result.isConfirmed) {";
						alertError += "window.location.href = 'Inventario.aspx?rol=" + Request.QueryString["rol"] + "';";
						alertError += "}";
						alertError += "});";

						ScriptManager.RegisterStartupScript(
							this, this.GetType(), "script", alertError, true
						);
					}

				}
			}
			else if (Request.QueryString["rol"] == encryBodeguero && Session["username"].ToString() == encryBodeguero)
			{

				navEmpleados.Visible = false;
				navProductos.Visible = false;
				navProveedores.Visible= false;
				if (Request["id"] != null)
				{

					int id = int.Parse(Request["id"]);
					inventario.id_inventario = id;


					if (nInventario.eliminarInventario(inventario))
					{
						string alertSuccess = "Swal.fire({";
						alertSuccess += "icon: 'success',";
						alertSuccess += "title: 'Successful',";
						alertSuccess += "text: 'El producto se elimino correctamente',";
						alertSuccess += "confirmButtonText: 'OK'";
						alertSuccess += "}).then((result) => {";
						alertSuccess += "if (result.isConfirmed) {";
						alertSuccess += "window.location.href = 'Inventario.aspx?rol=" + Request.QueryString["rol"] + "';";
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
						alertError += "text: 'El producto no pudo ser eliminado. Tienes una cantidad mayor a 0',";
						alertError += "confirmButtonColor: '#3085d6',";
						alertError += "confirmButtonText: 'OK'";
						alertError += "}).then((result) => {";
						alertError += "if (result.isConfirmed) {";
						alertError += "window.location.href = 'Inventario.aspx?rol=" + Request.QueryString["rol"] + "';";
						alertError += "}";
						alertError += "});";

						ScriptManager.RegisterStartupScript(
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

		protected void gridProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProducto.PageIndex = e.NewPageIndex;


            gridProducto.DataBind();
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

        

		protected void btnAgregar_Click(object sender, EventArgs e)
		{
			Response.Redirect("AgregarInventario.aspx?rol=" + Request.QueryString["rol"]);

		}

		protected void gridProducto_RowDataBound(object sender, GridViewRowEventArgs e)
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
