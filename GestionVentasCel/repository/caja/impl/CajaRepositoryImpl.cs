using GestionVentasCel.data;
using GestionVentasCel.enumerations.caja;
using GestionVentasCel.models.caja;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.caja.impl
{
    public class CajaRepositoryImpl : ICajaRepository
    {
        private readonly AppDbContext _context;

        public CajaRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        // --- Caja ---
        public void Add(Caja caja)
        {
            _context.Caja.Add(caja);
            _context.SaveChanges();
        }

        public void Update(Caja caja)
        {
            _context.Caja.Update(caja);
            _context.SaveChanges();
        }

        public IEnumerable<Caja> GetAll()
        {
            return _context.Caja
                           .AsNoTracking()
                           .Include(c => c.Usuario)
                           .Include(c => c.Movimientos)
                           .ToList();
        }

        public Caja? GetById(int id)
        {
            return _context.Caja
                           .Include(c => c.Usuario)
                           .FirstOrDefault(c => c.Id == id);
        }

        public Caja? GetWithMovimientosById(int id)
        {
            return _context.Caja
                           .Include(c => c.Usuario)
                           .Include(c => c.Movimientos)
                           .FirstOrDefault(c => c.Id == id);
        }

        public bool Exist(int id)
        {
            return _context.Caja.Any(c => c.Id == id);
        }

        public bool EstaCerrada(int id)
        {
            return _context.Caja.Any(c => c.Id == id && c.Estado == EstadoCajaEnum.Cerrada);
        }

        public bool HayCajaAbierta()
        {
            return _context.Caja.Any(c => c.Estado == EstadoCajaEnum.Abierta);
        }

        public Caja? ObtenerCajaActualAbierta()
        {
            return _context.Caja.FirstOrDefault(c => c.Estado == EstadoCajaEnum.Abierta);

        }

        // --- Movimientos ---
        public void AddMovimiento(MovimientoCaja movimiento)
        {
            _context.MovimientosCaja.Add(movimiento);
            _context.SaveChanges();
        }

        public IEnumerable<MovimientoCaja> GetMovimientosCaja(int cajaId)
        {
            return _context.MovimientosCaja
                           .AsNoTracking()
                           .Where(m => m.CajaId == cajaId)
                           .ToList();
        }
    }
}
