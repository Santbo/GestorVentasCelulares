using GestionVentasCel.models.compra;

namespace GestionVentasCel.repository.compra
{
    public interface ICompraRepository
    {
        Compra? GetById(int id);
        Compra? GetByIdWithDetails(int id);
        IEnumerable<Compra> GetAll();
        IEnumerable<Compra> GetAllWithDetails();
        IEnumerable<Compra> GetByProveedor(int proveedorId);
        IEnumerable<Compra> GetByFecha(DateTime fechaDesde, DateTime fechaHasta);
        void Add(Compra compra);
        void Update(Compra compra);
        void Delete(int id);
        bool Exist(int id);
    }
}
