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


namespace CapaPresentacion.Modulos
{
    public partial class Ventas : System.Web.UI.Page
    {
        NVentas ObjVentas = new NVentas();
        NProducto NProducto = new NProducto();
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.DataSource = ObjVentas.mostrarTipoPago();
            DropDownList1.DataTextField = "nombre";
            DropDownList1.DataValueField = "id_tipoPago";
            DropDownList1.DataBind();


            GridViewCargarProducto.DataSource = NProducto.mostrarAll();
            GridViewCargarProducto.DataBind();

        }


    }
}