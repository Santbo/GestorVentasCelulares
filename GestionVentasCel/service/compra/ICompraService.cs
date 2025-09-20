using GestionVentasCel.models.compra;

namespace GestionVentasCel.service.compra
{
    public interface ICompraService
    {
        void AgregarCompraConDetalles(Compra compra, List<DetalleCompra> detalles);
        IEnumerable<Compra> ListarCompras();
        IEnumerable<Compra> ListarComprasConDetalles();
        IEnumerable<Compra> GetByProveedor(int proveedorId);
        //void ActualizarCompra(Compra compra);
        void ActualizarCompraConDetalles(Compra compra, List<DetalleCompra> detalles);
        void EliminarCompra(int id);
        Compra? GetByIdWithDetails(int id);
        decimal CalcularTotal(List<DetalleCompra> detalles);
    }
}
