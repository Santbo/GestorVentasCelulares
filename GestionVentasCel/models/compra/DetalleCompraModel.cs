using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionVentasCel.models.articulo;

namespace GestionVentasCel.models.compra
{
    public class DetalleCompra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }

        // Relación con Compra
        public Compra? Compra { get; set; }

        [Required]
        public int CompraId { get; set; }

        // Relación con Articulo
        public Articulo? Articulo { get; set; }

        [Required]
        public int ArticuloId { get; set; }
    }
}
