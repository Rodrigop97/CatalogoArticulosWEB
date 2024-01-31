<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionArticulos.aspx.cs" Inherits="Vista.GestionArticulos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestion de articulos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <hr />
                <%--        busqueda rapida     --%>
            <div class="row m-3">
                <div class="input-group w-75">
                    <asp:TextBox runat="server" ID="txbBusquedaRapida" type="text" class="form-control" placeholder="Busqueda rapida (nombre, marca, categoria...)" aria-label="Recipient's username" aria-describedby="button-addon2" />
                    <asp:Button runat="server" class="btn btn-outline-secondary" type="button" Text="Buscar" OnClick="busquedaRapida_Click" />
                </div>
            </div>
            <%--        Categoria y marca       --%>
            <div class="row m-3">
                <div class="input-group col">
                    <label class="input-group-text" for="ddlCategoria">Categoria</label>
                    <asp:DropDownList runat="server" CssClass="form-select" ID="ddlCategoria" >
                    </asp:DropDownList>
                </div>
                <div class="input-group col">
                    <label class="input-group-text" for="ddlCategoria">Marca</label>
                    <asp:DropDownList runat="server" CssClass="form-select" ID="ddlMarca">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row m-3">
                <%--        Precio      --%>
                <div class="input-group col-lg col-md col-sm">
                    <span class="input-group-text">Precio</span>
                    <asp:TextBox runat="server" type="number" id="txbPrecioMin" placeholder="Precio minimo"  class="form-control"/>
                    <asp:TextBox runat="server" type="number" id="txbPrecioMax" placeholder="Precio maximo" class="form-control"/>
                </div>
                <%--        Buscar      --%>
                <div class="col">
                    <asp:Button Text="Buscar" CssClass="btn btn-success" runat="server" OnClick="Buscar_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <%--        Tabla articulos     --%>
                    <asp:GridView runat="server" ID="gvArticulos" CssClass="table" AutoGenerateColumns="false" AllowPaging="true"
                        OnSelectedIndexChanged="gvArticulos_SelectedIndexChanged" PageSize="8" OnRowDeleting="gvArticulos_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="Id" Visible="false" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                            <asp:BoundField DataField="Marca" HeaderText="Marca" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                            <asp:CommandField ShowSelectButton="true" SelectText="Editar" />
                            <asp:CommandField ShowDeleteButton="true" SelectText="Eliminar" />
                            <asp:CheckBoxField Text="Confirmar eliminacion" Visible="false" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="d-flex justify-content-end">
                    <asp:Button Text="Agregar nuevo" runat="server" CssClass="btn btn-primary m-3" OnClick="agregarNuevo_Click" />
                    <asp:Button Text="Salir" runat="server" CssClass="btn btn-danger m-3" OnClick="salir_Click" />
                </div>
            </div>
            <div class="row">
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>
