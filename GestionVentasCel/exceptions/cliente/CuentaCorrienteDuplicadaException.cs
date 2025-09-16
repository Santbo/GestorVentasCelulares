namespace GestionVentasCel.exceptions.cliente
{
    public class CuentaCorrienteDuplicadaException : Exception
    {

        public CuentaCorrienteDuplicadaException() { }

        public CuentaCorrienteDuplicadaException(string mensaje)
            : base(mensaje) { }

        public CuentaCorrienteDuplicadaException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
