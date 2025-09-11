namespace GestionVentasCel.exceptions.usuario
{
    public class UsuarioExistenteException : Exception
    {
        public UsuarioExistenteException() { }

        public UsuarioExistenteException(string mensaje)
            : base(mensaje) { }

        public UsuarioExistenteException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
