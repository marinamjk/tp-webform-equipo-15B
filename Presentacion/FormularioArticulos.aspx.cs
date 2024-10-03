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
                cargarMarcas();
                cargarCategorias();
                string idQuery = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idQuery))
                {
                    int idArticulo = int.Parse(idQuery);
                    cargarArticulo(idArticulo);
                }

            }
        }
        private void cargarMarcas()
        {
            MarcaManager marcaManager = new MarcaManager();
            List<Marca> lista = marcaManager.listar();

            ddlMarca.DataSource = lista;
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataBind();
        }
        private void cargarCategorias() 
        {
            CategoriaManager categoriaManager = new CategoriaManager();
            List<Categoria> lista = categoriaManager.listar();

            ddlCategoria.DataSource = lista;
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataBind();
        
        }
        private void cargarArticulo(int idArticulo)
        {

            ArticuloManager articulo_manager = new ArticuloManager();
            Articulo articulo = articulo_manager.listar().FirstOrDefault(a => a.Id == idArticulo);

            // Si el artículo existe
            if (articulo != null)
            {
                // Se asignan los valores a los controles del formulario
                txtId.Text = articulo.Id.ToString();
                txtNombre.Text = articulo.Nombre;
                txtNumero.Text = articulo.Codigo;
                txtDescripcion.Text = articulo.Descripcion;
                
                
                if (ddlMarca.Items.FindByValue(articulo.Marca.Id.ToString()) != null)
                {
                    ddlMarca.SelectedValue = articulo.Marca.Id.ToString();
                }
                if (ddlCategoria.Items.FindByValue(articulo.Categoria.id.ToString()) != null)
                {
                    ddlCategoria.SelectedValue = articulo.Categoria.id.ToString();
                }

                if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                {
                    imgArticulo.ImageUrl = articulo.Imagenes[0].ImagenUrl;
                }
                else
                {
                    imgArticulo.ImageUrl = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png";
                }

            }
        }
    }
}