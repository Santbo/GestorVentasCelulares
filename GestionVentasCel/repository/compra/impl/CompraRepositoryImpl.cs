using GestionVentasCel.data;
using GestionVentasCel.models.compra;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.compra.impl
{
    public class CompraRepositoryImpl : ICompraRepository
    {
        private readonly AppDbContext _context;

        public CompraRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Compra compra)
        {
            _context.Compras.Add(compra);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var compra = _context.Compras.Find(id);
            if (compra != null)
            {
                compra.Activo = false;
                _context.SaveChanges();
            }
        }

        public bool Exist(int id)
        {
            return _context.Compras.Any(c => c.Id == id);
        }

        public IEnumerable<Compra> GetAll()
        {
            return _context.Compras
                .Include(c => c.Proveedor)
                .Where(c => c.Activo)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Compra> GetAllWithDetails()
        {
            return _context.Compras
                .Include(c => c.Proveedor)
                .Include(c => c.Detalles)
                    .ThenInclude(d => d.Articulo)
                .Where(c => c.Activo)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Compra> GetByFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            return _context.Compras
                .Include(c => c.Proveedor)
                .Where(c => c.Activo && c.Fecha >= fechaDesde && c.Fecha <= fechaHasta)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Compra> GetByProveedor(int proveedorId)
        {
            return _context.Compras
                .Include(c => c.Proveedor)
                .Where(c => c.Activo && c.ProveedorId == proveedorId)
                .AsNoTracking()
                .ToList();
        }

        public Compra? GetById(int id)
        {
            return _context.Compras
                .Include(c => c.Proveedor)
                .FirstOrDefault(c => c.Id == id && c.Activo);
        }

        public Compra? GetByIdWithDetails(int id)
        {
            return _context.Compras
                .Include(c => c.Proveedor)
                .Include(c => c.Detalles)
                    .ThenInclude(d => d.Articulo)
                .FirstOrDefault(c => c.Id == id && c.Activo);
        }

        public void Update(Compra compra)
        {
            _context.Compras.Update(compra);
            _context.SaveChanges();
        }
    }
}
