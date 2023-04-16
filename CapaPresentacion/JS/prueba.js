$(document).ready(function () {
    $("#botonMostrarProductos").click(function () {
        // Obtener el ID del proveedor del input
        var idProveedor = $("#inputIdProveedor").val();

        // Hacer la petición AJAX
        $.ajax({
            url: "Compras.aspx/ObtenerProductos",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ idProveedor: idProveedor }),
            success: function (response) {
                // Limpiar la tabla
                $("#tablaProductos tbody").empty();

                // Agregar los productos a la tabla
                $.each(response.d, function (i, producto) {
                    var fila = "<tr>" +
                        "<td>" + producto.Id + "</td>" +
                        "<td>" + producto.Nombre + "</td>" +
                        "<td>" + producto.Precio + "</td>" +
                        "</tr>";
                    $("#tablaProductos tbody").append(fila);
                });

                // Mostrar el modal
                $("#modalProductos").modal("show");
            },
            error: function (xhr, status, error) {
                alert("Hubo un error al obtener los productos: " + error);
            }
        });
    });
});
