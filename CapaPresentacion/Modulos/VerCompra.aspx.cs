using CapaEntidad;
using CapaNegocio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using Image = iTextSharp.text.Image;
using iTextSharp.text.pdf.draw;
using System.Drawing;
using System.Xml.Linq;
using Rectangle = iTextSharp.text.Rectangle;
using Font = iTextSharp.text.Font;

namespace CapaPresentacion.Modulos
{
    public partial class VerCompra : System.Web.UI.Page
    {
        NProducto NProductos = new NProducto();
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("dd/MM/yyyy");
            lblFechaActual.Text = formattedDate;
            Label1.Text = formattedDate;



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

                        if (subtotal.InnerText != "0.00")
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

                   



                   






                    DropDownList2.DataSource = NProductos.mostrarProductoProveedor();
                    DropDownList2.DataTextField = "Vendedor";
                    DropDownList2.DataValueField = "IdProveedor";
                    DropDownList2.DataBind();

                    EProducto producto = new EProducto();
                    producto.id_proveedor = Convert.ToInt32(DropDownList2.SelectedValue);



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
                    detalleCompra.comprobante_compra = Request.QueryString["nFactura"].ToString();
                    GridView1.DataSource = nDetalleCompra.VerDetalleCompra(detalleCompra);
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

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            string alertError = "Swal.fire({";
            alertError += "icon: 'success',";
            alertError += "title: 'Creado',";
            alertError += "text: 'PDF creado exitosamenre',";
            alertError += "footer: '<a></a>'";
            alertError += "})";

            ScriptManager.RegisterClientScriptBlock(
                this, this.GetType(), "script", alertError, true
            );

            byte[] archivoPDF = GenerarPDF();


            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmm") + ".pdf");
            Response.BinaryWrite(archivoPDF);
            Response.End();

        }
        private byte[] GenerarPDF()
        {

            Document document = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();


            PdfPTable mainTable = new PdfPTable(2);
            mainTable.WidthPercentage = 100;


            PdfPTable infoTable = new PdfPTable(1);
            infoTable.DefaultCell.Border = Rectangle.NO_BORDER;


            PdfPCell clinicNameCell = new PdfPCell(new Phrase("Nombre de la Clínica: Clinica San Miguel"));
            clinicNameCell.Border = Rectangle.NO_BORDER;
            infoTable.AddCell(clinicNameCell);


            PdfPCell phoneCell = new PdfPCell(new Phrase("Teléfono de la empresa: 72783584"));
            phoneCell.Border = Rectangle.NO_BORDER;
            infoTable.AddCell(phoneCell);


            PdfPCell addressCell = new PdfPCell(new Phrase("Dirección de la empresa: San Miguel"));
            addressCell.Border = Rectangle.NO_BORDER;
            infoTable.AddCell(addressCell);


            PdfPCell infoCell = new PdfPCell(infoTable);
            infoCell.Border = Rectangle.NO_BORDER;
            infoCell.PaddingRight = 20;

            infoCell.AddElement(infoTable);
            mainTable.AddCell(infoCell);


            PdfPCell logoCell = new PdfPCell();
            logoCell.Border = Rectangle.NO_BORDER;
            string logoPath = Server.MapPath("~/img/cgundo.jpg");
            Image logo = Image.GetInstance(logoPath);
            logo.ScaleToFit(100f, 100f);
            logo.Alignment = Image.ALIGN_RIGHT;
            logoCell.AddElement(logo);
            mainTable.AddCell(logoCell);


            document.Add(mainTable);

            Paragraph spacing = new Paragraph();
            spacing.SpacingAfter = 10;
            document.Add(spacing);
            float[] columnWidths = { 2f, 2f, 3f, 1f, 1f, 1f };


            PdfPTable table = new PdfPTable(columnWidths);
            table.DefaultCell.Padding = 5;
            table.WidthPercentage = 100;


            table.DefaultCell.BackgroundColor = new BaseColor(240, 240, 240);
            table.DefaultCell.BorderColor = BaseColor.GRAY;






            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                PdfPCell headerCell = new PdfPCell();
                headerCell.BackgroundColor = new BaseColor(220, 220, 220);
                headerCell.BorderColor = BaseColor.GRAY;
                headerCell.Padding = 5;
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;

                if (i >= 3)
                {
                    Font smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 8f);
                    headerCell.Phrase = new Phrase(GridView1.Columns[i].HeaderText, smallFont);
                }
                else
                {
                    headerCell.Phrase = new Phrase(GridView1.Columns[i].HeaderText);
                }

                table.AddCell(headerCell);
            }



            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                for (int j = 0; j < GridView1.Columns.Count; j++)
                {
                    PdfPCell dataCell = new PdfPCell(new Phrase(GridView1.Rows[i].Cells[j].Text));
                    dataCell.Padding = 5;
                    dataCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(dataCell);
                }
            }


            document.Add(table);

            document.Add(new Paragraph(" "));


            Paragraph subtotalParagraph = new Paragraph();
            subtotalParagraph.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f);
            subtotalParagraph.Alignment = Element.ALIGN_RIGHT;
            subtotalParagraph.Add("Subtotal: ");
            subtotalParagraph.Add(new Chunk(subtotal.InnerText, FontFactory.GetFont(FontFactory.HELVETICA, 12f)));
            subtotalParagraph.Add(new Chunk(" USD", FontFactory.GetFont(FontFactory.HELVETICA, 12f)));


            document.Add(subtotalParagraph);


            Paragraph impuestoParagraph = new Paragraph();
            impuestoParagraph.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f);
            impuestoParagraph.Alignment = Element.ALIGN_RIGHT;
            impuestoParagraph.Add("Impuesto: ");
            impuestoParagraph.Add(new Chunk(impuesto.InnerText, FontFactory.GetFont(FontFactory.HELVETICA, 12f)));
            impuestoParagraph.Add(new Chunk(" USD", FontFactory.GetFont(FontFactory.HELVETICA, 12f)));


            document.Add(impuestoParagraph);


            Paragraph totalParagraph = new Paragraph();
            totalParagraph.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f);
            totalParagraph.Alignment = Element.ALIGN_RIGHT;
            totalParagraph.Add("Total: ");
            totalParagraph.Add(new Chunk(Label4.Text, FontFactory.GetFont(FontFactory.HELVETICA, 12f)));
            totalParagraph.Add(new Chunk(" USD", FontFactory.GetFont(FontFactory.HELVETICA, 12f)));

            document.Add(totalParagraph);


            document.Close();


            return memoryStream.ToArray();
        }

    }
}