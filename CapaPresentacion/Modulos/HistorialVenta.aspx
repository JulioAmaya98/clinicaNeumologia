<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="HistorialVenta.aspx.cs" Inherits="CapaPresentacion.Modulos.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
   
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="../css/StyleEmpleados.css" rel="stylesheet" />
    <script src="../JS/Roles.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css">
    <script src="../JS/sweetalert2.all.min.js"></script>



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
                        <a class="nav-link " runat="server" data-bs-toggle="tab" id="navEmpleados" href="#">Empleados</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link " runat="server" id="navInventario" href="#">Inventario</a>
                    </li>
                     <li class="nav-item">
                        <a class="nav-link   " runat="server" data-bs-toggle="tab" id="navCompras" href="#">Compras</a>
                    </li>
                      <li class="nav-item">
                        <a class="nav-link active" runat="server" data-bs-toggle="tab" id="Ventasnav" href="#">Ventas</a>
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
                            <h5>Historial de ventas</h5>
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

                       
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

                         
                            <asp:GridView ID="GridViewUs" runat="server" DataKeyNames="id_venta" DataSourceID="Sql"  AutoGenerateColumns="false" CssClass="table  table-hover myGridView"  HorizontalAlign="Center">

                                <Columns>
                                 
                                   <asp:BoundField DataField="id_venta" HeaderText="id_venta" Visible="false" InsertVisible="False" ReadOnly="True" SortExpression="id_venta"  />
                                   <asp:BoundField DataField="Numero Comprobante" HeaderText="Numero Comprobante" SortExpression="Numero Comprobante"  />
                                    <asp:BoundField DataField="Nombre Cliente" HeaderText="Nombre Cliente"   SortExpression="Nombre Cliente" />
                                    <asp:BoundField DataField="Tipo Documento" HeaderText="Tipo Documento" SortExpression="Tipo Documento" />
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                                    

                                    <asp:TemplateField ItemStyle-CssClass="ancho" HeaderText="Opciones">
                                        <ItemTemplate>
                                            
                                            <button type="button" class="btn  btn-danger btn-icon" style="background-color: #8B0000" onclick="eliminarVenta(<%#Eval("id_venta") %>, this.parentNode.parentNode.cells[0].innerHTML)" >
                                                <span><i class="bi bi-trash3"></i></i></span>
                                            </button>
                                            <button type="button" class="btn  btn-icon" style="background-color: #808080ff" onclick="verVenta(<%#Eval("id_venta") %>, this.parentNode.parentNode.cells[0].innerHTML)">                                                <span><i class="bi bi-eye-fill"></i></span>                                            </button>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                         <asp:SqlDataSource ID="Sql" runat="server" ConnectionString="<%$ ConnectionStrings:clinicConnectionString2 %>" SelectCommand="sp_mostrar_historial_venta" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                         
                    </div>
                </div>
    </div>
   </div>
            </form>
        </div>

 
      <script>


          var rol = window.location.search.substring(1);
          rol = rol.split("rol=")[1];
          const eliminarVenta = (id_venta, comprobante) => {
              Swal.fire({
                  title: 'Quieres borrar esta Venta?',
                  icon: 'warning',
                  showCancelButton: true,
                  confirmButtonColor: '#3085d6',
                  cancelButtonColor: '#d33',
                  confirmButtonText: 'Si, eliminar!'
              }).then((result) => {
                  if (result.isConfirmed) {
                      setTimeout(() => {
                          location.href = "HistorialVenta.aspx?rol=" + rol + "&id=" + id_venta + "&comprobante=" + encodeURIComponent(comprobante);
                      }, 500);
                  }
              })
          }

          const verVenta = (id, comprobante) => {                                    setTimeout(() => {                          location.href = "verVenta.aspx?rol=" + rol + "&nFactura=" + comprobante;                      }, 500);                                          }
      </script>

    




</body>
 
     
</html>


