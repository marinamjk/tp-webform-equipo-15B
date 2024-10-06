<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="Presentacion.FormularioCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .validacion {
            color: red;
            font: 12px;
        }
    </style>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row g-3">
                <div class="col-1">
                </div>
                <div class="col-10">
                    <h5>Complete el formulario
                    </h5>
                </div>
                <div class="col-1">
                </div>

                <div class="col-1">
                </div>
                <div class="col-10">

                    <label>Ingrese un documento sin giones ni puntos.</label>

                </div>
                <div class="col-1">
                </div>
                <div class="col-1">
                </div>
                <div class="col-5">
                    <div class="form-floating mb-3">

                        <asp:TextBox ID="txtDocumento" OnTextChanged="txtDocumento_TextChanged" AutoPostBack="true" runat="server" class="form-control" placeholder="12345678"></asp:TextBox>
                        <label for="txtDocumento">Documento</label>
                        <asp:RegularExpressionValidator CssClass="validacion" ControlToValidate="txtDocumento" ValidationExpression="^[0-9]+$" runat="server" />
                    </div>
                </div>
                <div class="col-6">
                </div>
            </div>
            <fieldset id="fieldsetDatos" disabled="disabled">
                <div class="row g-3">
                    <div class="col-1">
                    </div>
                    <div class="col-5">
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Este campo es requerido." ControlToValidate="txtNombre" runat="server" Display="Static" />
                            <label for="txtNombre">Nombre</label>
                        </div>
                    </div>
                    <div class="col-5">
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtApellido" runat="server" class="form-control" placeholder="Apellido"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Este campo es requerido." ControlToValidate="txtApellido" runat="server" />
                            <label for="txtApellido">Apellido</label>
                        </div>
                    </div>
                    <div class="col-1">
                    </div>

                    <div class="col-1">
                    </div>
                    <div class="col-8">
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="name@example.com"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Este campo es requerido." ControlToValidate="txtEmail" runat="server" />
                            <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Ingrese un formato válido de email." ControlToValidate="txtEmail" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" runat="server" />
                            <label for="txtEmail">Email</label>
                        </div>
                    </div>
                    <div class="col-3">
                    </div>

                    <div class="col-1">
                    </div>
                    <div class="col-4">
                        <div class="form-floating mb-6">
                            <asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="direccion 1234"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Este campo es requerido." ControlToValidate="txtDireccion" runat="server" />
                            <label for="txtDireccion">Direccion</label>
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtCiudad" runat="server" class="form-control" placeholder="ciudad"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Este campo es requerido." ControlToValidate="txtCiudad" runat="server" />
                            <label for="txtCiudad">Ciudad</label>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtCP" runat="server" class="form-control" placeholder="1234"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Este campo es requerido." ControlToValidate="txtCP" runat="server" />
                            <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Ingrese sólo números." ControlToValidate="txtCP" ValidationExpression="^[0-9]+$" runat="server" />
                            <label for="txtCP">CP</label>
                        </div>
                    </div>
                    <div class="col-1">
                    </div>
         
            </fieldset>
            <div class="row g-3">
                <div class="col-1">
                </div>
                <div class="col-10">
                    <asp:Button ID="btnParticipar" OnClick="btnParticipar_Click" runat="server" Text="Registrarme" class="btn btn-primary" />
                </div>
                <div class="col-1">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="lblError" runat="server" CssClass="validacion" Visible="false"></asp:Label>

</asp:Content>
