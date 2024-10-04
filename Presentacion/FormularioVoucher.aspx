<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioVoucher.aspx.cs" Inherits="Presentacion.FormularioVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">  
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title text-center">Ingresa el codigo del Voucher</h5>
                        <form id="voucherForm">
                        <div class="mb-3">
                            <input type="text" class="form-control" id="voucherCode" name="voucherCode" placeholder="Ingresa tu código" required>
                        </div>
                        <div class="d-grid">
                            <button type="submit" class="btn btn-primary">Verificar</button>
                        </div>
                        <div class="mt-3">
                            <p id="message" class="text-danger text-center"></p> <!-- Mensajes de error o éxito -->
                        </div>
                    </form>
                    </div>
                </div>
            </div>
        </div>

    </div>




</asp:Content>
