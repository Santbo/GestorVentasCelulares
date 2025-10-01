namespace GestionVentasCel.exceptions.usuario
{
    public class UsuarioNoEncontradoException : Exception
    {
        public UsuarioNoEncontradoException() { }

        public UsuarioNoEncontradoException(string mensaje)
            : base(mensaje) { }

        public UsuarioNoEncontradoException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
