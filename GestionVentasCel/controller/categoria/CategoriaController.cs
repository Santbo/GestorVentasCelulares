using GestionVentasCel.models.categoria;
using GestionVentasCel.service.categoria;

namespace GestionVentasCel.controller.categoria
{
    public class CategoriaController
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        public void CrearCategoria(string nombre, string descripcion) =>

            _service.AgregarCategoria(nombre, descripcion);

        public void UpdateCategoria(Categoria categoria)
        {
            _service.UpdateCategoria(categoria);
        }

        public IEnumerable<Categoria> ObtenerCategorias() =>
            _service.listarCategoria();


        //Alterna entre activo e inactivo
        public void ToggleActivo(int id)
        {
            _service?.ToggleActivo(id);
        }

        public Categoria? GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
