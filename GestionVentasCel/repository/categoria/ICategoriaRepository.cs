using GestionVentasCel.models.categoria;

namespace GestionVentasCel.repository.categoria
{
    public interface ICategoriaRepository
    {

        Categoria? GetById(int id);
        IEnumerable<Categoria> GetAll();
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        bool Exist(int id);

        bool NombreExist(string nombre);
    }
}
