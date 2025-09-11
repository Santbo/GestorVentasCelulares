using GestionVentasCel.enumerations.persona;
using GestionVentasCel.models.clientes;
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
        public void CrearCliente(
            int PersonaId,
            TipoDocumentoEnum TipoDocumento,
            string Dni,
            CondicionIVAEnum condicionIVA,
            string? Calle = null,
            string? Ciudad = null)
        {
            _service.CrearCliente(
                PersonaId: PersonaId,
                TipoDocumento: TipoDocumento,
                Dni: Dni,
                CondicionIVA: condicionIVA,
                Calle: Calle,
                Ciudad: Ciudad);
        }

        public void CrearCliente(string Nombre, string? Apellido, TipoDocumentoEnum TipoDocumento, string Dni, CondicionIVAEnum CondicionIVA, string Telefono, string Email, string Calle, string Ciudad)
        {
            _service.CrearCliente(
                Nombre: Nombre,
                Apellido: Apellido,
                TipoDocumento: TipoDocumento,
                Dni: Dni,
                CondicionIVA: CondicionIVA,
                Calle: Calle,
                Ciudad: Ciudad,
                Telefono: Telefono,
                Email: Email
                );

        }

        public IEnumerable<Cliente> ObtenerClientes() => _service.ListarClientes();

        public void ToggleActivo(int id)
        {
            _service.ToggleActivo(id);
        }

        public Cliente? GetById(int id)
        {
            return _service.GetById(id);
        }

        internal void ActualizarCliente(Cliente cliente)
        {
            _service.UpdateCliente(cliente);
        }
    }
}
