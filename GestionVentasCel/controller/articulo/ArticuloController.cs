using GestionVentasCel.models.articulo;
using GestionVentasCel.service.articulo;

namespace GestionVentasCel.controller.articulo
{
    public class ArticuloController
    {
        private readonly IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        public void CrearArticulo(string nombre,
                                    int aviso_stock,
                                    decimal precio,
                                    int stock,
                                    string marca,
                                    int categoriaId,
                                    string? descripcion = null)
        {
            _articuloService.CrearArticulo(nombre,
                                        aviso_stock,
                                        precio,
                                        stock,
                                        marca,
                                        categoriaId,
                                        descripcion);
        }

        public Articulo? GetById(int id)
        {
            return _articuloService.GetById(id);
        }

        public IEnumerable<Articulo> ObtenerArticulos() => _articuloService.ListarArticulo();

        public void ToggleActivo(int id)
        {
            _articuloService?.ToggleActivo(id);
        }

        public void UpdateArticulo(Articulo articulo)
        {
            _articuloService.UpdateArticulo(articulo);
        }
    }
}
