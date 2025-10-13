using GestionVentasCel.models.reportes;
using GestionVentasCel.service;

namespace GestionVentasCel.controller.reportes
{
    public class ReporteVentaController
    {
        private readonly ReporteVentaService _service;

        public ReporteVentaController(ReporteVentaService service)
        {
            _service = service;
        }

        public IEnumerable<ReporteVentaDTO> ObtenerVentasPorRangoFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                return _service.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener ventas: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ReporteVentaDTO>();
            }
        }

        public ResumenReporteDTO ObtenerResumenVentas(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                return _service.ObtenerResumenVentas(fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener resumen de ventas: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new ResumenReporteDTO();
            }
        }

        public IEnumerable<ReporteVentaDTO> ObtenerVentasDelMesActual()
        {
            try
            {
                return _service.ObtenerVentasDelMesActual();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener ventas del mes: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ReporteVentaDTO>();
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

