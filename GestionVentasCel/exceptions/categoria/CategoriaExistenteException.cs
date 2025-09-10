using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVentasCel.exceptions.categoria
{
    public class CategoriaExistenteException : Exception
    {
        public CategoriaExistenteException() { }

        public CategoriaExistenteException(string mensaje)
            : base(mensaje) { }

        public CategoriaExistenteException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
