using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace DBManager
{
    public class ClienteManager
    {
        public Cliente buscarClientePorDNI(string documento)
        {
            Cliente aux = null;
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @documento");
                accesoDatos.setearParametros("@documento", documento);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    aux = new Cliente();

                    aux.Id = (int)accesoDatos.Lector["Id"];
                    aux.Dni = (string)accesoDatos.Lector["Documento"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Apellido = (string)accesoDatos.Lector["Apellido"];
                    aux.Email = (string)accesoDatos.Lector["Email"];
                    aux.Direccion = (string)accesoDatos.Lector["Direccion"];
                    aux.Ciudad = (string)accesoDatos.Lector["Ciudad"];
                    aux.CP = (int)accesoDatos.Lector["CP"];

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
            return aux;
        }

        public int agregarCliente(Cliente cliente)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO Clientes(Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP)" +
                                           "OUTPUT INSERTED.Id " +  // Esta línea devuelve el ID del artículo recién creado
                                           "VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");

                accesoDatos.setearParametros("@Documento", cliente.Dni);
                accesoDatos.setearParametros("@Nombre", cliente.Nombre);
                accesoDatos.setearParametros("@Apellido", cliente.Apellido);
                accesoDatos.setearParametros("@Email", cliente.Email);
                accesoDatos.setearParametros("@Direccion", cliente.Direccion);
                accesoDatos.setearParametros("@Ciudad", cliente.Ciudad);
                accesoDatos.setearParametros("@CP", cliente.CP);

                int idClienteNuevo = (int)accesoDatos.ejecutarEscalar();
                return idClienteNuevo;
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
    }
}
