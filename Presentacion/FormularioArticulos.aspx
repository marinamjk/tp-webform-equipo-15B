<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="Presentacion.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Formulario de Articulos</h1>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" ReadOnly="true"/>
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
            <div class="mb-3">
                <a href="ListadoProductos.aspx" class="btn btn-secondary">Cancelar</a>
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" ReadOnly="true" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                        runat="server" ID="imgArticulo" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
