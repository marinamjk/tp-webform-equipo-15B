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
        
            ArticuloManager negocio = new ArticuloManager();
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    cargarArticulos();
                }
            }

            private void cargarArticulos()
            {
                dgvArticulos.DataSource = negocio.listar();
                dgvArticulos.DataBind();
            }
            protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
            {
                int id = Convert.ToInt32(dgvArticulos.SelectedDataKey.Value);
                Response.Redirect("FormularioArticulos.aspx?id=" + id);
            }

            protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                dgvArticulos.PageIndex = e.NewPageIndex;
                cargarArticulos();
            }
        }
    
}