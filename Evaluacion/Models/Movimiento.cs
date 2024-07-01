using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluacion.Models
{
    public class Movimiento
    {
        public string codCia { get; set; }
        public string companiaVenta { get; set; }
        public string almacenVenta { get; set; }
        public string tipoMovimiento { get; set; }
        public string tipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public string codItem { get; set; }
        public string proveedor { get; set; }
        public string almacendestino { get; set; }
        public string cantidad { get; set; }

        public DateTime fechaTransaccion { get; set; }
    }
}