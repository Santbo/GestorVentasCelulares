using GestionVentasCel.data;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.ventas;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.ventas.impl
{
    public class VentaRepositoryImpl : IVentaRepository
    {
        private readonly AppDbContext _context;

        public VentaRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Agregar(Venta venta)
        {
            _context.Ventas.Add(venta);
            _context.SaveChanges();
        }

        public void Actualizar(Venta venta)
        {

            _context.Ventas.Update(venta);
            _context.SaveChanges();

        }

        public void Eliminar(int id)
        {
            var venta = _context.Ventas.Find(id);
            if (venta != null)
            {
                venta.EstadoVenta = EstadoVentaEnum.Anulada;
                _context.SaveChanges();
            }
        }

        public bool Existe(int id)
        {
            return _context.Ventas.Any(v => v.Id == id);
        }

        public IEnumerable<Venta> ObtenerTodas()
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Venta> ObtenerTodasConDetalles()
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Articulo)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Reparacion)
                .AsNoTracking()
                .ToList();
        }

        public Venta? ObtenerPorId(int id)
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .FirstOrDefault(v => v.Id == id);
        }

        public Venta? ObtenerPorIdConDetalles(int id)
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Articulo)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Reparacion)
                .FirstOrDefault(v => v.Id == id);
        }
        
        public Venta? ObtenerPorIdConDetallesNoTracking(int id)
        {
            return _context.Ventas
                .AsNoTracking()
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Articulo)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Reparacion)
                .FirstOrDefault(v => v.Id == id);
        }

        /// <summary>
        /// Obtener las ventas que SÍ son presupuestos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Venta> ObtenerPresupuestos()
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Where(v => v.FechaVenta == null && v.EstadoVenta == EstadoVentaEnum.Presupuesto)
                .AsNoTracking()
                .ToList();
        }

        /// <summary>
        /// Obtener todas las ventas que NO sean prespuestos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Venta> ObtenerVentas()
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Detalles)
                .Where(v => v.EstadoVenta != EstadoVentaEnum.Presupuesto)
                .AsNoTracking()
                .ToList();
        }

        public void AgregarDetalle(int ventaId, DetalleVenta detalle)
        {
            var venta = _context.Ventas
                .Include(v => v.Detalles)
                .FirstOrDefault(v => v.Id == ventaId);

            if (venta != null)
            {
                venta.Detalles.Add(detalle);
                _context.SaveChanges();
            }
        }

        public void EliminarDetalle(int detalleId)
        {
            var detalle = _context.DetallesVenta.Find(detalleId);
            if (detalle != null)
            {
                _context.DetallesVenta.Remove(detalle);
                _context.SaveChanges();
            }
        }

        public Venta? ObtenerPresupuestoPorId(int idVenta)
        {
            return _context.Ventas.FirstOrDefault(v => v.Id == idVenta && v.EstadoVenta == EstadoVentaEnum.Presupuesto);
        }
    }

}
