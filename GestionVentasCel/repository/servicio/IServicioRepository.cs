using GestionVentasCel.models.servicio;

namespace GestionVentasCel.repository.servicio
{
    public interface IServicioRepository
    {
        void Add(Servicio servicio);
        void Update(Servicio servicio);
        IEnumerable<Servicio> GetAll();
        Servicio? GetById(int id);
        bool Exist(int id);
        Servicio? GetServicioConArticulo(int id);

    }
}
