<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Ventas.aspx.cs" Inherits="CapaPresentacion.Modulos.Ventas" %>


<style>
    .container-principal {
        padding-top: 40px;
        margin-bottom: 20px;
        display: flex;
        justify-content: center;
        align-items: center;
    }

    .container {
        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.3);
        padding: 20px;
        border-radius: 10px;
    }

    .bo {
        border-radius: 5px;
    }


    .form-group {
        display: grid;
        grid-template-rows: auto auto;
        grid-gap: 5px;
    }

    .in {
        border: 1px solid #ced4da;
        border-radius: 0.25rem;
        transition: border-color 0.2s ease-in-out;
    }

        .in:focus {
            border-color: #007bff;
            outline: none;
            box-shadow: 0 0 4px #00bfff;
        }
</style>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet">
    <title></title>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="../JS/sweetalert2.all.min.js"></script>
</head>

<body style="background-color: #F4F4F4">
    <div class="container-principal">





        <div class="container">

            <form runat="server" class="row g-3">

                <div class="row">






                    <div class="col-6 mx-0">
                        <div class="float-start w-100 d-flex ">

                            <div class="dropdown mx-0">



                                <asp:DropDownList class="btn btn-secondary dropdown-toggle" aria-labelledby="dropdownMenu2" ID="DropDownList1" AutoPostBack="true" data-bs-toggle="dropdown" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server">
                                </asp:DropDownList>

                            </div>


                            <button class="btn btn-primary dropdown-toggle mx-3" type="button" data-bs-toggle="collapse" data-bs-target="#clienteFormulario" aria-expanded="false" aria-controls="clienteFormulario">
                                Datos del cliente
                            </button>

                        </div>
                    </div>

                    <div class="col-6 mx-0">
                        <div class="float-end w-100">

                            <div class="dropdown">




                                <asp:Label Style="font-size: 30px; color: blue; font-weight: bold;" ID="Label1" runat="server" Text="Label" CssClass="text-end w-100 d-block">#0000005</asp:Label>
                                <asp:Label ID="Label2" runat="server" Text="Label" CssClass="text-end w-100 d-block">Fecha</asp:Label>
                            </div>
                        </div>
                    </div>

                    <div style="margin-top: 50px; padding-left: 10%; padding-right: 10%" class="collapse" id="clienteFormulario">

                        <div class="mb-3">
                            <label for="dui" class="form-label">DUI</label>
                            <input type="text" runat="server" class="form-control" id="Dui" placeholder="Ingrese su DUI" />
                        </div>
                        <div class="mb-3">
                            <label for="nombre" class="form-label">Nombre</label>
                            <input type="text" runat="server" class="form-control" id="nombre" placeholder="Ingrese su nombre" />
                        </div>

                        <div class="mb-3">
                            <label for="direccion" class="form-label">Dirección</label>
                            <textarea class="form-control" runat="server" id="direccion" rows="3" placeholder="Ingrese la dirección del cliente"></textarea>
                        </div>


                    </div>
                </div>

                <hr style="margin-top: 20px; margin-bottom: 20px; border: none; border-top: 3px solid #808080;" />

                <div class="input-group mb-3">

                    <span class="input-group-text">Buscar</span>
                    <input id="txtBuscarProducto" type="text" aria-label="First name" class="form-control">

                    <span style="margin-left: 10px" class="input-group-text">Cantidad</span>
                    <asp:TextBox ID="txtCantidad" runat="server" class="form-group in" onkeypress="return isNumberKey(event)" onchange="validateNumberInput(this)" placeholder="Ingrese la cantidad" />
                </div>
                <div id="divGridView" style="display: none;">
                    <asp:GridView ShowHeader="True" AutoGenerateColumns="false" CssClass="table table-striped " ID="GridViewCargarProducto" runat="server">

                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>

                                    <button type="button" class="btn btn-icon" style="background-color: #FFA500; color: white;" onclick="agregarProducto(<%#Eval("id_producto") %>)">
                                        <span>Agregar</span>
                                    </button>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="id_producto" HeaderText="id" />
                            <asp:BoundField DataField="nombre" HeaderText="Producto" />
                            <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                            <asp:BoundField DataField="precio" HeaderText="Precio" DataFormatString="{0:N2}"/>
                            <asp:BoundField DataField="existencia" HeaderText="Existencia" /> 
                        </Columns>

                    </asp:GridView>

                </div>

                <div id="divNoResults" style="display: none;">No se encontraron resultados</div>


                <asp:GridView ID="gridviewDetalleVenta" CssClass="table table-striped " runat="server" AutoGenerateColumns="false" OnRowDataBound="GridViewCargarProducto_RowDataBound">

                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>

                                <button type="button" class="btn btn-icon" style="background-color: #FFA500; color: white;" onclick="editarProducto(<%#Eval("id_ventas") %>)">
                                    <span>Editar</span>
                                </button>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id_ventas" HeaderText="id" />
                        <asp:BoundField DataField="codigo_producto" HeaderText="Codigo" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="precio" HeaderText="Precio" DataFormatString="{0:N2}"/>
                        <asp:BoundField DataField="subtotal" HeaderText="Subtotal" DataFormatString="{0:N2}" />
                    </Columns>

                </asp:GridView>

                <hr style="margin-top: 20px; margin-bottom: 20px; border: none; border-top: 3px solid #808080;" />

                <div id="TOTAL" class="col-12 mx-0">





                    <div class="float-end w-100" style="display: flex;">
                        <!--Campos de parte Izquierda-->
                        <div class="" style="margin-right: auto; width: 400px">

                            <div class="form-group" id="divSubtotal">
                                <label for="subtotal" id="lbSubtotal" runat="server">Subtotal</label>
                                <div class="input-group" style="width: 100%;">
                                    <span class="input-group-text">$</span>

                                    <label type="text" runat="server" class="form-control form-control-lg" id="subtotal" aria-label="Dollar amount (with dot and two decimal places)" />
                                </div>
                            </div>
                            <div class="form-group" id="divIva" runat="server" style="width: 100%;">
                                <label for="iva" >IVA</label>
                                <div class="input-group">
                                    <span class="input-group-text">$</span>

                                    <label type="text" id="txtIva" runat="server" class="form-control form-control-lg" aria-label="Dollar amount (with dot and two decimal places)" ></label>
                                </div>
                            </div>
                            <div class="form-group" id="divPagar" runat="server" style="width: 100%;">
                                <label for="totalPagar" id="lbTotalPagar" runat="server" >Total a pagar</label>
                                <div class="input-group">
                                    <span class="input-group-text">$</span>

                                    <label type="text" runat="server" class="form-control form-control-lg" id="txtTotalPagar" aria-label="Dollar amount (with dot and two decimal places)" DataFormatString="{0:F2}"></label>
                                </div>
                            </div>
                        </div>
                        <!--Campos de parte Derecha-->
                        <div class="" style="margin-left: auto; width: 400px">

                            <div class="form-group">
                                <label for="txtTotalPagado">Total pagado</label>
                                <div class="input-group" style="width: 100%;">
                                    <span class="input-group-text">$</span>

                                    <input type="text" runat="server" class="form-control form-control-lg" id="txtTotalPagado" aria-label="Dollar amount (with dot and two decimal places)" />
                                </div>
                            </div>
                            <div class="form-group" style="width: 100%;">
                                <label for="saldo-pendiente" >Saldo Pendiente</label>
                                <div class="input-group">
                                    <span class="input-group-text">$</span>

                                    <label type="text" runat="server"  class="form-control form-control-lg" id="txtSaldoPendiente" aria-label="Dollar amount (with dot and two decimal places)" ></label>
                                </div>
                            </div>
                            <div class="form-group" style="width: 100%;">
                                <label for="su-cambio" >Su cambio</label>
                                <div class="input-group">
                                    <span class="input-group-text">$</span>

                                    <label type="text" runat="server"  class="form-control form-control-lg" id="txtSuCambio" aria-label="Dollar amount (with dot and two decimal places)" ></label>
                                </div>
                            </div>

                            <asp:Button Style="margin-top: 15px;" type="button" class="btn btn-success btn-lg" ID="btnTerminarVenta" runat="server" Text="Terminar venta" OnClick="btnTerminarVenta_Click"/>
                            <asp:Button Style="margin-top: 15px;" type="button" class="btn btn-warning btn-lg" ID="ButtonCancelar" runat="server" Text="Cancelar" OnClick="ButtonCancelar_Click" />

                        </div>
                    </div>
                </div>


            </form>

        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>



    <script>
        var txtBuscarProducto = document.getElementById("txtBuscarProducto");
        var divGridView = document.getElementById("divGridView");
        var divNoResults = document.getElementById("divNoResults");


        var saldoPendinete = document.getElementById("txtSaldoPendiente");
        var iva = document.getElementById("txtIva");
        var totalPagar = document.getElementById("txtTotalPagar");
        var subtotal = document.getElementById("subtotal");
       
        var cambio = document.getElementById("txtSuCambio");

        subtotal.innerHTML = parseFloat(subtotal.innerHTML).toFixed(2);
        totalPagar.innerHTML = parseFloat(totalPagar.innerHTML).toFixed(2); 
        iva.innerHTML = parseFloat(iva.innerHTML).toFixed(2);

        if (isNaN(saldoPendinete.innerText)) {
            saldoPendinete.innerHTML=""
        } else {
            saldoPendinete.innerHTML = parseFloat(saldoPendinete.innerHTML).toFixed(2)
        }
        if (isNaN(cambio.innerText)) {
            cambio.innerHTML = ""
        } else {
            cambio.innerHTML = parseFloat(cambio.innerHTML).toFixed(2);
        }
       
        
        
        
        

        txtBuscarProducto.addEventListener("input", function () {

            var searchTerm = this.value.toLowerCase();
            var rows = divGridView.querySelectorAll("table tr");

            var resultsFound = false;

            var headerRow = divGridView.querySelector("table tr:first-child");




            for (var i = 0; i < rows.length; i++) {

                var cells = rows[i].querySelectorAll("td");
                var rowText = "";


                for (var j = 0; j < cells.length; j++) {

                    rowText += cells[j].textContent.toLowerCase() + " ";
                }
                if (rowText.indexOf(searchTerm) > -1) {
                    rows[i].style.display = "";
                    resultsFound = true;
                } else {
                    rows[i].style.display = "none";
                }
            }
            if (resultsFound) {
                headerRow.style.display = "";
                divGridView.style.display = "";
                divNoResults.style.display = "none";
            } else {
                headerRow.style.display = "none";
                divGridView.style.display = "none";
                divNoResults.style.display = "";
            }
            if (!searchTerm.trim()) {
                headerRow.style.display = "none";
                divGridView.style.display = "none";
                divNoResults.style.display = "none";
            }
        });

        const agregarProducto = (id_producto) => {

            var cantidad = document.getElementById("<%= txtCantidad.ClientID %>").value;

            location.href = `Ventas.aspx?idProducto=${id_producto}&cantidad=${cantidad}`;

        }

        document.addEventListener("DOMContentLoaded", function () {
            const totalPagado = document.getElementById("txtTotalPagado");
            const total = document.getElementById("txtTotalPagar");
            const txtPendiente = document.getElementById("txtSaldoPendiente");
            const txtCambio = document.getElementById("txtSuCambio");
            
            totalPagado.addEventListener('input', actualizarData);
            

            function actualizarData() {

                
                const pagado = parseFloat(totalPagado.value);
                const total2 = parseFloat(total.innerText);

                

                if (isNaN(pagado)) {
                    txtPendiente.textContent = "";
                    txtCambio.textContent = "";
                    return false;
                }

               

                const resta = pagado - total2;

                if (pagado < total2) {
                    console.log(pagado);
                    if (isNaN(pagado)) {
                        txtPendiente.textContent = "";
                        txtCambio.textContent = "";

                    }

                    txtCambio.textContent = 0;
                    txtPendiente.textContent = resta;
                } else {
                    console.log(pagado);
                    if (isNaN(pagado)) {
                        txtPendiente.textContent = "";
                        txtCambio.textContent = "";

                    }
                    txtPendiente.textContent = 0;
                    txtCambio.textContent = resta;
                }
                

            } 

        })

         
       



    </script>



    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function validateNumberInput(input) {
            var currentValue = parseInt(input.value);
            if (isNaN(currentValue) || currentValue < 0) {
                input.value = "";

            } else {
                input.style.borderColor = "";
                input.title = "Ingrese la cantidad";
            }
        }
    </script>





</body>
</html>
