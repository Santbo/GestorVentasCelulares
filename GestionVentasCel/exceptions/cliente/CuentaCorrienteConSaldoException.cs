namespace GestionVentasCel.exceptions.cliente
{
    public class CuentaCorrienteConSaldoException : Exception
    {

        public CuentaCorrienteConSaldoException() { }

        public CuentaCorrienteConSaldoException(string mensaje)
            : base(mensaje) { }

        public CuentaCorrienteConSaldoException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
