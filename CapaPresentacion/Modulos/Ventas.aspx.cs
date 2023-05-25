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

                int valorDelDDL2 = Convert.ToInt32(DropDownList1.SelectedValue);

                if (valorDelDDL2 == 1)
                {
                    lbSubtotal.InnerText = "SubTotal";
                    divIva.Visible = true;
                    divPagar.Visible = true;

                    try
                    {
                        NVentas objventaSubTotal = new NVentas();
                        EVentas entsubTotal = new EVentas();
                        DataTable dt = new DataTable();
                        NVentas correlativoSubtotal = new NVentas();

                        DataTable tabla2 = new DataTable();
                        tabla2 = correlativoSubtotal.mostrarCorrelativo(1);
                        int numeroCorrelativo2 = Convert.ToInt32(tabla2.Rows[0]["numero_correlativo"].ToString());
                        int cantidad2 = Convert.ToInt32(tabla2.Rows[0]["cantidad_numero"].ToString());
                        string ceros2 = string.Concat(Enumerable.Repeat("0", cantidad2));
                        string numeroVenta2 = ceros2 + numeroCorrelativo2;
                        numeroVenta2 = numeroVenta2.Substring(numeroVenta2.Length - cantidad2, cantidad2);

                        entsubTotal.comrprobante_venta = numeroVenta2;
                        dt = objventaSubTotal.MostrarSumaSubTotal(entsubTotal);
                        subtotal.InnerHtml = dt.Rows[0]["subtotal"].ToString();
                        double subTotal = Convert.ToDouble(subtotal.InnerText);
                        double iva = subTotal * 0.13;
                        txtIva.InnerText = iva.ToString();
                        double Total = subTotal + iva;
                        txtTotalPagar.InnerHtml = Total.ToString();

                    }
                    catch (Exception)
                    {

                        subtotal.InnerText = "";
                        txtIva.InnerText = "";
                        txtTotalPagar.InnerText = "";
                    }




                }
                else
                {
                    if (subtotal.InnerText == "")
                    {
                        NVentas objventaSubTotal = new NVentas();
                        EVentas entsubTotal = new EVentas();
                        DataTable dt = new DataTable();
                        NVentas correlativoSubtotal = new NVentas();
                        DataTable tabla2 = new DataTable();
                        tabla2 = correlativoSubtotal.mostrarCorrelativo(2);
                        int numeroCorrelativo2 = Convert.ToInt32(tabla2.Rows[0]["numero_correlativo"].ToString());
                        int cantidad2 = Convert.ToInt32(tabla2.Rows[0]["cantidad_numero"].ToString());
                        string ceros2 = string.Concat(Enumerable.Repeat("0", cantidad2));
                        string numeroVenta2 = ceros2 + numeroCorrelativo2;
                        numeroVenta2 = numeroVenta2.Substring(numeroVenta2.Length - cantidad2, cantidad2);

                        entsubTotal.comrprobante_venta = numeroVenta2;
                        dt = objventaSubTotal.MostrarSumaSubTotal(entsubTotal);
                        lbSubtotal.InnerText = "Total a pagar";
                        subtotal.InnerHtml = dt.Rows[0]["subtotal"].ToString();
                        divIva.Visible = false;
                        divPagar.Visible = false;

                    }
                }









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
            int valorDelDDL = Convert.ToInt32(DropDownList1.SelectedValue);
            if (valorDelDDL == 1)
            {
                lbSubtotal.InnerText = "SubTotal";
                divIva.Visible = true;
                divPagar.Visible = true;

                try
                {
                    NVentas objventaSubTotal = new NVentas();
                    EVentas entsubTotal = new EVentas();
                    DataTable dt = new DataTable();
                    NVentas correlativoSubtotal = new NVentas();

                    DataTable tabla2 = new DataTable();
                    tabla2 = correlativoSubtotal.mostrarCorrelativo(1);
                    int numeroCorrelativo2 = Convert.ToInt32(tabla2.Rows[0]["numero_correlativo"].ToString());
                    int cantidad2 = Convert.ToInt32(tabla2.Rows[0]["cantidad_numero"].ToString());
                    string ceros2 = string.Concat(Enumerable.Repeat("0", cantidad2));
                    string numeroVenta2 = ceros2 + numeroCorrelativo2;
                    numeroVenta2 = numeroVenta2.Substring(numeroVenta2.Length - cantidad2, cantidad2);

                    entsubTotal.comrprobante_venta = numeroVenta2;
                    dt = objventaSubTotal.MostrarSumaSubTotal(entsubTotal);
                    subtotal.InnerHtml = dt.Rows[0]["subtotal"].ToString();
                    double subTotal = Convert.ToDouble(subtotal.InnerText);
                    double iva = subTotal * 0.13;
                    txtIva.InnerHtml = iva.ToString();
                    double Total = subTotal + iva;
                    txtTotalPagar.InnerHtml = Total.ToString();

                }
                catch (Exception)
                {

                    subtotal.InnerText = "";
                    txtIva.InnerText = "";
                    txtTotalPagar.InnerText = "";
                }

            }
            else
            {
                if (subtotal.InnerText == "")
                {
                    NVentas objventaSubTotal = new NVentas();
                    EVentas entsubTotal = new EVentas();
                    DataTable dt = new DataTable();
                    NVentas correlativoSubtotal = new NVentas();
                    DataTable tabla2 = new DataTable();
                    tabla2 = correlativoSubtotal.mostrarCorrelativo(2);
                    int numeroCorrelativo2 = Convert.ToInt32(tabla2.Rows[0]["numero_correlativo"].ToString());
                    int cantidad2 = Convert.ToInt32(tabla2.Rows[0]["cantidad_numero"].ToString());
                    string ceros2 = string.Concat(Enumerable.Repeat("0", cantidad2));
                    string numeroVenta2 = ceros2 + numeroCorrelativo2;
                    numeroVenta2 = numeroVenta2.Substring(numeroVenta2.Length - cantidad2, cantidad2);

                    entsubTotal.comrprobante_venta = numeroVenta2;
                    dt = objventaSubTotal.MostrarSumaSubTotal(entsubTotal);
                    lbSubtotal.InnerText = "Total a pagar";
                    subtotal.InnerHtml = dt.Rows[0]["subtotal"].ToString();
                    divIva.Visible = false;
                    divPagar.Visible = false;

                }
                else
                {
                    NVentas objventaSubTotal = new NVentas();
                    EVentas entsubTotal = new EVentas();
                    DataTable dt = new DataTable();
                    NVentas correlativoSubtotal = new NVentas();
                    DataTable tabla2 = new DataTable();
                    tabla2 = correlativoSubtotal.mostrarCorrelativo(2);
                    int numeroCorrelativo2 = Convert.ToInt32(tabla2.Rows[0]["numero_correlativo"].ToString());
                    int cantidad2 = Convert.ToInt32(tabla2.Rows[0]["cantidad_numero"].ToString());
                    string ceros2 = string.Concat(Enumerable.Repeat("0", cantidad2));
                    string numeroVenta2 = ceros2 + numeroCorrelativo2;
                    numeroVenta2 = numeroVenta2.Substring(numeroVenta2.Length - cantidad2, cantidad2);

                    entsubTotal.comrprobante_venta = numeroVenta2;
                    dt = objventaSubTotal.MostrarSumaSubTotal(entsubTotal);
                    lbSubtotal.InnerText = "Total a pagar";
                    subtotal.InnerHtml = dt.Rows[0]["subtotal"].ToString();
                    divIva.Visible = false;
                    divPagar.Visible = false;
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

        protected void GridViewCargarProducto_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void btnTerminarVenta_Click(object sender, EventArgs e)
        {
            NVentas agregarVenta = new NVentas();
            EVenta agregar = new EVenta();

            if (subtotal.InnerText == "")
            {
                string alertError = "Swal.fire({";
                alertError += "icon: 'error',";
                alertError += "title: 'Error',";
                alertError += "text: 'Por favor ingrese un producto',";
                alertError += "})";

                ScriptManager.RegisterClientScriptBlock(
                    this, this.GetType(), "script", alertError, true
                );
                return;
            }

            if (nombre.Value == "")
            {
                string alertError = "Swal.fire({";
                alertError += "icon: 'error',";
                alertError += "title: 'Error',";
                alertError += "text: 'Ingrese un nombre',";
                alertError += "})";

                ScriptManager.RegisterClientScriptBlock(
                    this, this.GetType(), "script", alertError, true
                );
                return;
            }
            else if (Dui.Value == "")
            {
                string alertError = "Swal.fire({";
                alertError += "icon: 'error',";
                alertError += "title: 'Error',";
                alertError += "text: 'Ingrese DUI',";
                alertError += "})";

                ScriptManager.RegisterClientScriptBlock(
                    this, this.GetType(), "script", alertError, true
                );
                return;
            }
            else if (direccion.Value == "")
            {
                string alertError = "Swal.fire({";
                alertError += "icon: 'error',";
                alertError += "title: 'Error',";
                alertError += "text: 'Ingrese direccion',";
                alertError += "})";

                ScriptManager.RegisterClientScriptBlock(
                    this, this.GetType(), "script", alertError, true
                );
                return;
            }
            double num1 = Convert.ToDouble(txtTotalPagar.InnerText);
            double num2 = Convert.ToDouble(txtTotalPagado.Value);

            if (num1 > num2)
            {
                string alertError = "Swal.fire({";
                alertError += "icon: 'error',";
                alertError += "title: 'Error',";
                alertError += "text: 'Tiene saldo pendiente',";
                alertError += "})";

                ScriptManager.RegisterClientScriptBlock(
                    this, this.GetType(), "script", alertError, true
                );
                return;
            }

            if (Convert.ToInt32(DropDownList1.SelectedValue) == 1)
            {

                DataTable tabla = new DataTable();
                tabla = ObjVentas.mostrarCorrelativo(1);
                int numeroCorrelativo = Convert.ToInt32(tabla.Rows[0]["numero_correlativo"].ToString());
                int cantidad = Convert.ToInt32(tabla.Rows[0]["cantidad_numero"].ToString());
                string ceros = string.Concat(Enumerable.Repeat("0", cantidad));
                string numeroVenta = ceros + numeroCorrelativo;
                numeroVenta = numeroVenta.Substring(numeroVenta.Length - cantidad, cantidad);

                agregar.comprobante = numeroVenta;
                agregar.total = Convert.ToDouble(txtTotalPagar.InnerText);
                agregar.documnto = Dui.Value;
                agregar.nombre = nombre.Value;
                agregar.direccion = direccion.Value;
                agregar.tipo = "Ticket";
                if (agregarVenta.InsertVenta(agregar))
                {
                    string alertError = "Swal.fire({";
                    alertError += "icon: 'success',";
                    alertError += "title: 'Creada',";
                    alertError += "text: 'Numero Venta: " + numeroVenta + " ',";
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
                    return;

                }
                else
                {
                    string alertError = "Swal.fire({";
                    alertError += "icon: 'Success',";
                    alertError += "title: 'ads',";
                    alertError += "text: 'sdasdas' ,";
                    alertError += "})";

                    ScriptManager.RegisterClientScriptBlock(
                        this, this.GetType(), "script", alertError, true
                    );
                    return;
                }

            }
            else if(Convert.ToInt32(DropDownList1.SelectedValue) == 2)
            {
                DataTable tabla = new DataTable();
                tabla = ObjVentas.mostrarCorrelativo(2);
                int numeroCorrelativo = Convert.ToInt32(tabla.Rows[0]["numero_correlativo"].ToString());
                int cantidad = Convert.ToInt32(tabla.Rows[0]["cantidad_numero"].ToString());
                string ceros = string.Concat(Enumerable.Repeat("0", cantidad));
                string numeroVenta = ceros + numeroCorrelativo;
                numeroVenta = numeroVenta.Substring(numeroVenta.Length - cantidad, cantidad);

                agregar.comprobante = numeroVenta;
                agregar.total = Convert.ToDouble(txtTotalPagar.InnerText);
                agregar.documnto = Dui.Value;
                agregar.nombre = nombre.Value;
                agregar.direccion = direccion.Value;
                agregar.tipo = "Factura";
                if (agregarVenta.InsertVenta(agregar))
                {
                    string alertError = "Swal.fire({";
                    alertError += "icon: 'success',";
                    alertError += "title: 'Creada',";
                    alertError += "text: 'Numero Venta: " + numeroVenta + " ',";
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
                    return;

                }
                else
                {
                    string alertError = "Swal.fire({";
                    alertError += "icon: 'Success',";
                    alertError += "title: 'ads',";
                    alertError += "text: 'sdasdas' ,";
                    alertError += "})";

                    ScriptManager.RegisterClientScriptBlock(
                        this, this.GetType(), "script", alertError, true
                    );
                    return;
                }
            }
        }
    }
}