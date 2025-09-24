namespace GestionVentasCel.exceptions.reparacion
{
    public class DispositivoNoEncontradoException : Exception
    {
        public DispositivoNoEncontradoException(string message) : base(message) { }
        public DispositivoNoEncontradoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
