using GestionVentasCel.models.articulo;

namespace GestionVentasCel.service.articulo
{
    public interface IArticuloService
    {
        void CrearArticulo(string nombre,
                                int aviso_stock,
                                decimal precio,
                                int stock,
                                string marca,
                                int categoriaId,
                                string? descripcion = null
                                 );
        IEnumerable<Articulo> ListarArticulo();
        void UpdateArticulo(Articulo articulo);

        void ToggleActivo(int id);

        Articulo? GetById(int id);
    }
}
