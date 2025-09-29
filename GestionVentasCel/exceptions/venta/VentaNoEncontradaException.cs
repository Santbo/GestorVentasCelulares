namespace GestionVentasCel.exceptions.venta
{
    internal class VentaNoEncontradaException : Exception
    {
        public VentaNoEncontradaException() { }

        public VentaNoEncontradaException(string mensaje)
            : base(mensaje) { }

        public VentaNoEncontradaException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
