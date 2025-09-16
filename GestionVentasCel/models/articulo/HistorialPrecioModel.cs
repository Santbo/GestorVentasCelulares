using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionVentasCel.models.articulo
{
    public class HistorialPrecio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ArticuloId { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal PrecioAnterior { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal PrecioNuevo { get; set; }

        [Required]
        public DateTime FechaCambio { get; set; }

        [MaxLength(100)]
        public string? Motivo { get; set; } // "Compra", "EliminacionCompra", etc.

        // Relación
        public Articulo Articulo { get; set; } = null!;
    }
}
