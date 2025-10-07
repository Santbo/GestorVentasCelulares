namespace GestionVentasCel.exceptions.articulo
{
    public class ArticuloNoEncontradoException : Exception
    {
        public ArticuloNoEncontradoException() { }

        public ArticuloNoEncontradoException(string mensaje)
            : base(mensaje) { }

        public ArticuloNoEncontradoException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
