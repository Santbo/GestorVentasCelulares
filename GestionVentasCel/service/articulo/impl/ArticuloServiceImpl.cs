using GestionVentasCel.exceptions.articulo;
using GestionVentasCel.models.articulo;
using GestionVentasCel.repository.articulo;

namespace GestionVentasCel.service.articulo.impl
{
    public class ArticuloServiceImpl : IArticuloService
    {
        private readonly IArticuloRepository _repo;

        public ArticuloServiceImpl(IArticuloRepository repo)
        {
            _repo = repo;
        }

        public void CrearArticulo(string nombre, int aviso_stock, decimal precio, int stock, string marca, int categoriaId, string? descripcion = null)
        {
            var articulo = new Articulo
            {
                Nombre = nombre,
                Aviso_stock = aviso_stock,
                Precio = precio,
                Stock = stock,
                Marca = marca,
                CategoriaId = categoriaId,
                Descripcion = descripcion


            };

            _repo.Add(articulo);
        }

        public Articulo? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public IEnumerable<Articulo> ListarArticulo() => _repo.GetAll();

        public void ToggleActivo(int id)
        {
            var articulo = _repo.GetById(id);

            if (articulo != null)
            {
                articulo.Activo = !articulo.Activo;
                _repo.Update(articulo);
            }
            else
            {
                throw new ArticuloNoEncontradoException("Articulo no encontrado.");
            }
        }

        public void UpdateArticulo(Articulo articulo)
        {
            if (_repo.Exist(articulo.Id))
            {

                _repo.Update(articulo);
            }
            else
            {

                throw new ArticuloNoEncontradoException("Articulo no encontrado.");
            }
        }
    }
}
