using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVentasCel.exceptions.usuario
{
    internal class UsuarioNoEncontradoException : Exception
    {
        public UsuarioNoEncontradoException() { }

        public UsuarioNoEncontradoException(string mensaje)
            : base(mensaje) { }

        public UsuarioNoEncontradoException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
