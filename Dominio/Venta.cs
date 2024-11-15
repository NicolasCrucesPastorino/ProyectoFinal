using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int idVenta { get; set; }
        public string numeroVenta { get; set; }
        public int idTipoDocumentoVenta { get; set; }
        public int idUsuario { get; set; }
        public string documentoClientes { get; set; }
        public string nombreCliente { get; set; }
        public float subTotal { get; set; }
        public float impuestoTotal { get; set; }
        public float Total { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int Id_cliente { get; set; }

    }
}
 