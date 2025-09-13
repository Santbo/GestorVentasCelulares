using System.ComponentModel;
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

        public override string ToString()
        {
            return $"{this.Nombre} {this.Apellido}";
        }
    }
}
