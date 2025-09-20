using GestionVentasCel.data;
using GestionVentasCel.models.proveedor;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.proveedor.impl
{
    public class ProveedorRepositoryImpl : IProveedorRepository
    {
        private readonly AppDbContext _context;

        public ProveedorRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            _context.SaveChanges();
        }

        public void CambiarEstado(int id, bool activo)
        {
            var proveedor = _context.Proveedores.Find(id);
            if (proveedor != null)
            {
                proveedor.Activo = activo;
                _context.SaveChanges();
            }
        }

        public bool DocumentoExist(string documento, string tipoDocumento, int? idExcluir = null)
        {
            return _context.Proveedores.Any(p =>
                p.Dni == documento &&
                p.TipoDocumento.ToString() == tipoDocumento &&
                (idExcluir == null || p.Id != idExcluir));
        }

        public bool Exist(int id)
        {
            return _context.Proveedores.Any(p => p.Id == id);
        }

        public IEnumerable<Proveedor> GetAll()
        {
            return _context.Proveedores
                .AsNoTracking()
                .ToList();
        }

        public Proveedor? GetById(int id)
        {
            return _context.Proveedores
                .FirstOrDefault(p => p.Id == id);
        }


        public void Update(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            _context.SaveChanges();
        }
    }
}
