namespace GestionVentasCel.exceptions.cliente
{
    public class MovimientoInexistenteException : Exception
    {

        public MovimientoInexistenteException() { }

        public MovimientoInexistenteException(string mensaje)
            : base(mensaje) { }

        public MovimientoInexistenteException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
