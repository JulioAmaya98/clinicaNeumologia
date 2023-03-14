<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductosBodega.aspx.cs" Inherits="CapaPresentacion.ProductosBodega" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="css/StyleLProducto.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div>
        <form id="form1" runat="server">
   
    <div class="container mt-3">
        <ul class="nav nav-tabs justify-content-end " role="tablist">
            <li class="nav-item">
                <a class="nav-link " href="InicioBod.html">Inicio</a>
            </li>
            <li class="nav-item">
                <a class="nav-link active " href="productosBodega.aspx">Productos</a>
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
                                <h4>Productos</h4>
                                <div class="container-fluid">
                                    <asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="btn btn-outline-success botoRedondo " />
                                </div>
                                <div class="container-fluid">
                                    <form class="d-flex" role="search">

                                        <input id="myInput" style="margin-right: 1%" class="form-control " placeholder="Search" aria-label="Search">
                                    </form>
                                </div>
                            </nav>
                        </div>
                        <asp:GridView OnPageIndexChanging="gridProducto_PageIndexChanging" AllowPaging="false" ID="gridProducto" runat="server" CssClass="table table-hover  myGridView" HorizontalAlign="Justify">
                            <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
                            <Columns>
                                <asp:TemplateField  ItemStyle-CssClass="ancho" HeaderText="Opciones">
                                    <ItemTemplate>
                                        <asp:Button ID="ButtonEditar" runat="server" Text="Editar" CssClass="btn btn-outline-warning"  />
                                        <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
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
                $("#gridProducto tbody tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
    </script>
</body>
</html>
