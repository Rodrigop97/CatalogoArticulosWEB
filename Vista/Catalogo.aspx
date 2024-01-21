<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="Vista.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function noImage(img) {
            img.src = "img/utilities/noImage.jpg";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--        Solo para ver como se muestran los datos        --%>
    <%--<asp:DataGrid ID="gvArticulos" CssClass="table" runat="server" >
    </asp:DataGrid>--%>
    <%--<div class="row row-cols-2 row-cols-sm-4 g-4 mt-auto">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col>
                    <div class="card" style="width: 18rem;">
                        <img src="" class="card-img-top" alt="...">
                        <div class="card-body">
                            <p class="card-text"></p>
                            <h5 class="card-title">$ <%#Eval("Precio") %> </h5>
                            <a href="#" class="btn btn-primary">Comprar</a>
                            <a href="#">Ver más</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>--%>
    <div class="row">
        <div class="col-3 mt-3">
            <h4>Filtros aplicados</h4>
            <hr />
            <div class="m-4">
                <h4 class="">Categoria</h4>
                <ul class="list-group-item">
                    <asp:RadioButtonList runat="server" ID="rblCategoria" OnSelectedIndexChanged="rblCategoria_SelectedIndexChanged" AutoPostBack="true">
                    </asp:RadioButtonList>
                </ul>
            </div>
            <div class="m-4">
                <h4 class="">Marca</h4>
                <ul class="list-group-item">
                    <%--Funciona la MARCA--%>
                    <asp:CheckBoxList runat="server" ID="cblMarca" AutoPostBack="true" OnSelectedIndexChanged="cblMarca_SelectedIndexChanged" >    
                    </asp:CheckBoxList>

                    <%--<asp:Repeater runat="server" ID="cblMarca">
                        <ItemTemplate>
                            <li class="list-group-item">
                                <label class="form-check-label" for='<%# "chkMarca_" + Eval("Descripcion") %>'><%# Eval("Descripcion") %></label>
                                <asp:CheckBox runat="server" OnCheckedChanged="cblMarca_SelectedIndexChanged"  AutoPostBack="true"/>
                                <label class="form-check-label" for="marca-<%#Eval("Descripcion") %>"><%#Eval("Descripcion") %></label>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>--%>
                    <%--<li class="list-group-item">
                        <a href="#" runat="server" id="vmMarca">Ver mas</a>
                    </li>--%>
                </ul>
            </div>
            <div class="m-4">
                <h4 class="">Precio</h4>
                <div class="row g-3">
                    <div class="col">
                        <asp:TextBox runat="server" type="Number" class="form-control" placeholder="Min" ID="precioMin" />
                    </div>
                    <div class="col-1">
                        <span style="align-self: center">-</span>
                    </div>
                    <div class="col">
                        <asp:TextBox runat="server" type="Number" class="form-control" placeholder="Max" ID="precioMax" />
                    </div>
                    <div class="col-1">
                        <asp:Button Text=">" runat="server" CssClass="btn btn-primary" OnClick="rango_Click" />
                    </div>
                </div>
            </div>

            <a href="Catalogo.aspx" class="m-4">Borrar filtros</a>
        </div>
        <div class="col">
            <div class="row row-cols-2 row-cols-sm-3 row-cols-lg-4 g-4 mt-auto">
                <asp:Repeater runat="server" ID="repArticulos">
                    <ItemTemplate>
                        <div class="card-group">
                            <div class="card">
                                <img src="<%#Eval("Imagen")%>" class="card-img-top img-thumbnail" alt="imagen-<%#Eval("Nombre") %>" onerror="noImage(this)" />
                                <div class="card-body">
                                    <p class="card-title"><%#Eval("Nombre") %></p>
                                    <h5 class="card-text">$ <%#Eval("Precio") %> </h5>
                                    <a href="#" class="btn btn-primary">Comprar</a>
                                    <a href="#">Ver más</a>
                                </div>
                                <%--<div class="card-footer">
                                <small class="text-body-secondary">Last updated 3 mins ago</small>
                            </div>--%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
