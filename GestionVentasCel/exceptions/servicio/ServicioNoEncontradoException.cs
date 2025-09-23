namespace GestionVentasCel.exceptions.servicio
{
    public class ServicioNoEncontradoException : Exception
    {
        public ServicioNoEncontradoException() { }

        public ServicioNoEncontradoException(string mensaje)
            : base(mensaje) { }

        public ServicioNoEncontradoException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
