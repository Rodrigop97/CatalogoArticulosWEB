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
        <div class="container-fluid">
            <hr />
            <div class="row">
                <div class="col-4">
                    <asp:DropDownList runat="server" ID="ddlCategoria" class="form-select form-select-sm" aria-label="Small select example"></asp:DropDownList>

                </div>
            </div>
            <div class="row">
                <div class="col-6">
                <asp:GridView runat="server" ID="gvArticulos" CssClass="table" AutoGenerateColumns="false" AllowPaging="true"
                    OnSelectedIndexChanged="gvArticulos_SelectedIndexChanged" OnRowDeleting="gvArticulos_RowDeleting" >
                    <Columns>
                        <asp:BoundField DataField="Id" Visible="false" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca"  />
                        <asp:BoundField DataField="Precio" HeaderText="Precio"/>
                        <asp:CommandField ShowSelectButton="true" SelectText="Editar" />
                        <asp:CommandField ShowDeleteButton="true" SelectText="Eliminar" />
                        <asp:CheckBoxField Text="Confirmar eliminacion" Visible="false" />
                    </Columns>
                </asp:GridView>
                    </div>
            </div>
            <div class="row">
            </div>
            <div class="row">
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>
