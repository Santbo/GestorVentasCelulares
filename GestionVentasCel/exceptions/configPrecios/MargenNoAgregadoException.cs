using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVentasCel.exceptions.configPrecios
{
    public class MargenNoAgregadoException : Exception
    {
        public MargenNoAgregadoException() { }

        public MargenNoAgregadoException(string mensaje)
            : base(mensaje) { }

        public MargenNoAgregadoException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}

