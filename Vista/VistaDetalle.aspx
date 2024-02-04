<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="VistaDetalle.aspx.cs" Inherits="Vista.VistaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-7 col-md-6 d-flex flex-column">
            <img runat="server" id="imgArticulo" src="#" class="object-fit-contain" alt="Imagen" onerror="noImage(this)" style="max-height: 60vh" />
        </div>
        <div class="align-items-center col col-lg-auto d-flex justify-content-center my-5">
            <div class="card" style="width: 18rem;">
                <div class="card-body">
                    <h5 runat="server" id="txtNombre" class="card-title"></h5>
                    <h6 runat="server" id="txtPrecio" class="card-subtitle mb-2 text-body-secondary"></h6>
                    <p runat="server" id="txtDescripcion" class="card-text"></p>
                    <div class="card-body d-flex justify-content-end" style="font-size: 0.8rem">
                        <p runat="server" id="txtMarca" class="m-2"></p>
                        <p runat="server" id="txtCategoria" class="m-2"></p>
                    </div>
                    <%if ((Dominio.Usuario)Session["usuario"] != null)
                        {
                            if (((List<int>)Session["favoritos"]).Exists(x => x == int.Parse((string)Request.QueryString["id"])))
                            {%>
                        <asp:Button Text="Quitar de favoritos" runat="server" CssClass="btn btn-outline-danger" OnClick="quitarFavorito_Click" /><%}
                            else
                            {  %>
                        <asp:Button Text="Añadir a favoritos" runat="server" CssClass="btn btn-outline-primary" OnClick="favoritos_Click" />
                            <%}
                        }
                        else
                        { %>
                    <div title="Debe iniciar sesion para agregar a favoritos">
                        <asp:Button Text="Añadir a favoritos" runat="server" CssClass="btn btn-outline-primary" Enabled="false" ToolTip="Debe iniciar sesion para agregar a favoritos" />
                    </div>
                    <%} %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
