using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVentasCel.exceptions.caja
{
    public class CajaYaCerradaException : Exception
    {
        public CajaYaCerradaException() { }

        public CajaYaCerradaException(string mensaje)
            : base(mensaje) { }

        public CajaYaCerradaException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
