<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Vista.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>    
        function img() {

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-4">
        <h1 runat="server" id="h1Bienvenida" class="text-center">Bienvenido!</h1>
    </div>
    <div class="row mx-2">
        <%--    Datos del usuario   --%>
        <div class="col-5">
            <div class="row m-4">
                <label for="inputEmail3" class="col-sm-2 col-form-label">Email</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" type="email" class="form-control" ID="txbEmail" ReadOnly="true"  />
                </div>
            </div>
            
                <div class="row mb-4">
                    <asp:TextBox runat="server" type="text" class="form-control" placeholder="Nombre" id="txbNombre" />
                </div>
                <div class="row mb-4">
                    <asp:TextBox runat="server" type="text" class="form-control" placeholder="Apellido" aria-label="Last name" ID="txbApellido"/>
                </div>
            <asp:Button Text="Guardar" runat="server" class="btn btn-primary" OnClick="Guardar_Click"/>
        </div>
        <div class="col"></div>
        <%--    ARTICULOS FAVORITOS --%>
        <div class="col-6">
            <%--style="min-height:60vh; max-height:60vh">--%>
            <h2 class="m-3">Favoritos</h2>
            <div id="carouselExampleSlidesOnly" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner" style="">
                    <div class="carousel-item active" style="max-width:450px">
                        <img src="/img/icons/logo.png" class="d-block w-100" style="max-width:450px" alt="...">
                    </div>
                    <asp:Repeater runat="server" ID="repArticulos">
                        <ItemTemplate>
                            <div class="carousel-item text-center" style="background-color: white; justify-items: center; text-align: center;">
                                <img src="<%#Eval("Imagen") %>" style="" class="img-fluid" alt="Contenido no encontrado">
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <%--<div class="col-2"></div>
        <div class="col-4 mt-5">
            <div class="row">
                <% if (Session["usuario"] == null)
                    {%>
                <h2>Iniciar Sesion</h2>
                <div class="col-md-12">
                    <label for="inputEmail4" class="form-label">Email</label>
                    <asp:TextBox runat="server" ID="txbEmail" type="email" class="form-control" />
                </div>
                <div class="col-md-12">
                    <label for="inputPassword4" class="form-label">Contraseña</label>
                    <asp:TextBox runat="server" ID="txbContraseña" type="password" class="form-control" />
                </div>
                <div class="row g-3">
                    <div class="col">
                        <input type="text" class="form-control" placeholder="Nombre" aria-label="First name">
                    </div>
                    <div class="col">
                        <input type="text" class="form-control" placeholder="Apellido" aria-label="Last name">
                    </div>
                </div>
                <div class="col-12">
                    <asp:Button Text="Iniciar sesion" runat="server" CssClass="btn btn-primary mt-4" OnClick="iniciarSesion_Click" />
                    <a href="#" style="position:relative; left:10px; top:15px">Registrarse</a>
                </div>
                <%} %>
            </div>
        </div>
        <div class="col"></div>--%>
    </div>
</asp:Content>
