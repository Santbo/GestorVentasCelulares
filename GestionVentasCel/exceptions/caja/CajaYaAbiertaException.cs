using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVentasCel.exceptions.caja
{
    public class CajaYaAbiertaException : Exception
    {
        public CajaYaAbiertaException() { }

        public CajaYaAbiertaException(string mensaje)
            : base(mensaje) { }

        public CajaYaAbiertaException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
