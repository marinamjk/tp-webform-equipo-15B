using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace DBManager
{
    public class ArticuloManager
    {
        public List<Articulo> listar()
        {
            List<Articulo> catalogo= new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
    
            try
            {
                datos.setearConsulta("SELECT A.Id as ArticuloId, Codigo, Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, A.IdMarca, A.IdCategoria, Precio FROM ARTICULOS A JOIN MARCAS M ON M.Id = A.IdMarca JOIN CATEGORIAS C ON C.Id = A.IdCategoria ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux= new Articulo();
                    aux.Id = (int) datos.Lector["ArticuloId"];

                    if(!(datos.Lector["Codigo"] is DBNull))
                    aux.Codigo = (string) datos.Lector["Codigo"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string) datos.Lector["Nombre"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string) datos.Lector["Descripcion"];

                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca = new Marca();

                    aux.Marca.Id = (int)datos.Lector["IdMarca"];

                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                                     
                    aux.Categoria.id = (int)datos.Lector["IdCategoria"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal) datos.Lector["Precio"];

                    ImagenManager im = new ImagenManager();
                    aux.Imagenes= im.buscarImagenesXArticulo(aux.Id);
                    catalogo.Add(aux);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            finally 
            {
                datos.cerrarConexion();
            }
            return catalogo;
        }
    
        public int agregar(Articulo articulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                //("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion,@IdMarca, @IdCategoria, @Precio)");
              

                // Insertar el artículo y devolver el ID insertado
                accesoDatos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) " +
                                           "OUTPUT INSERTED.Id " +  // Esta línea devuelve el ID del artículo recién creado
                                           "VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");

                accesoDatos.setearParametros("@Codigo", articulo.Codigo);
                accesoDatos.setearParametros("@Nombre", articulo.Nombre);
                accesoDatos.setearParametros("@Descripcion", articulo.Descripcion);
                accesoDatos.setearParametros("@IdMarca", articulo.Marca.Id);
                accesoDatos.setearParametros("@IdCategoria", articulo.Categoria.id);
                accesoDatos.setearParametros("@Precio", articulo.Precio);

                // Ejecutar la consulta y devolver el ID
                int idArticuloNuevo = (int)accesoDatos.ejecutarEscalar();
                return idArticuloNuevo;


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");

                datos.setearParametros("@Codigo", articulo.Codigo);
                datos.setearParametros("@Nombre", articulo.Nombre);
                datos.setearParametros("@Descripcion", articulo.Descripcion);
                datos.setearParametros("@IdMarca", articulo.Marca.Id);
                datos.setearParametros("@IdCategoria", articulo.Categoria.id);
                datos.setearParametros("@Precio", articulo.Precio);
                datos.setearParametros("@Id", articulo.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    
        public void eliminar(int id) 
        {
            try
            {
                // Eliminar imágene
                ImagenManager imagenManager = new ImagenManager();
                imagenManager.eliminarPorArticulo(id);

                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> ordenarLista(List<Articulo> listaArticulos,string TipoOrden)
        {
            if(TipoOrden == "Menor a mayor")
            {
                return listaArticulos.OrderBy(a => a.Precio).ToList();
            }
            else
            {
                return listaArticulos.OrderByDescending(a => a.Precio).ToList();
            }
        }

        public List<Articulo> ordenarListaAlfabeto(List<Articulo> listaArticulos,string TipoOrden)
        {
            if(TipoOrden == "Alfabeticamente de A-Z")
            {
                return listaArticulos.OrderBy(x => x.Marca.ToString()).ToList();
            }
            else
            {
                return listaArticulos.OrderByDescending(x => x.Marca.ToString()).ToList();
            }
        }

        public List<Articulo> filtrar(string campo,string criterio,string filtro)
        {
            List<Articulo> ListaFiltrada = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id as ArticuloId, Codigo, Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, A.IdMarca, A.IdCategoria, Precio FROM ARTICULOS A JOIN MARCAS M ON M.Id = A.IdMarca JOIN CATEGORIAS C ON C.Id = A.IdCategoria And ";
                switch (campo)
                {
                    case "Precio":
                        if(criterio == "Menor a")
                        {
                            consulta += "Precio <" + filtro;
                        }else if(criterio == "Mayor a")
                        {
                            consulta += "Precio >" + filtro;
                        }
                        else
                        {
                            consulta += "precio = " + filtro;
                        }
                        break;
                    case "Marca":
                        if(criterio == "Termina con")
                        {
                            consulta += "M.Descripcion like '%" + filtro + "'";
                        }else if(criterio == "Empieza con")
                        {
                            consulta += "M.Descripcion like '" + filtro + "%' ";
                        }
                        else
                        {
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                        }
                        break;

                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["ArticuloId"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.id = (int)datos.Lector["IdCategoria"];



                    aux.Precio = (decimal)datos.Lector["Precio"];



                    ImagenManager im = new ImagenManager();
                    aux.Imagenes = im.buscarImagenesXArticulo(aux.Id);
                    ListaFiltrada.Add(aux);
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                datos.cerrarConexion();
            }
            return ListaFiltrada;
        }
    }
}
