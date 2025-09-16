namespace GestionVentasCel.exceptions.persona
{
    public class CuitDuplicadoException : Exception
    {
        public CuitDuplicadoException() : base("El CUIT ya existe en el sistema.")
        {
        }

        public CuitDuplicadoException(string message) : base(message)
        {
        }

        public CuitDuplicadoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
