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

            try
            {

                _context.Compras.Add(compra);
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

        public void Delete(int id)
        {
            var compra = _context.Compras.Find(id);

            _context.Compras.Remove(compra);
            _context.SaveChanges();

        }

        public bool Exist(int id)
        {
            return _context.Compras.Any(c => c.Id == id);
        }

        public IEnumerable<Compra> GetAll()
        {
            return _context.Compras
                .Include(c => c.Proveedor)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Compra> GetAllWithDetails()
        {
            return _context.Compras
                .Include(c => c.Proveedor)
                .Include(c => c.Detalles)
                    .ThenInclude(d => d.Articulo)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Compra> GetByProveedor(int proveedorId)
        {
            return _context.Compras
                .Include(c => c.Proveedor)
                .Where(c => c.ProveedorId == proveedorId)
                .AsNoTracking()
                .ToList();
        }


        public Compra? GetByIdWithDetails(int id)
        {
            return _context.Compras
                .Include(c => c.Proveedor)
                .Include(c => c.Detalles)
                    .ThenInclude(d => d.Articulo)
                .FirstOrDefault(c => c.Id == id);
        }

        public void Update(Compra compra)
        {

            try
            {

                _context.Compras.Update(compra);
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
    }
}
