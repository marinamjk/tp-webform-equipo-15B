using DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class ListadoProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloManager negocio = new ArticuloManager();
            try
            {
            dgvArticulos.DataSource = negocio.listar();
            dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}