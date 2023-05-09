<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaPresentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link href="../css/StyleLogin.css" rel="stylesheet" />
   
    <title></title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
</head>


<body>
    <div id="principal">
        <form id="form1" runat="server">

            <asp:Label ID="Label1" runat="server" Visible="false" Text="Label"></asp:Label>

            <div id="titulo">

                <p>Unidad de neumología</p>
            </div>
            <div class="mi-div">
                <div class="mi2-div ">
                    <h2 style="font-family: Modern Sample; font-weight: bolder; margin-left: 120px; color: white; margin-top: -10px">Login</h2>


                    <div class="mb-3">

                        <img src="https://cdn-icons-png.flaticon.com/512/5087/5087579.png">
                        <div class="mb-3">
                            <label for="validationCustomUsername" class="form-label" style="font-family: Modern Sample; font-size: 17px; color: white" class="form-label">Usuario</label>
                            <div class="input-group has-validation">
                                <span class="input-group-text" id="inputGroupPrepend"></span>
                                <input type="text" class="form-control" runat="server" id="txtNombre" 
                                    aria-describedby="inputGroupPrepend" required>
                                <div class="invalid-feedback">
                                    Please choose a username.
                                </div>
                            </div>

                        </div>


                    </div>
                    <div class="mb-3">
                        <label for="validationCustomUsername" class="form-label" style="font-family: Modern Sample; font-size: 17px; color: white" class="form-label">Contraseña</label>
                        <div class="input-group has-validation">
                            <span class="input-group-text" id="inputGroupPrepend"></span>
                            <input type="password" class="form-control" runat="server" id="txtContra" aria-describedby="inputGroupPrepend" required>
                            <div class="invalid-feedback">
                                Please choose a username.
                            </div>
                        </div>

                        <div style="margin-top: 3%" class="alert alert-danger" role="alert" runat="server" id="error">
                            Usuario o contraseña incorrecta
                        </div>

                        <asp:Button ID="boton" class="btn" runat="server" Text="Ingresar" OnClick="boton_Click" />

                    </div>





                </div>


            </div>


        </form>
    </div>
</body>
</html>
