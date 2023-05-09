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
</style>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet">
    <title></title>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"></script>

</head>

<body style="background-color: #F4F4F4">
    <div class="container-principal">





        <div class="container">

            <form runat="server" class="row g-3">

                <div class="row">






                    <div class="col-6 mx-0">
                        <div class="float-start w-100 d-flex ">

                            <div class="dropdown mx-0">
                              


                                <asp:DropDownList  class="btn btn-secondary dropdown-toggle" aria-labelledby="dropdownMenu2" ID="DropDownList1" data-bs-toggle="dropdown" runat="server">

                                 

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
                            <label for="nombre" class="form-label">Nombre</label>
                            <input type="text" class="form-control" id="nombre" placeholder="Ingrese el nombre del cliente" />
                        </div>
                        <div class="mb-3">
                            <label for="apellido" class="form-label">Apellido</label>
                            <input type="text" class="form-control" id="apellido" placeholder="Ingrese el apellido del cliente" />
                        </div>

                        <div class="mb-3">
                            <label for="direccion" class="form-label">Dirección</label>
                            <textarea class="form-control" id="direccion" rows="3" placeholder="Ingrese la dirección del cliente"></textarea>
                        </div>


                    </div>
                </div>

                <hr style="margin-top: 20px; margin-bottom: 20px; border: none; border-top: 3px solid #808080;" />

                <div class="input-group mb-3">

                    <span class="input-group-text">Buscar</span>
                    <input id="txtBuscarProducto" type="text" aria-label="First name" class="form-control">
                </div>

                <div id="divGridView" style="display: none;">
                    <asp:GridView ShowHeader="True" AutoGenerateColumns="false" CssClass="table table-striped " ID="GridViewCargarProducto" runat="server">

                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>

                                    <asp:Button CssClass="btn btn-primary" ID="Agregar" runat="server" Text="Agregar" />
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="nombre" HeaderText="Producto" />
                            <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                            <asp:BoundField DataField="precio" HeaderText="Precio" />
                            
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                 <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)" onchange="validateNumberInput(this)" placeholder="Ingrese la cantidad" />


                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>

                <div id="divNoResults" style="display: none;">No se encontraron resultados</div>


                <div>
                    <div class="grid text-center bd-example-cssgrid">
                        <div class="g-col-3">Producto</div>
                        <div class="g-col-3">Cantidad</div>
                        <div class="g-col-3">Precio</div>
                        <div class="g-col-3">Total</div>
                    </div>






                </div>

                <hr style="margin-top: 20px; margin-bottom: 20px; border: none; border-top: 3px solid #808080;" />

                <div id="TOTAL" class="col-12 mx-0">





                    <div class="float-end w-100" style="display: flex;">

                        <div class="" style="margin-right: auto; width: 400px">
                            <div class="form-group">
                                <label for="total-apagar">Total a pagar</label>
                                <div class="input-group" style="width: 100%;">
                                    <span class="input-group-text">$</span>

                                    <label type="text" class="form-control form-control-lg" id="total-apagar" aria-label="Dollar amount (with dot and two decimal places)"></label>
                                </div>
                            </div>
                        </div>
                        <div class="" style="margin-left: auto; width: 400px">

                            <div class="form-group">
                                <label for="total-pagado">Total pagado</label>
                                <div class="input-group" style="width: 100%;">
                                    <span class="input-group-text">$</span>

                                    <input type="text" class="form-control form-control-lg" id="total-pagado" aria-label="Dollar amount (with dot and two decimal places)" />
                                </div>
                            </div>
                            <div class="form-group" style="width: 100%;">
                                <label for="saldo-pendiente">Saldo Pendiente</label>
                                <div class="input-group">
                                    <span class="input-group-text">$</span>

                                    <label type="text" class="form-control form-control-lg" id="saldo-pendiente" aria-label="Dollar amount (with dot and two decimal places)"></label>
                                </div>
                            </div>
                            <div class="form-group" style="width: 100%;">
                                <label for="su-cambio">Su cambio</label>
                                <div class="input-group">
                                    <span class="input-group-text">$</span>

                                    <label type="text" class="form-control form-control-lg" id="su-cambio" aria-label="Dollar amount (with dot and two decimal places)"></label>
                                </div>
                            </div>

                            <asp:Button Style="margin-top: 15px;" type="button" class="btn btn-success btn-lg" ID="Button1" runat="server" Text="Hecho" />

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

        txtBuscarProducto.addEventListener("input", function () {

            var searchTerm = this.value.toLowerCase();
            var rows = divGridView.querySelectorAll("table tr");

            var resultsFound = false;

         



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
                divGridView.style.display = "";
                divNoResults.style.display = "none";
            } else {
                divGridView.style.display = "none";
                divNoResults.style.display = "";
            }
            if (!searchTerm.trim()) {
                divGridView.style.display = "none";
                divNoResults.style.display = "none";
            }
        });
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
