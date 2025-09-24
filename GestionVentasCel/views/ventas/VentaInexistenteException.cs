
namespace GestionVentasCel.views.usuario_empleado
{
    [Serializable]
    internal class VentaInexistenteException : Exception
    {
        public VentaInexistenteException()
        {
        }

        public VentaInexistenteException(string? message) : base(message)
        {
        }

        public VentaInexistenteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}