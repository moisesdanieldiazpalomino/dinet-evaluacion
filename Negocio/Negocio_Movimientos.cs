using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class Negocio_Movimientos
    {
        bool resultado;
        public bool RegistrarMovimientos(Movimiento obj)
        {
            return Datos_Movimientos.RegistrarMovimiento(obj);
        }

        public List<Movimiento> BuscarMovimientos(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string numeroDocumento)
        {
            return Datos_Movimientos.Buscar(fechaInicio, fechaFin, tipoMovimiento, numeroDocumento);
        }
    }
}
