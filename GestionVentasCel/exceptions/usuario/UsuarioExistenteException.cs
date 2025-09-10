using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVentasCel.exceptions.usuario
{
    public class UsuarioExistenteException : Exception
    {
        public UsuarioExistenteException() { }

        public UsuarioExistenteException(string mensaje)
            : base(mensaje) { }

        public UsuarioExistenteException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
