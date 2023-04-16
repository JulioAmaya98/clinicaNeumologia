<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarInventario.aspx.cs" Inherits="CapaPresentacion.AgregarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                                    <label class="form-label">Proveedor</label>
                                    <asp:DropDownList  ID="dropProveedor"
                                        runat="server" class="form-control" OnSelectedIndexChanged="dropProveedor_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                  <div>
                                    <label class="form-label">Codigo del Producto</label>
                                    <asp:DropDownList  ID="dropCodigoProducto"
                                        runat="server" class="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <label class="form-label">Stock</label>
                                    <asp:TextBox
                                        ID="TextBoxStock"
                                        runat="server"
                                        CssClass="form-control"
                                        TextMode="Number"
                                        min="0"
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
                                    <label class="form-label">Lote</label>
                                    <asp:TextBox
                                        ID="txtLote"
                                        runat="server"
                                        CssClass="form-control"
                                        TextMode="Number"
                                        placeholder="Ingresa el lote del producto"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrecio" ControlToValidate="txtLote" runat="server" ErrorMessage="Ingrese el lote del producto!" CssClass="text-danger"></asp:RequiredFieldValidator>
                                
                                <div>
                                    <label class="form-label">Ubicacion</label>
                                    <asp:TextBox
                                        ID="txtUbicacion"
                                        runat="server"
                                        CssClass="form-control"
                                        TextMode="MultiLine"
                                        placeholder="Ingresa la ubicación"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcion" ControlToValidate="txtUbicacion" runat="server" ErrorMessage="Ingrese una ubicacion!" CssClass="text-danger"></asp:RequiredFieldValidator>
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
