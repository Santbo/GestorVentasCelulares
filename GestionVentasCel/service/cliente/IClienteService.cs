using GestionVentasCel.enumerations.persona;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.persona;

namespace GestionVentasCel.service.cliente
{
    public interface IClienteService
    {

        void CrearCliente (Cliente cliente);
        /// <summary>
        /// Crear un nuevo cliente, pero partiendo desde una persona existente. Solamente se tiene que agregar los datos nullables en persona
        /// Hay que asegurarse de que la persona tenga una calle fijada.
        /// </summary>
        /// <param name="PersonaId"></param>
        /// <param name="TipoDocumento"></param>
        /// <param name="Dni"></param>
        /// <param name="CondicionIVA"></param>
        void CrearCliente(
            int PersonaId,
            TipoDocumentoEnum TipoDocumento,
            string Dni,
            CondicionIVAEnum CondicionIVA,
            string? Calle = null,
            string? Ciudad = null
        );

        /// <summary>
        /// Crear un nuevo cliente, creando primero una nueva persona.
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="Telefono"></param>
        /// <param name="TipoDocumento"></param>
        /// <param name="Dni"></param>
        /// <param name="Email"></param>
        void CrearCliente(
            string Nombre,
            string? Apellido,
            TipoDocumentoEnum TipoDocumento,
            string Dni,
            CondicionIVAEnum CondicionIVA,
            string Telefono,
            string Email,
            string Calle,
            string Ciudad
            );

        IEnumerable<Cliente> ListarClientes();
        void UpdateCliente(Cliente cliente);
        void ToggleActivo(int id);

        CuentaCorriente? ObtenerCuentaCorriente(Cliente cliente);
        Decimal ObtenerSaldoCuentaCorriente(Cliente cliente);

        void CrearCuentaCorriente(Cliente cliente);

        void EliminarCuentaCorriente(Cliente cliente);

        void EliminarMovimiento(MovimientoCuentaCorriente movimiento);
        void RegistrarMovimientoCuentaCorriente(Cliente cliente, MovimientoCuentaCorriente movimiento);
        Cliente? GetById(int id);

        IEnumerable<Persona> ObtenerPersonasSinClientes();
        Persona? GetPersonaById(int id);
    }
}
