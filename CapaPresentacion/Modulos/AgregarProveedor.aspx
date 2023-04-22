<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarProveedor.aspx.cs" Inherits="CapaPresentacion.Modulos.AgregarProveedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="../css/StyleEmpleados.css" rel="stylesheet" />
    <script src="../JS/Roles.js"></script>
    <script src="../JS/sweetalert2.all.min.js"></script>
    <title></title>
</head>
<body>
        <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div id="AgregarALL">
                    <div id="AgregarConten">
                        <div class="card shadow-lg border-primary">
                            <div class="card-header bg-primary text-white">
                                Agregar Proveedor
                            </div>
                            <div class="card-body">
                                <div>
                                    <label class="form-label">Nombre Empresa</label>
                                    <asp:TextBox
                                        ID="TextBoxNombre"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingrese el nombre de la empresa"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" ControlToValidate="TextBoxNombre" runat="server" ErrorMessage="Ingrese un nombre!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div>
                                    <label class="form-label">Direccion</label>
                                    <asp:TextBox
                                        ID="TextBoxDireccion"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingrese la direccion "></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDireccion" ControlToValidate="TextBoxDireccion" runat="server" ErrorMessage="Ingrese una direccion!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div>
                                    <label class="form-label">Nombre de Vendedor</label>
                                    <asp:TextBox
                                        ID="TextBoxVendedor"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingrese nombre del vendedor"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorVendedor" ControlToValidate="TextBoxVendedor" runat="server" ErrorMessage="Ingrese un nombre de vendedor!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div>
                                    <label class="form-label">Telefono Vendedor</label>
                                    <asp:TextBox
                                        ID="TextBoxTelefono"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingresa telefono del vendedor"
                                        TextMode="Number"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" ControlToValidate="TextBoxTelefono" runat="server" ErrorMessage="Ingrese numero de telefono" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div>
                                    <label class="form-label">Correo Electronico</label>
                                    <asp:TextBox
                                        ID="TextBoxCorreo"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingrese Correo electronico"
                                        TextMode="Email"
                                       ></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCorreo" ControlToValidate="TextBoxCorreo" runat="server" ErrorMessage="Ingrese un Correo" CssClass="text-danger"></asp:RequiredFieldValidator>
                                 
                                <div class="card-footer">
                                    <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="ButtonGuardar_Click" />
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
