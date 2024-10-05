<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherError.aspx.cs" Inherits="Presentacion.VoucherError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <<div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">  
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title text-center text-danger">Error con el Voucher</h5>
                        <p class="text-center">El voucher ingresado es inválido o ya ha sido utilizado.</p>
                        <div class="d-grid">
                            <asp:Button ID="btnVolverInicio" runat="server" Text="Volver al inicio" CssClass="btn btn-primary" OnClick="btnVolverInicio_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
