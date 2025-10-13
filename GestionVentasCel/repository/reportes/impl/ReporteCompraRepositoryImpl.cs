using GestionVentasCel.data;
using GestionVentasCel.enumerations.cliente;
using GestionVentasCel.models.reportes;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.reportes.impl
{
    public class ReporteCompraRepositoryImpl : IReporteCompraRepository
    {
        private readonly AppDbContext _context;

        public ReporteCompraRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ReporteCompraDTO> ObtenerComprasPorRangoFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            // Ajustar la fecha hasta para incluir todo el día
            fechaHasta = fechaHasta.Date.AddDays(1).AddTicks(-1);

            return _context.Compras
                .Include(c => c.Proveedor)
                .Include(c => c.Detalles)
                .Where(c => c.Fecha >= fechaDesde && c.Fecha <= fechaHasta)
                .AsNoTracking()
                .Select(c => new ReporteCompraDTO
                {
                    Id = c.Id,
                    Fecha = c.Fecha,
                    NumeroComprobante = $"C-{c.Id:D6}",
                    Proveedor = c.Proveedor != null ? c.Proveedor.Nombre : "Sin Proveedor",
                    TipoCompra = c.Proveedor != null && c.Proveedor.CondicionIVA.HasValue ? 
                        DeterminarTipoCompra(c.Proveedor.CondicionIVA.Value) : "Sin Especificar",
                    MontoTotal = c.Total,
                    Observaciones = c.Observaciones ?? ""
                })
                .OrderByDescending(c => c.Fecha)
                .ToList();
        }

        private static string DeterminarTipoCompra(CondicionIVAEnum condicionIVA)
        {
            // Lógica simple para determinar el tipo de compra basado en condición IVA
            // Se puede mejorar según la lógica de negocio
            return condicionIVA.ToString().Contains("Exterior") ? "Proveedor Externo" : "Proveedor Local";
        }

        public ResumenReporteDTO ObtenerResumenCompras(DateTime fechaDesde, DateTime fechaHasta)
        {
            // Ajustar la fecha hasta para incluir todo el día
            fechaHasta = fechaHasta.Date.AddDays(1).AddTicks(-1);

            var compras = _context.Compras
                .Include(c => c.Proveedor)
                .Where(c => c.Fecha >= fechaDesde && c.Fecha <= fechaHasta)
                .AsNoTracking()
                .ToList();

            var totalGeneral = compras.Sum(c => c.Total);
            var cantidadOperaciones = compras.Count;
            var promedio = cantidadOperaciones > 0 ? totalGeneral / cantidadOperaciones : 0;

            var totalesPorTipo = compras
                .Where(c => c.Proveedor != null && c.Proveedor.CondicionIVA.HasValue)
                .GroupBy(c => DeterminarTipoCompra(c.Proveedor!.CondicionIVA!.Value))
                .ToDictionary(g => g.Key, g => g.Sum(c => c.Total));

            return new ResumenReporteDTO
            {
                TotalGeneral = totalGeneral,
                CantidadOperaciones = cantidadOperaciones,
                PromedioOperacion = promedio,
                FechaDesde = fechaDesde,
                FechaHasta = fechaHasta.Date,
                TotalesPorTipo = totalesPorTipo
            };
        }
    }
}

