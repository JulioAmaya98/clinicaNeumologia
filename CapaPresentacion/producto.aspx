<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="producto.aspx.cs" Inherits="CapaPresentacion.producto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="css/StyleInicio.css" rel="stylesheet" />
    <title></title>
</head>
<body style=" background-image: url('../img/fondo.jpg');">
    <form id="form1" runat="server">
        <div >
                        <div class="container mt-3">
                <ul class="nav nav-tabs justify-content-end " role="tablist">
                    <li class="nav-item">
                        <a class="nav-link" href="Inicio.aspx">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" data-bs-toggle="tab" href="producto.aspx">Mostrar Productos</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" style="text-decoration: none" data-bs-toggle="tab" href="#menu2">Menu 2</a>
                    </li>
                        </ul>

                                        </div>

            <div style="display: flex; justify-content: center; align-items: center;">
                <asp:GridView ID="gridProducto" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>

                        </div>
            </div>
    </form>
</body>
</html>
