using System.ComponentModel;
using GestionVentasCel.enumerations.ventas;

namespace GestionVentasCel.models.ventas
{
    public class Factura
    {
        public int Id { get; set; }

        // Datos de la factura
        [DisplayName("Tipo de Comprobante")]
        public TipoFacturaEnum TipoComprobante { get; set; }

        [DisplayName("Número de Factura")]
        public string NumeroFactura { get; set; }

        [DisplayName("Fecha de Emisión")]
        public DateTime FechaEmision { get; set; }

        // Relación con la venta original
        public int VentaId { get; set; }

        public Venta Venta { get; set; }

        // Cliente
        [DisplayName("Cliente")]
        public string NombreCliente { get; set; }

        [DisplayName("CUIT Cliente")]
        public string CUITCliente { get; set; }

        [DisplayName("Domicilio Cliente")]
        public string DomicilioCliente { get; set; }

        [DisplayName("Condición IVA Cliente")]
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
