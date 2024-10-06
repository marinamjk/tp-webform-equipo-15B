<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherExito.aspx.cs" Inherits="Presentacion.VoucherExito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <<div class="container mt-5">
     <div class="row justify-content-center">
         <div class="col-md-6">  
             <div class="card">
                 <div class="card-body">
                     <h5 class="card-title text-center text-success">¡Su Voucher fue canjeado exitosamente!</h5>
                     <p class="text-center">!El voucher ingresado fue válidado y felicitaciones!.</p>
                     <div class="d-grid">
                         <asp:Button ID="btnVolverInicio" runat="server" Text="Volver al inicio" CssClass="btn btn-primary" OnClick="btnVolverInicio_Click"/>
                     </div>
                 </div>
             </div>
         </div>
     </div>
 </div>
</asp:Content>
