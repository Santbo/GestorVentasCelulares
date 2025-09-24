using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.service.reparacion;

namespace GestionVentasCel.controller.reparaciones
{
    public class ReparacionController
    {
        private readonly IReparacionService _service;

        public ReparacionController(IReparacionService service)
        {
            _service = service;
        }

        public void CrearReparacion(Reparacion reparacion)
        {
            _service.CrearReparacion(reparacion);
        }

        public void ActualizarReparacion(Reparacion reparacion)
        {
            _service.ActualizarReparacion(reparacion);
        }

        public IEnumerable<Reparacion> ListarReparaciones()
        {
            return _service.ListarReparaciones();
        }

        public Reparacion? ObtenerPorId(int id)
        {
            return _service.ObtenerPorId(id);
        }

        public Reparacion? ObtenerPorIdConCliente(int id)
        {
            return _service.ObtenerPorIdConCliente(id);
        }

        public bool Existe(int id)
        {
            return _service.Existe(id);
        }

        public void CambiarEstado(int id, EstadoReparacionEnum nuevoEstado)
        {
            _service.CambiarEstado(id, nuevoEstado);

            if (nuevoEstado == EstadoReparacionEnum.Entregado)
            {
                var reparacion = _service.ObtenerPorId(id);
                reparacion.FechaEgreso = DateTime.Now;
                _service.ActualizarReparacion(reparacion);
            }
        }

        public IEnumerable<Reparacion>? ObtenerPorDispositivo(Dispositivo dispositivo)
        {
            return _service.ObtenerPorDispositivo(dispositivo);
        }

        public void ToggleActivo(int id)
        {
            _service.ToggleActivo(id);
        }

        public IEnumerable<Dispositivo>? ObtenerDispositivoPorCliente(int ClienteId)
        {
            return _service.ObtenerDispositivoPorCliente(ClienteId);
        }

        public void AgregarDispositivo(string nombre, int clienteId)
        {
            _service.AddDispositivo(nombre, clienteId);
        }

        public void ActualizarDispositivo(Dispositivo dispositivo)
        {
            _service.UpdateDispositivo(dispositivo);
        }

        public Dispositivo? GetDispositivoById(int dispositivoId)
        {
            return _service.GetDispositivoById(dispositivoId);
        }
    }
}
