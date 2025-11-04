using GestionVentasCel.enumerations.ventas;

namespace GestionVentasCel.models.reportes
{
    public class DetalleVentaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroComprobante { get; set; } = string.Empty;
        public string TipoComprobante { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public TipoPagoEnum TipoPago { get; set; }
        public string TipoPagoDescripcion { get; set; } = string.Empty;
        public EstadoVentaEnum Estado { get; set; }
        public string EstadoDescripcion { get; set; } = string.Empty;
        public decimal MontoTotal { get; set; }
        public decimal MontoSinIva { get; set; }
        public decimal MontoIva { get; set; }
        public List<DetalleVentaItemDTO> Detalles { get; set; } = new List<DetalleVentaItemDTO>();
    }

    public class DetalleVentaItemDTO
    {
        public string Articulo { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubtotalSinIva { get; set; }
        public decimal PorcentajeIva { get; set; }
        public decimal SubtotalConIva { get; set; }
    }
}

