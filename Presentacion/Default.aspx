<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repArticulos" runat="server">
            <ItemTemplate>

                <div class="col">
                    <div class="card  border-dark mb-3" style="max-width: 20rem;">
                        <img src="<%# ((List<dominio.Imagen>)Eval("Imagenes"))[0].ImagenUrl %>>" class="card-img-top" alt="..." style="height: 400px; object-fit: contain;" >
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <h4 class="card-title" style="color: blue; text-align: right;">$<%# Eval("Precio", "{0:F2}") %></h4>                            
                            <a href="formularioArticulos.aspx?id=<%# Eval("Id") %>" class="btn btn-primary">Ver Detalle</a>
                        </div>
                    </div>
                </div>

            </ItemTemplate>

        </asp:Repeater>
    </div>
</asp:Content>
