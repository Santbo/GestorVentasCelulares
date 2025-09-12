using GestionVentasCel.enumerations.persona;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.persona;
using GestionVentasCel.service.cliente;

namespace GestionVentasCel.controller.cliente
{
    public class ClienteController
    {
        public readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        public void CrearCliente(Cliente cliente)
        {
            _service.CrearCliente(cliente);
        }


        public IEnumerable<Cliente> ObtenerClientes() => _service.ListarClientes();
        public IEnumerable<Persona> ObtenerPersonasSinClientes() => _service.ObtenerPersonasSinClientes();

        public void ToggleActivo(int id)
        {
            _service.ToggleActivo(id);
        }

        public Cliente? GetById(int id)
        {
            return _service.GetById(id);
        }

        public void ActualizarCliente(Cliente cliente)
        {
            _service.UpdateCliente(cliente);
        }

        public Persona? GetPersonaById(int id)
        {
            return _service.GetPersonaById(id);
        }

        public IEnumerable<CuentaCorriente> ObtenerCuentasCorrientes() => _service.ObtenerCuentasCorrientes();

        public void ToggleActivoCuentaCorriente(int id)
        {
            _service.ToggleActivoCuentaCorriente(id);
        }

        public Decimal ObtenerSaldoCuentaCorriente(CuentaCorriente cuenta)
        {
            return _service.ObtenerSaldoCuentaCorriente(cuenta);
        }


        public DateTime? ObtenerFechaUltimoMovimiento(CuentaCorriente cuenta)
        {
            return _service.ObtenerFechaUltimoMovimiento(cuenta);
        }

        public void CrearCuentaCorriente(Cliente cliente)
        {
            _service.CrearCuentaCorriente(cliente);
        }
    }
}
