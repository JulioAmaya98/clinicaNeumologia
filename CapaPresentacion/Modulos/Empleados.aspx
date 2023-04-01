<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="CapaPresentacion.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css" rel="stylesheet">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="../css/StyleEmpleados.css" rel="stylesheet" />
    <script src="../JS/Roles.js"></script>
    <title></title>
</head>

    <style>
        .hidden {
    display: none;
}

    </style>
<body>

    <div>

        
            <form id="form1" runat="server">

    <div class="container mt-3">
        <ul class="nav nav-tabs justify-content-end " role="tablist">
            <li class="nav-item">
                <a class="nav-link " id="navInicio" href="#">Inicio</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="navProductos" href="#" >Productos</a>
            </li>
            <li class="nav-item">
                        <a class="nav-link " runat="server" id="navProveedores" href="#">Proveedores</a>
                    </li>
            <li class="nav-item">
                <a class="nav-link  active" data-bs-toggle="tab" id="navEmpleados" href="#">Empleados</a>
                </li>
              <li class="nav-item">
                <a class="nav-link " id="navInventario" href="#">Inventario</a>
            </li>
            <li class="nav-item">
                <asp:Button ID="Cerrar" runat="server" CssClass="btn btn-danger" Text="Cerrar Session" OnClick="Cerrar_Click" />
            </li>
        </ul>

    </div>


    <div class="container">

        <div class="row">







                   

                    <div class="ALL">

                    <div  id="conten">

                        <div id="encabezado">


                            <nav class="navbar navbar-expand-lg">
                                <h4>Empleados</h4>
                                <div class="container-fluid">


                                    <asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="btn btn-outline-success botoRedondo " OnClick="ButtonAgregar_Click" />



                                </div>
                                <div class="container-fluid">
                                    <form class="d-flex" role="search">

                                        <input id="myInput" style="margin-right: 1%" class="form-control "  placeholder="Search" aria-label="Search">
                                    </form>
                                </div>

                            </nav>


                        </div>

                        <asp:GridView ID="GridViewUsuarios" runat="server"  AutoGenerateColumns="false" CssClass="table  table-hover myGridView" OnRowDataBound="GridViewUsuarios_RowDataBound" HorizontalAlign="Center">                                <Columns>                                    <asp:BoundField DataField="id_usuario" ItemStyle-CssClass="hidden" HeaderText="id_usuario" SortExpression="id_usuario" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"   SortExpression="Nombre" />                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />                                    <asp:BoundField DataField="Rol" HeaderText="Rol" SortExpression="Rol" />                                    <asp:TemplateField ItemStyle-CssClass="ancho" HeaderText="Opciones">                                        <ItemTemplate>                                            <button type="button" class="btn btn-icon" style="background-color: #FFA500; color: white;" onclick="editarProveedor(this)">                                                <span><i class="bi bi-pencil-square"></i></span>                                            </button>                                            <button type="button" class="btn  btn-danger btn-icon" style="background-color: #8B0000" onclick="eliminarProveedor">                                                <span><i class="bi bi-trash3"></i></i></span>                                            </button>                                        </ItemTemplate>                                    </asp:TemplateField>                                </Columns>                            </asp:GridView>
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
                $("#GridViewUsuarios tbody tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
        </script>
    <script>


        function editarProveedor(btn) {
            var fila = btn.parentNode.parentNode;
            var celda = fila.cells[0];

            var valor = celda.textContent;
            window.location.href = "aqui.aspx?id=" + valor;
        }


        

    </script>
</body>
</html>
