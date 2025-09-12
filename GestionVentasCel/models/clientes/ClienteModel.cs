using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.persona;

namespace GestionVentasCel.models.clientes
{
    public class Cliente : Persona
    {
        public CuentaCorriente? CuentaCorriente { get; set; }

        [DisplayName("Condición ante IVA")]
        public CondicionIVAEnum? CondicionIVA { get; set; }
        public bool Activo { get; set; } = true;

        [NotMapped]
        [DisplayName("Cuenta corriente")]
        public string CuentaCorrienteTexto => CuentaCorriente == null ? "No hay cuenta corriente" : "Activa";
    }
}
