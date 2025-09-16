namespace GestionVentasCel.exceptions.compra
{
    public class CompraNoEncontradaException : Exception
    {
        public CompraNoEncontradaException(string message) : base(message) { }
        public CompraNoEncontradaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
