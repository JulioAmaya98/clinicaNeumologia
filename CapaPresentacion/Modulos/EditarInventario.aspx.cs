using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Modulos
{
	public partial class EditarInventario : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			EProducto eProducto = new EProducto();
			EInventario inventario = new EInventario();
			NInventario nInventario=new NInventario();
			NProducto producto=new NProducto();
			DataTable tabla = new DataTable();
			string encrypMedico = Encriptar("Medico");
			string encryBodeguero = Encriptar("Bodeguero");

			if (!IsPostBack)
			{
				if (Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico)
				{
					int idInventario = Convert.ToInt32(Request.QueryString["id_inventario"].ToString());
					inventario.id_inventario = idInventario;
					tabla = nInventario.editarInventarioByID(inventario);

					dropCodigoProducto.SelectedValue = tabla.Rows[0]["codigo_producto"].ToString();
					dropProveedor.SelectedValue = tabla.Rows[0]["IdProveedor"].ToString();
					TextBoxStock.Text = tabla.Rows[0]["cantidad"].ToString();
					TextBoxFechaVencimiento.Text = tabla.Rows[0]["fecha_vencimiento"].ToString();
					
					txtLote.Text = tabla.Rows[0]["lote"].ToString();
					txtUbicacion.Text = tabla.Rows[0]["ubicacion"].ToString();


					dropProveedor.DataSource = producto.mostrarProductoProveedor();
					dropProveedor.DataTextField = "Vendedor";
					dropProveedor.DataValueField = "IdProveedor";
					dropProveedor.DataBind();
					dropProveedor.SelectedIndexChanged += new EventHandler(dropProveedor_SelectedIndexChanged);

					eProducto.id_proveedor = Convert.ToInt32(dropProveedor.SelectedValue.ToString());
					dropCodigoProducto.DataSource = producto.mostrarProductosDrop(eProducto);
					dropCodigoProducto.DataTextField = "codigo_producto";
					dropCodigoProducto.DataValueField = "codigo_producto";
					dropCodigoProducto.DataBind();

				}
				else if (Request.QueryString["rol"] == encryBodeguero && Session["username"].ToString() == encryBodeguero)
				{


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

		protected void dropProveedor_SelectedIndexChanged(object sender, EventArgs e)
		{
			NProducto producto = new NProducto();

			EProducto productos = new EProducto();
			productos.id_proveedor = Convert.ToInt32(dropProveedor.SelectedValue.ToString());
			dropCodigoProducto.DataSource = producto.mostrarProductosDrop(productos);
			dropCodigoProducto.DataTextField = "codigo_producto";
			dropCodigoProducto.DataValueField = "codigo_producto";
			dropCodigoProducto.DataBind();
		}

		protected void ButtonGuardar_Click(object sender, EventArgs e)
		{
			NInventario nInventario = new NInventario();
			EInventario inventario = new EInventario();
			inventario.id_inventario = Convert.ToInt32(Request.QueryString["id_inventario"].ToString());
			inventario.codigo_producto = dropCodigoProducto.SelectedValue.ToString();
			inventario.id_proveedor = Convert.ToInt32(dropProveedor.SelectedValue.ToString());
			inventario.cantidad = Convert.ToInt32(TextBoxStock.Text);
			inventario.fecha_entrada = Convert.ToDateTime(txtFechaEntrada.Text);
			inventario.fecha_vencimiento = Convert.ToDateTime(TextBoxFechaVencimiento.Text);
			inventario.lote = Convert.ToInt32(txtLote.Text);
			inventario.ubicacion = txtUbicacion.Text;
			nInventario.editarInventario(inventario);
			Response.Redirect("Inventario.aspx?rol=" + Request.QueryString["rol"]);

		}
	}
}