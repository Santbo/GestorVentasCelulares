namespace GestionVentasCel.exceptions.reparacion
{
    public class ReparacionNoEncontradaException : Exception
    {
        public ReparacionNoEncontradaException(string message) : base(message) { }
        public ReparacionNoEncontradaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
