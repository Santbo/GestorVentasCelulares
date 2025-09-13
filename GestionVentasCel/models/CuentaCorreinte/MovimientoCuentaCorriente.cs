using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GestionVentasCel.enumerations.cuentaCorriente;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.models.CuentaCorreinte
{
    public class MovimientoCuentaCorriente
    {
        public int Id { get; set; }
        public int CuentaCorrienteId { get; set; }
        public CuentaCorriente CuentaCorriente { get; set; } = null!;

        [Required]
        public DateTime Fecha { get; set; }
        [Required, Precision(18, 2)]
        public decimal Monto { get; set; }
        [Required]
        public TipoMovimiento Tipo { get; set; }

        [MaxLength(255), DisplayName("Descripción")]
        public string? Descripcion {  get; set; }
    }
}
