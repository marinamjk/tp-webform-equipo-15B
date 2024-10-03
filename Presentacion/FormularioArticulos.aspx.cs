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
    public partial class FormularioArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idQuery = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idQuery))
                {
                    int idArticulo = int.Parse(idQuery);
                    cargarArticulo(idArticulo);
                }

            }
        }
        private void cargarArticulo(int id_articulo)
        {

            ArticuloManager articulo_manager = new ArticuloManager();
            Articulo articulo = articulo_manager.listar().FirstOrDefault(a => a.Id == id_articulo);

            // Verificar si el artículo existe
            if (articulo != null)
            {
                // Asignar los valores a los controles del formulario
                txtId.Text = articulo.Id.ToString();
                txtNombre.Text = articulo.Nombre;
                txtNumero.Text = articulo.Codigo;
                txtDescripcion.Text = articulo.Descripcion;
                ddlMarca.SelectedValue = articulo.Marca.Id.ToString();
                ddlCategoria.SelectedValue = articulo.Categoria.id.ToString();

            }
        }
    }
}