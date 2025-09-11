using GestionVentasCel.exceptions.categoria;
using GestionVentasCel.models.categoria;
using GestionVentasCel.repository.categoria;

namespace GestionVentasCel.service.categoria.impl
{
    public class CategoriaServiceImpl : ICategoriaService
    {
        private readonly ICategoriaRepository _repo;

        public CategoriaServiceImpl(ICategoriaRepository repo)
        {
            _repo = repo;
        }

        public void AgregarCategoria(string nombre, string descripcion)
        {


            if (!_repo.NombreExist(nombre))
            {

                var categoria = new Categoria
                {
                    Nombre = nombre,
                    Descripcion = descripcion

                };

                _repo.Add(categoria);
            }
            else
            {
                throw new CategoriaExistenteException("El nombre de la categoria ya existe.");
            }



        }

        public Categoria? GetById(int id)
        {
            return _repo.GetById(id);
        }

        //Obtener todas las categorias
        public IEnumerable<Categoria> listarCategoria() => _repo.GetAll();

        public void ToggleActivo(int id)
        {
            var categoria = _repo.GetById(id);

            if (categoria != null)
            {
                categoria.Activo = !categoria.Activo;
                _repo.Update(categoria);
            }
            else
            {
                throw new CategoriaNoEncontradaException("Categoria no encontrada");
            }
        }

        public void UpdateCategoria(Categoria categoria)
        {
            if (_repo.Exist(categoria.Id))
            {

                _repo.Update(categoria);
            }
            else
            {

                throw new CategoriaNoEncontradaException("Categoria no encontrada");
            }
        }
    }
}
