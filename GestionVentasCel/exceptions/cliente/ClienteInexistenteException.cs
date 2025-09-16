namespace GestionVentasCel.exceptions.cliente
{
    [Serializable]
    internal class ClienteInexistenteException : Exception
    {
        public ClienteInexistenteException()
        {
        }

        public ClienteInexistenteException(string? message) : base(message)
        {
        }

        public ClienteInexistenteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}