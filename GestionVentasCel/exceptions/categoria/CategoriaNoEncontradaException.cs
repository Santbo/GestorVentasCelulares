using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVentasCel.exceptions.categoria
{
    public class CategoriaNoEncontradaException : Exception
    {
        
        public CategoriaNoEncontradaException() { }

        public CategoriaNoEncontradaException(string mensaje)
            : base(mensaje) { }

        public CategoriaNoEncontradaException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
        
    }
}
