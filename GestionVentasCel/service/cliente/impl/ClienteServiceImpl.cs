using GestionVentasCel.enumerations.cuentaCorriente;
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
            if (!_repo.Exist(cliente.Id))
            {
                throw new ClienteInexistenteException("Se intentó crear una cuenta corriente a un cliente que no existe.");
            }

            _repoCuentaCorriente.Add(
                new CuentaCorriente
                {
                    Cliente = cliente,
                });
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

        public void RegistrarMovimientoCuentaCorriente(Cliente cliente, MovimientoCuentaCorriente movimiento)
        {
            var cuenta = cliente.CuentaCorriente ?? throw new CuentaCorrienteInexistenteException("Se intentó registrar un movimiento a una cuenta corriente que no existe.");

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

            // Asegurarse de que el cliente esté activo, había un bug de agregar clientes a personas existentes que los agregaba inactivos
            cliente.Activo = true;

            _repo.Add(cliente);
        }

        public Persona? GetPersonaById(int id)
        {
            return _repoPersona.GetById(id);
        }

        public IEnumerable<CuentaCorriente> ObtenerCuentasCorrientes()
        {
            return _repoCuentaCorriente.GetAll();
        }

        public void ToggleActivoCuentaCorriente(int id)
        {
            var cuenta = _repoCuentaCorriente.GetById(id);

            if (cuenta != null)
            {
                cuenta.Activo = !cuenta.Activo;
                _repoCuentaCorriente.Update(cuenta);
            }
            else
            {
                throw new ClienteInexistenteException("Se intentó togglear el activo de un usuario que no existe.");
            }
        }

        public DateTime? ObtenerFechaUltimoMovimiento(CuentaCorriente cuenta)
        {
            return cuenta.Movimientos
                .OrderByDescending(m => m.Fecha)
                .FirstOrDefault()?.Fecha;
        }

        public decimal ObtenerSaldoCuentaCorriente(CuentaCorriente cuenta)
        {
            decimal total = 0;

            foreach (var movimiento in cuenta.Movimientos)
            {
                total += movimiento.Tipo == TipoMovimiento.Aumento ? movimiento.Monto : -movimiento.Monto;
            }

            return total;
        }

        public IEnumerable<Cliente> ObtenerClientesSinCuentas()
        {
            return _repo.ObtenerClientesSinCuentas();
        }

        public void ActualizarMovimientoCuentaCorriente(MovimientoCuentaCorriente movimiento)
        {
            var cuenta = movimiento.CuentaCorriente;

            var movimientoEnDB = cuenta.Movimientos
                .Where(m => m.Id == movimiento.Id)
                .FirstOrDefault();

            if (movimientoEnDB != null)
            {
                movimientoEnDB.Tipo = movimiento.Tipo;
                movimientoEnDB.Fecha = movimiento.Fecha;
                movimientoEnDB.Monto = movimiento.Monto;

            }
            else
            {
                throw new MovimientoInexistenteException("Se intentó actualizar un movimiento de CC que no existe en la base de datos");
            }

            _repoCuentaCorriente.Update(cuenta);
        }
    }
}
