using GestionVentasCel.models.compra;

namespace GestionVentasCel.repository.compra
{
    public interface IDetalleCompraRepository
    {
        IEnumerable<DetalleCompra> GetByCompraId(int compraId);
        void AddRange(IEnumerable<DetalleCompra> detalles);
        void DeleteByCompraId(int compraId);
        
    }
}
