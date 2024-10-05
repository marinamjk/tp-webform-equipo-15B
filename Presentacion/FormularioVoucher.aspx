<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioVoucher.aspx.cs" Inherits="Presentacion.FormularioVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">  
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title text-center">Ingresa el código del Voucher</h5>
                        <div class="mb-3">
                            <asp:TextBox ID="voucherCode" runat="server" CssClass="form-control" placeholder="Ingresa tu código" required></asp:TextBox>
                        </div>
                        <div class="d-grid">
                            <asp:Button ID="btnVerificar" runat="server" Text="Verificar" CssClass="btn btn-primary" OnClick="btnVerificar_Click"/>
                        </div>
                        <div class="mt-3">
                            <asp:Label ID="message" runat="server" CssClass="text-danger text-center"></asp:Label> <!-- si es valido muestra un mensaje y deberia redirigir si no muestra mensaje de error -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
