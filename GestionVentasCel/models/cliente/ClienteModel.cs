using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionVentasCel.models.persona;
using GestionVentasCel.enumerations.persona;

namespace GestionVentasCel.models.cliente
{
    public class Cliente : Persona
    {
        [Required]
        public TipoCliente TipoCliente { get; set; }

        [MaxLength(200)]
        public string? Observaciones { get; set; }

        // Relación con cuenta corriente (opcional)
        public CuentaCorriente? CuentaCorriente { get; set; }
    }
}
