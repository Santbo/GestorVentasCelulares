using GestionVentasCel.models.clientes;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.persona;

namespace GestionVentasCel.service.cliente
{
    public interface IClienteService
    {

        void CrearCliente(Cliente cliente);
        /// <summary>
        /// Crear un nuevo cliente, pero partiendo desde una persona existente. Solamente se tiene que agregar los datos nullables en persona
        /// Hay que asegurarse de que la persona tenga una calle fijada.
        /// </summary>
        /// <param name="PersonaId"></param>
        /// <param name="TipoDocumento"></param>
        /// <param name="Dni"></param>
        /// <param name="CondicionIVA"></param>

        IEnumerable<Cliente> ListarClientes();
        void UpdateCliente(Cliente cliente);
        void ToggleActivo(int id);

        CuentaCorriente? ObtenerCuentaCorriente(Cliente cliente);
        decimal ObtenerSaldoCuentaCorriente(CuentaCorriente cuenta);

        void CrearCuentaCorriente(Cliente cliente);

        void EliminarMovimiento(MovimientoCuentaCorriente movimiento);
        void RegistrarMovimientoCuentaCorriente(Cliente cliente, MovimientoCuentaCorriente movimiento);
        Cliente? GetById(int id);

        IEnumerable<Persona> ObtenerPersonasSinClientes();
        Persona? GetPersonaById(int id);
        IEnumerable<CuentaCorriente> ObtenerCuentasCorrientes();
        void ToggleActivoCuentaCorriente(int id);
        DateTime? ObtenerFechaUltimoMovimiento(CuentaCorriente cuenta);
        IEnumerable<Cliente> ObtenerClientesSinCuentas();
        void ActualizarMovimientoCuentaCorriente(MovimientoCuentaCorriente movimiento);
    }
}
