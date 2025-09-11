using GestionVentasCel.models.clientes;

namespace GestionVentasCel.models.CuentaCorreinte
{
    public class CuentaCorriente
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;


        // Movimientos de la cuenta
        public ICollection<MovimientoCuentaCorriente> Movimientos { get; set; } = new List<MovimientoCuentaCorriente>();
    }
}
