<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="CapaPresentacion.Modulos.Proveedores" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
    <link href="../css/StyleInicio.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="../css/StyleLProveedores.css" rel="stylesheet" />
    <script src="../JS/Roles.js"></script>
    <script src="../JS/sweetalert2.all.min.js"></script>

    <link href="../css/StyleLProducto.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
                        <a class="nav-link  active " runat="server" id="navProveedores" href="#">Proveedores</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link " runat="server" data-bs-toggle="tab" id="navEmpleados" href="#">Empleados</a>
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
                        <br />
                        <div id="conten">
                            <div id="encabezado">
                                <nav class="navbar navbar-expand-lg">
                                    <h4>Proveedores</h4>
                                    <div class="container-fluid">
                                        <asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="btn btn-outline-success botoRedondo " OnClick="Button1_Click" />
                                    </div>
                                    <div class="container-fluid">
                                        <form class="d-flex" role="search">
                                            <input id="myInput" style="margin-right: 1%" class="form-control " placeholder="Search" aria-label="Search">
                                        </form>
                                    </div>
                                </nav>
                            </div>
                            <asp:GridView OnPageIndexChanging="gridProveedores_PageIndexChanging" AutoGenerateColumns="false" AllowPaging="false" ID="gridProveedores" runat="server" CssClass="table table-hover  myGridView" HorizontalAlign="Justify" DataKeyNames="IdProveedor" DataSourceID="SqlDataSourceCategorias" OnSelectIndexChanged="gridProveedores_SelectedIndexChanged">
                                <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
                                <Columns>
                                    <asp:BoundField DataField="IdProveedor" HeaderText="IdProveedor" Visible="false" InsertVisible="False" ReadOnly="True" SortExpression="IdProveedor"/>
                                    <asp:BoundField DataField="NombreEmpresa" HeaderText="Nombre de la Empresa" SortExpression="NombreEmpresa"/>
                                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion"/>
                                    <asp:BoundField DataField="Vendedor" HeaderText="Nombre del Vendedor" SortExpression="Vendedor"/>
                                    <asp:BoundField DataField="Contacto" HeaderText="Telefono" SortExpression="Contacto"/>
                                    <asp:BoundField DataField="CorreoElectronico" HeaderText="Email" SortExpression="CorreoElectronico"/>
                                    <asp:TemplateField ItemStyle-CssClass="ancho" HeaderText="Opciones">
                                        <ItemTemplate>
                                           
                                             <button type="button" class="btn btn-icon" style="background-color:#FFA500;color:white;" onclick="editarProveedor(<%#Eval("IdProveedor") %>)">
                                                <span ><i class="bi bi-pencil-square"></i></span>
                                            </button>
                                                <button type="button" class="btn  btn-danger btn-icon" style="background-color:#8B0000" onclick="eliminarProveedor(<%#Eval("IdProveedor") %>)">
                                                <span ><i class="bi bi-trash3"></i></span>
                                            </button>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-CssClass="ancho" HeaderText="Producto">
                                        <ItemTemplate>
                                           
                                             <button type="button" class="btn btn-icon"  style="background-color:#FFA500;color:white;" onclick="agregarProducto(<%#Eval("IdProveedor") %>)">
                                                <span ><i class="bi bi-plus-square-fill"></i></span>
                                            </button>
                                                <button type="button" class="btn btn-danger btn-icon" style="background-color:#8B0000" onclick="verProducto(<%#Eval("IdProveedor") %>)">
                                                <span ><i class="bi bi-eye-fill"></i></span>
                                            </button>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceCategorias" runat="server" ConnectionString="<%$ ConnectionStrings:clinicConnectionString2 %>" SelectCommand="sp_mostrar_proveedores" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                           
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
                $("#gridProveedores tbody tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
    </script>
    <script>
        var rol = window.location.search.substring(1);
        rol = rol.split("rol=")[1];

        function editarProveedor(idProveedor) {
            window.location.href = 'EditarProveedor.aspx?id_proveedor=' + idProveedor + "&rol=" + rol
        }

        function agregarProducto(idProveedor) {
            window.location.href = 'AgregarProducto.aspx?id_proveedor=' + idProveedor + "&rol=" + rol
        }

        function verProducto(idProveedor) {
            window.location.href = 'ViewProductSupplier.aspx?id_proveedor=' + idProveedor + "&rol=" + rol
        }

        const eliminarProveedor = (idProveedor) => {
            Swal.fire({
                title: 'Quieres borrar este Proveedor?',
                text: "Una vez borrada no podras recurperarla",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si, eliminar!'
            }).then((result) => {
                if (result.isConfirmed) {
                    Swal.fire(
                        'Eliminado!',
                        'Tu registro fue eleminado correctamente.',
                        'success'
                    )
                    
                    setTimeout(() => {
                        location.href = "Proveedores.aspx?rol=" + rol + "&id=" + idProveedor
                    }, 500);
                }
            })
        }
    </script>
</body>
</html>
