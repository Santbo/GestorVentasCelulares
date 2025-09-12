using GestionVentasCel.enumerations.persona;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.persona;

namespace GestionVentasCel.models.clientes
{
    public class Cliente : Persona
    {
        public CuentaCorriente? CuentaCorriente { get; set; }
        public CondicionIVAEnum? CondicionIVA { get; set; }
    }
}
