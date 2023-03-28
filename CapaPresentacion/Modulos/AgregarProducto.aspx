<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="CapaPresentacion.Modulos.AgregarProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="../css/StyleEmpleados.css" rel="stylesheet" />
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
                                Ingresar Producto
                            </div>
                            <div class="card-body">
                                <div>
                                    <label class="form-label">Codigo del Producto</label>
                                    <asp:TextBox
                                        ID="codigoProducto"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingresa codigo del producto"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCodigoProducto" ControlToValidate="codigoProducto" runat="server" ErrorMessage="Ingrese codigo del producto!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div>
                                    <label class="form-label">Nombre</label>
                                    <asp:TextBox
                                        ID="NombreProducto"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingresa el nombre del producto"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombreProducto" ControlToValidate="NombreProducto" runat="server" ErrorMessage="Ingrese el nombre del producto!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                

                                <div>
                                    <label class="form-label">Precio</label>
                                    <asp:TextBox
                                        ID="precioProducto"
                                        runat="server"
                                        CssClass="form-control"
                                        type="number"
                                        step="0.01"
                                        placeholder="Precio Producto"
                                        min="0"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrecioProducto" ControlToValidate="PrecioProducto" runat="server" ErrorMessage="Ingrese precio producto!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                
                                <div>
                                    <label class="form-label">Descripcion</label>
                                    <asp:TextBox
                                        ID="TextBoxDescripcion"
                                        runat="server"
                                        CssClass="form-control"
                                        TextMode="MultiLine"
                                        placeholder="Ingresa una descripcion"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcion" ControlToValidate="TextBoxDescripcion" runat="server" ErrorMessage="Ingrese una pequeña descripcion!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div class="card-footer">
                                    <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="ButtonAgregar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
