using GestionVentasCel.data;
using GestionVentasCel.models.compra;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.compra.impl
{
    public class DetalleCompraRepositoryImpl : IDetalleCompraRepository
    {
        private readonly AppDbContext _context;

        public DetalleCompraRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Add(DetalleCompra detalle)
        {
            _context.DetallesCompra.Add(detalle);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<DetalleCompra> detalles)
        {
            _context.DetallesCompra.AddRange(detalles);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var detalle = _context.DetallesCompra.Find(id);
            if (detalle != null)
            {
                _context.DetallesCompra.Remove(detalle);
                _context.SaveChanges();
            }
        }

        public void DeleteByCompraId(int compraId)
        {
            var detalles = _context.DetallesCompra.Where(d => d.CompraId == compraId);
            _context.DetallesCompra.RemoveRange(detalles);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.DetallesCompra.Any(d => d.Id == id);
        }

        public IEnumerable<DetalleCompra> GetAll()
        {
            return _context.DetallesCompra
                .Include(d => d.Compra)
                .Include(d => d.Articulo)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<DetalleCompra> GetByArticuloId(int articuloId)
        {
            return _context.DetallesCompra
                .Include(d => d.Compra)
                .Include(d => d.Articulo)
                .Where(d => d.ArticuloId == articuloId)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<DetalleCompra> GetByCompraId(int compraId)
        {
            return _context.DetallesCompra
                .Include(d => d.Compra)
                .Include(d => d.Articulo)
                .Where(d => d.CompraId == compraId)
                .AsNoTracking()
                .ToList();
        }

        public DetalleCompra? GetById(int id)
        {
            return _context.DetallesCompra
                .Include(d => d.Compra)
                .Include(d => d.Articulo)
                .FirstOrDefault(d => d.Id == id);
        }

        public void Update(DetalleCompra detalle)
        {
            _context.DetallesCompra.Update(detalle);
            _context.SaveChanges();
        }
    }
}
