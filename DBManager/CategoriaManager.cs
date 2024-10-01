using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
  public class CategoriaManager 
  { 
    public List<Categoria> listar()
    {
        List<Categoria> lista = new List<Categoria>();
        AccesoDatos datos = new AccesoDatos();

        try
        {
            datos.setearConsulta("Select Id, Descripcion From CATEGORIAS");
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Categoria aux = new Categoria();
               
                aux.id = (int)datos.Lector["Id"];

               if (!(datos.Lector["Descripcion"] is DBNull))
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                lista.Add(aux);
            }

            return lista;
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
        public void agregar(Categoria categoria) // no se si es mejor mandar el string antes que un objeto
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert Into CATEGORIAS (Descripcion) Values (@Descripcion)");
                datos.setearParametros("@Descripcion", categoria.Descripcion);
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

        public void modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update CATEGORIAS Set Descripcion = @Descripcion where id= @id");
                datos.setearParametros("@Descripcion", categoria.Descripcion);
                datos.setearParametros("@id", categoria.id);
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
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE from CATEGORIAS WHERE id= @id");
                datos.setearParametros("@id", id);
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
    }

}
