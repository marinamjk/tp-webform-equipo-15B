<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="Presentacion.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalles de Articulos</h1>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo: </label>
                <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria: </label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server" Enabled="false"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server" Enabled="false"></asp:DropDownList>
            </div>
<<<<<<< HEAD
=======
            <div class="mb-3">
                <a href="Default.aspx" class="btn btn-primary">Volver</a>
            </div>
>>>>>>> 00f86db459a83b0dd18c22ae5ca3b7f9a7dbe249
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" ReadOnly="true" />
            </div>
   <%--         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                    <%--           <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                        runat="server" ID="imgArticulo" Width="60%" />--%>
                    <div id="carouselImagenes" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <asp:Repeater ID="repeterImagenes" runat="server">
                                  <ItemTemplate>
                                <div class="carousel-item<%# Container.ItemIndex == 0 ? " active" : "" %>">
                                    <asp:Image ImageUrl='<%# Eval("imagenUrl") %>' class="d-block w-100" runat="server" />
                                </div>
                                 </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselImagenes" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselImagenes" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>

            <div class="mb-3 d-flex justify-content-end">
                <a href="Default.aspx" class="btn btn-secondary">Salir</a>
            </div>
         <%--       </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
</asp:Content>
