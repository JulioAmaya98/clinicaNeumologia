document.addEventListener("DOMContentLoaded", function () {

    var rol = window.location.search.substring(1);
    rol = rol.split("rol=")[1];

    if (rol == "TQBlAGQAaQBjAG8A") {

        const empleados = document.getElementById('navEmpleados');
        empleados.setAttribute('href', 'Empleados.aspx?rol=' + rol);

        const proveedores = document.getElementById('navProveedores');
        proveedores.setAttribute('href', 'Proveedores.aspx?rol=' + rol);

        const inventario = document.getElementById('navInventario');
        inventario.setAttribute('href', 'Inventario.aspx?rol=' + rol);

        const productos = document.getElementById('navProductos');
        productos.setAttribute('href', 'producto.aspx?rol=' + rol);

        const inicio = document.getElementById('navInicio');
        inicio.setAttribute('href', 'Inicio.aspx?rol=' + rol);

    } else if (rol == "QgBvAGQAZQBnAHUAZQByAG8A") {

        const inventario = document.getElementById('navInventario');
        inventario.setAttribute('href', 'Inventario.aspx?rol=' + rol);

        const inicio = document.getElementById('navInicio');
        inicio.setAttribute('href', 'Inicio.aspx?rol=' + rol);

    } else if (rol == "UwBlAGMAcgBlAHQAYQByAGkAYQA=") {

        const inicio = document.getElementById('navInicio');
        inicio.setAttribute('href', 'Inicio.aspx?rol=' + rol);

        const productos = document.getElementById('navProductos');
        productos.setAttribute('href', 'producto.aspx?rol=' + rol);

        const proveedores = document.getElementById('navProveedores');
        proveedores.setAttribute('href', 'Proveedores.aspx?rol=' + rol);

       
    }
});