using GestionVentasCel.models.servicio;
using GestionVentasCel.service.servicio;

namespace GestionVentasCel.controller.servicio
{
    public class ServicioController
    {
        private readonly IServicioService _service;
        public ServicioController(IServicioService service)
        {
            _service = service;
        }

        public void AgregarServicio(string nombre,
                                    decimal precio,
                                    List<ServicioArticulo> articulosUsados,
                                    string descripcion = null)
        {
            _service.Add(nombre, precio, articulosUsados, descripcion);
        }

        public void ActualizarServicio(Servicio servicio)
        {
            _service.Update(servicio);
        }

        public IEnumerable<Servicio> GetAll() => _service.GetAll();


        public Servicio GetById(int id) => _service.GetById(id);

        public void CambiarEstado(int id)
        {
            _service.ToggleEstado(id);
        }

        public Servicio? GetServicioConArticulos(int id)
        {
            return _service.GetServicioConArticulos(id);
        }
    }
}
