<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="VistaDetalle.aspx.cs" Inherits="Vista.VistaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-7 col-md-6 d-flex flex-column">
                <img runat="server" id="imgArticulo" src="#" class="object-fit-contain" alt="Imagen" onerror="noImage(this)" style="max-height:60vh"  />
            <% if ((Dominio.Usuario)Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).Admin) { %>
            <div class="d-inline">
                <select onchange="change()" runat="server" id="sImg" class="m-3 btn border-dark-subtle">
                    <option value="local">Imagen local</option>
                    <option value="internet">Imagen de internet</option>
                </select>
                 <input type="file" id="imgLocal" runat="server" class="form-control" ClientIDMode="Static" onchange="cargarImgLocal(this)"  />
                <input type="url" id="imgInternet" placeholder="URL imagen" runat="server" class="form-control d-none" ClientIDMode="Static" onblur="cargarImgWeb(this)" />
            </div>
                <%}%>
        </div>
        <div class="align-items-center col col-lg-auto d-flex justify-content-center my-5">
            <div class="card" style="width: 18rem;">
                <div class="card-body">
                    <% if ((Dominio.Usuario)Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).Admin)
                        {                    %>
                    <%--<h5 runat="server" id="H1" class="card-title"></h5>
                    <h6 runat="server" id="H2" class="card-subtitle mb-2 text-body-secondary"></h6>
                    <p runat="server" id="P1" class="card-text"></p>--%>
                    <asp:Textbox runat="server" type="text"  Class="form-control card-title" id="txbNombre"  />
                    <asp:Textbox runat="server" type="number"  ID="txbPrecio" Class="card-subtitle form-control mb-2 text-body-secondary" />
                    <asp:TextBox runat="server" type="text" CssClass="card-text form-control"  id="txbDescripcion" TextMode="MultiLine"/>
                    <div class="card-body d-flex justify-content-end" style="font-size:0.8rem">
                        <asp:DropDownList runat="server" ID="ddlMarca" CssClass="rounded-3 border"></asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="rounded-3 border"></asp:DropDownList>
                    </div>
                    <asp:Button Text="Guardar cambios" runat="server" CssClass="btn btn-outline-primary" OnClick="guardar_Click" />
                    <%}
                        else
                        {  %>
                    <h5 runat="server" id="txtNombre" class="card-title"></h5>
                    <h6 runat="server" id="txtPrecio" class="card-subtitle mb-2 text-body-secondary"></h6>
                    <p runat="server" id="txtDescripcion" class="card-text"></p>
                    <div class="card-body d-flex justify-content-end" style="font-size:0.8rem">
                        <p runat="server" ID="txtMarca" CssClass="rounded-3 border"></p>
                        <p runat="server" ID="txtCategoria" CssClass="rounded-3 border"></p>
                    </div>
                    <asp:Button Text="Añadir a favoritos" runat="server" CssClass="btn btn-outline-primary" OnClick="favoritos_Click" />
                    <%} %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
