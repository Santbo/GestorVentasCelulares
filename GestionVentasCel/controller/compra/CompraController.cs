using GestionVentasCel.models.compra;
using GestionVentasCel.service.compra;

namespace GestionVentasCel.controller.compra
{
    public class CompraController
    {
        private readonly ICompraService _service;

        public CompraController(ICompraService service)
        {
            _service = service;
        }

        public void CrearCompraConDetalles(Compra compra, List<DetalleCompra> detalles)
        {
            _service.AgregarCompraConDetalles(compra, detalles);
        }


        public void ActualizarCompraConDetalles(Compra compra, List<DetalleCompra> detalles)
        {
            _service.ActualizarCompraConDetalles(compra, detalles);
        }

        public void EliminarCompra(int id)
        {
            _service.EliminarCompra(id);
        }

        public IEnumerable<Compra> ObtenerCompras()
        {
            return _service.ListarCompras();
        }

        public IEnumerable<Compra> GetByProveedor(int proveedorId)
        {
            return _service.GetByProveedor(proveedorId);
        }

        public Compra? GetByIdWithDetails(int id)
        {
            return _service.GetByIdWithDetails(id);
        }


    }
}
