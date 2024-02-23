<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="Vista.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .carta:hover {
            transform: scale(1.02);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="row my-4">
        <%--    FILTROS   --%>
        <div class="col-3 mt-3 z-2">
            <div class="sticky-top" style="top: 70px">
                <h4>Filtros aplicados</h4>
                <hr />
                <%--Ordenar por --%>
                <div class="d-flex align-items-baseline">
                    <%--<label>Ordenar por:</label>--%>
                    <h6>Ordenar por: </h6>
                    <asp:DropDownList runat="server" ID="ddlOrdenar" AutoPostBack="true" 
                        OnSelectedIndexChanged="ejecutarFiltros" CssClass="border-0" >
                        <asp:ListItem Text="Mas relevante" />
                        <asp:ListItem Text="Menor precio" />
                        <asp:ListItem Text="Mayor precio" />
                    </asp:DropDownList>
                </div>
                <%--    CATEGORIA   --%>
                <div class="m-4">
                    <h5 class="">Categoria</h5>
                    <ul class="list-group-item">
                        <asp:RadioButtonList runat="server" ID="rblCategoria" OnSelectedIndexChanged="ejecutarFiltros" AutoPostBack="true">
                        </asp:RadioButtonList>
                    </ul>
                </div>
                <%--    MARCA   --%>
                <div class="m-4">
                    <h5 class="">Marca</h5>
                    <ul class="list-group-item">
                        <asp:CheckBoxList runat="server" ID="cblMarca" AutoPostBack="true" OnSelectedIndexChanged="ejecutarFiltros">
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
                <%--    PRECIO --%>
                <div class="m-4">
                    <h5 class="">Precio</h5>
                    <div class="row g-3">
                        <div class="col">
                            <asp:TextBox runat="server" type="Number" class="form-control" placeholder="Min" ID="txbPrecioMin" />
                        </div>
                        <div class="col-1">
                            <span style="align-self: center">-</span>
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" type="Number" class="form-control" placeholder="Max" ID="txbPrecioMax" />
                        </div>
                        <div class="col-1">
                            <asp:Button Text=">" runat="server" CssClass="btn btn-primary" OnClick="ejecutarFiltros" />
                        </div>
                    </div>
                </div>
                <a href="Catalogo.aspx" class="m-4">Borrar filtros</a>
            </div>
        </div>
        <%--    CATALOGO   --%>
        <div class="col">
            <div class="row row-cols-2 row-cols-sm-3 row-cols-lg-4 g-4 mt-auto">
                <asp:Repeater runat="server" ID="repArticulos">
                    <ItemTemplate>
                        <div class="card-group carta">
                            <div class="card">
                                <img src="<%#((string)Eval("Imagen")).Replace("~/","")%>" class="card-img-top img-thumbnail object-fit-contain" alt="imagen-<%#Eval("Nombre") %>" onerror="noImage(this)" style="max-height: 250px; min-height: 225px" />
                                <div class="card-body">
                                    <p class="card-title"><%#Eval("Nombre") %></p>
                                    <h5 class="card-text">$ <%#Eval("Precio") %> </h5>
                                    <a class="btn btn-primary" href="VistaDetalle.aspx?id=<%#Eval("Id")%>">Ver mas </a>
                                </div>
                                <%--<div class="card-footer">
                            </div>--%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
