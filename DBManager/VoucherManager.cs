using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
    public class VoucherManager
    {
        public Voucher buscarVoucher(string codigoVoucher)
        {
            Voucher aux = null;
            AccesoDatos accesoDatos = new AccesoDatos();
            
             try
            {
                accesoDatos.setearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher = @codigoVoucher");
                accesoDatos.setearParametros("@codigoVoucher", codigoVoucher);
                accesoDatos.ejecutarLectura();
               
                if (accesoDatos.Lector.Read())
                {
                    aux = new Voucher();

                    aux.CodigoVoucher = (string)accesoDatos.Lector["CodigoVoucher"];
                    
                    //!= DBNull.Value ?  se manejan si hay nulos
                    aux.IdCliente = accesoDatos.Lector["IdCliente"] != DBNull.Value ? (int)accesoDatos.Lector["IdCliente"] : 0;
                    aux.FechaCanje = accesoDatos.Lector["FechaCanje"] != DBNull.Value ? (DateTime)accesoDatos.Lector["FechaCanje"] : DateTime.MinValue;
                    aux.IdArticulo = accesoDatos.Lector["IdArticulo"] != DBNull.Value ? (int)accesoDatos.Lector["IdArticulo"] : 0;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error en la busqueda - VoucherManager - buscarVoucher",ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
            return aux;
        }
        public void modificar(Voucher voucher)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Vouchers SET IdCliente = @IdCliente, FechaCanje = @FechaCanje, IdArticulo = @IdArticulo WHERE CodigoVoucher = @CodigoVoucher;");
            
                datos.setearParametros("@IdCliente", voucher.IdCliente);
                datos.setearParametros("@FechaCanje", voucher.FechaCanje);
                datos.setearParametros("@IdArticulo", voucher.IdArticulo);
                datos.setearParametros("@CodigoVoucher", voucher.CodigoVoucher);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error - VoucherMAnager - Modificar", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

