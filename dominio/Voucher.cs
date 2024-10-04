using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Voucher
    {
        public string CodigoVoucher { get; set; }
        public int idCliente { get; set;}
        public DateTime fecha { get; set;}
        public int idArticulo { get; set;}
    }
}
