using DBManager;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class formularioSeleccion : System.Web.UI.Page
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
            try
            {
                string IdArticuloStr = ((Button)sender).CommandArgument;
                int IdArticulo = int.Parse(IdArticuloStr);
                Session.Add("idArtSeleccionado", IdArticulo);
                Response.Redirect("FormularioCliente.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }

        }
    }
}