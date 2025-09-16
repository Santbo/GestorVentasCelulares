namespace GestionVentasCel.exceptions.cliente
{
    public class PersonaNoExisteException : Exception
    {

        public PersonaNoExisteException() { }

        public PersonaNoExisteException(string mensaje)
            : base(mensaje) { }

        public PersonaNoExisteException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
