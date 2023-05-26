<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerVenta.aspx.cs" Inherits="CapaPresentacion.Modulos.VerVenta" %>


<style>
    .mm {
        width: 80px;
        background-color: gray;
        border-radius: 2px 2px 2px 2px;
        display: flex;
        justify-content: center;
        align-items: center;

      
    }

    

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

                            <div class="mm">



                                <asp:DropDownList aria-labelledby="dropdownMenu2" ID="DropDownList1" data-bs-toggle="dropdown" runat="server">
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
                                <asp:Label ID="txtFecha" runat="server" Text="Label" CssClass="text-end w-100 d-block">Fecha</asp:Label>
                            </div>
                        </div>
                    </div>

                    <div style="margin-top: 50px; padding-left: 10%; padding-right: 10%" class="collapse" id="clienteFormulario">

                        <div class="mb-3">
                            <label for="dui" class="form-label">DUI</label>
                            <label type="text" runat="server" class="form-control" id="Dui"></label>
                        </div>
                        <div class="mb-3">
                            <label for="nombre" class="form-label">Nombre</label>
                            <label type="text" runat="server" class="form-control" id="txtNombre" />
                        </div>

                        <div class="mb-3">
                            <label for="direccion" class="form-label">Dirección</label>
                            <label class="form-control" runat="server" id="direccion" rows="3"></label>
                        </div>


                    </div>
                </div>

                <hr style="margin-top: 20px; margin-bottom: 20px; border: none; border-top: 3px solid #808080;" />


                <asp:GridView ID="gridviewDetalleVenta" CssClass="table table-striped " runat="server" AutoGenerateColumns="false">

                    <Columns>

                        <asp:BoundField DataField="Codigo del producto" HeaderText="codigo" SortExpression="Codigo del producto" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="precio" HeaderText="Precio" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="subtotal" HeaderText="Subtotal" DataFormatString="{0:N2}" />
                    </Columns>

                </asp:GridView>



                <hr style="margin-top: 20px; margin-bottom: 20px; border: none; border-top: 3px solid #808080;" />

                <div id="TOTAL" class="col-12 mx-0">





                    <div class="contenedor float-end" style="display: flex;">
                        <!--Campos de parte Izquierda-->

                        <!--Campos de parte Derecha-->
                        <div class="" style="margin-right: 0; width: 400px">

                            <div class="form-group" id="divSubtotal">
                                <label for="subtotal" id="lbSubtotal" runat="server">Subtotal</label>
                                <div class="input-group" style="width: 100%;">
                                    <span class="input-group-text">$</span>

                                    <label type="text" runat="server" class="form-control form-control-lg" id="subtotal" aria-label="Dollar amount (with dot and two decimal places)" />
                                </div>
                            </div>
                            <div class="form-group" id="divIva" runat="server" style="width: 100%;">
                                <label for="iva">IVA</label>
                                <div class="input-group">
                                    <span class="input-group-text">$</span>

                                    <label type="text" id="txtIva" runat="server" class="form-control form-control-lg" aria-label="Dollar amount (with dot and two decimal places)"></label>
                                </div>
                            </div>
                            <div class="form-group" id="divPagar" runat="server" style="width: 100%;">
                                <label for="totalPagar" id="lbTotalPagar" runat="server">Total a pagar</label>
                                <div class="input-group">
                                    <span class="input-group-text">$</span>

                                    <label type="text" runat="server" class="form-control form-control-lg" id="txtTotalPagar" aria-label="Dollar amount (with dot and two decimal places)" dataformatstring="{0:F2}"></label>
                                </div>
                            </div>
                            <div>
                                <asp:Button Style="margin-top: 15px;" type="button" class="btn btn-success btn-lg" ID="btnImprimirVenta" runat="server" Text="Imprimir" OnClick="btnImprimirVenta_Click" />
                                <asp:Button Style="margin-top: 15px;" type="button" class="btn btn-warning btn-lg" ID="ButtonCancelar" runat="server" Text="Regresar" OnClick="ButtonCancelar_Click" />
                            </div>
                        </div>

                    </div>


                </div>
        </div>
    </div>


    </form>

     
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











        document.addEventListener("DOMContentLoaded", function () {


            const totalPagado = document.getElementById("txtTotalPagado");
            const total = document.getElementById("txtTotalPagar");
            const txtPendiente = document.getElementById("txtSaldoPendiente");
            const txtCambio = document.getElementById("txtSuCambio");
            var tipoID = document.getElementById("<%= DropDownList1.ClientID %>")
            const txtSubtotal = document.getElementById("subtotal")

            var dropDownlist = tipoID.value;
            totalPagado.addEventListener('input', actualizarData);


            function actualizarData() {


                if (dropDownlist == 2) {
                    const pagado = parseFloat(totalPagado.value);
                    const total2 = parseFloat(txtSubtotal.innerText);
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

                } else if (dropDownlist == 1) {
                    const pagado = parseFloat(totalPagado.value);
                    const total2 = parseFloat(total.innerText);
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





                if (isNaN(pagado)) {
                    txtPendiente.textContent = "";
                    txtCambio.textContent = "";
                    return false;
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

