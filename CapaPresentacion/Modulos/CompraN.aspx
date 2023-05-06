﻿<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="CompraN.aspx.cs" Inherits="CapaPresentacion.Modulos.CompraN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- Option 1: Include in HTML -->
    <link href="../css/StyleCompras.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
       <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css">

    <script src="../JS/sweetalert2.all.min.js"></script>
    <title></title>
    <style>
        .btnG {
            bottom: 0;
            right: 35px;
        }
    </style>
    <style>
		body{
			width: 100%;
			margin: 0 auto;
            
		}

       
	</style>
    
</head>

<body onload="onPageLoad()">
    <div style="padding: 40px">
        <button style="right: 35px;  color: #009933; border-color: #009933; width:85px; height:35px" class="btn btn botonagg" data-toggle="modal" data-target="#modalData">Agregar</button>

        <form style="bottom: 0" id="form1" runat="server">

            <asp:Button ID="Regresar" runat="server" Text="Regresar" Style="float: right; border-color: gray; color: gray;" class="btn btn" OnClick="Regresar_Click" />


            <h2>Factura
                <asp:Label runat="server" ID="numeroFactura" ForeColor="#009933"></asp:Label></h2>
            <label>
                Creada el:
               <asp:Label ID="lblFechaActual" runat="server" Text="<%=currentDate.ToString()%>"></asp:Label>
            </label>

            <div class="text-lef" style="width: 100%;">
                <div class="row">
                    <div class="col">
                        <label>Factura: </label>
                    </div>
                    <div class="col">
                        <label>Proveedor: </label>
                    </div>

                </div>
                <div class="text-lef" style="width: 100%;">
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
                        <asp:Label ID="Label1" runat="server" Text=" <%=currentDate.ToString()%>"></asp:Label>

                        </label>

                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <div style="width: 100%;">

                <asp:GridView AutoGenerateColumns="false" AllowPaging="false" ID="GridView1" runat="server" CssClass="table  table-hover  myGridView" HorizontalAlign="Justify" OnRowUpdating="ActualizarFila" OnRowDataBound="GridView1_RowDataBound">
                    <HeaderStyle BackColor="transparent" ForeColor="#009933" />
                    <RowStyle BackColor="white" />
                    <AlternatingRowStyle BackColor="#E3EAEB" />
                    <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
                    <Columns>
                         <asp:TemplateField ItemStyle-CssClass="ancho" HeaderText="Opciones">
                                        <ItemTemplate>
                                           
                                             <button  type="button" class="btn btn-icon" style="background-color:#FFA500;color:white;"  onclick = "editarProducto(<%#Eval("id_detalle_compra") %>)">
                                                <span ><i class="bi bi-pencil-square"></i></span>
                                            </button>
                                                <button type="button" class="btn  btn-danger btn-icon" style="background-color:#8B0000" onclick="eliminarProducto(<%#Eval("id_detalle_compra") %>)">
                                                <span ><i class="bi bi-trash3"></i></span>
                                            </button>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                         <asp:BoundField DataField="id_detalle_compra" HeaderText="id_detalle_compra" Visible="true" InsertVisible="False" ReadOnly="True" SortExpression="id_detalle_compra"/>
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
                    <label runat="server" id="subtotal">0.00</label>
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
                                <div class="d-flex" role="search">

                                    <input id="myInput" style="margin-right: 1%" class="form-control " placeholder="Search" aria-label="Search">
                                </div>
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
                            <asp:Button ID="Button2" class="btn btn-primary agregar " runat="server" Text="Agregar" OnClick="Button2_Click" />
                            <asp:HiddenField ID="Button2Clicked" runat="server" Value="0" />
                            <button class="btn btn-danger btn-sm" type="button" data-dismiss="modal">Cancel</button>
                        </div>
                    </div>
                </div>
            </div>

            <!--Inicio  Modal para editar cantidad-->
            <div class="modal fade" id="modalDataEdit" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static">
                <div class="modal-dialog" role="document">
                    <div class="modal-content" style="text-align:center">
                        <div class="modal-header">
                            <h4>Modificar Cantidad</h4>
                            
                            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                        <div class="modal-body" >
                            
                            <asp:TextBox class="form-control" TextMode="Number" min="1" ID="txtCantidad" runat="server" Size="3" placeholder="Ingrese Nueva Cantidad"></asp:TextBox>
                            <span runat="server" id="prueba" ></span>
                        </div>
                        <div class="modal-footer">
                            <button id="btnGuardar2" type="button"  class="btn btn-primary btn-sm">Guardar</button>
                            
                            <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                            <button class="btn btn-danger btn-sm" type="button" data-dismiss="modal">Cancel</button>
                        </div>
                    </div>
                </div>
            </div>
            <!--Fin  Modal para editar cantidad-->
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success btnG" OnClick="btnGuardar_Click" />
            
        </form>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe" crossorigin="anonymous"></script>




    </div>
</body>
<script>
   
    var rol = window.location.search.substring(1);
    rol = rol.split("rol=")[1];

    var nFactura=document.getElementById("TextBox3").value


    const editarProducto = (id_detalle_compra) => {

                 
        $('#modalDataEdit').modal('show');

        document.getElementById("btnGuardar2").addEventListener("click", function () {
            var textCantidad = document.getElementById("txtCantidad").value;

            if (textCantidad != "Ingrese Nueva Cantidad" || textCantidad != "" || textCantidad != null) {

                 let nFactura = document.getElementById("<%= TextBox3.ClientID %>").value;
                    nFactura = nFactura.replace(/,/g, ' ');
                    let url = window.location.href;

                    
                if (url.indexOf("nFactura") !== -1) {

                    let currentNFactura = url.split("nFactura=")[1].split("&")[0];

                    if (currentNFactura == nFactura) {

                        location.href = window.location.href + "&cantidad=" + textCantidad + "&idDetalle=" + id_detalle_compra;
                        console.log(currentNFactura)
                        return;
                    }
                } else {
                    location.href = `CompraN.aspx?rol=${rol}&idDetalle=${id_detalle_compra}&nFactura=${encodeURIComponent(nFactura)}&cantidad=${textCantidad}`;
                }

            } else {
                Swal.fire({
                    title:" + rol + ",
                    text: "Por favor ingrese una cantidad",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'ok'
                })
            }

            
        });

     }



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
    var rol = window.location.search.substring(1);
    rol = rol.split("rol=")[1];
    

    const eliminarProducto = (id_detalle_compra) => {
        Swal.fire({
            title: 'Quieres borrar este producto?',
            text: "Una vez borrado no podras recurperarlo",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, eliminar!'
        }).then((result) => {
            if (result.isConfirmed) {
                Swal.fire(
                    'Eliminado!',
                    'Tu producto fue eleminado correctamente.',
                    'success'
                )

                setTimeout(() => {
                    let nFactura = document.getElementById("<%= TextBox3.ClientID %>").value;
                    nFactura = nFactura.replace(/,/g, ' ');
                    let url = window.location.href;

                    
                    if (url.indexOf("nFactura") !== -1) {
                        
                        let currentNFactura = url.split("nFactura=")[1].split("&")[0];

                        if (currentNFactura == nFactura) {
                            
                            location.href = window.location.href+"&id="+id_detalle_compra;
                            console.log(currentNFactura)
                            return;
                        }
                    }

         
                    location.href = `CompraN.aspx?rol=${rol}&id=${id_detalle_compra}&nFactura=${encodeURIComponent(nFactura)}`;

                }, 2500);
            }
        })
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
