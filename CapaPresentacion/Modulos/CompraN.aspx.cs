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
	public partial class CompraN : System.Web.UI.Page
	{

		NProducto NProductos = new NProducto();
		protected void Page_Load(object sender, EventArgs e)
		{
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("dd/MM/yyyy");
            lblFechaActual.Text =   formattedDate;
            Label1.Text=  formattedDate;

            if (!IsPostBack)
			{
               

                string encrypMedico = Encriptar("Medico");

				string encrypSecretaria = Encriptar("Secretaria");


				if (Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico || Request.QueryString["rol"] == encrypSecretaria && Session["username"].ToString() == encrypSecretaria)
				{
					if (Request.QueryString["nFactura"] != null)
					{
						TextBox3.Text = Request.QueryString["nFactura"];
						TextBox3.ReadOnly = true;
						DropDownList2.Enabled = false;
						

						DataTable tableSubTotal2 = new DataTable();
						NCompra compra22 = new NCompra();
						ECompra comprita2 = new ECompra();
						comprita2.comprobante_compra = TextBox3.Text;
						tableSubTotal2 = compra22.Subtotal(comprita2);
						subtotal.InnerText = tableSubTotal2.Rows[0]["subtotal"].ToString();

						if (subtotal.InnerText!="0.00")
						{
							try
							{
                                DataTable tableSubTotal = new DataTable();
                                NCompra compra2 = new NCompra();
                                ECompra comprita = new ECompra();
                                comprita.comprobante_compra = TextBox3.Text;
                                tableSubTotal = compra2.Subtotal(comprita);
                                subtotal.InnerText = tableSubTotal.Rows[0]["subtotal"].ToString();

                                double aux = Convert.ToDouble(subtotal.InnerText);
                                subtotal.InnerText = aux.ToString("N2");
                                double subtotalReal = Convert.ToDouble(subtotal.InnerText);
                                double auxImpuestoReal = subtotalReal * 0.13;
                                impuesto.InnerText = auxImpuestoReal.ToString("N2");

                                double impuestoReal = Convert.ToDouble(impuesto.InnerText);
                                double auxTotal = aux + auxImpuestoReal;

                                Label4.Text = auxTotal.ToString("N2");
                            }
							catch (Exception)
							{

                                subtotal.InnerHtml = "0.00";
                                impuesto.InnerHtml = "0.00";
                                Label4.Text = "0.00";
                            }
							

						}
						else
						{
							subtotal.InnerHtml = "0.00";
							impuesto.InnerHtml = "0.00";
							Label4.Text = "0.00";



						}
					}

					if (Request["id"] != null)
					{
						NCompra eliminarCompra = new NCompra();
						int id = int.Parse(Request["id"]);

						if (eliminarCompra.eliminarDetalleCompra(id))
						{
							Response.Redirect("CompraN.aspx?rol=" + Request.QueryString["rol"] + "&nFactura=" + Request["nFactura"].ToString());
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






						DropDownList2.DataSource = NProductos.mostrarProductoProveedor();
					DropDownList2.DataTextField = "Vendedor";
					DropDownList2.DataValueField = "IdProveedor";
					DropDownList2.DataBind();

					EProducto producto = new EProducto();
					producto.id_proveedor = Convert.ToInt32(DropDownList2.SelectedValue);

					gridProducto.DataSource = NProductos.mostrarProductosDrop(producto);
					gridProducto.DataBind();

					DataTable tabla = new DataTable();
					NProveedores nProveedores = new NProveedores();
					EUProveedor proveedor = new EUProveedor();
					proveedor.Id = Convert.ToInt32(DropDownList2.SelectedValue);
					tabla = nProveedores.DataProveedores(proveedor);
					proveedorName.InnerText = tabla.Rows[0]["Vendedor"].ToString();
					proveedorDireccion.InnerText = tabla.Rows[0]["Direccion"].ToString();
					proveedorTelefono.InnerText = tabla.Rows[0]["Contacto"].ToString();


		


					DataTable mostrarDetalleCompra = new DataTable();
					ECompra detalleCompra = new ECompra();
					NCompra nDetalleCompra = new NCompra();
					detalleCompra.comprobante_compra = TextBox3.Text;
					GridView1.DataSource = nDetalleCompra.MostrarDetalleCompra(detalleCompra);
					GridView1.DataBind();



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

		protected DataTable ObtenerDatosProveedor(int proveedorId)
		{
			EProducto producto = new EProducto();
			producto.id_proveedor = proveedorId;
			return NProductos.mostrarProductosDrop(producto);

		}



		protected void Button2_Click(object sender, EventArgs e)
		{
			


			bool productoAgregado = false;
			NCompra ExistenciaCompra = new NCompra();
			ECompra lCExistenciaCompra = new ECompra();
			lCExistenciaCompra.comprobante_compra = TextBox3.Text;

			if (ExistenciaCompra.ExistenciaCompra(lCExistenciaCompra))
			{
				foreach (GridViewRow row in gridProducto.Rows)
				{
					CheckBox checkBox = (CheckBox)row.FindControl("CheckBox1");

					if (checkBox.Checked && TextBox1.Text != "" && TextBox3.Text.Trim() != "")
					{
						NCompra ncompra = new NCompra();
						ECompra compra = new ECompra();
						compra.codigo_producto = row.Cells[1].Text;
						compra.id_proveedor = Convert.ToInt32(DropDownList2.SelectedValue);
						compra.cantidad = Convert.ToInt32(TextBox1.Text);
						compra.comprobante_compra = TextBox3.Text;
						ncompra.Insertar(compra);
						
						productoAgregado = true;
						checkBox.Checked = false;
						TextBox3.ReadOnly = true;
						DropDownList2.Enabled = false;
						DataTable mostrarDetalleCompra = new DataTable();
						ECompra detalleCompra = new ECompra();
						NCompra nDetalleCompra = new NCompra();
						detalleCompra.comprobante_compra = TextBox3.Text;
						GridView1.DataSource = nDetalleCompra.MostrarDetalleCompra(detalleCompra);
						GridView1.DataBind();

					}
					checkBox.Checked = false;
				}
				
			}
			else
			{
				string alertError = "Swal.fire({";
				alertError += "icon: 'error',";
				alertError += "title: 'Error',";
				alertError += "text: 'Ya existe el numero de factura',";
				alertError += "})";

				ScriptManager.RegisterClientScriptBlock(
					this, this.GetType(), "script", alertError, true
				);
				productoAgregado = true;

			

			}
			


			if (!productoAgregado)
			{
				string alertError = "Swal.fire({";
				alertError += "icon: 'error',";
				alertError += "title: 'Error',";
				alertError += "text: 'Error al agregar el producto',";
				alertError += "})";

				ScriptManager.RegisterClientScriptBlock(
					this, this.GetType(), "script", alertError, true
				);
			}
            if (productoAgregado)
            {
                DataTable tableSubTotal = new DataTable();
                NCompra compra2 = new NCompra();
                ECompra comprita = new ECompra();
                comprita.comprobante_compra = TextBox3.Text;
                tableSubTotal = compra2.Subtotal(comprita);
                subtotal.InnerText = tableSubTotal.Rows[0]["subtotal"].ToString();
                double aux = Convert.ToDouble(subtotal.InnerText);
                subtotal.InnerText = aux.ToString("N2");
                double subtotalReal = Convert.ToDouble(subtotal.InnerText);
                double auxImpuestoReal = subtotalReal * 0.13;
                impuesto.InnerText = auxImpuestoReal.ToString("N2");

                double impuestoReal = Convert.ToDouble(impuesto.InnerText);
                double auxTotal = aux + auxImpuestoReal;

                Label4.Text = auxTotal.ToString("N2");
            }
            TextBox1.Text = "";
		}

		protected void ActualizarFila(object sender, GridViewUpdateEventArgs e)
		{

			string codigoProducto = e.Keys["Codigo del producto"].ToString();
			string nombre = e.NewValues["nombre"].ToString();
			string descripcion = e.NewValues["descripcion"].ToString();
			decimal precio = Convert.ToDecimal(e.NewValues["precio"]);
			int cantidad = Convert.ToInt32(e.NewValues["cantidad"]);
			decimal subtotal = Convert.ToDecimal(e.NewValues["subtotal"]);
			GridView1.EditIndex = -1;

		}


		protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
		{
			EProducto producto = new EProducto();
			producto.id_proveedor = Convert.ToInt32(DropDownList2.SelectedValue);

			gridProducto.DataSource = NProductos.mostrarProductosDrop(producto);
			gridProducto.DataBind();

			DataTable tabla = new DataTable();
			NProveedores nProveedores = new NProveedores();
			EUProveedor proveedor = new EUProveedor();
			proveedor.Id = Convert.ToInt32(DropDownList2.SelectedValue);
			tabla = nProveedores.DataProveedores(proveedor);
			proveedorName.InnerText = tabla.Rows[0]["Vendedor"].ToString();
			proveedorDireccion.InnerText = tabla.Rows[0]["Direccion"].ToString();
			proveedorTelefono.InnerText = tabla.Rows[0]["Contacto"].ToString();

		}

		protected void Button1_Click(object sender, EventArgs e)
		{

		}

		protected void btnGuardar_Click(object sender, EventArgs e)
		{
			NCompra nCompra = new NCompra();
			ECompra compra = new ECompra();
			if (TextBox3.Text!="")
			{
				
					if (Label4.Text!="0.00")
					{
						compra.comprobante_compra = TextBox3.Text;
						compra.total = Convert.ToDouble(Label4.Text);
						nCompra.GuardarCompra(compra);
						string alertError = "Swal.fire({";
						alertError += "icon: 'success',";
						alertError += "title: 'Guardado',";
						alertError += "text: 'La compra se realizo exitosamente',";
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
						alertError += "text: 'Por favor agregue un producto',";
						alertError += "})";

						ScriptManager.RegisterClientScriptBlock(
							this, this.GetType(), "script", alertError, true
						);
					}
				
				
			}
			else
			{
				string alertError = "Swal.fire({";
				alertError += "icon: 'error',";
				alertError += "title: 'Error',";
				alertError += "text: 'Por favor ingrese un numero de factura',";
				alertError += "})";

				ScriptManager.RegisterClientScriptBlock(
					this, this.GetType(), "script", alertError, true
				);
			}

		}

		protected void Regresar_Click(object sender, EventArgs e)
		{
			Response.Redirect("HistorialCompras.aspx?rol=" + Request.QueryString["rol"]);
		}

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }
    }
}
