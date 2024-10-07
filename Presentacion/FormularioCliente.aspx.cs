using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using DBManager;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Presentacion
{
    public partial class FormularioCliente : System.Web.UI.Page
    {
        private Cliente cliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                DocValidator.Validate();
        }


        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            Voucher voucher = new Voucher();
            VoucherManager mVoucher = new VoucherManager();
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
                string IdVoucher = Session["IdCoidgoVoucher"].ToString();
                int IdSelec = ((int)(Session["idArtSeleccionado"]));
                voucher.CodigoVoucher = IdVoucher;
                voucher.IdArticulo = IdSelec;
                voucher.IdCliente = idCliente;
                voucher.FechaCanje = DateTime.Now;
                mVoucher.modificar(voucher);
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error: " + ex.Message;
                lblError.Visible = true;
            }
            //Modificar el voucher por id con el idCliente y el idArticulo seleccionado
            //Session["idCodArt"].ToString();
            //(int)Session["idArtSeleccionado"];
            //Redirigir a una pantalla de exito
            Response.Redirect("VoucherExito.aspx", false);
        }

        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {

            if (!IsValidDocumento(txtDocumento.Text))
            {
                // Deshabilitar el fieldset si el documento es inválido
                string script = "document.getElementById('fieldsetDatos').disabled = true;";
                ScriptManager.RegisterStartupScript(this, GetType(), "DisableFieldset", script, true);
                return; // Salir de la función si el documento es inválido
            }

           

            try
                {
                ClienteManager clienteManager = new ClienteManager();
                cliente = clienteManager.buscarClientePorDNI(txtDocumento.Text);
                if (!(cliente is null))
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
                    LimpiarCampos();
                    // Habilitar el fieldset si el documento es válido y no exite
                    string enableScript = "document.getElementById('fieldsetDatos').disabled = false;";
                    ScriptManager.RegisterStartupScript(this, GetType(), "EnableFieldset", enableScript, true);
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