using GestionVentasCel.data;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.CuentaCorreinte;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.ClienteCuentaCorriente.impl
{
    public class CuentaCorrienteRepositoryImpl : ICuentaCorrienteRepository
    {
        private readonly AppDbContext _context;

        public CuentaCorrienteRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Add(CuentaCorriente cuenta)
        {
            _context.CuentasCorrientes.Add(cuenta);
            _context.SaveChanges();
        }

        public void Delete(CuentaCorriente cuenta)
        {
            _context.CuentasCorrientes.Remove(cuenta);
            _context.SaveChanges();
        }

        public bool Exist(int clienteId)
        {
            return _context.CuentasCorrientes.Any(cc => cc.ClienteId == clienteId);
        }

        public IEnumerable<CuentaCorriente> GetAll()
        {
            return _context.CuentasCorrientes
                .Include(cc => cc.ClienteId)
                .Include(cc => cc.Movimientos)
                .AsNoTracking()
                .ToList();
        }

        public CuentaCorriente? GetByClienteId(int clienteId)
        {
            return _context.CuentasCorrientes
                .Include(c => c.ClienteId)
                .Include(cc => cc.Movimientos)
                .FirstOrDefault(cc => cc.ClienteId == clienteId);
        }

        public CuentaCorriente? GetById(int id)
        {
            return _context.CuentasCorrientes
                .Include(c => c.ClienteId)
                .Include(cc => cc.Movimientos)
                .FirstOrDefault(cc => cc.Id == id);
        }

        public void Update(CuentaCorriente cuenta)
        {
            _context.CuentasCorrientes.Update(cuenta);
            _context.SaveChanges();
        }
    }
}
