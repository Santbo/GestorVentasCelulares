using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.models.reparacion;

namespace GestionVentasCel.repository.reparacion
{
    public interface IReparacionRepository
    {
        void Add(Reparacion reparacion);
        void Update(Reparacion reparacion);
        IEnumerable<Reparacion> GetAll();
        Reparacion? GetById(int id);
        Reparacion? GetWithClienteById(int id);
        bool Exist(int id);
        void CambiarEstado(int id, EstadoReparacionEnum nuevoEstado);
        IEnumerable<Reparacion>? GetReparacionesDispositivo(Dispositivo dispositivo);
        IEnumerable<Dispositivo>? BuscarDispositivoPorCliente(int ClienteId);

        void AddDispositivo(Dispositivo dispositivo);
        void UpdateDispositivo(Dispositivo dispositivo);
        Dispositivo? GetDispositivoById(int dispositivoId);
        bool ExistDispositivo(int id);
        

    }
}
