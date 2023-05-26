<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarUsuarios.aspx.cs" Inherits="CapaPresentacion.AgregarUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="../css/StyleEmpleados.css" rel="stylesheet" />
    <script src="../JS/Roles.js"></script>
    <title></title>
</head>
<body>
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
                        <a class="nav-link active" runat="server" data-bs-toggle="tab" id="navEmpleados" href="#">Empleados</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link " runat="server" id="navInventario" href="#">Inventario</a>
                    </li>
                     <li class="nav-item">
                        <a class="nav-link   " runat="server" data-bs-toggle="tab" id="navCompras" href="#">Compras</a>
                    </li>
                      <li class="nav-item">
                        <a class="nav-link " runat="server" data-bs-toggle="tab" id="Ventasnav" href="#">Ventas</a>
                    </li>
                    <li class="nav-item">
                        <asp:Button ID="Cerrar" runat="server" CssClass="btn btn-danger" Text="Cerrar Session" OnClick="Cerrar_Click" />
                    </li>
                </ul>

            </div>

          
            
        </div>


        <div class="container">
            <div class="row">
                <div id="AgregarALL">
                    <div id="AgregarConten">
                        <div class="card shadow-lg border-primary">
                            <div class="card-header bg-primary text-white">
                                Crear cuenta
                            </div>
                            <div class="card-body">
                                <div>
                                    <label class="form-label">Nombre</label>
                                    <asp:TextBox
                                        ID="TextBoxNombre"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingresa su nombre"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" ControlToValidate="TextBoxNombre" runat="server" ErrorMessage="Ingrese nombre!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div>
                                    <label class="form-label">Apellido</label>
                                    <asp:TextBox
                                        ID="TextBoxApellido"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingresa su apellido"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" ControlToValidate="TextBoxApellido" runat="server" ErrorMessage="Ingrese apellido!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div>
                                    <label class="form-label">Nombre de usuario</label>
                                    <asp:TextBox
                                        ID="TextBoxuserName"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingresa su usuario"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatoruserName" ControlToValidate="TextBoxuserName" runat="server" ErrorMessage="El usuario es requerido!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div>
                                    <label class="form-label">Telefono</label>
                                    <asp:TextBox
                                        ID="TextBoxTelefono"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingresa su telefono"
                                        TextMode="Number"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" ControlToValidate="TextBoxTelefono" runat="server" ErrorMessage="Ingrese numero de telefono" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div>
                                    <label class="form-label">Contraseña</label>
                                    <asp:TextBox
                                        ID="TextBoxPassword"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingresa tu contraseña"
                                        TextMode="Password"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorContrasenia" ControlToValidate="TextBoxPassword" runat="server" ErrorMessage="La contraseña es requerida" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div>
                                    <label class="form-label">Rol</label>
                                    <asp:DropDownList  ID="DropDownListRol"
                                        runat="server" class="form-control">
                                    </asp:DropDownList>
                                </div>



                                <div style="margin-top: 3%" class="alert alert-danger" role="alert" runat="server" id="mensajeError">
                                    Usuario ya registrado
                                </div>
                                <div class="card-footer">
                                    <asp:Button ID="ButtonGuardar" runat="server" Text="Crear Usuario" CssClass="btn btn-primary" OnClick="ButtonGuardar_Click" />
                                </div>

                            </div>
                        </div>
                    </div>



                </div>
            </div>

            <div class="col-12">
            </div>

        </div>
    </form>
</body>
</html>
