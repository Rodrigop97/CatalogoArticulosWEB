<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="Vista.Acceso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <div class="container d-flex flex-column align-items-center text-bg-dark">
            <div class="row d-flex justify-content-center">
                <img src="img/icons/technologyLogo.png" alt="LOGO" class="img-fluid w-25" />
            </div>
            <div class="row">
                <div class="border border-2 m-5 p-5 rounded-5" style="max-width: 550px">
                    <h3>Bienvenido</h3>
                    <div class="mb-3">
                        <label for="txbEmail" class="form-label">Email</label>
                        <asp:TextBox runat="server" type="email" ID="txbEmail" class="form-control" aria-describedby="emailHelp" />
                        <div id="emailHelp" class="form-text"></div>
                    </div>
                    <div class="mb-3">
                        <label for="txbContraseña" class="form-label">Contraseña</label>
                        <asp:TextBox runat="server" ID="txbContraseña" type="password" class="form-control" />
                    </div>
                    <% if (Request.QueryString["signin"] == null)
                        {
                    %>
                    <asp:Button runat="server" Text="Iniciar sesion" CssClass="btn btn-primary" OnClick="login_Click" />
                    <a href="Acceso.aspx?signin=true">Registrarse</a>
                    <%}
                        else
                        {  %>
                    <div class="mb-3">
                        <label for="txbNombre" class="form-label">Nombre (opcional)</label>
                        <asp:TextBox runat="server" type="text" ID="txbNombre" class="form-control"/>
                    </div>
                    <div class="mb-3">
                        <label for="txbApellido" class="form-label">Apellido (opcional)</label>
                        <asp:TextBox runat="server" type="text" ID="txbApellido" class="form-control" />
                    </div>
                    <div class="mb-3 form-check">
                        <asp:CheckBox ID="cbxAdmin" runat="server" />
                        <label class="form-check-label" for="cbxAdmin">Solicitar rol admin</label>
                    </div>
                    <asp:Button runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="signin_Click" />
                    <a href="Catalogo.aspx">Cancelar</a>
                    <%} %>
                </div>
            </div>
        </div>
    </form>
</body>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</html>
