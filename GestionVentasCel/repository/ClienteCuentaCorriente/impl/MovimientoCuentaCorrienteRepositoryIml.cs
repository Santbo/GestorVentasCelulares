using GestionVentasCel.data;
using GestionVentasCel.models.CuentaCorreinte;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.ClienteCuentaCorriente.impl
{
    public class MovimientoCuentaCorrienteRepositoryImpl : IMovimientoCuentaCorrienteRepository
    {
        private readonly AppDbContext _context;

        public MovimientoCuentaCorrienteRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Add(MovimientoCuentaCorriente movimiento)
        {
            _context.MovimientosCuentasCorrientes.Add(movimiento);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.MovimientosCuentasCorrientes.Any(m => m.Id == id);
        }

        public IEnumerable<MovimientoCuentaCorriente> GetAll()
        {
            return _context.MovimientosCuentasCorrientes
                .Include(m => m.CuentaCorriente)
                .ThenInclude(cc => cc.Cliente)
                .AsNoTracking()
                .ToList();
        }

        public MovimientoCuentaCorriente? GetById(int id)
        {
            return _context.MovimientosCuentasCorrientes
                .Include(m => m.CuentaCorriente)
                .ThenInclude(cc => cc.Cliente)
                .FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<MovimientoCuentaCorriente> GetByCuentaId(int cuentaCorrienteId)
        {
            return _context.MovimientosCuentasCorrientes
                .Where(m => m.CuentaCorrienteId == cuentaCorrienteId)
                .Include(m => m.CuentaCorriente)
                .ThenInclude(cc => cc.Cliente)
                .AsNoTracking()
                .ToList();
        }

        public void Update(MovimientoCuentaCorriente movimiento)
        {
            _context.MovimientosCuentasCorrientes.Update(movimiento);
            _context.SaveChanges();
        }
    }
}
