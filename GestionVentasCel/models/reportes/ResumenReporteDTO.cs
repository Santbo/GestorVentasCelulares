namespace GestionVentasCel.models.reportes
{
    public class ResumenReporteDTO
    {
        public decimal TotalGeneral { get; set; }
        public int CantidadOperaciones { get; set; }
        public decimal PromedioOperacion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public Dictionary<string, decimal> TotalesPorTipo { get; set; } = new Dictionary<string, decimal>();
    }
}

