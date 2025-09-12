namespace GestionVentasCel.exceptions.proveedor
{
    public class ProveedorNoEncontradoException : Exception
    {
        public ProveedorNoEncontradoException(string message) : base(message) { }
        public ProveedorNoEncontradoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
