using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.exceptions.reparacion;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.repository.reparacion;

namespace GestionVentasCel.service.reparacion.impl
{
    public class ReparacionServiceImpl : IReparacionService
    {

        private readonly IReparacionRepository _repo;

        public ReparacionServiceImpl(IReparacionRepository reparacionRepository)
        {
            _repo = reparacionRepository;
        }

        public void CrearReparacion(Reparacion reparacion)
        {
            _repo.Add(reparacion);
        }

        public void ActualizarReparacion(Reparacion reparacion)
        {
            if (!_repo.Exist(reparacion.Id))
                throw new ReparacionNoEncontradaException("La reparación no existe.");

            _repo.Update(reparacion);
        }

        public IEnumerable<Reparacion> ListarReparaciones() => _repo.GetAll();
        public Reparacion? ObtenerPorId(int id) => _repo.GetById(id);

        public Reparacion? ObtenerPorIdConCliente(int id) => _repo.GetWithClienteById(id);
        public bool Existe(int id) => _repo.Exist(id);


        public void CambiarEstado(int id, EstadoReparacionEnum nuevoEstado)
        {
            if (!_repo.Exist(id))
                throw new ReparacionNoEncontradaException("La reparación no existe.");

            _repo.CambiarEstado(id, nuevoEstado);
        }

        public IEnumerable<Reparacion>? ObtenerPorDispositivo(Dispositivo dispositivo)
        {
            return _repo.GetReparacionesDispositivo(dispositivo);
        }

        public void ToggleActivo(int id)
        {
            var reparacion = _repo.GetById(id);

            if (reparacion == null)
            {
                throw new ReparacionNoEncontradaException("La reparación no existe.");
            }

            reparacion.Activo = !reparacion.Activo;

            _repo.Update(reparacion);
        }

        public IEnumerable<Dispositivo>? ObtenerDispositivoPorCliente(int ClienteId)
        {
            return _repo.BuscarDispositivoPorCliente(ClienteId);
        }

        public void AddDispositivo(string nombre, int clienteId)
        {
            var dispositivo = new Dispositivo
            {
                Nombre = nombre,
                ClienteId = clienteId
            };

            _repo.AddDispositivo(dispositivo);
        }

        public void UpdateDispositivo(Dispositivo dispositivo)
        {
            if (!_repo.ExistDispositivo(dispositivo.Id)) throw new DispositivoNoEncontradoException("El dispositivo no fue encontrado.");
            _repo.UpdateDispositivo(dispositivo);
        }

        public Dispositivo? GetDispositivoById(int dispositivoId)
        {
            return _repo.GetDispositivoById(dispositivoId);
        }
    }
}
