<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CapaPresentacion.Modulos.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="../css/StyleInicio.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container mt-3">
                <ul class="nav nav-tabs justify-content-end " role="tablist">
                    <li class="nav-item">
                        <a class="nav-link  active "  id="navInicio" href="#">Inicio</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" runat="server" id="navProductos" href="#">Productos</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link " runat="server" data-bs-toggle="tab" id="navEmpleados" href="#">Empleados</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link " runat="server" id="navInventario" href="#">Inventario</a>
                    </li>
                    <li class="nav-item">
                        <asp:Button ID="Cerrar" runat="server" CssClass="btn btn-danger" Text="Cerrar Session" OnClick="Cerrar_Click" />
                    </li>
                </ul>

            </div>

          

        </div>

    </form>


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
        rol = rol.split("=")[1];

      

        if (rol == "TQBlAGQAaQBjAG8A") {

            const empleados = document.getElementById('navEmpleados');
            empleados.setAttribute('href', 'Empleados.aspx?rol=' + rol);
            const inventario = document.getElementById('navInventario');
            inventario.setAttribute('href', '../Bodeguero/Inventario.aspx?rol=' + rol);
            const productos = document.getElementById('navProductos');
            productos.setAttribute('href', 'producto.aspx?rol=' + rol);
            const inicio = document.getElementById('navInicio');
            inicio.setAttribute('href', 'Inicio.aspx?rol=' + rol);
        } else if (rol == "QgBvAGQAZQBnAHUAZQByAG8A") {
            const inventario = document.getElementById('navInventario');
            inventario.setAttribute('href', '../Bodeguero/Inventario.aspx?rol=' + rol);
            const inicio = document.getElementById('navInicio');
             inicio = document.getElementById('navInicio');
        } else if (rol =="UwBlAGMAcgBlAHQAYQByAGkAYQA=") {
            const productos = document.getElementById('navProductos');
            productos.setAttribute('href', 'producto.aspx?rol=' + rol);
            const inicio = document.getElementById('navInicio');
            inicio.setAttribute('href', 'Inicio.aspx?rol=' + rol);
        }


    </script>
</body>
</html>
