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
