using GestionVentasCel.models.reportes;

namespace GestionVentasCel.repository.reportes
{
    public interface IReporteVentaRepository
    {
        IEnumerable<ReporteVentaDTO> ObtenerVentasPorRangoFecha(DateTime fechaDesde, DateTime fechaHasta);
        ResumenReporteDTO ObtenerResumenVentas(DateTime fechaDesde, DateTime fechaHasta);
    }
}

