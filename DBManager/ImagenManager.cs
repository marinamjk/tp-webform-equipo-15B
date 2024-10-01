using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace DBManager
{
    public class ImagenManager
    {
        public List<Imagen> buscarImagenesXArticulo(int idArt)
        {
            List<Imagen> imagenes = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, IdArticulo, ImagenUrl from IMAGENES WHERE IdArticulo=" + idArt +"");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux= new Imagen();
                    aux.id = (int) datos.Lector["Id"];
                    aux.idArticulo= (int) datos.Lector["IdArticulo"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    Console.WriteLine(aux.ImagenUrl);
                    imagenes.Add(aux);
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
            return imagenes;
        }

        public void agregarImagen(Imagen imagen)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");

                accesoDatos.setearParametros("@IdArticulo", imagen.idArticulo);
                accesoDatos.setearParametros("@ImagenUrl", imagen.ImagenUrl);

                accesoDatos.ejecutarAccion();
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
        public void modificarImagen(Imagen imagen)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE Id = @Id");
                accesoDatos.setearParametros("@ImagenUrl", imagen.ImagenUrl);
                accesoDatos.setearParametros("@Id", imagen.id);
                accesoDatos.ejecutarAccion();
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

        public void eliminarPorArticulo(int idArticulo)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @idArticulo");
                datos.setearParametros("@idArticulo", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarImagen(int idImagen)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM IMAGENES WHERE Id = @idImagen");
                datos.setearParametros("@idImagen", idImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
