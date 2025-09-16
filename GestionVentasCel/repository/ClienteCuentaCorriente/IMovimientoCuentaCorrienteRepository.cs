using GestionVentasCel.models.CuentaCorreinte;

namespace GestionVentasCel.repository.ClienteCuentaCorriente
{
    public interface IMovimientoCuentaCorrienteRepository
    {
        MovimientoCuentaCorriente? GetById(int id);
        IEnumerable<MovimientoCuentaCorriente> GetAll();
        IEnumerable<MovimientoCuentaCorriente> GetByCuentaId(int cuentaCorrienteId);
        void Add(MovimientoCuentaCorriente movimiento);
        void Update(MovimientoCuentaCorriente movimiento);
        bool Exist(int id);
    }
}
