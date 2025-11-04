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

            var facturas = _context.Facturas
                .AsNoTracking()
                .Where(f => ventas.Select(v => v.Id).Contains(f.VentaId))
                .ToList();

            return ventas.Select(v => 
            {
                //para el manejo de casos donde no existe factura
                var factura = facturas.FirstOrDefault(f => f.VentaId == v.Id);
                return new ReporteVentaDTO
                {
                    Id = v.Id,
                    Fecha = v.FechaVenta ?? v.FechaCreacion,
                    NumeroComprobante = factura?.NumeroFactura ?? "Sin Factura",
                    TipoComprobante = factura != null ? factura.TipoComprobante.ToString().Replace("Factura", "Factura ") : "Sin Comprobante",
                    Cliente = v.Cliente != null ? v.Cliente.NombreCompleto : "Sin Cliente",
                    TipoPago = v.TipoPago,
                    TipoPagoDescripcion = v.TipoPago.ToString(),
                    Estado = v.EstadoVenta,
                    EstadoDescripcion = v.EstadoVenta.ToString(),
                    MontoTotal = v.Detalles.Sum(d => d.SubtotalConIva),
                    MontoSinIva = v.Detalles.Sum(d => d.SubtotalSinIva),
                    MontoIva = v.Detalles.Sum(d => d.SubtotalSinIva * d.PorcentajeIva)
                };
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
                .GroupBy(v => v.TipoPago)
                .ToDictionary(g => ObtenerNombreTipoPago(g.Key), 
                              g => g.Sum(v => v.TotalConIva));

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

        private string ObtenerNombreTipoPago(TipoPagoEnum tipo)
        {
            return tipo switch
            {
                TipoPagoEnum.Efectivo => "Efectivo",
                TipoPagoEnum.CuentaCorriente => "Cuenta Corriente",
                TipoPagoEnum.TarjetaCredito => "Tarjeta de Crédito",
                TipoPagoEnum.TarjetaDebito => "Tarjeta de Débito",
                TipoPagoEnum.Transferencia => "Transferencia",
                TipoPagoEnum.BilleteraVirtual => "Billetera Virtual",
                _ => "Otro"
            };
        }

        public DetalleVentaDTO? ObtenerDetalleVenta(int ventaId)
        {
            var venta = _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Articulo)
                .FirstOrDefault(v => v.Id == ventaId);

            if (venta == null)
                return null;

            var factura = _context.Facturas
                .FirstOrDefault(f => f.VentaId == ventaId);

            var detalles = venta.Detalles.Select(d => new DetalleVentaItemDTO
            {
                Articulo = d.Articulo?.Nombre ?? "Artículo eliminado",
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                SubtotalSinIva = d.SubtotalSinIva,
                PorcentajeIva = d.PorcentajeIva,
                SubtotalConIva = d.SubtotalConIva
            }).ToList();

            return new DetalleVentaDTO
            {
                Id = venta.Id,
                Fecha = venta.FechaVenta ?? venta.FechaCreacion,
                NumeroComprobante = factura?.NumeroFactura ?? "Sin Factura",
                TipoComprobante = factura != null ? factura.TipoComprobante.ToString().Replace("Factura", "Factura ") : "Sin Comprobante",
                Cliente = venta.Cliente != null ? venta.Cliente.NombreCompleto : "Sin Cliente",
                TipoPago = venta.TipoPago,
                TipoPagoDescripcion = venta.TipoPago.ToString(),
                Estado = venta.EstadoVenta,
                EstadoDescripcion = venta.EstadoVenta.ToString(),
                MontoTotal = venta.Detalles.Sum(d => d.SubtotalConIva),
                MontoSinIva = venta.Detalles.Sum(d => d.SubtotalSinIva),
                MontoIva = venta.Detalles.Sum(d => d.SubtotalSinIva * d.PorcentajeIva),
                Detalles = detalles
            };
        }
    }
}

