<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vista.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>    
        function img() {

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mx-5 text-center">Bienvenido!</h1>
    <div class="row">
        <div class="col"></div>
        <div class="col-4 mt-5">
            <%--style="min-height:60vh; max-height:60vh">--%>
            <div id="carouselExampleSlidesOnly" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner" style="">
                    <div class="carousel-item active" style="">
                        <img src="/img/icons/logo.png" class="d-block w-100" alt="...">
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
        <div class="col"></div>
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
