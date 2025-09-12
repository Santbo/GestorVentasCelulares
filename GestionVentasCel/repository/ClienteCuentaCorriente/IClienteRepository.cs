using GestionVentasCel.models.clientes;

namespace GestionVentasCel.repository.ClienteCuentaCorriente
{
    public interface IClienteRepository
    {
        Cliente? GetById(int id);
        IEnumerable<Cliente> GetAll();
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        bool Exist(int id);
        IEnumerable<Cliente> ObtenerClientesSinCuentas();
    }
}
