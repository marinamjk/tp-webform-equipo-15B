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
    
    public partial class _Default : Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloManager negocio = new ArticuloManager();

            try
            {
                ListaArticulos = negocio.listar();

                if (!IsPostBack)
                {
                    repArticulos.DataSource = ListaArticulos;
                    repArticulos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
        protected void BtSeleccionar_Click(object sender, EventArgs e)
        {
            string IdArticulo = ((Button)sender).CommandArgument;
            Response.Redirect("FormularioCliente.ASPX?ID=" + IdArticulo);
        }
    }
}