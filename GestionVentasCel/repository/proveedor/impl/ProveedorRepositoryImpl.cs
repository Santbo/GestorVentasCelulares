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

        public void Delete(int id)
        {
            var proveedor = _context.Proveedores.Find(id);
            if (proveedor != null)
            {
                proveedor.Activo = false;
                _context.SaveChanges();
            }
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

        public bool DocumentoExist(string documento, string tipoDocumento)
        {
            return _context.Proveedores.Any(p => p.Dni == documento &&
                                               p.TipoDocumento.ToString() == tipoDocumento);
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

        public IEnumerable<Proveedor> GetAllActivos()
        {
            return _context.Proveedores
                .Where(p => p.Activo)
                .AsNoTracking()
                .ToList();
        }

        public Proveedor? GetById(int id)
        {
            return _context.Proveedores
                .FirstOrDefault(p => p.Id == id);
        }

        public bool NombreExist(string nombre)
        {
            return _context.Proveedores.Any(p => p.Nombre == nombre);
        }

        public void Update(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            _context.SaveChanges();
        }
    }
}
