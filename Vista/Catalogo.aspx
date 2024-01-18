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
        <div class="col-3">
            <h4>Filtros aplicados</h4>
            <hr />
            <div class="m-4">
                <h4 class="">Marca</h4>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
                    <label class="form-check-label" for="flexCheckDefault">
                        Samsung
                    </label>
                </div>

                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked">
                    <label class="form-check-label" for="flexCheckChecked">
                        Motorola
                    </label>
                </div>
            </div>
            <div class="m-4">
                <h4 class="">Categoria</h4>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="categoria1">
                    <label class="form-check-label" for="categoria1">
                        Televisores
                    </label>
                </div>

                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="categoria2">
                    <label class="form-check-label" for="categoria2">
                        Celulares
                    </label>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="row row-cols-2 row-cols-sm-3 row-cols-lg-4 g-4 mt-auto">
                <asp:Repeater runat="server" ID="repRepetidor">
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
