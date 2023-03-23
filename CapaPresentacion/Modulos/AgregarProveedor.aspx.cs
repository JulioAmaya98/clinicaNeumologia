﻿using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Modulos
{
    public partial class AgregarProveedor : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string encrypMedico = Encriptar("Medico");

                string encrypSecretaria = Encriptar("Secretaria");


                if (Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico)
                {
                }
                else if (Request.QueryString["rol"] == encrypSecretaria && Session["username"].ToString() == encrypSecretaria)
                {


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
        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            EUProveedor provee = new EUProveedor();
            NProveedores proveedores= new NProveedores();

                provee.nombre = TextBoxNombre.Text;
                provee.direccion = TextBoxDireccion.Text;
                provee.vendedor = TextBoxVendedor.Text;
                provee.telefono = TextBoxTelefono.Text;
                provee.correo = TextBoxCorreo.Text;
                proveedores.agregarProveedor(provee);
            Response.Redirect("proveedores.aspx?rol=" + Request.QueryString["rol"]);
        }
        public void limpiarCampos()
        {
            TextBoxNombre.Text = "";
            TextBoxDireccion.Text = "";
            TextBoxTelefono.Text = "";
            TextBoxCorreo.Text = "";
            TextBoxVendedor.Text = "";
        }

    }
}
