<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="VistaDetalle.aspx.cs" Inherits="Vista.VistaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    function noImage(img) {
        img.src = "img/utilities/noImage.jpg";
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-7 col-md-6 text-center">
            <img runat="server" id="imgArticulo" src="#"  alt="Imagen" onerror="noImage(this)" style="max-width:450px" />
        </div>
        <div class="align-items-center col col-lg-auto d-flex justify-content-center">
            <div class="card" style="width: 18rem;">
                <div class="card-body">
                    <h5 runat="server" id="txtNombre" class="card-title"></h5>
                    <h6 runat="server" id="txtPrecio" class="card-subtitle mb-2 text-body-secondary"></h6>
                    <p runat="server" id="txtDescripcion" class="card-text"></p>
                    <asp:Button Text="Añadir a favoritos" runat="server" CssClass="button" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
