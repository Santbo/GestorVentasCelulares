using GestionVentasCel.data;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.reportes;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.reportes.impl
{
    public class ReporteVentaRepositoryImpl : IReporteVentaRepository
    {
        private readonly AppDbContext _context;

        public ReporteVentaRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ReporteVentaDTO> ObtenerVentasPorRangoFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            // Ajustar la fecha hasta para incluir todo el día
            fechaHasta = fechaHasta.Date.AddDays(1).AddTicks(-1);

            var ventas = _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Detalles)
                .Where(v => v.FechaVenta.HasValue && 
                           v.FechaVenta >= fechaDesde && 
                           v.FechaVenta <= fechaHasta &&
                           v.EstadoVenta != EstadoVentaEnum.Anulada)
                .AsNoTracking()
                .ToList();

            return ventas.Select(v => new ReporteVentaDTO
            {
                Id = v.Id,
                Fecha = v.FechaVenta ?? v.FechaCreacion,
                NumeroComprobante = $"V-{v.Id:D6}",
                Cliente = v.Cliente != null ? v.Cliente.NombreCompleto : "Sin Cliente",
                TipoPago = v.TipoPago,
                TipoPagoDescripcion = v.TipoPago == TipoPagoEnum.Efectivo ? "Efectivo" : "Cuenta Corriente",
                Estado = v.EstadoVenta,
                EstadoDescripcion = v.EstadoVenta.ToString(),
                MontoTotal = v.Detalles.Sum(d => d.SubtotalConIva),
                MontoSinIva = v.Detalles.Sum(d => d.SubtotalSinIva),
                MontoIva = v.Detalles.Sum(d => d.SubtotalSinIva * d.PorcentajeIva)
            })
            .OrderByDescending(v => v.Fecha)
            .ToList();
        }

        public ResumenReporteDTO ObtenerResumenVentas(DateTime fechaDesde, DateTime fechaHasta)
        {
            // Ajustar la fecha hasta para incluir todo el día
            fechaHasta = fechaHasta.Date.AddDays(1).AddTicks(-1);

            var ventas = _context.Ventas
                .Include(v => v.Detalles)
                .Where(v => v.FechaVenta.HasValue && 
                           v.FechaVenta >= fechaDesde && 
                           v.FechaVenta <= fechaHasta &&
                           v.EstadoVenta != EstadoVentaEnum.Anulada)
                .AsNoTracking()
                .ToList();

            var totalGeneral = ventas.Sum(v => v.TotalConIva);
            var cantidadOperaciones = ventas.Count;
            var promedio = cantidadOperaciones > 0 ? totalGeneral / cantidadOperaciones : 0;

            var totalesPorTipo = ventas
                .GroupBy(v => v.TipoPago == TipoPagoEnum.Efectivo ? "Efectivo" : "Cuenta Corriente")
                .ToDictionary(g => g.Key, g => g.Sum(v => v.TotalConIva));

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

