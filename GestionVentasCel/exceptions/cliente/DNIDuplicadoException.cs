using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVentasCel.exceptions.cliente
{
    [Serializable]
    public class DNIDuplicadoException : Exception
    {
        public DNIDuplicadoException()
        {
        }

        public DNIDuplicadoException(string? message) : base(message)
        {
        }

        public DNIDuplicadoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
