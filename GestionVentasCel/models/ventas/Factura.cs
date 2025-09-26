using GestionVentasCel.enumerations.ventas;

namespace GestionVentasCel.models.ventas
{
    public class Factura
    {
        public int Id { get; set; }

        // Datos de la factura
        public TipoFacturaEnum TipoComprobante { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaEmision { get; set; }

        // Cliente
        public string NombreCliente { get; set; }
        public string CUITCliente { get; set; }
        public string DomicilioCliente { get; set; }
        public string CondicionIVACliente { get; set; }

        // Relación con vendedor/empresa
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        // Totales
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }

        public ICollection<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
    }
}
