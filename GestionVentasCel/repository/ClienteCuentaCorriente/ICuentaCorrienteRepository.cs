using GestionVentasCel.models.clientes;
using GestionVentasCel.models.CuentaCorreinte;

namespace GestionVentasCel.repository.ClienteCuentaCorriente
{
    public interface ICuentaCorrienteRepository
    {
        CuentaCorriente? GetByClienteId(int clienteId);
        CuentaCorriente? GetById(int id);
        IEnumerable<CuentaCorriente> GetAll();
        void Add(CuentaCorriente cuenta);
        void Update(CuentaCorriente cuenta);
        bool Exist(int clienteId);
        void Delete(CuentaCorriente cuenta);
    }
}
