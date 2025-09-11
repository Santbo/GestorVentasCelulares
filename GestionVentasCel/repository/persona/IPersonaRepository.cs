using GestionVentasCel.models.persona;

namespace GestionVentasCel.repository.persona
{
    public interface IPersonaRepository
    {
        Persona? GetById(int id);

        IEnumerable<Persona> GetAll();

        void Add(Persona persona);

        void Update(Persona persona);

        bool Exist(int id);

        Persona? GetByDni(string dni);
    }
}
