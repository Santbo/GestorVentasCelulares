using GestionVentasCel.models.compra;

namespace GestionVentasCel.repository.compra
{
    public interface ICompraRepository
    {
        Compra? GetByIdWithDetails(int id);
        IEnumerable<Compra> GetAll(bool ultimoMes = false);
        IEnumerable<Compra> GetAllWithDetails();
        IEnumerable<Compra> GetByProveedor(int proveedorId);
        void Add(Compra compra);
        void Update(Compra compra);
        void Delete(int id);
        bool Exist(int id);
    }
}
