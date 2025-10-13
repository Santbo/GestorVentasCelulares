using GestionVentasCel.models.reportes;
using GestionVentasCel.service;

namespace GestionVentasCel.controller.reportes
{
    public class ReporteCompraController
    {
        private readonly ReporteCompraService _service;

        public ReporteCompraController(ReporteCompraService service)
        {
            _service = service;
        }

        public IEnumerable<ReporteCompraDTO> ObtenerComprasPorRangoFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                return _service.ObtenerComprasPorRangoFecha(fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener compras: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ReporteCompraDTO>();
            }
        }

        public ResumenReporteDTO ObtenerResumenCompras(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                return _service.ObtenerResumenCompras(fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener resumen de compras: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new ResumenReporteDTO();
            }
        }

        public IEnumerable<ReporteCompraDTO> ObtenerComprasDelMesActual()
        {
            try
            {
                return _service.ObtenerComprasDelMesActual();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener compras del mes: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ReporteCompraDTO>();
            }
        }

        public ResumenReporteDTO ObtenerResumenDelMesActual()
        {
            try
            {
                return _service.ObtenerResumenDelMesActual();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener resumen del mes: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new ResumenReporteDTO();
            }
        }
    }
}

