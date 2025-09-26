namespace GestionVentasCel.models.ventas
{
    public class Empresa
    {
        public int Id { get; set; }

        public string RazonSocial { get; set; } = null!;
        public string CUIT { get; set; } = null!;
        public string DomicilioFiscal { get; set; } = null!;
        public string CondicionIVA { get; set; } = null!;
        public string PuntoVenta { get; set; } = null!;
        public string IngresosBrutos { get; set; } = null!;
        public string InicioActividades { get; set; } = null!;

        // Relación con facturas emitidas
        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
