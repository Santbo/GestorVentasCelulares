using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionVentasCel.models.proveedor;

namespace GestionVentasCel.models.compra
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [MaxLength(500)]
        public string? Observaciones { get; set; }

        // Relación con Proveedor
        public Proveedor? Proveedor { get; set; }

        [Required]
        public int ProveedorId { get; set; }

        // Navegación hacia detalles
        public virtual ICollection<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>();
    }
}
