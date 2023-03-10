<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CapaPresentacion.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="css/StyleInicio.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>

            <div class="container mt-3">
                <ul class="nav nav-tabs justify-content-end " role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" data-bs-toggle="tab" href="#home">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="WebForm2.aspx">Menu 1</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" style="text-decoration: none" data-bs-toggle="tab" href="#menu2">Menu 2</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-bs-toggle="tab" href="#menu3">Menu 3</a>
                    </li>
                </ul>

            </div>
            <div>
                <div class="container">
                    <h4>Bienvenido Dr. Julio</h4>
                    <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar" CssClass="btn btn-info" OnClick="ButtonAgregar_Click"/>
                    <br />
                    <div class="row">
                        <div class="col-lg-7">
                            <asp:GridView ID="GridViewUsuarios" runat="server" CssClass="table table-bordered table-light table-hover" OnRowDataBound="GridViewUsuarios_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Opciones">
                                        <ItemTemplate>
                                            <asp:Button ID="ButtonEditar" runat="server" Text="Editar" CssClass="btn btn-outline-warning" />
                                            <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
