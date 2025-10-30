namespace GestionVentasCel.models.reportes
{
    public class DetalleCompraDTO
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public string ArticuloNombre { get; set; } = string.Empty;
        public string ArticuloCodigo { get; set; } = string.Empty;
        public string ArticuloMarca { get; set; } = string.Empty;
        public string ArticuloModelo { get; set; } = string.Empty;
    }
}

