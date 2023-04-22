
<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="CapaPresentacion.Empleados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script src="../JS/sweetalert2.all.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="../css/StyleEmpleados.css" rel="stylesheet" />
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
                        <a class="nav-link  "  id="navInicio" href="#">Inicio</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" runat="server" id="navProductos" href="#">Productos</a>
                    </li>
                     <li class="nav-item">
                        <a class="nav-link " runat="server" id="navProveedores" href="#">Proveedores</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link  active " runat="server" data-bs-toggle="tab" id="navEmpleados" href="#">Empleados</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link " runat="server" id="navInventario" href="#">Inventario</a>
                    </li>
                     <li class="nav-item">
                        <a class="nav-link " runat="server" data-bs-toggle="tab" id="navCompras" href="#">Compras</a>
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

                        <div id="conten">

                            <div id="encabezado">


                                <nav class="navbar navbar-expand-lg">
                                    <h4>Empleados</h4>
                                    <div class="container-fluid">


                                        <asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="btn btn-outline-success botoRedondo " OnClick="ButtonAgregar_Click" />



                                    </div>
                                    <div class="container-fluid">
                                        <form class="d-flex" role="search">

                                            <input id="myInput" style="margin-right: 1%" class="form-control " placeholder="Search" aria-label="Search">
                                        </form>
                                    </div>

                                </nav>


                            </div>

                            <asp:GridView ID="GridViewUsuarios" runat="server" DataKeyNames="id_usuario" DataSourceID="SqlDataSourceEmpleados"  AutoGenerateColumns="false" CssClass="table  table-hover myGridView"  HorizontalAlign="Center">

                                <Columns>
                                 
                                             <asp:BoundField DataField="id_usuario" HeaderText="id_usuario" SortExpression="id_usuario"  />

                                   
                                   
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"   SortExpression="Nombre" />
                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />
                                    <asp:BoundField DataField="Rol" HeaderText="Rol" SortExpression="Rol" />

                                    <asp:TemplateField ItemStyle-CssClass="ancho" HeaderText="Opciones">
                                        <ItemTemplate>
                                            <button type="button" class="btn btn-icon" style="background-color: #FFA500; color: white;" onclick="editarEmpleado(<%#Eval("id_usuario") %>)">
                                                <span><i class="bi bi-pencil-square"></i></span>
                                            </button>
                                            <button type="button" class="btn  btn-danger btn-icon" style="background-color: #8B0000" onclick="eliminarEmpleado(<%#Eval("id_usuario") %>)">
                                                <span><i class="bi bi-trash3"></i></i></span>
                                            </button>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                         <asp:SqlDataSource ID="SqlDataSourceEmpleados" runat="server" ConnectionString="<%$ ConnectionStrings:clinicConnectionString2 %>" SelectCommand="sp_mostrar_usuario" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

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
        var rol = window.location.search.substring(1);
        rol = rol.split("rol=")[1];

        function editarEmpleado(id_usuario) {

            window.location.href = 'EditarUsuario.aspx?id_usuario=' + id_usuario + "&rol=" + rol;
        }

        const eliminarEmpleado = (id_usuario) => {
            Swal.fire({
                title: 'Quieres borrar este Empleado?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si, eliminar!'
            }).then((result) => {
                if (result.isConfirmed) {
             

                    setTimeout(() => {
                        location.href = "Empleados.aspx?rol=" + rol + "&id=" + id_usuario
                    }, 500);
                }
            })
        }
        
    </script>
</body>
</html>
