namespace GestionVentasCel.exceptions.venta
{
    internal class ConfirmacionVentaDupicadaException : Exception
    {
        public ConfirmacionVentaDupicadaException() { }

        public ConfirmacionVentaDupicadaException(string mensaje)
            : base(mensaje) { }

        public ConfirmacionVentaDupicadaException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
