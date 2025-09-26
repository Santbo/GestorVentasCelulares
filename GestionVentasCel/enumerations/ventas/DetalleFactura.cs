﻿using GestionVentasCel.models.ventas;

namespace GestionVentasCel.enumerations.ventas
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        public int FacturaId { get; set; }
        public Factura Factura { get; set; } = null!;
    }
}
