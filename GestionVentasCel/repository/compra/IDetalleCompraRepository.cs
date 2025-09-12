using GestionVentasCel.models.compra;

namespace GestionVentasCel.repository.compra
{
    public interface IDetalleCompraRepository
    {
        DetalleCompra? GetById(int id);
        IEnumerable<DetalleCompra> GetAll();
        IEnumerable<DetalleCompra> GetByCompraId(int compraId);
        IEnumerable<DetalleCompra> GetByArticuloId(int articuloId);
        void Add(DetalleCompra detalle);
        void AddRange(IEnumerable<DetalleCompra> detalles);
        void Update(DetalleCompra detalle);
        void Delete(int id);
        void DeleteByCompraId(int compraId);
        bool Exist(int id);
    }
}
