namespace GestionVentasCel.exceptions.persona
{
    public class DocumentoDuplicadoException : Exception
    {
        public DocumentoDuplicadoException() : base("El CUIT ya existe en el sistema.")
        {
        }

        public DocumentoDuplicadoException(string message) : base(message)
        {
        }

        public DocumentoDuplicadoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
