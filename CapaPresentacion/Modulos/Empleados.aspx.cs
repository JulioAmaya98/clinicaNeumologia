using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CapaPresentacion
{
    public partial class Inicio : BasePage
    {
        NUsuarios objusuario = new NUsuarios();
        EUsuarios EUsuarios = new EUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            
                string encryp = Encriptar("Medico");
                if (Request.QueryString["rol"] ==encryp && Session["username"].ToString()==encryp)
                {
                   
					if (Request["id"] != null)
					{

						int id = int.Parse(Request["id"]);
						EUsuarios.id_usuario = id;


						if (objusuario.eliminarUsuarios(EUsuarios))
						{
						string alertSuccess = "Swal.fire({";
						alertSuccess += "icon: 'success',";
						alertSuccess += "title: 'Successful',";
						alertSuccess += "text: 'El empleado se elimino correctamente',";
						alertSuccess += "confirmButtonText: 'OK'";
						alertSuccess += "}).then((result) => {";
						alertSuccess += "if (result.isConfirmed) {";
						alertSuccess += "window.location.href = 'Empleados.aspx?rol=" + Request.QueryString["rol"] + "';";
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
							alertError += "text: 'El empleado no pudo ser eliminado',";
							alertError += "footer: '<a>Ingresa aqui para obtener más información?</a>'";
							alertError += "})";

							ScriptManager.RegisterClientScriptBlock(
								this, this.GetType(), "script", alertError, true
							);
						}

					}
					foreach (GridViewRow row in GridViewUsuarios.Rows)
                    {
                        if (row.Cells[3].Text == "JL")
                        {
                            row.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("../Layout/Login.aspx");

                }

           
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarUsuarios.aspx?rol=" + Request.QueryString["rol"]);
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

        
    }
}