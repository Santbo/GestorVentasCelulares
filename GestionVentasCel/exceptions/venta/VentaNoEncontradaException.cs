namespace GestionVentasCel.exceptions.venta
{
    public class VentaNoEncontradaException : Exception
    {
        public VentaNoEncontradaException() { }

        public VentaNoEncontradaException(string mensaje)
            : base(mensaje) { }

        public VentaNoEncontradaException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
