using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.servicio;
using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.exceptions.reparacion;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.models.servicio;
using GestionVentasCel.service.reparacion;

namespace GestionVentasCel.controller.reparaciones
{
    public class ReparacionController
    {
        private readonly IReparacionService _service;
        private readonly ArticuloController _articuloController;
        private readonly ServicioController _servicioController;

        public ReparacionController(IReparacionService service, ArticuloController articuloController, ServicioController servicioController)
        {
            _service = service;
            _articuloController = articuloController;
            _servicioController = servicioController;
        }

        public void CrearReparacion(Reparacion reparacion)
        {
            _service.CrearReparacion(reparacion);
        }

        public void ActualizarReparacion(Reparacion reparacion)
        {
            if (reparacion.Estado > EstadoReparacionEnum.Ingresado)
            {
                reparacion.FechaVencimiento = null;
            }
            _service.ActualizarReparacion(reparacion);
        }

        public IEnumerable<Reparacion> ListarReparaciones()
        {
            return _service.ListarReparaciones();
        }

        public IEnumerable<Reparacion> ListarReparacionesTerminadasCliente(int idCliente)
        {
            return _service.ListarReparacionesTerminadasCliente(idCliente);
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

            if (nuevoEstado >= EstadoReparacionEnum.Reparando)
            {
                var reparacion = _service.ObtenerPorId(id);
                reparacion.FechaVencimiento = null;
                _service.ActualizarReparacion(reparacion);
            }
        }

        public void RecalcularReparacion(int reparacionId)
        {
            Reparacion? reparacion = _service.ObtenerPorId(reparacionId);

            if (reparacion == null)
            {
                throw new ReparacionNoEncontradaException("Se intentó recalcular el precio de una reparación que no existe");
            }
            decimal total = 0;
            var servicios = reparacion.ReparacionServicios
                   .Select(rs => rs.Servicio!)
                   .ToList();

            foreach (var servicio in servicios)
            {
                if (servicio is Servicio servicioSeleccionado)
                {
                    // Sumo artículos usados por el servicio
                    var articulosUsados = _servicioController.GetServicioConArticulos(servicioSeleccionado.Id);

                    foreach (var articulo in articulosUsados.ArticulosUsados)
                    {
                        var articuloSeleccionado = _articuloController.GetById(articulo.ArticuloId);
                        total += articuloSeleccionado.Precio * articulo.Cantidad;
                    }

                    // Sumo el precio base del servicio
                    total += servicioSeleccionado.Precio;
                }
            }

            reparacion.Total = total;
            reparacion.FechaVencimiento = DateTime.Now.AddDays(7);

            _service.ActualizarReparacion(reparacion);

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
