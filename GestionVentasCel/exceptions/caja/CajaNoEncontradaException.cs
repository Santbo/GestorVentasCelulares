namespace GestionVentasCel.exceptions.caja
{
    public class CajaNoEncontradaException : Exception
    {
        public CajaNoEncontradaException() { }

        public CajaNoEncontradaException(string mensaje)
            : base(mensaje) { }

        public CajaNoEncontradaException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
