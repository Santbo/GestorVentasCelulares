using GestionVentasCel.models.reportes;
using GestionVentasCel.repository.reportes;

namespace GestionVentasCel.service
{
    public class ReporteCompraService
    {
        private readonly IReporteCompraRepository _repository;

        public ReporteCompraService(IReporteCompraRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ReporteCompraDTO> ObtenerComprasPorRangoFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            return _repository.ObtenerComprasPorRangoFecha(fechaDesde, fechaHasta);
        }

        public ResumenReporteDTO ObtenerResumenCompras(DateTime fechaDesde, DateTime fechaHasta)
        {
            return _repository.ObtenerResumenCompras(fechaDesde, fechaHasta);
        }

        public IEnumerable<ReporteCompraDTO> ObtenerComprasDelMesActual()
        {
            var hoy = DateTime.Today;
            var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
            var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            return ObtenerComprasPorRangoFecha(primerDiaDelMes, ultimoDiaDelMes);
        }

        public ResumenReporteDTO ObtenerResumenDelMesActual()
        {
            var hoy = DateTime.Today;
            var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
            var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            return ObtenerResumenCompras(primerDiaDelMes, ultimoDiaDelMes);
        }
    }
}

