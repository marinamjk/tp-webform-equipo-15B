﻿<%@ Page Title="Seleccion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formularioSeleccion.aspx.cs" Inherits="Presentacion.formularioSeleccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="row row-cols-1 row-cols-md-3 g-4">
       <asp:Repeater ID="repArticulos" runat="server">
           <ItemTemplate>

               <div class="col">
                   <div class="card  border-dark mb-3" style="max-width: 20rem;">
                       <img src="<%# ((List<dominio.Imagen>)Eval("Imagenes"))[0].ImagenUrl %>>" class="card-img-top" alt="...">
                       <div class="card-body">
                           <h5 class="card-title"><%# Eval("Nombre") %></h5>
                           <p class="card-text"><%# Eval("Descripcion") %></p>
                           <h5 class="card-title"><%# Eval("Precio") %></h5>                            
                           <a class ="btn btn-primary" href="formularioArticulos.aspx?id=<%# Eval("Id") %>">Detalle </a>
                       </div>
                   </div>
               </div>

           </ItemTemplate>

       </asp:Repeater>
   </div>
</asp:Content>
