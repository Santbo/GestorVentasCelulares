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

        public void AddRange(IEnumerable<DetalleCompra> detalles)
        {
            try
            {

                _context.DetallesCompra.AddRange(detalles);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                string error = "DbUpdateException: " + ex.Message;

                var inner = ex.InnerException;
                while (inner != null)
                {
                    error += "\n" + inner.Message;
                    inner = inner.InnerException;
                }

                MessageBox.Show(error, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void DeleteByCompraId(int compraId)
        {
            var detalles = _context.DetallesCompra.Where(d => d.CompraId == compraId);
            _context.DetallesCompra.RemoveRange(detalles);
            _context.SaveChanges();
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

    }
}
