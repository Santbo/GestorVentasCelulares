using GestionVentasCel.data;
using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.models.reparacion;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.reparacion.impl
{
    public class ReparacionRepositoryImpl : IReparacionRepository
    {
        private readonly AppDbContext _context;

        public ReparacionRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Reparacion reparacion)
        {
            _context.Reparaciones.Add(reparacion);
            _context.SaveChanges();
        }

        public void Update(Reparacion reparacion)
        {
            _context.Reparaciones.Update(reparacion);
            _context.SaveChanges();
        }

        public IEnumerable<Reparacion> GetAll()
        {
            return _context.Reparaciones
                           .AsNoTracking()
                           .Include(r => r.Dispositivo)
                               .ThenInclude(d => d.Cliente)
                           .Include(r => r.Servicios)
                           .ToList();
        }

        public Reparacion? GetById(int id)
        {
            return _context.Reparaciones
                           .FirstOrDefault(r => r.Id == id);
        }

        public bool Exist(int id)
        {
            return _context.Reparaciones.Any(r => r.Id == id);
        }

        public void CambiarEstado(int id, EstadoReparacionEnum nuevoEstado)
        {
            var reparacion = _context.Reparaciones.FirstOrDefault(r => r.Id == id);
            if (reparacion != null)
            {
                reparacion.Estado = nuevoEstado;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Reparacion>? GetReparacionesDispositivo(Dispositivo dispositivo)
        {
            return _context.Reparaciones
                                .AsNoTracking()
                                .Where(r => r.DispositivoId == dispositivo.Id)
                                .ToList();
        }
    }
}
