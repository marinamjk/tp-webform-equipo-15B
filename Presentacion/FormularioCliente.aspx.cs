using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using DBManager;

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
            ClienteManager clienteManager = new ClienteManager();
            try
            {
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

                    int nuevoCliente= clienteManager.agregarCliente(cliente);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error",ex);
            }
            //Modificar el voucher con el idCliente del nuevoCliente y el idArticulo seleccionado
            //Redirigir a una pantalla de exito
            Response.Redirect("Default.aspx", false);
        }

        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            ClienteManager clienteManager= new ClienteManager();
            try
            {
                cliente= clienteManager.buscarClientePorDNI(txtDocumento.Text);
                if (cliente != null)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtEmail.Text = cliente.Email;
                    txtDireccion.Text= cliente.Direccion;
                    txtCiudad.Text = cliente.Ciudad;
                    txtCP.Text= (cliente.CP).ToString();
                } 
                else
                {
                    txtNombre.Text = string.Empty;
                    txtApellido.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtDireccion.Text = string.Empty;
                    txtCiudad.Text = string.Empty;
                    txtCP.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error",ex);
            }
        }
    }
}