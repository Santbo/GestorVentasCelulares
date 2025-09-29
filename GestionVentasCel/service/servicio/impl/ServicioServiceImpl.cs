using GestionVentasCel.exceptions.servicio;
using GestionVentasCel.models.servicio;
using GestionVentasCel.repository.servicio;

namespace GestionVentasCel.service.servicio.impl
{
    public class ServicioServiceImpl : IServicioService
    {
        private readonly IServicioRepository _repo;

        public ServicioServiceImpl(IServicioRepository repo)
        {
            _repo = repo;
        }
        public void Add(string nombre,
                        decimal precio,
                        List<ServicioArticulo> articulosUsados,
                        string descripcion = null)
        {
            var servicio = new Servicio
            {
                Nombre = nombre,
                Precio = precio,
                ArticulosUsados = articulosUsados,
                Descripcion = descripcion

            };
            _repo.Add(servicio);
        }

        public IEnumerable<Servicio> GetAll() => _repo.GetAll();

        public Servicio? GetById(int id)
        {
            if (!_repo.Exist(id)) throw new ServicioNoEncontradoException($"El Servicio con el id: {id} no existe.");
            return _repo.GetById(id);
        }

        public Servicio? GetServicioConArticulos(int id)
        {
            if (!_repo.Exist(id)) throw new ServicioNoEncontradoException($"El Servicio con el id: {id} no existe.");
            return _repo.GetServicioConArticulo(id);
        }

        public void ToggleEstado(int id)
        {
            var servicio = _repo.GetById(id);
            if (servicio != null)
            {
                servicio.Activo = !servicio.Activo;
                _repo.Update(servicio);
            }
            else
            {
                throw new ServicioNoEncontradoException($"El Servicio con el id: {id} no existe.");
            }
        }

        public void Update(Servicio servicio)
        {
            if (_repo.Exist(servicio.Id))
            {
                _repo.Update(servicio);
            }
            else
            {
                throw new ServicioNoEncontradoException($"El Servicio con el id: {servicio.Id} no existe.");
            }
        }
    }
}
