using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVentasCel.exceptions.persona
{
    public class CuitInvalidoException :Exception
    {
        public CuitInvalidoException() : base("El CUIT ya existe en el sistema.")
        {
        }

        public CuitInvalidoException(string message) : base(message)
        {
        }

        public CuitInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
