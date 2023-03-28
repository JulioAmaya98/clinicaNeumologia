<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarInventario.aspx.cs" Inherits="CapaPresentacion.AgregarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="css/StyleEmpleados.css" rel="stylesheet" />
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
                                    <label class="form-label">Nombre Producto</label>
                                    <asp:TextBox
                                        ID="TextBoxNombreProducto"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Ingresa nombre del producto"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombreProducto" ControlToValidate="TextBoxNombreProducto" runat="server" ErrorMessage="Ingrese nombre del producto!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div>
                                    <label class="form-label">Stock</label>
                                    <asp:TextBox
                                        ID="TextBoxStock"
                                        runat="server"
                                        CssClass="form-control"
                                        TextMode="Number"
                                        placeholder="Ingresa la cantidad del producto"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorStock" ControlToValidate="TextBoxStock" runat="server" ErrorMessage="Ingrese la cantidad!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                

                                <div>
                                    <label class="form-label">Fecha vencimiento</label>
                                    <asp:TextBox
                                        ID="TextBoxFechaVencimiento"
                                        runat="server"
                                        CssClass="form-control"
                                        TextMode="Date"
                                        placeholder="Ingresa la fecha de vencimiento"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaVencimiento" ControlToValidate="TextBoxFechaVencimiento" runat="server" ErrorMessage="Ingrese la fecha de vencimiento!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <div>
                                    <label class="form-label">Precio</label>
                                    <asp:TextBox
                                        ID="TextBoxPrecio"
                                        runat="server"
                                        CssClass="form-control"
                                        type="number"
                                        step="0.01"
                                        placeholder="Ingresa precio del producto"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrecio" ControlToValidate="TextBoxPrecio" runat="server" ErrorMessage="Ingrese precio de producto!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                
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
                                    <asp:Button ID="ButtonGuardar" runat="server" Text="Ingresar Producto" CssClass="btn btn-primary" OnClick="ButtonGuardar_Click" />
                                    <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" CssClass="btn btn-warning"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
