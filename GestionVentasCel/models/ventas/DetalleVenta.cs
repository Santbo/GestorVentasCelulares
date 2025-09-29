using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.reparacion;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.models.ventas
{
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        public int VentaId { get; set; }
        public Venta Venta { get; set; } = null!;

        [DisplayName("Precio unitario sin IVA"), Precision(18, 2)]
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        /// <summary>
        /// Porcentaje de IVA entre 0,000 y 1,000
        /// </summary>
        [Precision(4, 3), DisplayName("Porcentaje de IVA")]
        public decimal PorcentajeIva { get; set; } = 0.21m;

        [NotMapped, DisplayName("Subtotal sin IVA")]
        public decimal SubtotalSinIva => Math.Round(PrecioUnitario * Cantidad, 2);


        [NotMapped, DisplayName("Subtotal con IVA")]
        public decimal SubtotalConIva => Math.Round(SubtotalSinIva * (1 + PorcentajeIva));

        // artículo o servicio
        public int? ArticuloId { get; set; }
        public Articulo? Articulo { get; set; }

        public int? ReparacionId { get; set; }
        public Reparacion? Reparacion { get; set; }

        public bool EsArticulo => ArticuloId.HasValue || Articulo != null;
        public bool EsReparacion => ReparacionId.HasValue || Reparacion != null;

    }
}
