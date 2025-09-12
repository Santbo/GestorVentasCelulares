namespace GestionVentasCel.exceptions.proveedor
{
    public class ProveedorExistenteException : Exception
    {
        public ProveedorExistenteException(string message) : base(message) { }
        public ProveedorExistenteException(string message, Exception innerException) : base(message, innerException) { }
    }
}
