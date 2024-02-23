<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelArticulos.aspx.cs" Inherits="Vista.PanelArticulos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container px-5 py-2 shadow pb-5">
            <div class="row m-4">
                <h3 runat="server" id="titulo"></h3>
            </div>
            <div class="row">
                <div class="col">
                    <div class="col-md-6 m-2">
                        <label for="txbCodigo" class="form-label">Codigo</label>
                        <asp:TextBox runat="server" ID="txbCodigo" type="text" cssclass="form-control" required />
                    </div>
                    <div class="col-md-6 m-2">
                        <label for="txbNombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="txbNombre" type="text" cssclass="form-control" required />
                    </div>
                    <div class="col-12 m-2">
                        <label for="txbDescripcion" class="form-label">Descripcion</label>
                        <asp:TextBox runat="server" id="txbDescripcion" type="text" cssclass="form-control" required TextMode="MultiLine"/>
                    </div>
                    <div class="row">
                        <div class="col-4 m-2">
                            <label for="ddlMarca" class="form-label">Marca</label>
                            <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select" >
                                <asp:ListItem Text="text1" />
                                <asp:ListItem Text="text2" />
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 m-2">
                            <label for="ddlCategoria" class="form-label">Categoria</label>
                            <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select">
                                <asp:ListItem Text="text1" />
                                <asp:ListItem Text="text2" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3 m-2">
                        <label for="txbPrecio" class="form-label">Precio</label>
                        <asp:TextBox runat="server" ID="txbPrecio" TextMode="Number" class="form-control" required />
                    </div>
                </div>
                <%--        Imagen      --%>
                <div class="col-lg-7 col-md-6 d-flex flex-column">
                    <img runat="server" id="imgArticulo" src="#" class="object-fit-contain" alt="Imagen" onerror="noImage(this)" style="max-height: 60vh" />
                    <div class="d-inline">
                        <select onchange="change()" runat="server" id="sImg" class="m-3 btn border-dark-subtle text-start">
                            <option value="local">Imagen local</option>
                            <option value="internet">Imagen de internet</option>
                        </select>
                        <input type="file" id="imgLocal" runat="server" class="form-control" clientidmode="Static" onchange="cargarImgLocal(this)" />
                        <input type="url" id="imgInternet" placeholder="URL imagen" runat="server" class="form-control d-none" clientidmode="Static" onblur="cargarImgWeb(this)" />
                    </div>
                </div>
            </div>
            <%--        Boton Guardar/Agregar/Eliminar      --%>
            <div class="row">
                <div class="col-md-4">
                    <% if (int.Parse(Request.QueryString["id"]) == -1)
                        { %>
                    <asp:Button Text="Agregar articulo" ID="btnArgergar" runat="server" CssClass="btn btn-primary" OnClick="btnArgergar_Click" />
                    <%}
                        else if ((string)Request.QueryString["eliminar"] != null){%>
                    <h4>Desea elimiar el articulo?</h4>
                    <asp:Button Text="Si, eliminar" ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                    <%} else { %>
                    <asp:Button Text="Guardar" ID="btnGuardar" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <%} %>
                    <a href="GestionArticulos.aspx">Cancelar</a>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
    <script src="Scripts/mainJS.js"></script>
</body>
</html>
