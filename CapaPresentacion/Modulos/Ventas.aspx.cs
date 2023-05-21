using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;

namespace CapaPresentacion.Modulos
{
    public partial class Ventas : System.Web.UI.Page
    {
        NVentas ObjVentas = new NVentas();
        NProducto NProducto = new NProducto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = ObjVentas.mostrarTipoPago();
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataValueField = "id_tipoPago";
                DropDownList1.DataBind();



                GridViewCargarProducto.DataSource = NProducto.mostrarAll();
                GridViewCargarProducto.DataBind();

                string tipo = DropDownList1.SelectedValue;
                int corre = Convert.ToInt32(tipo);
                DataTable tabla = new DataTable();
                tabla = ObjVentas.mostrarCorrelativo(corre);
                int numeroCorrelativo = Convert.ToInt32(tabla.Rows[0]["numero_correlativo"].ToString());
                int cantidad = Convert.ToInt32(tabla.Rows[0]["cantidad_numero"].ToString());
                string ceros = string.Concat(Enumerable.Repeat("0", cantidad));
                string numeroVenta = ceros + numeroCorrelativo;
                numeroVenta = numeroVenta.Substring(numeroVenta.Length - cantidad, cantidad);
                Label1.Text = "#" + numeroVenta;

                NVentas verDetalleVenta = new NVentas();
                EVentas EMostrarDV = new EVentas();
                EMostrarDV.comrprobante_venta = numeroVenta;

                gridviewDetalleVenta.DataSource = verDetalleVenta.MostrarDetalleVenta(EMostrarDV);
                gridviewDetalleVenta.DataBind();




                if (Request.QueryString["idProducto"] != null && Request.QueryString["cantidad"] != null)
                {
                    NVentas proveedorVenta = new NVentas();
                    EVentas venta = new EVentas();
                    EVentas detalleVenta = new EVentas();
                    DataTable tablita = new DataTable();
                    NVentas insertVentas = new NVentas();

                    int id = Convert.ToInt32(Request.QueryString["idProducto"].ToString());
                    venta.id_producto = id;

                    try
                    {

                        tablita = proveedorVenta.verProveedor(venta);
                        detalleVenta.codigo_producto = tablita.Rows[0]["codigo_producto"].ToString();
                        detalleVenta.id_proveedor = Convert.ToInt32(tablita.Rows[0]["id_proveedor"].ToString());
                        detalleVenta.cantidad = Convert.ToInt32(Request.QueryString["cantidad"].ToString());
                        detalleVenta.comrprobante_venta = numeroVenta;
                        if (insertVentas.InsertDetalleVenta(detalleVenta))
                        {
                            string alertError = "Swal.fire({";
                            alertError += "icon: 'success',";
                            alertError += "title: 'Agregado',";
                            alertError += "text: 'Producto agregado exitosamente',";
                            alertError += "confirmButtonColor: '#3085d6',";
                            alertError += "confirmButtonText: 'OK'";
                            alertError += "}).then((result) => {";
                            alertError += "if (result.isConfirmed) {";
                            alertError += "window.location.href = 'Ventas.aspx';";
                            alertError += "}";
                            alertError += "});";

                            ScriptManager.RegisterStartupScript(
                                this, this.GetType(), "script", alertError, true
                            );

                        }
                        else
                        {

                        }

                    }
                    catch (Exception)
                    {
                        string alertError = "Swal.fire({";
                        alertError += "icon: 'error',";
                        alertError += "title: 'Error',";
                        alertError += "text: 'agregue una cantidad correcta',";
                        alertError += "confirmButtonColor: '#3085d6',";
                        alertError += "confirmButtonText: 'OK'";
                        alertError += "}).then((result) => {";
                        alertError += "if (result.isConfirmed) {";
                        alertError += "window.location.href = 'Ventas.aspx';";
                        alertError += "}";
                        alertError += "});";

                        ScriptManager.RegisterStartupScript(
                            this, this.GetType(), "script", alertError, true
                        );

                    }

                }

            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {


            int tipo = Convert.ToInt32(DropDownList1.SelectedValue);

            DataTable tabla = new DataTable();
            tabla = ObjVentas.mostrarCorrelativo(tipo);
            int numeroCorrelativo = Convert.ToInt32(tabla.Rows[0]["numero_correlativo"].ToString());
            int cantidad = Convert.ToInt32(tabla.Rows[0]["cantidad_numero"].ToString());
            string ceros = string.Concat(Enumerable.Repeat("0", cantidad));
            string numeroVenta = ceros + numeroCorrelativo;
            numeroVenta = numeroVenta.Substring(numeroVenta.Length - cantidad, cantidad);
            Label1.Text = "#" + numeroVenta;

            NVentas verDetalleVenta = new NVentas();
            EVentas EMostrarDV = new EVentas();
            EMostrarDV.comrprobante_venta = numeroVenta;

            gridviewDetalleVenta.DataSource = verDetalleVenta.MostrarDetalleVenta(EMostrarDV);
            gridviewDetalleVenta.DataBind();
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx?rol=" + Request["rol"]);
        }
    }
}