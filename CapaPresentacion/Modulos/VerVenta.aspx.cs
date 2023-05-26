using CapaEntidad;
using CapaNegocio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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
    public partial class VerVenta : System.Web.UI.Page
    {
        NVentas ObjVentas = new NVentas();
        NProducto NProducto = new NProducto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                string encrypMedico = Encriptar("Medico");

                string encrypSecretaria = Encriptar("Secretaria");


                if (Request.QueryString["rol"] == encrypMedico && Session["username"].ToString() == encrypMedico || Request.QueryString["rol"] == encrypSecretaria && Session["username"].ToString() == encrypSecretaria)
                {
                    if (Request.QueryString["nFactura"] != null)
                    {
                        Label1.Text = Request.QueryString["nFactura"];

                        DropDownList1.Enabled = false;

                        NVentas objventaSubTotal = new NVentas();
                        EVentas entsubTotal = new EVentas();
                        DataTable dt = new DataTable();

                        entsubTotal.comrprobante_venta = Label1.Text;
                        dt = objventaSubTotal.MostrarSumaSubTotal(entsubTotal);
                        lbSubtotal.InnerText = "SubTotal";
                        subtotal.InnerHtml = dt.Rows[0]["subtotal"].ToString();

                        DataTable tablita = new DataTable();
                        NVentas NDataCliente = new NVentas();
                        EVenta dataCliente = new EVenta();

                        dataCliente.comprobante = Label1.Text;
                        tablita = NDataCliente.VerClienteData(dataCliente);

                        string dui = tablita.Rows[0]["documento"].ToString();
                        Dui.InnerText = dui;
                        string nombre = tablita.Rows[0]["nombre"].ToString();
                        txtNombre.InnerText = nombre;
                        string direccion2 = tablita.Rows[0]["direccion"].ToString();
                        direccion.InnerText = direccion2;
                        DateTime fecha = Convert.ToDateTime(tablita.Rows[0]["fecha_venta"].ToString());
                        txtFecha.Text ="Fecha: " + fecha.ToString("dd/MM/yyyy")+"  Hora: "+fecha.ToString("HH:mm");

                        Label1.Text = "#" + Request.QueryString["nFactura"];

                        string noje= tablita.Rows[0]["tipo"].ToString();
                        int valor = 0;
                        if (noje == "Ticket")
                        {
                            valor = 1;
                        }
                        else
                        {
                            valor = 2;
                        }
                        DropDownList1.SelectedValue = valor.ToString();

                        



                        if (valor==1)
                        {
                            try
                            {
                           

                                double aux = Convert.ToDouble(subtotal.InnerText);
                                subtotal.InnerText = aux.ToString("N2");
                                double subtotalReal = Convert.ToDouble(subtotal.InnerText);
                                double auxImpuestoReal = subtotalReal * 0.13;
                                txtIva.InnerText = auxImpuestoReal.ToString("N2");

                                double impuestoReal = Convert.ToDouble(txtIva.InnerText);
                                double auxTotal = aux + auxImpuestoReal;

                                txtTotalPagar.InnerText = auxTotal.ToString("N2");
                            }
                            catch (Exception)
                            {

                                subtotal.InnerHtml = "0.00";
                                txtIva.InnerHtml = "0.00";
                                txtTotalPagar.InnerText = "0.00";
                            }


                        }
                        else
                        {
                            lbSubtotal.InnerText = "Total";
                            double aux = Convert.ToDouble(subtotal.InnerText);
                            subtotal.InnerText = aux.ToString("N2");
                            divIva.Visible = false;
                            divPagar.Visible = false;




                        }








                    }












                    DropDownList1.DataSource = ObjVentas.mostrarTipoPago();
                    DropDownList1.DataTextField = "nombre";
                    DropDownList1.DataValueField = "id_tipoPago";
                    DropDownList1.DataBind();

                    EProducto producto = new EProducto();
                    producto.id_proveedor = Convert.ToInt32(DropDownList1.SelectedValue);



                   





                    DataTable mostrarDetalleCompra = new DataTable();
                    EVenta detalleCompra = new EVenta();
                    NVentas nDetalleCompra = new NVentas();
                    detalleCompra.comprobante = Request.QueryString["nFactura"].ToString();
                    gridviewDetalleVenta.DataSource = nDetalleCompra.VerDetalleVenta(detalleCompra);
                    gridviewDetalleVenta.DataBind();



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

        protected void btnImprimirVenta_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(DropDownList1.SelectedValue);
            if (valor == 1)
            {
                byte[] archivoPDF = GenerarPDFTicket();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmm") + ".pdf");
                Response.BinaryWrite(archivoPDF);
                Response.End();
            }
            else
            {
                byte[] archivoPDF = GenerarPDFFactura();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmm") + ".pdf");
                Response.BinaryWrite(archivoPDF);
                Response.End();
            }

            


            
        }
        private byte[] GenerarPDFTicket()
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

            PdfPCell dui = new PdfPCell(new Phrase("DUI: " + Dui.InnerText));
            dui.Border = Rectangle.NO_BORDER;
            infoTable.AddCell(dui);

            PdfPCell cliente = new PdfPCell(new Phrase("Nombre del cliente: " + txtNombre.InnerText));
            cliente.Border = Rectangle.NO_BORDER;
            infoTable.AddCell(cliente);

            PdfPCell direcciona = new PdfPCell(new Phrase("Direccion: " + direccion.InnerText));
            direcciona.Border = Rectangle.NO_BORDER;
            infoTable.AddCell(direcciona);


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






            for (int i = 0; i < gridviewDetalleVenta.Columns.Count; i++)
            {
                PdfPCell headerCell = new PdfPCell();
                headerCell.BackgroundColor = new BaseColor(220, 220, 220);
                headerCell.BorderColor = BaseColor.GRAY;
                headerCell.Padding = 5;
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;

                if (i >= 3)
                {
                    Font smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 8f);
                    headerCell.Phrase = new Phrase(gridviewDetalleVenta.Columns[i].HeaderText, smallFont);
                }
                else
                {
                    headerCell.Phrase = new Phrase(gridviewDetalleVenta.Columns[i].HeaderText);
                }

                table.AddCell(headerCell);
            }



            for (int i = 0; i < gridviewDetalleVenta.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewDetalleVenta.Columns.Count; j++)
                {
                    PdfPCell dataCell = new PdfPCell(new Phrase(gridviewDetalleVenta.Rows[i].Cells[j].Text));
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
            impuestoParagraph.Add(new Chunk(txtIva.InnerText, FontFactory.GetFont(FontFactory.HELVETICA, 12f)));
            impuestoParagraph.Add(new Chunk(" USD", FontFactory.GetFont(FontFactory.HELVETICA, 12f)));


            document.Add(impuestoParagraph);


            Paragraph totalParagraph = new Paragraph();
            totalParagraph.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f);
            totalParagraph.Alignment = Element.ALIGN_RIGHT;
            totalParagraph.Add("Total: ");
            totalParagraph.Add(new Chunk(txtTotalPagar.InnerText, FontFactory.GetFont(FontFactory.HELVETICA, 12f)));
            totalParagraph.Add(new Chunk(" USD", FontFactory.GetFont(FontFactory.HELVETICA, 12f)));

            document.Add(totalParagraph);


            document.Close();


            return memoryStream.ToArray();
        }

        private byte[] GenerarPDFFactura()
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

            PdfPCell dui = new PdfPCell(new Phrase("DUI: " + Dui.InnerText));
            dui.Border = Rectangle.NO_BORDER;
            infoTable.AddCell(dui);

            PdfPCell cliente = new PdfPCell(new Phrase("Nombre del cliente: " + txtNombre.InnerText));
            cliente.Border = Rectangle.NO_BORDER;
            infoTable.AddCell(cliente);

            PdfPCell direcciona = new PdfPCell(new Phrase("Direccion: " + direccion.InnerText));
            direcciona.Border = Rectangle.NO_BORDER;
            infoTable.AddCell(direcciona);


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






            for (int i = 0; i < gridviewDetalleVenta.Columns.Count; i++)
            {
                PdfPCell headerCell = new PdfPCell();
                headerCell.BackgroundColor = new BaseColor(220, 220, 220);
                headerCell.BorderColor = BaseColor.GRAY;
                headerCell.Padding = 5;
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;

                if (i >= 3)
                {
                    Font smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 8f);
                    headerCell.Phrase = new Phrase(gridviewDetalleVenta.Columns[i].HeaderText, smallFont);
                }
                else
                {
                    headerCell.Phrase = new Phrase(gridviewDetalleVenta.Columns[i].HeaderText);
                }

                table.AddCell(headerCell);
            }



            for (int i = 0; i < gridviewDetalleVenta.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewDetalleVenta.Columns.Count; j++)
                {
                    PdfPCell dataCell = new PdfPCell(new Phrase(gridviewDetalleVenta.Rows[i].Cells[j].Text));
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
            subtotalParagraph.Add("Total: ");
            subtotalParagraph.Add(new Chunk(subtotal.InnerText, FontFactory.GetFont(FontFactory.HELVETICA, 12f)));
            subtotalParagraph.Add(new Chunk(" USD", FontFactory.GetFont(FontFactory.HELVETICA, 12f)));


            document.Add(subtotalParagraph);

            document.Close();


            return memoryStream.ToArray();
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistorialVenta.aspx?rol=" + Request.QueryString["rol"]);
        }
    }
}