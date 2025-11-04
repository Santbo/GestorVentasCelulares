namespace GestionVentasCel.models.reportes
{
    public class DetalleCompraCompletoDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroComprobante { get; set; } = string.Empty;
        public string Proveedor { get; set; } = string.Empty;
        public string CondicionIVAProveedor { get; set; } = string.Empty;
        public decimal MontoTotal { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public List<DetalleCompraDTO> Detalles { get; set; } = new List<DetalleCompraDTO>();
    }
}

