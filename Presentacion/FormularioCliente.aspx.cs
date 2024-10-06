using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using DBManager;
using System.Text.RegularExpressions;

namespace Presentacion
{
    public partial class FormularioCliente : System.Web.UI.Page
    {
        private Cliente cliente;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
            
                ClienteManager clienteManager = new ClienteManager();
                int idCliente;
                if (cliente == null)
                {
                    cliente = new Cliente();
                    cliente.Dni = txtDocumento.Text;
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Ciudad = txtCiudad.Text;
                    cliente.CP = int.Parse(txtCP.Text);

                    idCliente = clienteManager.agregarCliente(cliente);
                }
                else
                {
                    idCliente = cliente.Id;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error: " + ex.Message;
                lblError.Visible = true;
            }
            //Modificar el voucher por id con el idCliente y el idArticulo seleccionado
            //Request.QueryString["idVoucher"];
            //Request.QueryString["idArticulo"];
            //Redirigir a una pantalla de exito
            Response.Redirect("Default.aspx", false);
        }

        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            
            if (!IsValidDocumento(txtDocumento.Text))
            {
                return;
            }

            try
                {
                ClienteManager clienteManager = new ClienteManager();
                cliente = clienteManager.buscarClientePorDNI(txtDocumento.Text);
                if (cliente != null)
                {                
                   
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtEmail.Text = cliente.Email;
                    txtDireccion.Text= cliente.Direccion;
                    txtCiudad.Text = cliente.Ciudad;
                    txtCP.Text= (cliente.CP).ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "disableFieldset", "document.getElementById('fieldsetDatos').disabled = true;", true);

                } 
                else
                {    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "enableFieldset", "document.getElementById('fieldsetDatos').disabled = false;", true);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error: " + ex.Message; 
                lblError.Visible = true;
            }
        }

        private bool IsValidDocumento(string documento)
        {
            return Regex.IsMatch(documento, "^[0-9]+$");
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtCP.Text = string.Empty;
        }
    }
}