<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoProductos.aspx.cs" Inherits="Presentacion.ListadoProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <div class="row">
       <div class="col">

        <asp:GridView ID="dgvArticulos" runat="server" class="table table-dark table-striped table-hover" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Marca" />
                <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
            </Columns>
        </asp:GridView>

       </div>
   </div>

</asp:Content>
