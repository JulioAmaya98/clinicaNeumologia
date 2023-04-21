<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="CompraN.aspx.cs" Inherits="CapaPresentacion.Modulos.CompraN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- Option 1: Include in HTML -->
    <link href="../css/StyleCompras.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
    <script src="../JS/sweetalert2.all.min.js"></script>
    <title></title>
    <style>
        .btnG {
            bottom: 0;
            right: 35px;
        }
    </style>
</head>

<body onload="onPageLoad()">
    <div style="padding: 40px">
        <button style="right: 35px; color: #009933; border-color: #009933;" class="btn btn botonagg" data-toggle="modal" data-target="#modalData">+ Agregar</button>

        <form style="bottom: 0" id="form1" runat="server">

            <asp:Button ID="Regresar" runat="server" Text="Regresar" Style="float: right; border-color: gray; color: gray;" class="btn btn" OnClick="Regresar_Click" />


            <h2>Factura
                <asp:Label runat="server" ID="numeroFactura" ForeColor="#009933"></asp:Label></h2>
            <label>
                Creada el:
                <asp:Label ID="Label1" runat="server" Text="05 Diciembre 2023 8:30 am"></asp:Label>
            </label>

            <div class="text-lef" style="width: 1200px;">
                <div class="row">
                    <div class="col">
                        <label>Factura: </label>
                    </div>
                    <div class="col">
                        <label>Proveedor: </label>
                    </div>

                </div>
                <div class="text-lef" style="width: 1200px;">
                    <div class="row">
                        <div class="col">
                            <asp:TextBox CssClass="form-control" ID="TextBox3" size="1" runat="server" oninput="updateLabel(this.value)"></asp:TextBox>
                        </div>
                        <div class="col">
                            <asp:DropDownList CssClass="btn btnl" ID="DropDownList2" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged1" AutoPostBack="True" runat="server"></asp:DropDownList>
                        </div>


                    </div>
                </div>
                <hr />
            </div>

            <!--aqui el agg -->
            <br />
            <br />
            <div class="">
                <div>
                    <div style="float: left; margin-left: 35px">
                        DATOS DEL PROVEEDOR
                    <h3 style="color: black;" runat="server" id="proveedorName"></h3>
                        <label><i class="bi bi-geo-alt" runat="server" id="proveedorDireccion"></i></label>
                        <br />
                        <label><i class="bi bi-telephone-fill" runat="server" id="proveedorTelefono"></i></label>
                    </div>

                    <div style="text-align: center; float: right; margin-right: 35px">
                        <h1 style="color: #009933;">Factura</h1>
                        <label>
                            #Factura :
                        <asp:Label ID="Label2" runat="server"></asp:Label></label><br />
                        <label>
                            Fecha :
                        <asp:Label ID="Label3" runat="server"></asp:Label></label>

                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <div style="width: 1340px;">

                <asp:GridView AutoGenerateColumns="false" AllowPaging="false" ID="GridView1" runat="server" CssClass="table  table-hover  myGridView" HorizontalAlign="Justify" OnRowUpdating="ActualizarFila">
                    <HeaderStyle BackColor="transparent" ForeColor="#009933" />
                    <RowStyle BackColor="white" />
                    <AlternatingRowStyle BackColor="#E3EAEB" />
                    <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
                    <Columns>


                        <asp:BoundField DataField="Codigo del producto" HeaderText="CODIGO DEL PRODUCTO" SortExpression="Codigo del producto" />
                        <asp:BoundField DataField="nombre" HeaderText="NOMBRE" SortExpression="nombre" />

                        <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCION" SortExpression="descripcion" />
                        <asp:BoundField DataField="precio" HeaderText="PRECIO" SortExpression="precio" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD" SortExpression="cantidad" />
                        <asp:BoundField DataField="subtotal" HeaderText="SUBTOTAL" SortExpression="subtotal" DataFormatString="{0:N2}" />
                    </Columns>
                </asp:GridView>





            </div>


            <!-- Aqui total -->
            <div style="width: 400px; height: 190px; float: right; border: 10px; margin: 0px; margin-right: 135px">
                <div style="padding: 0px; float: left; width: 35%; text-align: justify; margin-left: 60px">
                    <label>Subtotal </label>
                    <br />
                    <label>Impuesto</label><br />
                    <label>TOTAL</label>

                </div>
                <div style="padding: 0px; float: right; width: 5%; text-align: justify;">
                    <label runat="server" id="subtotal">0.00 </label>
                    <br />
                    <label runat="server" id="impuesto">0.00</label><br />
                    <asp:Label ID="Label4" runat="server" Text="0.00"></asp:Label>
                </div>

            </div>



            <!--  Modal-->
            <div class="modal fade" id="modalData" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4>Productos</h4>
                            <div class="container-fluid">
                                <form class="d-flex" role="search">

                                    <input id="myInput" style="margin-right: 1%" class="form-control " placeholder="Search" aria-label="Search">
                                </form>
                            </div>
                            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <asp:Table ID="Table1" runat="server"></asp:Table>

                            <asp:GridView
                                ID="gridProducto" runat="server" CssClass="table table-striped myGridView" HorizontalAlign="Justify">
                                <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                        <div class="modal-footer">
                            <a href="#" onclick="incrementTextBoxValue(-1)"><i class="bi bi-dash"></i></a>
                            <asp:TextBox ID="TextBox1" runat="server" Size="3" placeholder="Cantidad"></asp:TextBox>
                            <a href="#" onclick="incrementTextBoxValue(1)"><i class="bi bi-plus"></i></a>
                            <asp:Button ID="Button2" class="btn btn-primary btn-sm" runat="server" Text="Agregar" OnClick="Button2_Click" />
                            <asp:HiddenField ID="Button2Clicked" runat="server" Value="0" />
                            <button class="btn btn-danger btn-sm" type="button" data-dismiss="modal">Cancel</button>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success btnG" OnClick="btnGuardar_Click" />
        </form>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe" crossorigin="anonymous"></script>




    </div>
