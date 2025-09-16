using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionVentasCel.models.cliente;

namespace GestionVentasCel.models.cliente
{
    public class MovimientoCuentaCorriente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CuentaCorrienteId { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Monto { get; set; }

        [Required]
        public string Tipo { get; set; } = null!; // "Debe", "Haber"

        [Required]
        public DateTime Fecha { get; set; }

        [MaxLength(200)]
        public string? Descripcion { get; set; }

        [MaxLength(100)]
        public string? Referencia { get; set; }

        // Relación
        public CuentaCorriente CuentaCorriente { get; set; } = null!;
    }
}
