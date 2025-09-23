using GestionVentasCel.data;
using GestionVentasCel.models.servicio;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.servicio.impl
{
    public class ServicioRepositoryImpl : IServicioRepository
    {
        private readonly AppDbContext _context;

        public ServicioRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Servicio servicio)
        {
            _context.Add(servicio);
            _context.SaveChanges();
        }

        public bool Exist(int id) => _context.Servicios.Any(s => s.Id == id);


        public IEnumerable<Servicio> GetAll() => _context.Servicios.AsNoTracking().ToList();


        public Servicio? GetById(int id)
        {
            return _context.Servicios.FirstOrDefault(s => s.Id == id);
        }

        public Servicio? GetServicioConArticulo(int id)
        {
            return _context.Servicios
                        .Include(s => s.ArticulosUsados)
                        .FirstOrDefault(s => s.Id == id);


        }

        public void Update(Servicio servicio)
        {
            _context.Servicios.Update(servicio);

            if (servicio.ArticulosUsados != null)
            {

                foreach (var articulo in servicio.ArticulosUsados)
                {
                    articulo.Articulo = null;
                    _context.ServicioArticulos.Update(articulo);
                }
            }

            _context.SaveChanges();

        }
    }
}