</body>
<script>
    function incrementTextBoxValue(increment) {
        var textBox = document.getElementById("TextBox1");
        var currentValue = parseInt(textBox.value) || 0;
        var newValue = currentValue + increment;
        if (newValue < 0) newValue = 0;
        textBox.value = newValue;
    }

    function updateLabel(text) {
        var label = document.getElementById("<%= Label2.ClientID %>");
        var label2 = document.getElementById("<%= numeroFactura.ClientID %>")
        label.textContent = text;
        label2.textContent = "#" + text;


        saveLabelValue(text);
    }
    function onPageLoad() {

        var textBoxValue = document.getElementById("<%= TextBox3.ClientID %>").value;
        updateLabel(textBoxValue);


        var labelValue = document.getElementById("<%= Label2.ClientID %>").textContent;
        if (labelValue != "") {
            updateLabel(labelValue);
        }
    }

</script>

<script>
    $(document).ready(function () {
        $("#myInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("#gridProducto tbody tr").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    });



</script>
</html>

<script src="../vendor/jquery/jquery.min.js"></script>
<script src="../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

<!-- Core plugin JavaScript-->
<script src="../vendor/jquery-easing/jquery.easing.min.js"></script>

<!-- Custom scripts for all pages-->
<script src="../js/sb-admin-2.js"></script>
<script src="../vendor/datatables/jquery.dataTables.min.js"></script>
<script src="../vendor/datatables/dataTables.bootstrap4.min.js"></script>

<script src="../vendor/datatables/extensiones/js/dataTables.responsive.min.js"></script>

<script src="../vendor/datatables/extensiones/js/dataTables.buttons.min.js"></script>
<script src="../vendor/datatables/extensiones/js/jszip.min.js"></script>
<script src="../vendor/datatables/extensiones/js/buttons.html5.min.js"></script>
<script src="../vendor/datatables/extensiones/js/buttons.print.min.js"></script>
