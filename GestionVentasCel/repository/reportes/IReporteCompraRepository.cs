using GestionVentasCel.models.reportes;

namespace GestionVentasCel.repository.reportes
{
    public interface IReporteCompraRepository
    {
        IEnumerable<ReporteCompraDTO> ObtenerComprasPorRangoFecha(DateTime fechaDesde, DateTime fechaHasta);
        ResumenReporteDTO ObtenerResumenCompras(DateTime fechaDesde, DateTime fechaHasta);
    }
}

