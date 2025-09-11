using GestionVentasCel.models.categoria;

namespace GestionVentasCel.service.categoria
{
    public interface ICategoriaService
    {
        void AgregarCategoria(string nombre, string descripcion);
        IEnumerable<Categoria> listarCategoria();

        void UpdateCategoria(Categoria categoria);

        void ToggleActivo(int id);

        Categoria? GetById(int id);
    }
}
