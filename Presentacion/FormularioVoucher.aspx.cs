using DBManager;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class FormularioVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
                string codigoVoucher = voucherCode.Text.Trim(); 

                VoucherManager voucherManager = new VoucherManager();
                Voucher voucher = voucherManager.buscarVoucher(codigoVoucher);//busco el voucher en base

                if (voucher != null)
                {
                    if (voucher.IdCliente != 0)
                    {
                        Response.Redirect("VoucherError.aspx");
                    }
                    else
                    {
                        message.Text = "Voucher válido";                 
                    }
                }
                else
                {
                    Response.Redirect("VoucherError.aspx");
                }

            
        }
    }
}