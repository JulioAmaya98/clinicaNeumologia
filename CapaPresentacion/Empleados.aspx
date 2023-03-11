﻿<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="CapaPresentacion.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="css/StyleEmpleados.css" rel="stylesheet" />
    <title></title>
</head>
<body>




    <div class="container mt-3">
        <ul class="nav nav-tabs justify-content-end " role="tablist">
            <li class="nav-item">
                <a class="nav-link " data-bs-toggle="tab" href="Inicio.html">Inicio</a>
            </li>
            <li class="nav-item">
                <a class="nav-link  " data-bs-toggle="tab" href="producto.aspx">Productos</a>
            </li>
            <li class="nav-item">
                <a class="nav-link  active" data-bs-toggle="tab" href="Empleados.aspx">Empleados</a>
            </li>
            <li class="nav-item">
                <a class="nav-link  " data-bs-toggle="tab" href="#menu3">Menu 3</a>
            </li>
        </ul>

    </div>


    <div class="container">

        <div class="row">





            <form id="form1" runat="server">


                   

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

                                        <input style="margin-right: 1%" class="form-control " type="search" placeholder="Search" aria-label="Search">

                                        <button class="btn btn-outline-success " type="submit">Search</button>
                                    </form>
                                </div>

                            </nav>


                        </div>

                        <asp:GridView ID="GridViewUsuarios" runat="server" CssClass="table  table-hover myGridView" OnRowDataBound="GridViewUsuarios_RowDataBound" HorizontalAlign="Center" OnSelectedIndexChanged="GridViewUsuarios_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField  ItemStyle-CssClass="ancho" HeaderText="Opciones">
                                    <ItemTemplate>
                                        <asp:Button ID="ButtonEditar" runat="server" Text="Editar" CssClass="btn btn-outline-warning" OnClick="ButtonEditar_Click" />
                                        <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="ButtonEliminar_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
   
       
   

    </form>
    </div>
   </div>

</body>
</html>
