using GestionVentasCel.enumerations.cuentaCorriente;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.persona;
using GestionVentasCel.repository.ClienteCuentaCorriente;
using GestionVentasCel.repository.persona;

namespace GestionVentasCel.service.cliente.impl
{
    public class ClienteServiceImpl : IClienteService
    {

        private readonly IClienteRepository _repo;
        private readonly IPersonaRepository _repoPersona;
        private readonly ICuentaCorrienteRepository _repoCuentaCorriente;

        public ClienteServiceImpl(IClienteRepository repo, IPersonaRepository repoPersona, ICuentaCorrienteRepository repoCuentaCorriente)
        {
            _repo = repo;
            _repoPersona = repoPersona;
            _repoCuentaCorriente = repoCuentaCorriente;
        }

        public void CrearCliente(int PersonaId, TipoDocumentoEnum TipoDocumento, string Dni, CondicionIVAEnum CondicionIVA, string? Calle = null, string? Ciudad = null)
        {
            var persona = _repoPersona.GetById(PersonaId)
                    ?? throw new PersonaNoExisteException("La persona no existe");

            if (_repo.Exist(PersonaId))
                throw new InvalidOperationException("La persona ya es cliente");

            if (persona.Calle == null)
            {
                if (Calle == null)
                {
                    throw new ArgumentException("Mientras se creaba un cliente, se intentó asignar una calle nula a la persona");
                }
                else
                {
                    persona.Calle = Calle;
                }
            }

            if (persona.Ciudad == null)
            {
                if (Ciudad == null)
                {
                    throw new ArgumentException("Mientras se creaba un cliente, se intentó asignar una ciudad nula a la persona");
                }
                else
                {
                    persona.Ciudad = Ciudad;
                }
            }


            persona.TipoDocumento = TipoDocumento;
            persona.Dni = Dni;
            persona.CondicionIVA = CondicionIVA;

            _repoPersona.Update(persona);

            var cliente = new Cliente { Id = persona.Id };

            _repo.Add(cliente);

        }

        public void CrearCliente(string Nombre, string? Apellido, TipoDocumentoEnum TipoDocumento, string Dni, CondicionIVAEnum CondicionIVA, string Telefono, string Email, string Calle, string Ciudad)
        {
            var cliente = new Cliente
            {
                Nombre = Nombre,
                Apellido = Apellido,
                TipoDocumento = TipoDocumento,
                Dni = Dni,
                CondicionIVA = CondicionIVA,
                Telefono = Telefono,
                Email = Email,
                Calle = Calle,
                Ciudad = Ciudad
            };

            // Guardar en base de datos
            _repo.Add(cliente);
        }

        public void CrearCuentaCorriente(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                throw new ClienteInexistenteException("Se intentó crear una cuenta corriente a un cliente que no se ha insertado todavía (tiene id=0)");
            }
            if (_repoCuentaCorriente.GetByClienteId(cliente.Id) != null)
            {
                throw new CuentaCorrienteDuplicadaException("Se intentó abrir una cuenta corriente a un cliente que ya tenía una");
            }

            _repoCuentaCorriente.Add(
                new CuentaCorriente
                {
                    Id = cliente.Id,
                });
        }


        public void EliminarCuentaCorriente(Cliente cliente)
        {

            if (!_repo.Exist(cliente.Id))
                throw new ClienteInexistenteException("Se intentó eliminar una cuenta corriente de un cliente que no existe");

            var cuenta = this.ObtenerCuentaCorriente(cliente) ?? throw new CuentaCorrienteInexistenteException("Se intentó eliminar una cuenta corriente que no existe");

            if (this.ObtenerSaldoCuentaCorriente(cliente) != 0)
            {
                throw new CuentaCorrienteConSaldoException("Se intentó eliminar una cuenta corriente que todavía tiene saldo");
            }

            _repoCuentaCorriente.Delete(cuenta);
        }

        public void EliminarMovimiento(MovimientoCuentaCorriente movimiento)
        {

            var cuenta = _repoCuentaCorriente.GetById(movimiento.CuentaCorrienteId) ??
                throw new CuentaCorrienteInexistenteException("Se intentó eliminar un movimiento que correspondía a una cuenta corriente que no existe");


            // Como viene trackeado de la db, es mas seguro seleccionarlo desde la cuenta corriente, y eliminarlo desde la Icollection
            var movimientoDB = cuenta.Movimientos.FirstOrDefault(m => m.Id == movimiento.Id) ??
                throw new ArgumentException("Se intentó eliminar un movimiento de una cuenta corriente a la que no pertenecía"); ;
            
            cuenta.Movimientos.Remove(movimientoDB!);

            _repoCuentaCorriente.Update(cuenta);
        }
        public Cliente? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public IEnumerable<Cliente> ListarClientes()
        {
            return _repo.GetAll();
        }

        public CuentaCorriente? ObtenerCuentaCorriente(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                throw new ClienteInexistenteException("Se intentó obtener la cuenta corriente de un cliente que no está guardado en la DB");
            }

            return _repoCuentaCorriente.GetByClienteId(cliente.Id);
        }

        public decimal ObtenerSaldoCuentaCorriente(Cliente cliente)
        {
            var cuenta = this.ObtenerCuentaCorriente(cliente) ?? throw new CuentaCorrienteInexistenteException("Se intentó acceder al saldo de la cuenta corriente de un cliente que no tiene cuenta corriente.");

            decimal total = 0;

            foreach (var movimiento in cuenta.Movimientos)
            {
                total += movimiento.Tipo == TipoMovimiento.Aumento ? movimiento.Monto : -movimiento.Monto;
            }

            return total;

        }

        public void RegistrarMovimientoCuentaCorriente(Cliente cliente, MovimientoCuentaCorriente movimiento)
        {
            var cuenta = this.ObtenerCuentaCorriente(cliente) ?? throw new CuentaCorrienteInexistenteException("Se intentó registrar un movimiento a una cuenta corriente que no existe.");

            cuenta.Movimientos.Add(movimiento);

            _repoCuentaCorriente.Update(cuenta);
        }

        public void ToggleActivo(int id)
        {
            var cliente = _repo.GetById(id);

            if (cliente != null)
            {
                cliente.Activo = !cliente.Activo;
                _repo.Update(cliente);
            }
            else
            {
                throw new ClienteInexistenteException("Se intentó togglear el activo de un usuario que no existe.");
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            if (_repo.Exist(cliente.Id))
            {
                _repo.Update(cliente);
            }
            else
            {
                throw new ClienteInexistenteException("Se intentó actualizar un cliente que no existe");
            }
        }

        public IEnumerable<Persona> ObtenerPersonasSinClientes()
        {
            return _repoPersona.ObtenerPersonasSinClientes();
        }

        public void CrearCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El Nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Calle))
                throw new ArgumentException("La Calle es obligatoria.");

            if (string.IsNullOrWhiteSpace(cliente.Ciudad))
                throw new ArgumentException("La Ciudad es obligatoria.");

            if (!cliente.TipoDocumento.HasValue)
                throw new ArgumentException("El Tipo de Documento es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Dni))
                throw new ArgumentException("El DNI es obligatorio.");

            if (!cliente.CondicionIVA.HasValue)
                throw new ArgumentException("La Condición IVA es obligatoria.");

            _repo.Add(cliente);
        }
    }
}
