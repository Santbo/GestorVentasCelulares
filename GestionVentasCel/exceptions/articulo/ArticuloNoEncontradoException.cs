using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVentasCel.exceptions.articulo
{
    internal class ArticuloNoEncontradoException : Exception
    {
        public ArticuloNoEncontradoException() { }

        public ArticuloNoEncontradoException(string mensaje)
            : base(mensaje) { }

        public ArticuloNoEncontradoException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
