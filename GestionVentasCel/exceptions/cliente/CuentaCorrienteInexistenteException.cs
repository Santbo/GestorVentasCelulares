namespace GestionVentasCel.exceptions.cliente
{
    public class CuentaCorrienteInexistenteException : Exception
    {

        public CuentaCorrienteInexistenteException() { }

        public CuentaCorrienteInexistenteException(string mensaje)
            : base(mensaje) { }

        public CuentaCorrienteInexistenteException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
