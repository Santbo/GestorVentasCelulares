namespace GestionVentasCel.models.reportes
{
    public class ReporteCompraDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroComprobante { get; set; } = string.Empty;
        public string Proveedor { get; set; } = string.Empty;
        public string TipoCompra { get; set; } = string.Empty;
        public decimal MontoTotal { get; set; }
        public string Observaciones { get; set; } = string.Empty;
    }
}

