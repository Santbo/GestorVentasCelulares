using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionVentasCel.models.cliente;

namespace GestionVentasCel.models.cliente
{
    public class CuentaCorriente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Saldo { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal LimiteCredito { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [MaxLength(200)]
        public string? Observaciones { get; set; }

        // Relación
        public Cliente Cliente { get; set; } = null!;
        public ICollection<MovimientoCuentaCorriente> Movimientos { get; set; } = new List<MovimientoCuentaCorriente>();
    }
}
