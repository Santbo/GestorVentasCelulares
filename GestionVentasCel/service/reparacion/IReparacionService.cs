using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.models.reparacion;

namespace GestionVentasCel.service.reparacion
{
    public interface IReparacionService
    {
        void CrearReparacion(Reparacion reparacion);
        void ActualizarReparacion(Reparacion reparacion);
        IEnumerable<Reparacion> ListarReparaciones();
        IEnumerable<Reparacion> ListarReparacionesTerminadasCliente(int idCliente);

        Reparacion? ObtenerPorId(int id);

        Reparacion? ObtenerPorIdConCliente(int id);
        bool Existe(int id);
        void CambiarEstado(int id, EstadoReparacionEnum nuevoEstado);
        IEnumerable<Reparacion>? ObtenerPorDispositivo(Dispositivo dispositivo);
        void Desactivar(int id);

        IEnumerable<Dispositivo>? ObtenerDispositivoPorCliente(int ClienteId);

        void AddDispositivo(string nombre, int clienteId);
        void UpdateDispositivo(Dispositivo dispositivo);

        Dispositivo? GetDispositivoById(int dispositivoId);
    }
}
