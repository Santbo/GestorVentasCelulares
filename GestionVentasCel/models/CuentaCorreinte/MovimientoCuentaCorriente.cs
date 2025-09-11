using System.ComponentModel.DataAnnotations;
using GestionVentasCel.enumerations.cuentaCorriente;

namespace GestionVentasCel.models.CuentaCorreinte
{
    public class MovimientoCuentaCorriente
    {
        public int Id { get; set; }
        public int CuentaCorrienteId { get; set; }
        public CuentaCorriente CuentaCorriente { get; set; } = null!;

        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal Monto { get; set; }
        [Required]
        public TipoMovimiento Tipo { get; set; }
    }
}
