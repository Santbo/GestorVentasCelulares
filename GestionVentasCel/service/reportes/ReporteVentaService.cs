using GestionVentasCel.models.reportes;
using GestionVentasCel.repository.reportes;

namespace GestionVentasCel.service
{
    public class ReporteVentaService
    {
        private readonly IReporteVentaRepository _repository;

        public ReporteVentaService(IReporteVentaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ReporteVentaDTO> ObtenerVentasPorRangoFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            return _repository.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta);
        }

        public ResumenReporteDTO ObtenerResumenVentas(DateTime fechaDesde, DateTime fechaHasta)
        {
            return _repository.ObtenerResumenVentas(fechaDesde, fechaHasta);
        }

        public IEnumerable<ReporteVentaDTO> ObtenerVentasDelMesActual()
        {
            var hoy = DateTime.Today;
            var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
            var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            return ObtenerVentasPorRangoFecha(primerDiaDelMes, ultimoDiaDelMes);
        }

        public ResumenReporteDTO ObtenerResumenDelMesActual()
        {
            var hoy = DateTime.Today;
            var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
            var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            return ObtenerResumenVentas(primerDiaDelMes, ultimoDiaDelMes);
        }

        public DetalleVentaDTO? ObtenerDetalleVenta(int ventaId)
        {
            return _repository.ObtenerDetalleVenta(ventaId);
        }
    }
}

