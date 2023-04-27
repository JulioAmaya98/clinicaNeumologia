
<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="HistorialCompras.aspx.cs" Inherits="CapaPresentacion.Modulos.HistorialCompras" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="../css/StyleLProducto.css" rel="stylesheet" />
    <script src="../JS/Roles.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css">
    <title></title>
</head>
<body>
    <div>
            <form id="form1" runat="server">
   <div>
            <div class="container mt-3">
                <ul class="nav nav-tabs justify-content-end " role="tablist">
                    <li class="nav-item">
                        <a class="nav-link   "  id="navInicio" href="#">Inicio</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" runat="server" id="navProductos" href="#">Productos</a>
                    </li>
                     <li class="nav-item">
                        <a class="nav-link " runat="server" id="navProveedores" href="#">Proveedores</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link " runat="server" data-bs-toggle="tab" id="navEmpleados" href="#">Empleados</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link " runat="server" id="navInventario" href="#">Inventario</a>
                    </li>
                     <li class="nav-item">
                        <a class="nav-link active" runat="server" data-bs-toggle="tab" id="navCompras" href="#">Compras</a>
                    </li>
                    <li class="nav-item">
                        <asp:Button ID="Cerrar" runat="server" CssClass="btn btn-danger" Text="Cerrar Session" OnClick="Cerrar_Click" />
                    </li>
                </ul>

            </div>

          
            
        </div>
    <div class="container">
        <div class="row">
                    <div class="ALL">
                    <div  id="conten">
                        <div id="encabezado">
                            <h5>Historial de compras</h5>
                            <nav class="navbar navbar-expand-lg">
                                
                              
                               
                                 <div class="container-fluid">


                                        <asp:Button ID="add" runat="server" Text="Agregar" CssClass="btn btn-outline-success botoRedondo " OnClick="add_Click" />



                                    </div>

                                <div class="container-fluid">
                                    <form class="d-flex" role="search">

                                        <input id="myInput" style="margin-right: 1%" class="form-control " placeholder="Search" aria-label="Search">
                                    </form>
                                </div>
                            </nav>
                        </div>

                       


                            <asp:GridView   ID="GridViewHistory" runat="server" CssClass="table table-hover  myGridView" >
                           
                        </asp:GridView> 
                         
                    </div>
                </div>
    </div>
   </div>
            </form>
        </div>
    <script>
        $(document).ready(function () {
            $("#myInput").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#GridViewHistory tbody tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
    </script>
      
</body>
</html>

